using Arsenal.Brace;
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

        private Weapon _MainWeapon;
        private Weapon _SecondWeapon;
        private Weapon _HandWeapon;

        private string _Map;
        private string _Compass;
        private string _Watch;
        private string _GPS;

        private string _Head;
        private string _Voice;
        private string _MysteriousProperty = "";
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
            get { return _Binocular; }
            set { _Binocular = value; }
        }
        public Weapon MainWeapon
        {
            get { return _MainWeapon; }
            set { _MainWeapon = value; }
        }
        public Weapon SecondWeapon
        {
            get { return _SecondWeapon; }
            set { _SecondWeapon = value; }
        }
        public Weapon HandWeapon
        {
            get { return _HandWeapon; }
            set { _HandWeapon = value; }
        }
        public string Map
        {
            get { return _Map; }
            set { _Map = value; }
        }
        public string Compass
        {
            get { return _Compass; }
            set { _Compass = value; }
        }

        public string Watch
        {
            get { return _Watch; }
            set { _Watch = value; }
        }
        public string GPS
        {
            get { return _GPS; }
            set { _GPS = value; }
        }
        public string Head
        {
            get { return _Head; }
            set { _Head = value; }
        }

        public string Voice
        {
            get { return _Voice; }
            set { _Voice = value; }
        }
        public string MysteriousProperty
        {
            get { return _MysteriousProperty; }
            set { _MysteriousProperty = value; }
        }

        
        #endregion //Properties

        public Set(BraceContent name, BraceContent content)
        {
            Name = name.Name;
            Uniform = new Wearable(content[0]);
            Vest = new Wearable(content[1]);
            Backpack = new Wearable(content[2]);

            Cap = content[3].Name;
            Glass = content[4].Name;
            Binocular = content[5].Name;

            MainWeapon = new Weapon(content[6]);
            SecondWeapon = new Weapon(content[7]);
            HandWeapon = new Weapon(content[8]);

            Map = content[9][0].Name;
            Compass = content[9][1].Name;
            Watch = content[9][2].Name;
            GPS = content[9][3].Name;

            Head = content[10][0].Name;
            Voice = content[10][1].Name;
            MysteriousProperty = content[10][2].Name;
        }


        public string toArmaArray()
        {
            string result = 
                quote(Name) + ",[" +
                Uniform.toArmaArray() + "," +
                Vest.toArmaArray() + "," +
                Backpack.toArmaArray() + "," +
                quote(Cap) + "," + 
                quote(Glass) + "," +
                quote(Binocular) + "," +
                MainWeapon.toArmaArray() + "," +
                SecondWeapon.toArmaArray() + "," +
                HandWeapon.toArmaArray() + "," +
                "[" +
                quote(Map) + "," +
                quote(Compass) + "," +
                quote(Watch) + "," +
                quote(GPS) + "]" +
                "," +
                "[" +
                quote(Head) + "," +
                quote(Voice) + "," +
                quote(MysteriousProperty) + "]]";
                

            return result;

        }

        protected string quote(string what)
        {
            return "\"" + what + "\"";
        }



    }
}
