using Arsenal.Equipment;
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

namespace Arsenal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string parse = "[\"U_cosa_uniform_multicam_g3_l9\",[\"RH_SFM952V_tan\",\"rhs_mag_mk84\",\"rhs_mag_mk84\",\"rhs_mag_mk84\",\"rhs_mag_mk84\",\"rhs_mag_m67\",\"rhs_mag_m67\",\"rhs_mag_m67\",\"rhs_mag_m67\",\"SmokeShell\",\"SmokeShell\",\"SmokeShell\",\"SmokeShell\",\"Chemlight_green\",\"Chemlight_green\",\"Chemlight_red\",\"Chemlight_red\",\"Chemlight_yellow\",\"Chemlight_yellow\",\"Chemlight_blue\",\"Chemlight_blue\"]]";

            Wearable wear = Wearable.Parse(parse);
            int a = 3;
            int b = 4;

        }
    }
}
