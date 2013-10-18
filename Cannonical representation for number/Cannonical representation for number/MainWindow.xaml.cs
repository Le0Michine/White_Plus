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

	    private void Number_GotFocus(object sender, RoutedEventArgs e)
	    {
	        var number = e.Source as TextBox;
	        if (number != null) number.Clear();
	    }


	    private String Represetation(int n)
        {
            var ans = String.Format("Representation for " + n +  " includes: \n");
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
	}
}
