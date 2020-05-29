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
        private readonly string languages;

        /// <summary>
        /// Construct a new DataAccess
        /// </summary>
        /// <param name="languages"> Config file for available snippet languages </param>
        public DataAccess(string languages = null)
        {
            this.languages = languages ?? Path.Combine("Config", "languages.json");
        }

        /// <summary>
        /// Get all available snippet languages
        /// </summary>
        /// <returns> IList of available languages </returns>
        public IList<string> GetLanguages() => DeserializeJsonFile<List<string>>(languages);

        /// <summary>
        /// Deserialize a JSON file
        /// </summary>
        /// <typeparam name="T"> Type of object to deserialize </typeparam>
        /// <param name="path"> Path of the JSON file </param>
        /// <returns> Deserialized object </returns>
        private T DeserializeJsonFile<T>(string path) => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
    }
}