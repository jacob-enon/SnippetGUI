using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnippetGUI.Data;
using System.Collections.Generic;

namespace SnippetGUITests
{
    [TestClass]
    public class DataAccessTests
    {
        DataAccess dataAccess;

        IList<string> languages;
        string snippetTemplate;
        string declarationTemplate;
        string replaceMarker;

        [TestInitialize]
        public void Init()
        {
            languages = new List<string>() { "a", "b" };
            snippetTemplate = "snippet";
            declarationTemplate = "declaration";
            replaceMarker = "replace";

            var config = new Config(languages, replaceMarker, snippetTemplate, declarationTemplate);
            var deserialiser = new Mock<IDeserialiser>();
            deserialiser.Setup(x => x.DeserialiseFile<Config>("")).Returns(config);

            dataAccess = new DataAccess("", deserialiser.Object);
        }

        [TestMethod]
        public void GetLanguages_ReturnsListOfLanguages()
        {
            Assert.AreEqual(languages, dataAccess.GetLanguages());
        }

        [TestMethod]
        public void GetSnippetTemplate_ReturnsSnippetTemplate()
        {
            Assert.AreEqual(snippetTemplate, dataAccess.GetSnippetTemplate());
        }

        [TestMethod]
        public void GetDeclarationTemplate_ReturnsDeclarationTemplate()
        {
            Assert.AreEqual(declarationTemplate, dataAccess.GetDeclarationTemplate());
        }

        [TestMethod]
        public void GetReplaceMarker_ReturnsReplaceMarker()
        {
            Assert.AreEqual(replaceMarker, dataAccess.GetReplaceMarker());
        }
    }
}