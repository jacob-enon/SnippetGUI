using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Model;
using System.Collections.Generic;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetValidatorTests
    {
        [TestMethod]
        public void ValidSnippet_ReturnsTrue_IfAllFieldsValid()
        {
            // Arrange
            var validator = new SnippetValidator();
            var language = "a";
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };
            var code = "test snippet";

            // Act
            var valid = validator.Validate(availableLanguages, language, code);

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        [DataRow("c")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfNotAvailableLanguage(string language)
        {
            // Arrange
            var validator = new SnippetValidator();
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };
            var code = "test snippet";

            // Act
            var valid = validator.Validate(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfCodeNullOrEmpty(string code)
        {
            // Arrange.
            var validator = new SnippetValidator();
            var language = "a";
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };

            // Act
            var valid = validator.Validate(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfNoAvailableLanguages()
        {
            // Arrange
            var validator = new SnippetValidator();
            var language = "a";
            var availableLanguages = new List<string>();
            var code = "test snippet";

            // Act
            var valid = validator.Validate(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfAvailableLanguagesIsNull()
        {
            // Arrange
            var validator = new SnippetValidator();
            var language = "a";
            List<string> availableLanguages = null;
            var code = "test snippet";

            // Act
            var valid = validator.Validate(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }
    }
}