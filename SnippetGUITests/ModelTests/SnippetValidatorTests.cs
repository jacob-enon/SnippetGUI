using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Model;
using System.Collections.Generic;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetValidatorTests
    {
        SnippetValidator validator;
        List<string> availableLanguages;
        string validCode;
        string validLanguage;

        [TestInitialize]
        public void Init()
        {
            validCode = "test snippet";
            validLanguage = "a";
            validator = new SnippetValidator();
            availableLanguages = new List<string>()
            {
                "a",
                "b"
            };
        }

        [TestMethod]
        public void ValidSnippet_ReturnsTrue_IfAllFieldsValid()
        {
            // Arrange

            // Act
            var valid = validator.Validate(availableLanguages, validLanguage, validCode);

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        [DataRow("c")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfNotAvailableLanguage(string language)
        {
            // Arrange

            // Act
            var valid = validator.Validate(availableLanguages, language, validCode);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfCodeNullOrEmpty(string code)
        {
            // Arrange

            // Act
            var valid = validator.Validate(availableLanguages, validLanguage, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfNoAvailableLanguages()
        {
            // Arrange
            var emptyAvailableLanguages = new List<string>();

            // Act
            var valid = validator.Validate(emptyAvailableLanguages, validLanguage, validCode);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfAvailableLanguagesIsNull()
        {
            // Arrange
            List<string> emptyAvailableLanguages = null;

            // Act
            var valid = validator.Validate(emptyAvailableLanguages, validLanguage, validCode);

            // Assert
            Assert.IsFalse(valid);
        }
    }
}