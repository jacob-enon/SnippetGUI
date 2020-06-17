using System.IO;

namespace SnippetGUI
{
    public static class Constants
    {
        /// <summary>
        /// Path to the default config file
        /// </summary>
        public static string ConfigFile => Path.Combine("Config", "config.json");
    }
}