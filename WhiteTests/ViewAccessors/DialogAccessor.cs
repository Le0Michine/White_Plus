using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using White.Core;
using White.Core.UIItems.WindowItems;


namespace ViewAccessors
{
    public class DialogAccessor<T> where T: AccessorBase, new()
    {
        public Window window;
        private T Taccessor;
        public OtherFunctionsAccessor accessor;

        public DialogAccessor(Window window)
        {
            Taccessor = new T();
            this.window = window.ModalWindow(Taccessor.Title);
            accessor = new OtherFunctionsAccessor(window);
        }

        ~DialogAccessor()
        {
            window.Close();
        }
    }
}



