using Newtonsoft.Json;
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

        private readonly string templateLocation;

        private string template;
        private string replacementMarker;

        /// <summary>
        /// Construct a new SnippetBuilder
        /// </summary>
        /// <param name="title"> Title of the snippet </param>
        /// <param name="author"> Author of the snippet </param>
        /// <param name="description"> Description of the snippet </param>
        /// <param name="shortcut"> Shortcut to access the snippet </param>
        /// <param name="language"> Language the snippet is in</param>
        /// <param name="code"> Code for the snippet </param>
        public SnippetBuilder(string title, string author, string description,
            string shortcut, string language, string code, string templateLocation = null)
        {
            this.title = title;
            this.author = author;
            this.description = description;
            this.shortcut = shortcut;
            this.language = language;
            this.code = code;
            this.templateLocation = templateLocation ?? Path.Combine("Config", "snippet_template.json");
        }

        /// <summary>
        /// Generate a code snippet
        /// </summary>
        /// <returns> A Code Snippet </returns>
        public string GenerateSnippet()
        {
            dynamic templateData = JsonConvert.DeserializeObject(File.ReadAllText(templateLocation));
            replacementMarker = templateData.replacement_marker;
            template = templateData.template;

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
        private string Marker(string value) => $"{replacementMarker}{value}{replacementMarker}";
    }
}