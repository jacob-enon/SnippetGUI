using SnippetGUI.Data;
using System.Collections.Generic;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Generates code snippets
    /// </summary>
    public interface ISnippetBuilder
    {
        /// <summary>
        /// Generate a declaration
        /// </summary>
        /// <param name="title"> Snippet title </param>
        /// <param name="author"> Snippet author </param>
        /// <param name="description"> Snippet description </param>
        /// <param name="shortcut"> Snippet shortcut </param>
        /// <param name="language"> Snippet language </param>
        /// <param name="code"> Snippet code </param>
        /// <param name="declarations"> Declarations for the snippet </param>
        /// <returns> Snippet as a string </returns>
        string GenerateSnippet(string title, string author, string description,
            string shortcut, string language, string code, IList<Declaration> declarations);
    }
}