using System.Collections.Generic;
using System.Linq;

namespace SnippetGUI.Model
{
    /// <summary>
    /// Validates declarations
    /// </summary>
    public class DeclarationValidator
    {
        /// <summary>
        /// Determines whether a declaration is valid in the context of the existing declarations
        /// </summary>
        /// <param name="existingDeclarations"> Declarations that have already been added </param>
        /// <param name="ID"> ID of the new declaration </param>
        /// <param name="defaultValue"> Default value of the new declaration </param>
        /// <returns> True if the declaration is valid and uniquely identified </returns>
        public bool Validate(IList<Declaration> existingDeclarations, string ID, string defaultValue)
            => !(string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(defaultValue))
                && !existingDeclarations.Where(x => x.ID == ID).Any();
    }
}