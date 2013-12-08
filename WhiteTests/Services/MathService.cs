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
            var window = accessor.window;
            var textBox = window.Get<White.Core.UIItems.TextBox>();
            textBox.Text = number;
            var decompButton = window.Get<White.Core.UIItems.Button>("DecomposeButton");
            decompButton.Click();
            var resultLabel = window.Get<White.Core.UIItems.Label>("Answer");
            string result = resultLabel.Text;
            window.Close();
            return result;
        }

        public string CalculationPhiFunction(DialogAccessor accessor, string number)
        {
            //var firstWindow = accessor.window;
            //var moreFuncButton = firstWindow.Get<White.Core.UIItems.Button>("MoreFunctions");
            //moreFuncButton.Click();
            //var window = accessor.application.GetWindow("OtherFunctions");
            var window = accessor.window;
            var comboBox = window.Get<White.Core.UIItems.ListBoxItems.ComboBox>();
            comboBox.Select("Phi function");
            var textBox = window.Get<White.Core.UIItems.TextBox>();
            textBox.Text = number;
            var calculateButton = window.Get<White.Core.UIItems.Button>("Calculation");
            calculateButton.Click();
            var resultLabel = window.Get<White.Core.UIItems.Label>("AnsForComboBox");
            string result = resultLabel.Text;
            window.Close();
            //firstWindow.Close();
            return result;
        }
    }
}