using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace ViewAccessors
{
    class AccessorBase
    {
        private static string ExeSourceFile = @"D:\study\White+\TestApps\Cannonical representation for number\Cannonical representation for number\bin\Debug\Cannonical representation for number.exe";
        private static Application application;
        private static Window mainWindow;
        
        /// <summary>
        /// to do: window должен передаваться как параметр конструктора и присваиваться
        /// </summary>
        AccessorBase() 
        {
            application = Application.Launch(ExeSourceFile);
            mainWindow = application.GetWindow("MainWindow", InitializeOption.NoCache);
        }
    }
}
