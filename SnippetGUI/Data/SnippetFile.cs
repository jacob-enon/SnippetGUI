using System.IO;
using System.Text;

namespace SnippetGUI.Data
{
    /// <summary>
    /// A file containing a code snippet
    /// </summary>
    public class SnippetFile : ISnippetFile
    {
        private const string extension = ".snippet";

        /// <summary>
        /// Location of the snippet file
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Snippet in the file
        /// </summary>
        public string Snippet { get; }

        /// <summary>
        /// Construct a new snippet file
        /// </summary>
        /// <param name="location"> Location of the file </param>
        /// <param name="snippet"> Code snippet to store </param>
        public SnippetFile(string location, string snippet)
        {
            Location = GetFileName(location);
            Snippet = snippet;
        }

        /// <summary>
        /// Save the snippet file
        /// </summary>
        public void Save()
        {
            File.WriteAllText(Location, Snippet);
        }

        /// <summary>
        /// Gets the name of the snippet file based on the given location
        /// </summary>
        /// <param name="location"> Location to store the file </param>
        /// <returns> Name of the snippet file </returns>
        private string GetFileName(string location)
        {
            var fileName = new StringBuilder();

            if (Directory.Exists(location))
            {
                fileName.Append(Path.Combine(location, $"snippet{extension}"));
            }
            else
            {
                fileName.Append(location);

                if (!location.EndsWith(extension))
                {
                    fileName.Append(extension);
                }
            }

            return fileName.ToString();
        }
    }
}