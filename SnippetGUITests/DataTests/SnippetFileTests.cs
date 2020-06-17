using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetFileTests
    {
        [TestMethod]
        public void Ctor_WithSnippetFile_UsesFileAsLocation()
        {
            // Arrange
            var location = Path.Combine("test_data", "snippet.snippet");

            // Act
            var snippetFile = new SnippetFile(location, string.Empty);

            // Assert
            Assert.AreEqual(location, snippetFile.Location);
        }
    }
}