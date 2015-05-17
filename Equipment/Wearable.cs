using Arsenal.Brace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Equipment
{
    public class Wearable :ICloneable
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private List<ItemStack> _Contents = new List<ItemStack>();

        public List<ItemStack> Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }

        public Wearable(BraceContent b)
        {
            Name = b[0].Name;

            foreach (var item in b[1])
            {
                int id = Contents.FindIndex(x => x.Name == item.Name);
                if (id != -1)
                    Contents[id].Quanity++;
                else
                    Contents.Add(new ItemStack(item.Name));
            }
        }

        private Wearable()
        {}

        public string toArmaArray()
        {
            string result = "[" + quote(Name) + ",[";
            for (int j = 0; j < Contents.Count; j++ )
            {
                var item = Contents[j];
                for (int i = 0; i < item.Quanity; i++)
                {
                    
                    result += quote(item.Name);
                    if (i != item.Quanity - 1 || j != Contents.Count - 1)
                        result += ",";
                }
            }
            result += "]]";
            return result;

        }

        protected string quote(string what)
        {
            return "\"" + what + "\"";
        }
    
        public object Clone()
        {
 	        Wearable wear = new Wearable();
            wear.Name = Name;
            List<ItemStack> clonedContents = new List<ItemStack>(Contents.Count);

            Contents.ForEach((item) =>
                {
                    clonedContents.Add(item.Clone() as ItemStack);
                });
            wear.Contents = clonedContents;
            return wear;
        }
}
}
