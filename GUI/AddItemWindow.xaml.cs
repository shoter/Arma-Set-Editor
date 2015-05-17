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
using System.Windows.Shapes;

namespace Arsenal.GUI
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public bool AddNewItem = false;
        public AddItemWindow()
        {
            InitializeComponent();
            Error.Visibility = Visibility.Hidden;
        }


        private void FieldFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Insert classname here")
            {
                textBox.Text = "";
            }
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (Error == null) return;
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "")
            {
               Error.Visibility = Visibility.Visible;
            }
            else
            {
                Error.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender == AddButton)
            {
                AddNewItem = true;
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
