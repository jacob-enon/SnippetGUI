using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Model;
using System;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetFileValidatorTests
    {
        SnippetFileValidator validator;
        string validSnippet;
        string validFile;

        [TestInitialize]
        public void Init()
        {
            validSnippet = "snippet.snippet";
            validFile = Path.Combine(Environment.GetEnvironmentVariable("tmp"), "snippet.snippet");
            validator = new SnippetFileValidator();
        }

        [TestMethod]
        public void Validate_ReturnsFalse_IfTypeNotSnippet()
        {
            // Arrange
            var file = "snippet.txt";

            // Act
            var valid = validator.Validate(validSnippet, file);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Validate_ReturnsFalse_IfFileNullOrEmpty(string file)
        {
            Assert.IsFalse(validator.Validate(validSnippet, file));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Validate_ReturnsFalse_IfSnippetNullOrEmpty(string snippet)
        {
            Assert.IsFalse(validator.Validate(snippet, validFile));
        }

        [TestMethod]
        public void Validate_ReturnsTrue_ForValidSNippetFile()
        {
            Assert.IsTrue(validator.Validate(validSnippet, validFile));
        }
    }
}