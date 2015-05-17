using Arsenal.Brace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Equipment
{
    public class Weapon : ICloneable
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private List<string> _Attachments = new List<string>();

        public List<string> Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }

        private string _Magazine;

        public string Magazine
        {
            get { return _Magazine; }
            set { _Magazine = value; }
        }
        public Weapon(BraceContent b)
        {
            Name = b[0].Name;

            foreach (var item in b[1])
            {
                Attachments.Add(item.Name);
            }

            Magazine = b[2].Name;
        }

        private Weapon()
        { }

        public string toArmaArray()
        {
            string result = "[" + quote(Name) + ",[";
            for (int i = 0; i < Attachments.Count; ++i )
            {
                result += quote(Attachments[i]);
                if (i != Attachments.Count - 1)
                    result += ",";

            }
            result += "],";
            result += quote(Magazine);
            result += "]";
            return result;

        }

        protected string quote(string what)
        {
            return "\"" + what + "\"";
        }

        public object Clone()
        {
            Weapon wep = new Weapon();
            wep.Name = Name;
            wep.Magazine = Magazine;
            Attachments = new List<string>(Attachments);
            return wep;
        }
    }
}
