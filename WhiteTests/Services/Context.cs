using System.IO;
using White.Core;
using White.Core.UIItems.WindowItems;
using _MathService;

namespace Services
{
    public class Context
    {
        private Application application;
        private Window window;
        private MathService mathService;
        public Window Window
        {
            get
            {
                if (window == null)
                {
                    StreamReader reader = File.OpenText(@"D:\WhitePlus\WhiteTests\Services\AppSource.txt");
                    string ExeSourceFile = reader.ReadToEnd();
                    application = Application.Launch(ExeSourceFile);
                    window = application.GetWindow("Decomposition");          
                }
                 return window;
            }   
        }
        public MathService MathService
        {
            get
            {
                if (mathService == null)
                {
                    mathService = new MathService(Window);
                }
                return mathService;
            }
        }

    }
}
