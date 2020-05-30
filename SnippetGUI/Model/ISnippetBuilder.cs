using SnippetGUI.Data;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Generates code snippets
    /// </summary>
    public interface ISnippetBuilder
    {
        /// <summary>
        ///  Generate a code snippet
        /// </summary>
        /// <returns> A Code Snippet </returns>
        /// <param name="dataAccess"> Data access for generating snippet template </param>
        string GenerateSnippet(IDataAccess dataAccess);
    }
}