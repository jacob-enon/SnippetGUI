namespace SnippetGUI.Data
{
    /// <summary>
    /// Deserialises data into objects
    /// </summary>
    public interface IDeserialiser
    {
        /// <summary>
        /// Deserialise a file into an object
        /// </summary>
        /// <typeparam name="T"> Type of object to deserialise into </typeparam>
        /// <param name="filePath"> Path of the file to deserialise </param>
        /// <returns> Deserialised object </returns>
        public T DeserialiseFile<T>(string filePath);
    }
}