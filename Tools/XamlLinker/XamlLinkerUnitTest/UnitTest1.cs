using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamlLinker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XamlLinker xamlLinker = new XamlLinker(projectPath: @"D:\Develop\White_plus", 
                outputPath: @"D:\Develop\White_plus\TestApps\out",
                projectFile: @"D:\Develop\White_plus\WhiteTests\ViewAccessors\ViewAccessors (2).csproj");
            xamlLinker.Link();
        }
    }
}
