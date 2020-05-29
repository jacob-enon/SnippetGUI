using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace SnippetGUI.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly string languages;

        public DataAccess(string languages = "languages.json")
        {
            this.languages = languages;
        }

        public IList<string> GetLanguages()
        {
            var languagesData = File.ReadAllText(languages);
            return JsonConvert.DeserializeObject<List<string>>(languagesData);
        }
    }
}