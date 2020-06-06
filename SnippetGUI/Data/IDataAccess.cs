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

        /// <summary>
        /// Get the marker to replace properties in the template
        /// </summary>
        /// <returns> The marker to replace properties in a template </returns>
        string GetReplaceMarker();

        /// <summary>
        /// Get the template for a code snippet
        /// </summary>
        /// <returns> The template for a code snippet </returns>
        string GetSnippetTemplate();

        /// <summary>
        /// Get the template for a declaration
        /// </summary>
        /// <returns> The template for a declaration </returns>
        string GetDeclarationTemplate();
    }
}