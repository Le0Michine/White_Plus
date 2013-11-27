using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cannonical_representation_of_number
{
    /// <summary>
    /// Логика взаимодействия для PhiFuncion.xaml
    /// </summary>
    public partial class PhiFuncion : Page
    {
        //public PhiFuncion()
        //{
        //    InitializeComponent();
        //}

        private void SecondTexBox_Initialized(object sender, EventArgs e)
        {
            var number = sender as TextBox;
            if (number != null) number.Text = "enter number";
        }

        private void SecondTexBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var number = e.Source as TextBox;
            if (number != null) number.Clear();
        }

        private string PhiFunc(int numb)
        {
            double result = 1;
            bool simpleNum = true;
            string strForReturn = "Phi funcion for " + numb + ":\n";
            for (int i = 2; i < numb / 2 + 1; i++)
            {
                if (numb % i == 0)
                {
                    simpleNum = false;
                    double sqrtI = Math.Sqrt(i);
                    int j = 2;
                    for (j = 2; j < sqrtI; j++)
                    {
                        if (sqrtI % j == 0)
                            break;
                    }
                    if (j >= sqrtI)
                    {
                        int degOfI = 0;
                        while (numb % i == 0)
                        {
                            numb = numb / i;
                            degOfI++;
                        }
                        result = result * (Math.Pow(i, degOfI) - Math.Pow(i, degOfI - 1));
                    }
                }
                if (simpleNum)
                    result = numb - 1;
            }

            return strForReturn + Convert.ToString(result);
        }

        private string PrimeFunc(int numb)
        {
            string isPrime = "";
            double sqrtNumb = Math.Sqrt(numb);
            for (int i = 2; i <= sqrtNumb; i++)
            {
                if (numb % i == 0)
                {
                    isPrime = "not ";
                    break;
                }
            }
            return Convert.ToString(numb) + " is " + isPrime + "prime";
        }



        private void _number2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Conculation_Click(sender, e);
                var t = sender as TextBox;
                if (t != null) t.Clear();
            }
        }

        private void Button_Conculation_Click(object sender, RoutedEventArgs e)
        {
            //AnsForComboBox.Text = "";
            //var str = SecondTextBox.Text;
            //if (!String.IsNullOrEmpty(str))
            //{
            //    try
            //    {
            //        int numb = int.Parse(str);
            //        if (comboBox.SelectedItem == PhiFuncion)
            //            AnsForComboBox.Text = PhiFunc(numb);
            //        else
            //            if (comboBox.SelectedItem == PrimeF)
            //                AnsForComboBox.Text = PrimeFunc(numb);
            //            else
            //                AnsForComboBox.Text = "Choose function!";
            //    }
            //    catch (FormatException)
            //    {
            //        AnsForComboBox.Text = "Incorrect input";
            //    }
            //    catch (OverflowException)
            //    {
            //        AnsForComboBox.Text = "The number is too large";
            //    }
            //}
            //else
            //{
            //    AnsForComboBox.Text = "Field is empty";
            //}
        }
    }
}
