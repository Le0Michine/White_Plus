using System.Collections.Generic;
using System.Text;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems.WindowItems;

namespace ViewAccessors
{
    public class AccessorBase
    {
        private static string ExeSourceFile = @"D:\study\White+\TestApps\Cannonical representation for number\Cannonical representation for number\bin\Debug\Cannonical representation for number.exe";
        private static Application application;
        public  Window window;
        
        /// <summary>
        /// to do: window 
        /// </summary>
        public AccessorBase() 
        {
            application = Application.Launch(ExeSourceFile);
            window = application.GetWindow("Decomposition of Number", InitializeOption.NoCache);
        }
    }
}