using Accessor_Generator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;


namespace UTests_for_AGenerator
{
    [TestFixture]
    internal class TestForAccessorGenerator
    {
        #region private fields

        private readonly List<String> _inputFiles = new List<string>()
            {
                Directory.GetCurrentDirectory() + @"\tests\MainWindow.xaml",
                Directory.GetCurrentDirectory() + @"\tests\ComboBox and DataGrid.xaml"
            };

        private List<String> _outputFiles = new List<string>();

        private readonly String OutputDirectory = Directory.GetCurrentDirectory() + @"\tests\";

        #endregion

        #region private methods

        private void InitializeOutputFileName()
        {
            foreach (var inputFile in _inputFiles)
            {
                var reader = new XmlTextReader(inputFile);
                reader.Read();
                while (reader.MoveToNextAttribute())
                {
                    if (reader.Name.Contains(":Class"))
                    {
                        String className = reader.Value.Split('.')[1];
                        _outputFiles.Add(OutputDirectory + className + "Accessor.cs");
                    }
                }
            }
        }

        private bool LineIsCommentOrEmpty(string line)
        {
            line = line.Trim();
            if (String.IsNullOrEmpty(line))
            {
                return true;
            }
            if (line.Length < 2)
            {
                return false;
            }
            return line.Substring(0, 2).Equals("//");
        }

        private void InitializeAccessorGenerator()
        {
            new AccessorGenerator(_inputFiles, OutputDirectory);
        }

        #endregion

        #region public methods

        [Test]
        public void TestNameOfFiles()
        {
            foreach (var outputFile in _outputFiles)
            {
                Assert.IsTrue(System.IO.File.Exists(outputFile));
            }
        }

        [Test]
        public void TestCountOfOutputFiles()
        {
            int countOfXamlFiles = (new DirectoryInfo(OutputDirectory).GetFiles("*.xaml")).Count();
            int countOfCsAccessorFiles = (new DirectoryInfo(OutputDirectory).GetFiles("*Accessor.cs")).Count();
            Assert.IsTrue(countOfCsAccessorFiles == countOfXamlFiles);
        }

        [Test]
        public void TestContentOfAccessorFiles()
        {
            foreach (var outputFile in _outputFiles)
            {
                var generatorOut = new StreamReader(outputFile);
                var exampleAccessor = new StreamReader((outputFile + ".Example"));
                Assert.IsNotNull(generatorOut);
                Assert.IsNotNull(exampleAccessor);
                String tmp;
                while ((tmp = generatorOut.ReadLine()) != null)
                {
                    string exampleLine = exampleAccessor.ReadLine();
                    if (LineIsCommentOrEmpty(tmp))
                    {
                        continue;
                    }
                    if (!tmp.Equals(exampleLine))
                    {
                        generatorOut.Close();
                        exampleAccessor.Close();
                        Assert.IsTrue(false);
                    }
                }
                generatorOut.Close();
                exampleAccessor.Close();
            }
        }

        [SetUp]
        public void SettingUp()
        {
            InitializeAccessorGenerator();
            InitializeOutputFileName();
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    #endregion
    }
}
