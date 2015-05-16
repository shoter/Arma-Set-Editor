using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Equipment
{
    public class ItemStack
    {
        public int Quanity;
        public string Name;

        public ItemStack(string name, int quanity = 1)
        {
            Name = name;
            Quanity = quanity;
        }

        public override string ToString()
        {
            return Name + " - " + Quanity.ToString();
        }
    }
}
