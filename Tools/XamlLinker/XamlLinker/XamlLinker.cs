using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XamlLinker
{
    public class XamlLinker
    {
        #region public properties

        public string ProjectDir { get; set; }
        public string OutputDir { get; set; }
        public string ProjectFile { get; set; }

        #endregion

        #region private fields

        private List<string> XamlFiles;
        private string accessorGeneratorBildAction = "GenerateAccessor";
        #endregion

        #region private methods
        private void FindAllXamlFiles()
        {
            XamlFiles.Clear();
            RecursiveSearch(new[] {ProjectDir});
        }

        private void RecursiveSearch(string[] dir)
        {
            if (!dir.Any())
            {
                return;
            }
            foreach (var innerDirectory in dir)
            {
                //TODO: maybe need to catch "failed to access axception"
                //TODO: recursive call - is evil or not? 
                //TODO: But in this case I'm sure that count of directory levels in project won't achieved "stackOverflowException"
                RecursiveSearch(Directory.GetDirectories(innerDirectory)); 
                XamlFiles.AddRange(Directory.GetFiles(innerDirectory, "*.xaml"));
            }
        }

        private XmlElement CreateLinkToXamlFile(string path, XmlDocument projectDocument)
        {
            XmlElement buildActionElement = projectDocument.CreateElement(accessorGeneratorBildAction);
            XmlAttribute includeAttribute = projectDocument.CreateAttribute("Include");
            includeAttribute.Value = path;
            buildActionElement.Attributes.Append(includeAttribute);
            XmlElement linkElement = projectDocument.CreateElement("Link");
            XmlText linkPath = projectDocument.CreateTextNode(OutputDir);
            linkElement.AppendChild(linkPath);
            buildActionElement.AppendChild(linkElement);
            return buildActionElement;
        }

        private void LinkXamlToProjectDocument(XmlDocument projectDocument)
        {
            XmlElement itemGroupElement = projectDocument.CreateElement("ItemGroup");
            foreach (string file in XamlFiles)
            {
                itemGroupElement.AppendChild(CreateLinkToXamlFile(file, projectDocument));
            }
            projectDocument.DocumentElement.AppendChild(itemGroupElement);
        }
        #endregion

        #region public methods

        public XamlLinker(string projectPath, string outputPath, string projectFile)
        {
            ProjectDir = projectPath;
            OutputDir = outputPath;
            ProjectFile = projectFile;
            XamlFiles = new List<string>();
        }

        public void Link()
        {
            FindAllXamlFiles();
            XmlDocument document = new XmlDocument();
            document.Load(ProjectFile);
            LinkXamlToProjectDocument(document);
            document.Save(ProjectFile);          
        }

        #endregion

    } 
}