using Arsenal.Brace;
using Arsenal.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Arsenal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            

            string parseFile = "";

            try
            {
                using (StreamReader sr = new StreamReader("test.txt"))
                {
                    parseFile = sr.ReadToEnd();
                }
            }
            catch (Exception) { }


            
            BraceContent test;
             test = BraceContent.Parse(parseFile);
             Set set = new Set(test[0], test[1]);
             string str = set.toArmaArray();
             Clipboard.SetText(str);
            InitializeComponent();

        }
    }
}
