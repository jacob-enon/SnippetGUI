using SnippetGUI.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Generates code snippets
    /// </summary>
    /// <remarks> Uses XML format </remarks>
    public class SnippetBuilder : ISnippetBuilder
    {
        #region Properties

        private readonly string title;
        private readonly string author;
        private readonly string description;
        private readonly string shortcut;
        private readonly string language;
        private readonly string code;

        private readonly IList<Declaration> declarations;

        private readonly string snippetTemplate;
        private readonly string declarationTemplate;
        private readonly string replaceMarker;

        #endregion

        public SnippetBuilder(string title, string author, string description,
            string shortcut, string language, string code, IList<Declaration> declarations, IDataAccess dataAccess = null)
        {
            this.title = title;
            this.author = author;
            this.description = description;
            this.shortcut = shortcut;
            this.language = language;
            this.code = code;

            this.declarations = declarations;

            dataAccess ??= new DataAccess();

            snippetTemplate = dataAccess.GetSnippetTemplate();
            declarationTemplate = dataAccess.GetDeclarationTemplate();
            replaceMarker = dataAccess.GetReplaceMarker();
        }

        #region Methods

        /// <summary>
        /// Determines if a snippet is valid to generate
        /// </summary>
        /// <param name="availableLanguages"> Available languages for a snippet </param>
        /// <param name="language"> Language the snippet is in </param>
        /// <param name="code"> Code for the snippet </param>
        /// <returns> True if a snippet is valid </returns>
        /// <remarks>
        /// A snippet must have code to insert,
        /// and the language must be one available in this configuration.
        /// There are no limitations on Title, Author, Shortcut etc. as these are optional
        ///     fields in VS
        /// </remarks>
        public static bool ValidSnippet(IList<string> availableLanguages, string language, string code) 
            => !string.IsNullOrEmpty(code) && (availableLanguages?.Contains(language) ?? false);

        /// <summary>
        /// Generate a code snippet
        /// </summary>
        /// <returns> A Code Snippet </returns>
        /// <param name="dataAccess"> Data access for generating snippet template </param>
        public string GenerateSnippet()
        {
            var snippet = snippetTemplate; //as it would be wrong to edit the template as it's not a template anymore

            snippet = snippet.Replace(Marker("title"), title);
            snippet = snippet.Replace(Marker("author"), author);
            snippet = snippet.Replace(Marker("description"), description);
            snippet = snippet.Replace(Marker("shortcut"), shortcut);
            snippet = snippet.Replace(Marker("language"), language);
            snippet = snippet.Replace(Marker("code"), code);

            var declarations = GenerateDeclarations();
            snippet = snippet.Replace(Marker("declarations"), declarations);

            return snippet;
        }

        private string GenerateDeclarations()
        {
            var declarationBuilder = new StringBuilder();

            foreach (var declarationData in declarations)
            {
                var declaration = declarationTemplate.Replace(Marker("ID"), declarationData.ID);
                declaration = declaration.Replace(Marker("Default"), declarationData.DefaultValue);
                declaration = declaration.Replace(Marker("ToolTip"), declarationData.ToolTip);
                declarationBuilder.Append(declaration);
            }

            return declarationBuilder.ToString();
        }

        /// <summary>
        /// Return marker for template property
        /// </summary>
        /// <param name="value"> Value to surround with markers </param>
        /// <returns> Value surrounded by markers </returns>
        private string Marker(string value) => $"{replaceMarker}{value}{replaceMarker}";

        #endregion
    }
}