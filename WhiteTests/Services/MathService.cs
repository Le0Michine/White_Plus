using White.Core.UIItems.Finders;
using System.Text;
using White.Core;
using System.Windows.Controls;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using ViewAccessors;

namespace MathService
{
    public class Test
    {
        public string CalculationDecomposition(AccessorBase accessor, string number)
        {
            accessor.textBox.Text = number;
            accessor.decompButton.Click();
            string result = accessor.resultLabel.Text;
            return result;
        }

        public string CalculationPhiFunction(DialogAccessor accessor, string number)
        {
            accessor.comboBox.Select("Phi function");
            accessor.textBox.Text = number;
            accessor.calculateButton.Click();
            string result = accessor.resultLabel.Text;
            return result;
        }
    }
}