using System.IO;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Validates snippet files
    /// </summary>
    public class SnippetFileValidator
    {
        private const string extension = ".snippet";

        /// <summary>
        /// Validate a snippet file
        /// </summary>
        /// <param name="snippet"> Snippet to be stored </param>
        /// <param name="filePath"> Path to store the snippet </param>
        /// <returns> True if the snippet file is valid </returns>
        public bool Validate(string snippet, string filePath)
        {
            if (string.IsNullOrEmpty(snippet))
            {
                return false;
            }

            if (Path.GetExtension(filePath) != extension)
            {
                return false;
            }

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                return false;
            }

            return true;
        }
    }
}