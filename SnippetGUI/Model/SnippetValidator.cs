using System.Collections.Generic;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Validates snippets
    /// </summary>
    public class SnippetValidator
    {
        /// <summary>
        /// Determine whether a given snippet is valid
        /// </summary>
        /// <param name="availableLanguages"> Languages available for the snippet </param>
        /// <param name="language"> Language of the snippet </param>
        /// <param name="code"> Code for the snippet </param>
        /// <returns> True if the snippet is valid </returns>
        public bool Validate(IList<string> availableLanguages, string language, string code)
            => !string.IsNullOrEmpty(code) && (availableLanguages?.Contains(language) ?? false);
    }
}