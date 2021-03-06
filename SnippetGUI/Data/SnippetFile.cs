﻿using System.IO;
using System.Threading.Tasks;

namespace SnippetGUI.Data
{
    /// <summary>
    /// A file containing a code snippet
    /// </summary>
    public class SnippetFile : ISnippetFile
    {
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
            Location = location;
            Snippet = snippet;
        }

        /// <summary>
        /// Asynchronously save the snippet file
        /// </summary>
        /// <returns> A task </returns>
        public async Task SaveAsync()
        {
            using var file = new StreamWriter(Location);
            await file.WriteAsync(Snippet);
        }
    }
}