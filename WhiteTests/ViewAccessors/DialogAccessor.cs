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
        public Window window;
        public Window dialogWindow;
        public White.Core.UIItems.ListBoxItems.ComboBox comboBox;
        public White.Core.UIItems.TextBox textBox;
        public White.Core.UIItems.Button calculateButton;
        public White.Core.UIItems.Label resultLabel;

        public DialogAccessor(Application application)
        {
            var window = application.GetWindow("Decomposition");
            var moreFuncButton = window.Get<White.Core.UIItems.Button>("MoreFunctions");
            moreFuncButton.Click();
            dialogWindow = application.GetWindow("OtherFunctions");
            comboBox = dialogWindow.Get<White.Core.UIItems.ListBoxItems.ComboBox>();
            textBox = dialogWindow.Get<White.Core.UIItems.TextBox>();
            calculateButton = dialogWindow.Get<White.Core.UIItems.Button>("Calculation");
            resultLabel = dialogWindow.Get<White.Core.UIItems.Label>("AnsForComboBox");
        }

        ~DialogAccessor()
        {
            dialogWindow.Close();
            window.Close();
        }
    }
}



