﻿using System.Collections.Generic;

namespace SnippetGUI.Data
{
    /// <summary>
    /// Configuration data to build snippets
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Available languages for the snippet
        /// </summary>
        public IList<string> Languages { get; }

        /// <summary>
        /// Marker to replace properties in the template
        /// </summary>
        public string ReplaceMarker { get; }

        /// <summary>
        /// Template for a code snippet
        /// </summary>
        public string SnippetTemplate { get; }

        /// <summary>
        /// Template for a declaration
        /// </summary>
        public string DeclarationTemplate { get; }

        /// <summary>
        /// Construct a new Config data
        /// </summary>
        /// <param name="languages"> Available languages for the snippet </param>
        /// <param name="replaceMarker"> Marker to replace properties in the template </param>
        /// <param name="snippetTemplate"> Template for a code snippet </param>
        public Config(IList<string> languages, string replaceMarker, string snippetTemplate, string declarationTemplate)
        {
            Languages = languages;
            ReplaceMarker = replaceMarker;
            SnippetTemplate = snippetTemplate;
            DeclarationTemplate = declarationTemplate;
        }
    }
}