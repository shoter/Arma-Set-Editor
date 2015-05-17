using Arsenal.Equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.ViewModel
{
    public class WeaponViewModel : ViewModelBase
    {
        protected Weapon Weapon;

        public string Name
        {
            get { return Weapon.Name; }
            set
            {
                Weapon.Name = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> _Attachments = new ObservableCollection<string>();

        public ObservableCollection<string> Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }
        
        public string Magazine
        {
            get { return Weapon.Magazine; }
            set
            {
                Weapon.Magazine = value;
                OnPropertyChanged();
            }
        }

        public WeaponViewModel(Weapon Weapon)
        {
            this.Weapon = Weapon;
            foreach (var att in Weapon.Attachments)
            {
                Attachments.Add(att);
            }
        }
    }
}
