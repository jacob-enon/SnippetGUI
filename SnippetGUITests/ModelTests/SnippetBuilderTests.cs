using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnippetGUI.Data;
using SnippetGUI.Model;
using System.Collections.Generic;

namespace SnippetGUITests
{
    [TestClass]
    public class SnippetBuilderTests
    {
        Mock<IDataAccess> dataAccess;
        string snippetTemplate;
        string declarationTemplate;

        [TestInitialize]
        public void Init()
        {
            snippetTemplate = "$title$$author$$description$$shortcut$$language$$code$$declarations$";
            declarationTemplate = "$ID$$Default$$ToolTip$";

            dataAccess = new Mock<IDataAccess>();
            dataAccess.Setup(x => x.GetSnippetTemplate()).Returns(snippetTemplate);
            dataAccess.Setup(x => x.GetDeclarationTemplate()).Returns(declarationTemplate);
            dataAccess.Setup(x => x.GetReplaceMarker()).Returns("$");
        }

        [TestMethod]
        public void SnippetBuilder_BuildsSnippet()
        {
            // Arrange
            var title = "test title";
            var author = "test author";
            var description = "test description";
            var shortcut = "test shortcut";
            var language = "test language";
            var code = "do this();";

            var declaration1 = new Declaration("1", "default 1");
            var declaration2 = new Declaration("2", "default 2", "tool tip 2");
            var declarations = new List<Declaration>()
            {
                declaration1,
                declaration2
            };

            var expected = $"{title}{author}{description}{shortcut}{language}{code}{declaration1.ID}" +
                $"{declaration1.DefaultValue}{declaration2.ID}{declaration2.DefaultValue}{declaration2.ToolTip}";

            var builder = new SnippetBuilder(dataAccess.Object);

            // Act
            var snippet = builder.GenerateSnippet(title, author, description, shortcut, language, code, declarations);

            // Assert
            Assert.AreEqual(expected, snippet);
        }
    }
}