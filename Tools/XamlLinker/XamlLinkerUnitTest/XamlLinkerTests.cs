using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamlLinker
{
    [TestClass]
    public class XamlLinkerTests
    {
        /// <summary>
        /// Links all xamls in dir
        /// </summary>
        [TestMethod]
        public void Link()
        {
            XamlLinker xamlLinker = new XamlLinker(projectPath: @"D:\Develop\White_plus",
                outputPath: @"Accessors\App.xaml",
                projectFile: @"D:\Develop\White_plus\WhiteTests\ViewAccessors\ViewAccessors.csproj");
            xamlLinker.Link();
        }
    }
}
