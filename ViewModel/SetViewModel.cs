using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Arsenal.Equipment;

namespace Arsenal.ViewModel
{
    class SetViewModel : ViewModelBase
    {
        protected Set Set;

        public WearableViewModel Uniform { get; set; }

        public WearableViewModel Vest { get; set; }

        public WearableViewModel Backpack { get; set; }

        public WeaponViewModel MainWeapon { get; set; }

        public WeaponViewModel SecondWeapon { get; set; }

        public WeaponViewModel HandWeapon { get; set; }

        public string Name
        {
            get { return Set.Name; }
            set
            {
                Set.Name = value;
                OnPropertyChanged();
            }
        }
        public string Cap
        {
            get { return Set.Cap; }
            set { Set.Cap = value; }
        }
        public string Glass
        {
            get { return Set.Glass; }
            set { Set.Glass = value; }
        }
        public string Binocular
        {
            get { return Set.Binocular; }
            set { Set.Binocular = value; }
        }
        public string Map
        {
            get { return Set.Map; }
            set { Set.Map = value; }
        }
        public string Compass
        {
            get { return Set.Compass; }
            set { Set.Compass = value; }
        }
        public string Watch
        {
            get { return Set.Watch; }
            set { Set.Watch = value; }
        }
        public string GPS
        {
            get { return Set.GPS; }
            set { Set.GPS = value; }
        }
        public string Head
        {
            get { return Set.Head; }
            set { Set.Head = value; }
        }
        public string Voice
        {
            get { return Set.Voice; }
            set { Set.Voice = value; }
        }
        public string MysteriousProperty
        {
            get { return Set.MysteriousProperty; }
            set { Set.MysteriousProperty = value; }
        }

        public Color Color
        {
            get { return Set.Color; }
            set { Set.Color = value; }
        }

        public SolidColorBrush SolidColorBrush
        {
            get { return Set.SolidColorBrush; }
        }

        public byte R
        {
            get { return Set.Color.R; }
            set
            {
                Set.Color = Color.FromArgb(Set.Color.A, value, Set.Color.G, Set.Color.B);
                OnPropertyChanged("Color");
                OnPropertyChanged("SolidColorBrush");
                OnPropertyChanged();
            }
        }
        public byte G
        {
            get { return Set.Color.G; }
            set
            {
                Set.Color = Color.FromArgb(Set.Color.A, Set.Color.R, value, Set.Color.B);
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("SolidColorBrush");
            }
        }
        public byte B
        {
            get { return Set.Color.B; }
            set
            {
                Set.Color = Color.FromArgb(Set.Color.A, Set.Color.R, Set.Color.G, value);
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("SolidColorBrush");
            }
        }
        public byte A
        {
            get { return Set.Color.A; }
            set
            {
                Set.Color = Color.FromArgb(value, Set.Color.R, Set.Color.G, Set.Color.B);
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("SolidColorBrush");
            }
        }


        public SetViewModel(Set Set)
        {
            this.Set = Set;
            Uniform = new WearableViewModel(Set.Uniform);
            Vest = new WearableViewModel(Set.Vest);
            Backpack = new WearableViewModel(Set.Backpack);

            MainWeapon = new WeaponViewModel(Set.MainWeapon);
            SecondWeapon = new WeaponViewModel(Set.SecondWeapon);
            HandWeapon = new WeaponViewModel(Set.HandWeapon);
        }


        public Set GetClone()
        {
            return Set.Clone() as Set;
        }


        
    }
}
