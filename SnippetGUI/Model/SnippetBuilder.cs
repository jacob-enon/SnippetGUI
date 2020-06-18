using SnippetGUI.Data;
using System.Collections.Generic;
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

        private readonly string snippetTemplate;
        private readonly string declarationTemplate;
        private readonly string replaceMarker;

        #endregion

        /// <summary>
        /// Construct a new SnippetBuilder
        /// </summary>
        /// <param name="dataAccess"> Access to data about the snippet </param>
        public SnippetBuilder(IDataAccess dataAccess)
        {
            snippetTemplate = dataAccess.GetSnippetTemplate();
            declarationTemplate = dataAccess.GetSnippetTemplate();
            replaceMarker = dataAccess.GetReplaceMarker();
        }

        #region Methods

        /// <inheritdoc/>
        public string GenerateSnippet(string title, string author, string description,
            string shortcut, string language, string code, IList<Declaration> declarationData)
        {
            var snippet = snippetTemplate; //as it would be wrong to edit the template as it's not a template anymore

            snippet = FillData(snippet, "title", title);
            snippet = FillData(snippet, "author", author);
            snippet = FillData(snippet, "description", description);
            snippet = FillData(snippet, "shortcut", shortcut);
            snippet = FillData(snippet, "language", language);
            snippet = FillData(snippet, "code", code);

            var declarations = GenerateDeclarations(declarationData);
            snippet = snippet.Replace(Marker("declarations"), declarations);

            return snippet;
        }

        /// <summary>
        /// Generate all declarations in a snippet
        /// </summary>
        /// <param name="declarations"> Declaration data </param>
        /// <returns> Declarations snippet </returns>
        private string GenerateDeclarations(IList<Declaration> declarations)
        {
            var declarationBuilder = new StringBuilder();

            foreach (var declarationData in declarations)
            {
                var declaration = FillData(declarationTemplate, "ID", declarationData.ID);
                declaration = FillData(declaration, "Default", declarationData.DefaultValue);
                declaration = FillData(declaration, "ToolTip", declarationData.ToolTip);
                declarationBuilder.Append(declaration);
            }

            return declarationBuilder.ToString();
        }

        /// <summary>
        /// Fill the snippet with data
        /// </summary>
        /// <param name="template"> Template to fill </param>
        /// <param name="id"> ID to replace </param>
        /// <param name="value"> Data to fill in place of ID </param>
        /// <returns> Template filled with data </returns>
        private string FillData(string template, string id, string value) => template.Replace(Marker(id), value);

        /// <summary>
        /// Return marker for template property
        /// </summary>
        /// <param name="value"> Value to surround with markers </param>
        /// <returns> Value surrounded by markers </returns>
        private string Marker(string value) => $"{replaceMarker}{value}{replaceMarker}";

        #endregion
    }
}