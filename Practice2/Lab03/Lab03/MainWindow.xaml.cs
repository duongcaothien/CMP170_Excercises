using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab03
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

        private void btnPlus(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 + number2;
            txtResult.Text = result.ToString();
            string result1 = number1 + " + " + number2 + " = " + result;
            lstRecentCalculation.Items.Add(result1);
        }

        private void btnMinus(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 - number2;
            txtResult.Text = result.ToString();
            string result1 = number1 + " - " + number2 + " = " + result;
            lstRecentCalculation.Items.Add(result1);

        }

        private void btnMutiply(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 * number2;
            txtResult.Text = result.ToString();
            string result1 = number1 + " * " + number2 + " = " + result;
            lstRecentCalculation.Items.Add(result1);
        }

        private void btnDivide(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 / number2;
            txtResult.Text = result.ToString();
            string result1 = number1 + " / " + number2 + " = " + result;
            lstRecentCalculation.Items.Add(result1);
        }

    }
}

