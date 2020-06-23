using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class JsonDeserialiserTests
    {
        [TestMethod]
        public void DeserialiseFile_ReturnsDeserialisedObject()
        {
            // Arrange
            var file = Path.Combine("test_data", "config.json");
            var deserialiser = new JsonDeserialiser();

            // Act
            var output = deserialiser.DeserialiseFile<dynamic>(file);

            // Assert
            Assert.AreEqual("A", output.a.ToString());
            Assert.AreEqual("B", output.b.ToString());
        }
    }
}