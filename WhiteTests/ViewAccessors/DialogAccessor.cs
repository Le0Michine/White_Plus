using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace ViewAccessors
{
    public class DialogAccessor
    {
        string ExeSourceFile = @"D:\study\White+\TestApps\Cannonical representation for number\Cannonical representation for number\bin\Debug\Cannonical representation for number.exe";
        public Application application;
        public Window window;

        public DialogAccessor()
        {
            application = Application.Launch(ExeSourceFile);
            var initWindow = application.GetWindow("Decomposition");
            var moreFuncButton = initWindow.Get<White.Core.UIItems.Button>("MoreFunctions");
            moreFuncButton.Click();
            window = application.GetWindow("OtherFunctions");
        }

    }
}