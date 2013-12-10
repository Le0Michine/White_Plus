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
        public Window window;
        public White.Core.UIItems.TextBox textBox;
        public White.Core.UIItems.Button decompButton;
        public White.Core.UIItems.Label resultLabel;

        public AccessorBase(Window appWindow) 
        {
            window = appWindow;
            textBox = window.Get<White.Core.UIItems.TextBox>();
            decompButton = window.Get<White.Core.UIItems.Button>("DecomposeButton");
            resultLabel = window.Get<White.Core.UIItems.Label>("Answer");
        }
        public AccessorBase() { }

        ~AccessorBase()
        {
            window.Close();
        }
    }

}