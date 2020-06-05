using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnippetGUI.Model;
using System.Collections.Generic;

namespace SnippetGUITests
{
    [TestClass]
    public class DeclarationTests
    {
        [TestMethod]
        public void ValidDeclaration_ReturnsTrue_IfDeclarationIsValidAndNoExisting()
        {
            // Arrange
            var existing = new List<Declaration>();

            // Act
            var valid = Declaration.ValidDeclaration(existing, "1", "default");

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void ValidDeclaration_ReturnsTrue_IfDeclarationIsValidAndUnique()
        {
            // Arrange
            var existing = new List<Declaration>()
            {
                new Declaration("1", "default 1")
            };

            // Act
            var valid = Declaration.ValidDeclaration(existing, "2", "default 1");

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void ValidDeclaration_ReturnsFalse_IfIDNotUnique()
        {
            // Arrange
            var ID = "1";
            var existing = new List<Declaration>()
            {
                new Declaration(ID, "default 1")
            };

            // Act
            var valid = Declaration.ValidDeclaration(existing, ID, "default 2");

            // Assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        [DataRow("", "default")]
        [DataRow("id", "")]
        [DataRow("", "")]
        [DataRow(null, null)]
        public void ValidDeclaration_ReturnsFalse_IfFieldsNullOrEmpty(string ID, string defaultValue)
        {
            // Arrange
            var existing = new List<Declaration>();

            // Act
            var valid = Declaration.ValidDeclaration(existing, ID, defaultValue);

            // Assert
            Assert.IsFalse(valid);
        }
    }
}