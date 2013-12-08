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
        
        public AccessorBase(Window appWindow) 
        {
            window = appWindow;
        }
        public AccessorBase() { }

    }

}