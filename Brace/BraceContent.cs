using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Brace
{
    public class BraceContent : IEnumerable<BraceContent>
    {
        List<BraceContent> Childrens = new List<BraceContent>();
        BraceContent Parent;
        public bool IsContainer = false;

        public int Count
        {
            get { return Childrens.Count; }
        }
        public BraceContent this[int i]
        {
            get { return Childrens[i]; }
            set { Childrens[i] = value; }
        }

        BraceContent(string Name = "", BraceContent Parent = null)
        {
            this.Parent = Parent;
                if(Parent != null)
                {
                    Parent.Childrens.Add(this);
                }
            this.Name = Name;
        }

        public string Name;

        public override string ToString()
        {
            if(!IsContainer)
                return Name;
            else
            {
                string result = "[";
                for (int i = 0; i < Childrens.Count; ++i )
                {
                    var child = Childrens[i];
                    result += child.ToString();
                    if(i != Childrens.Count -1)
                        result += ",";
                }
                result += "]";
                return result;
            }
        }

        [DebuggerStepThrough]
        public static BraceContent Parse(string s)
        {
            BraceContent root = new BraceContent("Root");
            root.IsContainer = true;
            BraceContent current = root;
            string temp = "";
            bool isParsing = false;
            int size = s.Count();
            for (int i = 1; i < size; ++i)
            {
                if (s[i] == ',' || (Char.IsWhiteSpace(s[i]) && isParsing == false)) continue;

                if(s[i] == '\"')
                {
                    if(!isParsing)
                        isParsing = true;
                    else
                    {
                        isParsing = false;
                        current.Childrens.Add(new BraceContent(temp));
                        temp = "";
                    }
                } else if(isParsing)
                {
                    temp += s[i];
                } 
                else if(s[i] == '[')  
                {
                    current = new BraceContent("", current);
                    current.IsContainer = true;
                }
                else if (s[i] == ']')
                {
                    current = current.Parent;
                } 
                
            }

            return root;
        }

        // For IEnumerable<Car>
        public IEnumerator<BraceContent> GetEnumerator() { return Childrens.GetEnumerator(); }

        // For IEnumerable
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
