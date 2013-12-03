using White.Core.UIItems.Finders;
using System.Text;
using White.Core;
using System.Windows.Controls;
using White.Core.UIItems.WindowItems;

namespace MathService
{
    public class Test
    {
        public string CalculationPhiFunc(Window window, string number)
        {
            var textBox = window.Get<White.Core.UIItems.TextBox>("Number");
            textBox.Text = number;
            var decompButton = window.Get<White.Core.UIItems.Button>("DecomposeButton");
            decompButton.Click();
            var resultLabel = window.Get<White.Core.UIItems.Label>("Answer");
            string result = resultLabel.Text;
            window.Close();
            return result;
        }
    }
}