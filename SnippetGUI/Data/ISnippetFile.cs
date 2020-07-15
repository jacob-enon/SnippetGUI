using System.Threading.Tasks;

namespace SnippetGUI.Data
{
    /// <summary>
    /// A file containing a code snippet
    /// </summary>
    public interface ISnippetFile
    {
        /// <summary>
        /// Location of the file
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Snippet of code in the file
        /// </summary>
        string Snippet { get; }

        /// <summary>
        /// Asynchronously save the file
        /// </summary>
        /// <returns> A task </returns>
        Task SaveAsync();
    }
}