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

        virtual public string Title { get; set; }

        public AccessorBase(Window window) 
        {
            this.window = window;
        }
        public AccessorBase() { }

        public DialogAccessor<MainWindowAccessor> getDialog()
        {
            var dialogAccessor = new DialogAccessor<MainWindowAccessor>(window);
            return dialogAccessor;
        }

        ~AccessorBase()
        {
            window.Close();
        }
    }

}