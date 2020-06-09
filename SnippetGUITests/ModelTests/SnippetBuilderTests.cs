﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Data;
using SnippetGUI.Model;
using System.Collections.Generic;
using System.IO;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetBuilderTests
    {
        [TestMethod]
        public void GenerateSnippet_ReplacesSnippetTemplateProperties()
        {
            // Arrange
            var title = "a";
            var author = "b";
            var description = "c";
            var shortcut = "d";
            var language = "e";
            var code = "f";
            var templateLocation = Path.Combine("test_data", "config.json");
            var builder = new SnippetBuilder(title, author, description, shortcut, language, code,
                new List<Declaration>(), new DataAccess(templateLocation));

            // Act
            var snippet = builder.GenerateSnippet();

            // Act
            Assert.AreEqual("abcdef", snippet);
        }

        [TestMethod]
        public void GenerateSnippet_WithDeclarations_ReplacesDeclarationTemplateProperties()
        {
            // Arrange
            var declarations = new List<Declaration>()
            {
                new Declaration("1", "a"),
                new Declaration("2", "b", "tip1")
            };
            var templateLocation = Path.Combine("test_data", "config_with_declarations.json");
            var builder = new SnippetBuilder("", "", "", "", "", "", declarations, new DataAccess(templateLocation));

            // Act
            var snippet = builder.GenerateSnippet();

            // Assert
            Assert.AreEqual("1a2btip1", snippet);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsTrue_IfAllFieldsValid()
        {
            // Arrange
            var language = "a";
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };
            var code = "test snippet";

            // Act
            var valid = SnippetBuilder.ValidSnippet(availableLanguages, language, code);

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        [DataRow("c")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfNotAvailableLanguage(string language)
        {
            // Arrange
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };
            var code = "test snippet";

            // Act
            var valid = SnippetBuilder.ValidSnippet(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ValidSnippet_ReturnsFalse_IfCodeNullOrEmpty(string code)
        {
            // Arrange
            var language = "a";
            var availableLanguages = new List<string>()
            {
                "a",
                "b"
            };

            // Act
            var valid = SnippetBuilder.ValidSnippet(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfNoAvailableLanguages()
        {
            // Arrange
            var language = "a";
            var availableLanguages = new List<string>();
            var code = "test snippet";

            // Act
            var valid = SnippetBuilder.ValidSnippet(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void ValidSnippet_ReturnsFalse_IfAvailableLanguagesIsNull()
        {
            // Arrange
            var language = "a";
            List<string> availableLanguages = null;
            var code = "test snippet";

            // Act
            var valid = SnippetBuilder.ValidSnippet(availableLanguages, language, code);

            // Assert
            Assert.IsFalse(valid);
        }
    }
}