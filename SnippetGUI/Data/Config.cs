using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetGUI.Data
{
    internal class Config
    {
        internal IList<string> Languages { get; }
        internal string ReplaceMarker { get; }
        internal string Template { get; }

        public Config(IList<string> languages, string replaceMarker, string template)
        {
            Languages = languages;
            ReplaceMarker = replaceMarker;
            Template = template;
        }
    }
}