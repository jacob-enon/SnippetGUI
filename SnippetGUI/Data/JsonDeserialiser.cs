using Newtonsoft.Json;
using System.IO;

namespace SnippetGUI.Data
{
    /// <summary>
    /// Deserialises JSON into objects
    /// </summary>
    public class JsonDeserialiser : IDeserialiser
    {
        /// <summary>
        /// Deserialise a JSON file into an object
        /// </summary>
        /// <typeparam name="T"> Type of object to deserialise into </typeparam>
        /// <param name="filePath"> Path of the file to deserialise </param>
        /// <returns> Deserialised object </returns>
        public T DeserialiseFile<T>(string filePath) => JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
    }
}