using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetBuilder
    {
        [TestMethod]
        public void SnippetBuilder_GenerateSnippet_ReplacesTemplateProperties()
        {
            // Arrange
            var title = "a";
            var author = "b";
            var description = "c";
            var shortcut = "d";
            var language = "e";
            var code = "f";
            var templateLocation = Path.Combine("test_data", "config.json");
            var builder = new SnippetGUI.Model.SnippetBuilder(title, author, description, shortcut, language, code, new DataAccess(templateLocation));

            // Act
            var snippet = builder.GenerateSnippet();

            // Act
            Assert.AreEqual("abcdef", snippet);
        }
    }
}