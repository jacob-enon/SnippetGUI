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

        [TestMethod]
        [DataRow("snippet")] // Just given a file name
        [DataRow("snippet.txt")] // Given a file name w/ incorrect extension
        [DataRow("this_file_does_not_exist.ppt")] // Using a non existant file
        public void Ctor_WithNonSnippetFile_UsesFileWithSnippetExtension(string file)
        {
            // Arrange
            var location = Path.Combine("test_data", file);

            // Act
            var snippetFile = new SnippetFile(location, string.Empty);

            // Assert
            Assert.AreEqual($"{location}.snippet", snippetFile.Location);
        }

        [TestMethod]
        public void Ctor_WithDir_UsesFileWithDefaultName()
        {
            // Arrange
            var dir = "test_data";

            // Act
            var snippetFile = new SnippetFile(dir, string.Empty);

            // Assert
            Assert.AreEqual($@"{dir}\snippet.snippet", snippetFile.Location);
        }
    }
}