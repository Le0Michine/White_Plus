using System.IO;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace Services
{
    public class Context
    {
        public Window getWindow()
        {
            StreamReader reader = File.OpenText("AppSource.txt");
            string ExeSourceFile = reader.ReadLine();
            var application = Application.Launch(ExeSourceFile);
            var window = application.GetWindow("Decomposition");
            return window;
        }
    }
}
