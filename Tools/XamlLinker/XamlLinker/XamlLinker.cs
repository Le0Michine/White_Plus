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

        #region private properties

        private List<string> XamlFiles;
 
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
            XmlTextReader reader = new XmlTextReader(ProjectFile);
            XmlDocument document = new XmlDocument();
            document.Load(ProjectFile);
            XmlElement node = document.CreateElement("ItemGroup");
            XmlElement createAccessor = document.CreateElement("GenerateAccessor");
            XmlAttribute attribute = document.CreateAttribute("Include");
            attribute.Value = XamlFiles[0];
            createAccessor.Attributes.Append(attribute);
            XmlElement linkNode = document.CreateElement("Link");
            XmlText link = document.CreateTextNode(OutputDir);
            linkNode.AppendChild(link);
            createAccessor.AppendChild(linkNode);
            node.AppendChild(createAccessor);
            document.DocumentElement.AppendChild(node);
            document.Save(ProjectFile);
        }

        #endregion

    } 
}