using System.Collections.Generic;

namespace SnippetGUI.Data
{
    /// <summary>
    /// Accesses configuration data for the application
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Get available snippet languages
        /// </summary>
        /// <returns> IList of available snippet languages </returns>
        IList<string> GetLanguages();

        string GetReplacementMarker();

        string GetTemplate();
    }
}