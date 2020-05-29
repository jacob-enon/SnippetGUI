using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetGUI.Data
{
    public interface IDataAccess
    {
        IList<string> GetLanguages();
    }
}
