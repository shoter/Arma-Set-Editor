using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsenal.Equipment
{
    class Set
    {
        private string _Name;
        private Wearable _Uniform;
        private Wearable _Backpack;
        private Wearable _Vest;

        private string _Cap;
        private string _Glass;
        private string _Binocular;

        #region Properties
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public Wearable Uniform
        {
            get { return _Uniform; }
            set { _Uniform = value; }
        }
        public Wearable Vest
        {
            get { return _Vest; }
            set { _Vest = value; }
        }
        public Wearable Backpack
        {
            get { return _Backpack; }
            set { _Backpack = value; }
        }
        public string Cap
        {
            get { return _Cap; }
            set { _Cap = value; }
        }
        public string Glass
        {
            get { return _Glass; }
            set { _Glass = value; }
        }
        public string Binocular
        {
            get { return Binocular; }
            set { Binocular = value; }
        }

        #endregion //Properties





    }
}
