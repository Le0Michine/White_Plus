using System.IO;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace Services
{
    public class Context
    {
        public Application application;
        public Window getWindow()
        {
            StreamReader reader = File.OpenText(@"D:\WhitePlus\WhiteTests\Services\AppSource.txt");
            string ExeSourceFile = reader.ReadToEnd();
            application = Application.Launch(ExeSourceFile);
            var window = application.GetWindow("Decomposition");
            return window;
        }
    }
}
