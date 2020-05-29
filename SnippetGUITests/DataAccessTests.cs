using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;

namespace SnippetGUITests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void GetLanguages_ReturnsListOfLanguages()
        {
            // Arrange
            var config = "test_data\\languages.json";
            var data = new DataAccess(config);

            // Act
            var languages = data.GetLanguages();

            // Assert
            Assert.AreEqual("language 1", languages[0]);
            Assert.AreEqual("language 2", languages[1]);
        }
    }
}