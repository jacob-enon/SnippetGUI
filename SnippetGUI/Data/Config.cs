using System.Collections.Generic;

namespace SnippetGUI.Data
{
    /// <summary>
    /// Configuration data to build snippets
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Available languages for the snippet
        /// </summary>
        internal IList<string> Languages { get; }

        /// <summary>
        /// Marker to replace properties in the template
        /// </summary>
        internal string ReplaceMarker { get; }

        /// <summary>
        /// Template for a code snippet
        /// </summary>
        internal string Template { get; }

        /// <summary>
        /// Construct a new Config data
        /// </summary>
        /// <param name="languages"> Available languages for the snippet </param>
        /// <param name="replaceMarker"> Marker to replace properties in the template </param>
        /// <param name="template"> Template for a code snippet </param>
        public Config(IList<string> languages, string replaceMarker, string template)
        {
            Languages = languages;
            ReplaceMarker = replaceMarker;
            Template = template;
        }
    }
}