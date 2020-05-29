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
        string GenerateSnippet();
    }
}