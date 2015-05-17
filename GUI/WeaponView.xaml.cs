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
using Arsenal.Equipment;
using Arsenal.ViewModel;

namespace Arsenal.GUI
{
    /// <summary>
    /// Interaction logic for WeaponItem.xaml
    /// </summary>
    public partial class WeaponView : UserControl
    {

        public WeaponViewModel Weapon
        {
            get
            {
                return DataContext as WeaponViewModel;
            }
        }
        public WeaponView()
        {
            InitializeComponent();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender == editButton)
            {
                int index = AttachmentsListBox.SelectedIndex;
                if (index >= 0)
                {
                    EditWIndow window = new EditWIndow();
                    window.Field.Text = Weapon.Attachments[index];
                    window.ShowDialog();
                    Weapon.Attachments[index] = window.Field.Text;
                }
               
                
            }
            else if (sender == RemoveButton)
            {
                int index = AttachmentsListBox.SelectedIndex;
                if (index >= 0)
                {
                    Weapon.Attachments[index] = "";
                }
            }
            else if (sender == CopyButton)
            {

            }
            else if (sender == ClearButton)
            {
                for (int i = 0; i < Weapon.Attachments.Count; ++i)
                    Weapon.Attachments[i] = "";
            }
        }
    }
}
