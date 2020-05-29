using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetGUI.Data
{
    interface IDataAccess
    {
        IList<string> GetLanguages();
    }
}
