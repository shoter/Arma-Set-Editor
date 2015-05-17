using Arsenal.Brace;
using Arsenal.Equipment;
using Arsenal.Gui;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Arsenal.ViewModel;

namespace Arsenal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SetViewModel> setsVM = new ObservableCollection<SetViewModel>();
        List<Set> sets = new List<Set>();
        public MainWindow()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;



            

        }

        private void OrderChangeClick(object sender, RoutedEventArgs e)
        {
            int index;
            switch((sender as Button).Content.ToString())
            {
                case "Up" :
                    index = SetListBox.SelectedIndex;
                    if(index > 0)
                    {
                        MoveTo(index, index - 1);
                        SetListBox.SelectedIndex = index - 1;
                    }
                    break;

                case "Down":
                    index = SetListBox.SelectedIndex;
                    if(index >= 0 && index < sets.Count - 1)
                    {
                        MoveTo(index, index + 1);
                        SetListBox.SelectedIndex = index + 1;
                    }
                    break;
            }
        }

        private void MoveTo(int startIndex, int endIndex)
        {
            var temp = sets[endIndex];
            sets[endIndex] = sets[startIndex];
            sets[startIndex] = temp;

            var tempVm = setsVM[endIndex];
            setsVM[endIndex] = setsVM[startIndex];
            setsVM[startIndex] = tempVm;

            
        }

        private void ShowSetClick(object sender, RoutedEventArgs e)
        {
            if(SetListBox.SelectedIndex >= 0)
                openNewTab(SetListBox.SelectedIndex);
        }

        private void MoveTopClick(object sender, RoutedEventArgs e)
        {
             if(SetListBox.SelectedIndex >= 0)
             {
                 MoveTo(SetListBox.SelectedIndex, 0);
             }
        }

        private void MoveDownClick(object sender, RoutedEventArgs e)
        {
            if (SetListBox.SelectedIndex >= 0)
            {
                MoveTo(SetListBox.SelectedIndex, sets.Capacity - 1);
            }
        }

        private void CloneClick(object sender, RoutedEventArgs e)
        {
            if (SetListBox.SelectedIndex >= 0)
            {
                Set clone = (SetListBox.SelectedItem as SetViewModel).GetClone();
                sets.Add(clone);
                setsVM.Add(new SetViewModel(clone));
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (SetListBox.SelectedIndex >= 0)
            {
                sets.RemoveAt(SetListBox.SelectedIndex);
                setsVM.RemoveAt(SetListBox.SelectedIndex);
            }
        }

        private void SetDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openNewTab(SetListBox.SelectedIndex);
        }

        private void openNewTab(int index)
        {
            var set = sets[index];
            CloseableTab theTabItem = new CloseableTab();
            SetTabControl.Items.Add(theTabItem);
            theTabItem.Content = new ArsenalItem();
            SetViewModel vm = setsVM[index];
            theTabItem.DataContext = vm;
            theTabItem.Focus();
        }

        private void ImportCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("command.txt"))
                {
                    String text = sr.ReadToEnd();
                    Clipboard.SetText(text);
                    MessageBox.Show("Now go to the ArmA and paste the command into script window to execute it.\n After executing command go back to program folder and paste (ctrl+v) clipboard's content to test.txt\n Afterwards do File->Open");
                }
            }
            catch (Exception)
            {
            }
        }

        private void ExportCommand(object sender, RoutedEventArgs e)
        {
            string result = "profileNamespace setVariable [ \"bis_fnc_saveInventory_data\",[";
            for(int i = 0;i < sets.Count; ++i)
            {
                var set = sets[i];
                result += set.toArmaArray();
                if (i != sets.Count - 1)
                    result += ",\n";
            }
            result += "]]";
            Clipboard.SetText(result);
            MessageBox.Show("Now go to Arma and execute command from clipboard");
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("test.txt"))
                {
                    String text = sr.ReadToEnd();
                    BraceContent brace = BraceContent.Parse(text);

                    for (int i = 0; i < brace.Count() ; i += 2)
                    {
                        sets.Add(new Set(brace[i ], brace[i + 1]));
                        setsVM.Add(new SetViewModel(sets[i / 2]));
                    }

                    SetListBox.ItemsSource = setsVM;

                }
            }
            catch (Exception)
            {
            }
        }

        

        

        
    }
}
