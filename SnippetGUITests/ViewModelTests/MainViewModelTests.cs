using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;
using SnippetGUI.Model;
using SnippetGUI.ViewModel;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void Ctor_GetsListOfAvailableLanguages()
        {
            // Arrange
            var languages = Path.Combine("test_data", "config.json");
            var dataAccess = new DataAccess(languages);

            // Act
            var vm = new MainViewModel(dataAccess);

            // Assert
            Assert.AreEqual("language 1", vm.Languages[0]);
            Assert.AreEqual("language 2", vm.Languages[1]);
        }
    }
}