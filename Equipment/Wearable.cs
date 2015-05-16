using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Equipment
{
    public class Wearable
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

        protected Wearable()
        { }

        public static Wearable Parse(string s)
        {
            Uniform wear = new Uniform();

            s = s.Substring(1, s.Length - 3);

            s = s.Replace("[", "");
            s = s.Replace("\"", "");

            List<string> list = s.Split(',').ToList();

            wear.Name = list[0];

            for (int i = 1; i < list.Count; ++i )
            {
                int id = wear.Contents.FindIndex(x => x.Name == list[i]);
                if(id != -1)
                    wear.Contents[id].Quanity++;
                else
                    wear.Contents.Add( new ItemStack(list[i]));
            }

           return wear;
        }

        public static bool TryParse(string s, out Wearable result)
        {
            if (!CanParse(s))
            {
                result = null;
                return false;
            }

            result = Parse(s);
            return true;
        }

        protected static bool CanParse(string s)
        {
            if (!s.StartsWith("[") || !s.EndsWith("]"))
            {
                return false;
            }
            return false;
        }
    }
}
