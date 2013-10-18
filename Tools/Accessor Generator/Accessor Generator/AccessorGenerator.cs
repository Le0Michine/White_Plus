using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.CodeDom;
using System.Xml;
using Microsoft.CSharp;

namespace Accessor_Generator
{
    public class AccessorGenerator
    { 
	    private readonly Dictionary<String, String> _dictionaryForWhiteUIItems = new Dictionary<String, String>
				{
					{"Button", "Button"},
					{"TextBox", "TextBox"},
					{"TextBlock", "Label"},
					{"Label", "Label"},
					{"DataGrid", "ListView"},
					{"ComboBox", "ListBoxItems"},

					{"List", "ListBox"},
					{"Slider", "Slider"},
					{"CheckBox", "CheckBox"},
					{"Hyperlink", "Hyperlink"},
					{"Tree", "Tree"},
					{"RadioButton", "RadioButton"},
					{"Table", "Table"},
					{"Document", "MultilineTextBox"},
					{"Tab", "Tab"},
					{"ToolBar", "ToolStrip"},
					{"MenuBar", "MenuBar"},
					{"Menu", "MenuBar"},
					{"MenuItem", "Menu"},
					{"Spinner", "Spinner"},
					{"StatusBar", "StatusStrip"},
					{"ProgressBar", "ProgressBar"},
					{"Image", "Image"},
					{"TabPage", "TabItem"},
					{"DataItem", "ListViewRow"},
					{"ListItem", "ListItem"},
					{"TreeItem", "TreeNode"},
					{"Group", "GroupBox"},
					{"Thumb", "Thumb"},
					{"TitleBar", "TitleBar"},
					{"ToolTip", "ToolTip"}
				}; 
		private String _xamlNameSpace;

		public AccessorGenerator(IEnumerable<String> xmlFiles, String outputDirectory)
		{
			foreach (String file in xmlFiles)
			{
				var reader = new XmlTextReader(file);
				var accessorClass = new CodeCompileUnit(); ;

				reader.Read();
				GetXamlNameSpace(reader);
				String className = reader.GetAttribute(_xamlNameSpace + "Class").Split('.')[1];

				var nameSpace = new CodeNamespace(@"TestFramework");
				var imports = new CodeNamespace();
				imports.Imports.Add(new CodeNamespaceImport("System"));
				imports.Imports.Add(new CodeNamespaceImport("White.Core"));
				imports.Imports.Add(new CodeNamespaceImport("White.Core.UIItems.WindowItems"));
				
				accessorClass.Namespaces.Add(imports);
				accessorClass.Namespaces.Add(nameSpace);

				var accessorClassDeclaration = new CodeTypeDeclaration(className + "Accessor");
				accessorClassDeclaration.BaseTypes.Add("AccessorBase");
				ParseXaml(reader, imports, accessorClassDeclaration);
				nameSpace.Types.Add(accessorClassDeclaration);
				String sourceFile = GenerateSourceFile(outputDirectory + className + "Accessor", accessorClass);
				Console.Out.WriteLine(sourceFile);
			}
		}
        
		private void GetXamlNameSpace(XmlTextReader reader)
		{
			while (reader.MoveToNextAttribute())
			{
				String tmp = reader.Name;
				if (tmp.Contains(":Class"))
				{
					_xamlNameSpace = tmp.Split(':')[0] + ":";
					return;
				}
			}
		}

		private void AddViewTitleAndName(XmlTextReader reader, CodeTypeDeclaration accessorClassDeclaration)
		{
			String viewTitle = reader.GetAttribute("Title");
			String viewName = reader.GetAttribute(_xamlNameSpace + "Name") ?? reader.GetAttribute("Name");
			AddStringProperty(accessorClassDeclaration, @"ViewTitle", viewTitle);
			AddStringProperty(accessorClassDeclaration, @"ViewName", viewName);
		}

		private void ParseXaml(XmlTextReader reader, CodeNamespace imports, CodeTypeDeclaration accessorClassDeclaration)
		{
			AddViewTitleAndName(reader, accessorClassDeclaration);
				while (reader.Read())
                {
	                if (reader.NodeType != XmlNodeType.Element) continue;
	                if (!_dictionaryForWhiteUIItems.ContainsKey(reader.Name)) continue;
	                
					String name = reader.GetAttribute(_xamlNameSpace + "Name") ?? reader.GetAttribute("Name");
	                switch (reader.Name)
	                {
			                default:
								AddPropertyControl(accessorClassDeclaration, _dictionaryForWhiteUIItems[reader.Name], name);
								AddUIItem(imports, _dictionaryForWhiteUIItems[reader.Name]);
							break;
	                }
                }
		}

		private void AddPropertyControl(CodeTypeDeclaration accessorClassDeclaration, String type, String name)
		{
			var property = new CodeMemberProperty
				{
					Attributes = (MemberAttributes.Public | MemberAttributes.Final),
					Name = name,
					Type = new CodeTypeReference(type)
				};
			property.GetStatements.Add(new CodeMethodReturnStatement(
				new CodeMethodInvokeExpression(
					new CodeMethodReferenceExpression(
						new CodeVariableReferenceExpression("window"), "Get", new CodeTypeReference(type)), new CodePrimitiveExpression(name))));
			accessorClassDeclaration.Members.Add(property);
		}

		private void AddStringProperty(CodeTypeDeclaration accessorClassDeclaration, String str, String value)
		{
			var property = new CodeMemberProperty
				{
					Attributes = (MemberAttributes.Public | MemberAttributes.Final),
					Name = str,
					Type = new CodeTypeReference("String")
				};
			property.GetStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(value)));
			accessorClassDeclaration.Members.Add(property);
		}

		private void AddUIItem(CodeNamespace imports, String UIItemType)
		{
			imports.Imports.Add(new CodeNamespaceImport("White.Core.UIItems." + UIItemType));
		}


        private String GenerateSourceFile(String outputFile, CodeCompileUnit accessorClass)
        {
            var codeProvider = new CSharpCodeProvider();
            if (codeProvider.FileExtension[0] == '.')
            {
                outputFile += codeProvider.FileExtension;
            }
            else
            {
                outputFile += '.' + codeProvider.FileExtension;
            }

            var streamWriter = new StreamWriter(outputFile, false);
            var textWriter = new IndentedTextWriter(streamWriter, "	");
			codeProvider.GenerateCodeFromCompileUnit(accessorClass, textWriter, new CodeGeneratorOptions());
			textWriter.Close();
            return outputFile;
        }
    }
}
