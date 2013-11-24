using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cannonical_representation_of_number
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Number_Initialized(object sender, EventArgs e)
        {
            var number = sender as TextBox;
            if (number != null) number.Text = "enter number";
        }

        //private void SecondTexBox_Initialized(object sender, EventArgs e)
        //{
        //    var number = sender as TextBox;
        //    if (number != null) number.Text = "enter number";
        //}

        private void Number_GotFocus(object sender, RoutedEventArgs e)
        {
            var number = e.Source as TextBox;
            if (number != null) number.Clear();
        }

        //private void SecondTexBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    var number = e.Source as TextBox;
        //    if (number != null) number.Clear();
        //}

        private String Represetation(int n)
        {
            var ans = String.Format("Representation for " + n + " includes: \n");
            var devisor = new List<int>();
            for (int i = 2; i < n / 2 + 1; i++)
            {
                if (isDevided(n, i))
                {
                    devisor.Add(i);
                }
            }

            for (int i = 1; i < devisor.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (isDevided(devisor.ElementAt(i), devisor.ElementAt(j)))
                    {
                        devisor.RemoveAt(i--);
                    }
                }
            }

            if (devisor.Count == 0)
            {
                devisor.Add(n);
            }

            return devisor.Aggregate(ans, (current, i) => current + (i + "\n"));
        }
        private bool isDevided(int n, int d)
        {
            return (n % d == 0);
        }
    
        //private string PhiFunc(int numb)
        //{
        //    double result = 1;
        //    bool simpleNum = true;
        //    string strForReturn = "Phi funcion for " + numb + ":\n";
        //    for (int i = 2; i < numb / 2 + 1; i++)
        //    {
        //        if (numb % i == 0)
        //        {
        //            simpleNum = false;
        //            double sqrtI = Math.Sqrt(i);
        //            int j = 2;
        //            for (j = 2; j < sqrtI; j++)
        //            {
        //                if (sqrtI % j == 0)
        //                    break;
        //            }
        //            if (j >= sqrtI)
        //            {
        //                int degOfI = 0;
        //                while (numb % i == 0)
        //                {
        //                    numb = numb / i;
        //                    degOfI++;
        //                }
        //                result = result * (Math.Pow(i, degOfI) - Math.Pow(i, degOfI - 1));
        //            }
        //        }
        //        if (simpleNum)
        //            result = numb - 1;
        //    }

        //    return strForReturn + Convert.ToString(result);
        //}

        //private string PrimeFunc(int numb)
        //{
        //    string isPrime = "";
        //    double sqrtNumb = Math.Sqrt(numb);
        //    for (int i = 2; i <= sqrtNumb; i++)
        //    {
        //        if (numb % i == 0)
        //        {
        //            isPrime = "not ";
        //            break;
        //        }
        //    }
        //        return Convert.ToString(numb) + " is " + isPrime + "prime";
        //}

        private void Button_Representation_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = "";
            var str = Number.Text;
            if (!String.IsNullOrEmpty(str))
            {
                try
                {
                    int n = int.Parse(str);
                    Answer.Text = n.ToString();
                    String ans = Represetation(n);
                    Answer.Text = ans;
                }
                catch (FormatException)
                {
                    Answer.Text = "Incorrect input";
                }
                catch (OverflowException)
                {
                    Answer.Text = "The number is too large";
                }
            }
            else
            {
                Answer.Text = "Field is empty";
            }
        }

        private void _number_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Representation_Click(sender, e);
                var t = sender as TextBox;
                if (t != null) t.Clear();
            }
        }
    
        //private void _number2_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        Button_Conculation_Click(sender, e);
        //        var t = sender as TextBox;
        //        if (t != null) t.Clear();
        //    }
        //}

        //private void Button_Conculation_Click(object sender, RoutedEventArgs e)
        //{
        //    //AnsForComboBox.Text = "";
        //    var str = SecondTextBox.Text;
        //    if (!String.IsNullOrEmpty(str))
        //    {
        //        try
        //        {
        //            int numb = int.Parse(str);
        //            if (comboBox.SelectedItem == PhiFuncion)
        //                AnsForComboBox.Text = PhiFunc(numb);
        //            else
        //                if (comboBox.SelectedItem == PrimeF)
        //                    AnsForComboBox.Text = PrimeFunc(numb);
        //                else
        //                    AnsForComboBox.Text = "Choose function!";
        //        }
        //        catch (FormatException)
        //        {
        //            AnsForComboBox.Text = "Incorrect input";
        //        }
        //        catch (OverflowException)
        //        {
        //            AnsForComboBox.Text = "The number is too large";
        //        }
        //    }
        //    else
        //    {
        //        AnsForComboBox.Text = "Field is empty";
        //    }
        //}
    }

}
