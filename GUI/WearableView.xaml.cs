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
using Arsenal.ViewModel;
using Arsenal.Equipment;

namespace Arsenal.GUI
{
    /// <summary>
    /// Interaction logic for UniformView.xaml
    /// </summary>
    public partial class WearableView : UserControl
    {
        public WearableViewModel Wearable
        {
            get
            {
                return DataContext as WearableViewModel;
            }
        }
        public WearableView()
        {
            InitializeComponent();
        }

        private void ChangeQuanity(object sender, RoutedEventArgs e)
        {
            int index;
            Button button = sender as Button;
            ItemStackViewModel ItemStack = button.DataContext as ItemStackViewModel;
            switch (button.Content.ToString())
            {
                case "+" :
                    ItemStack.Quanity++;
                    break;
                case "-":
                    index = ItemsListBox.SelectedIndex;
                    ItemStack.Quanity--;
                    break;
            }
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender == AddButton)
            {
                AddItemWindow itemWindow = new AddItemWindow();
                itemWindow.Owner = Window.GetWindow(this);
                itemWindow.ShowDialog();
                if (itemWindow.AddNewItem)
                {
                    int quanity = Int32.Parse(itemWindow.Quanity.Text);
                    ItemStack stack = new ItemStack(itemWindow.Classname.Text, quanity);
                    Wearable.AddItem(stack);
                }
            }
            else if (sender == RemoveButton)
            {
                int index = ItemsListBox.SelectedIndex;
                if (index >= 0)
                {
                    Wearable.ItemStack.RemoveAt(index);
                }
            }
            else if (sender == CopyButton)
            {
                
            }
            else if (sender == ClearButton)
            {
                Wearable.ItemStack.Clear();
            }
        }
    }
}
