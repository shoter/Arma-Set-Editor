using Arsenal.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.ViewModel
{
    public class ItemStackViewModel : ViewModelBase
    {
        protected ItemStack ItemStack;

        public string Name
        {
            get { return ItemStack.Name; }
            set
            {
                ItemStack.Name = value;
                OnPropertyChanged();
            }
        }

        public int Quanity
        {
            get { return ItemStack.Quanity; }
            set
            {
                ItemStack.Quanity = value;
                OnPropertyChanged();
            }
        }

        public ItemStackViewModel(ItemStack itemStack)
        {
            this.ItemStack = itemStack;
        }
    }
}
