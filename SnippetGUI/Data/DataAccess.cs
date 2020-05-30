using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SnippetGUI.Data
{
    /// <summary>
    /// Accesses config files
    /// </summary>
    public class DataAccess : IDataAccess
    {
        private readonly Config config;

        /// <summary>
        /// Construct a new DataAccess
        /// </summary>
        public DataAccess(string configLocation = null)
        {
            config = DeserializeJsonFile<Config>(configLocation ?? Path.Combine("Config", "config.json"));
        }

        /// <summary>
        /// Get all available snippet languages
        /// </summary>
        /// <returns> IList of available languages </returns>
        public IList<string> GetLanguages() => config.Languages;

        /// <summary>
        /// Get the marker to replace properties in the template
        /// </summary>
        /// <returns> The marker to replace properties in a template </returns>
        public string GetReplacementMarker() => config.ReplaceMarker;

        /// <summary>
        /// Get the template for a code snippet
        /// </summary>
        /// <returns> The template for a code snippet </returns>
        public string GetTemplate() => config.Template;

        /// <summary>
        /// Deserialize a JSON file
        /// </summary>
        /// <typeparam name="T"> Type of object to deserialize </typeparam>
        /// <param name="path"> Path of the JSON file </param>
        /// <returns> Deserialized object </returns>
        private T DeserializeJsonFile<T>(string path) => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
    }
}