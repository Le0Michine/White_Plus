using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace MathService
{
    class Test
    {
        private static void CalculationPhiFunc(Window window, string number)
        {
            var textBox = window.Get<White.Core.UIItems.TextBox>();
            textBox.Text = number;
            var decompButton = window.Get<White.Core.UIItems.Button>("Decomposition");
            decompButton.Click();
            var resultLabel = window.Get<White.Core.UIItems.Label>();
            string result = resultLabel.Text;

        }
    }
}