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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // I have declared three variables,
        // "output " stories the defferent numbers the user clicked, i have used it in the switch statmenet 
        // "temp" also stories "output" as double, line 91 -99
        string output = "";
        double temp = 0;
        string operation = "";
        
        private void Btn_click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;
            
            switch (name)
            {
                case "btn_0":
                    output += 0;
                    ResultScreen.Text = output;
                    break;
                case "btn_1":
                    output += 1;
                    ResultScreen.Text = output;
                    break;
                case "btn_2":
                    output += 2;
                    ResultScreen.Text = output;
                    break;
                case "btn_3":
                    output += 3;
                    ResultScreen.Text = output;
                    break;
                case "btn_4":
                    output += 4;
                    ResultScreen.Text = output;
                    break;
                case "btn_5":
                    output += 5;
                    ResultScreen.Text = output;
                    break;
                case "btn_6":
                    output += 6;
                    ResultScreen.Text = output;
                    break;
                case "btn_7":
                    output += 7;
                    ResultScreen.Text = output;
                    break;
                case "btn_8":
                    output += 8;
                    ResultScreen.Text = output;
                    break;
                case "btn_9":
                    output += 9;
                    ResultScreen.Text = output;
                    break;
                case "btn_AC":
                    output = string.Empty;
                    ResultScreen.Text = output;
                    break;
                case "btn_comma":
                    output += ",";
                    ResultScreen.Text = output;
                    break;
            }
        }
        // Minus button
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if(output != "") // If the "output" have a string 
            {
                temp = double.Parse(output); // then is will be storied in "temp" as a double - fx 1 is clicked and then minus btn and then 1 the first one will be storied in temp variable!
                output = "";
                operation = "Minus";
            }
        }
        // Plus button
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Plus";
            }
        }
        // Mulitiplay button
        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Multiplay";
            }
        }
        // Devision button
        private void btnDevision_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Devision";
            }
        }
        // Percentage button
        private void btn_pc_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "Percentage"; 
            }
        }

        // button equal click event - I have switch statment if user want to multiplay, devide, substract act..
        // If one of the condition mutches, it will do the excution,
        // it will take the first user input(output) and put it on "temp"
        // and then Minus, multiplay and so on.. with the second user input(output) it will be storied in the "outpuTemp"
        // So the outputTemp will be like " outputTemp = temp + double.Parse(output); "
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "Minus":  // For minus
                    double outputTemp = temp - double.Parse(output); // Stories the privious user clicked number
                    output = outputTemp.ToString(); // output stories outputTemp.ToString()
                    ResultScreen.Text = output;  // ResultScreen will display output / same as  -> temp - double.Parse(output);
                    break;

                case "Plus": // For plus 
                    outputTemp = temp + double.Parse(output);
                    output = outputTemp.ToString(); // Convert output temp to a string
                    ResultScreen.Text = output;  // And then it wil be displayed in the TextBox.Text(ResultScreen)
                    break;

                case "Multiplay": // For Miltiplication
                    outputTemp = temp * double.Parse(output);
                    output = outputTemp.ToString();
                    ResultScreen.Text = output;
                    break;

                case "Devision": // For Devision
                    outputTemp = temp / double.Parse(output);
                    output = outputTemp.ToString();
                    ResultScreen.Text = output;
                    break;

                case "Percentage": // For Percentage
                    outputTemp = temp / 100;  // This will devide the first number by 100, and give you a percentage
                    output = outputTemp.ToString();
                    ResultScreen.Text = output;
                    break;
            }
        }
    }
}

