using System.Collections.Generic;

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
        /// <param name="configLocation"> Location of the config file </param>
        /// <param name="deserialiser"> Deserialiser to deserialise the config file </param>
        public DataAccess(string configLocation, IDeserialiser deserialiser)
        {
            config = deserialiser.DeserialiseFile<Config>(configLocation);
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
        public string GetReplaceMarker() => config.ReplaceMarker;

        /// <summary>
        /// Get the template for a code snippet
        /// </summary>
        /// <returns> The template for a code snippet </returns>
        public string GetSnippetTemplate() => config.SnippetTemplate;

        /// <summary>
        /// Get the template for a declaration
        /// </summary>
        /// <returns> The template for a declaration snippet </returns>
        public string GetDeclarationTemplate() => config.DeclarationTemplate;
    }
}