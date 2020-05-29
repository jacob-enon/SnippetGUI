using System;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Generates code snippets
    /// </summary>
    /// <remarks> Uses XML format </remarks>
    public class SnippetBuilder : ISnippetBuilder
    {
        /// <summary>
        /// Generate a code snippet
        /// </summary>
        /// <param name="title"> Title of the snippet </param>
        /// <param name="author"> Author of the snippet </param>
        /// <param name="description"> Description of the snippet </param>
        /// <param name="shortcut"> Shortcut to access the snippet </param>
        /// <param name="language"> Language the snippet is in</param>
        /// <param name="code"> Code for the snippet </param>
        /// <returns> A Code Snippet </returns>
        public string GenerateSnippet(string title, string author, string description,
            string shortcut, string language, string code)
        {
            throw new NotImplementedException();
        }
    }
}