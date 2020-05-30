using SnippetGUI.Data;
using System.IO;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Generates code snippets
    /// </summary>
    /// <remarks> Uses XML format </remarks>
    public class SnippetBuilder : ISnippetBuilder
    {
        private readonly string title;
        private readonly string author;
        private readonly string description;
        private readonly string shortcut;
        private readonly string language;
        private readonly string code;

        private readonly string template;
        private readonly string replaceMarker;

        public SnippetBuilder(string title, string author, string description,
            string shortcut, string language, string code, IDataAccess dataAccess)
        {
            this.title = title;
            this.author = author;
            this.description = description;
            this.shortcut = shortcut;
            this.language = language;
            this.code = code;

            template = dataAccess.GetTemplate();
            replaceMarker = dataAccess.GetReplaceMarker();
        }

        /// <summary>
        /// Generate a code snippet
        /// </summary>
        /// <returns> A Code Snippet </returns>
        /// <param name="dataAccess"> Data access for generating snippet template </param>
        public string GenerateSnippet()
        {
            return FillTemplate();
        }

        /// <summary>
        /// Fill a snippet template
        /// </summary>
        private string FillTemplate()
        {
            var snippet = template;

            snippet = snippet.Replace(Marker("title"), title);
            snippet = snippet.Replace(Marker("author"), author);
            snippet = snippet.Replace(Marker("description"), description);
            snippet = snippet.Replace(Marker("shortcut"), shortcut);
            snippet = snippet.Replace(Marker("language"), language);
            snippet = snippet.Replace(Marker("code"), code);

            return snippet;
        }

        /// <summary>
        /// Return marker for template property
        /// </summary>
        /// <param name="value"> Value to return marker </param>
        /// <returns> Value surrounded by markers </returns>
        private string Marker(string value) => $"{replaceMarker}{value}{replaceMarker}";
    }
}