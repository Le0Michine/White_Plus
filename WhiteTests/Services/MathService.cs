using White.Core.UIItems.Finders;
using System.Text;
using White.Core;
using System.Windows.Controls;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using ViewAccessors;

namespace _MathService
{
    public class MathService
    {
        private Window window;
        public MathService(Window window)
        {
            this.window = window;
        }

        public string CalculationDecomposition(string number)
        {
            var accessor = new MainWindowAccessor(window);
            accessor.Number.Text = number;
            accessor.DecomposeButton.Click();
            string result = accessor.Answer.Text;
            return result;
        }

        //public string CalculationPhiFunction(string number)
        //{
        //    accessor.comboBox.Select("Phi function");
        //    accessor.textBox.Text = number;
        //    accessor.calculateButton.Click();
        //    string result = accessor.resultLabel.Text;
        //    return result;
        //}
    }
}