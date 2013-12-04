using System.Collections.Generic;
using System.Text;
using White.Core;
using System.Windows.Controls;
using White.Core.Factory;
using White.Core.UIItems.WindowItems;
using White.Core.UIItems.Finders;

namespace ViewAccessors
{
    public class AccessorBase
    {
        string ExeSourceFile = @"D:\study\White+\TestApps\Cannonical representation for number\Cannonical representation for number\bin\Debug\Cannonical representation for number.exe";
        public Application application;
        public Window window;
        
        /// <summary>
        /// to do: window 
        /// </summary>
        public AccessorBase() 
        {
            application = Application.Launch(ExeSourceFile);
            window = application.GetWindow("Decomposition");
        }

    }

}