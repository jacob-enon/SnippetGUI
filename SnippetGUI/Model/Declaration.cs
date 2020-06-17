namespace SnippetGUI.Model
{
    /// <summary>
    /// A declaration to add to a snippet
    /// </summary>
    public class Declaration
    {
        /// <summary>
        /// Unique ID of the declaration
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Default value to be put in place of the ID
        /// </summary>
        public string DefaultValue { get; }

        /// <summary>
        /// Information on the declaration
        /// </summary>
        public string ToolTip { get; }

        /// <summary>
        /// Construct a declaration
        /// </summary>
        /// <param name="id"> Unique ID of the declaration </param>
        /// <param name="defaultValue"> Default value to be put in place of the ID </param>
        /// <param name="toolTip"> Information on the declaration </param>
        public Declaration(string id, string defaultValue, string toolTip = null)
        {
            ID = id;
            DefaultValue = defaultValue;
            ToolTip = toolTip;
        }
    }
}