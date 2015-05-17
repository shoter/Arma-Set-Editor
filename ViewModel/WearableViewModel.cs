using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arsenal.Equipment;

namespace Arsenal.ViewModel
{
    public class WearableViewModel : ViewModelBase
    {
        protected Wearable Wearable;

        public ObservableCollection<ItemStackViewModel> _ItemStack = new ObservableCollection<ItemStackViewModel>();
        public ObservableCollection<ItemStackViewModel> ItemStack
        {
            get
            {
                return _ItemStack;
            }
            set
            {
                _ItemStack = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return Wearable.Name; }
            set { Wearable.Name = value; OnPropertyChanged(); }
        }
        

        public WearableViewModel(Wearable Wearable)
        {
            this.Wearable = Wearable;
            foreach (ItemStack stack in Wearable.Contents)
            {
                ItemStack.Add( new ItemStackViewModel(stack));
            }
        }

        public void AddItem(ItemStack item)
        {
            Wearable.Contents.Add(item);
            ItemStack.Add(new ItemStackViewModel(item));
        }
    }
}
