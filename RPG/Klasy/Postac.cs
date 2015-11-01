using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Postac
    {
        public string nazwa;

        int punkty;

        int sila;
        int zrecznosc;
        int witalnosc;
        int inteligencja;
        

        
        public Postac(string _nazwa)
        {
            nazwa = _nazwa;
        }

        public int Sila
        {
            get
            {
                return sila;
            }
            set
            {
                sila = value;
            }
        }


        public int Zrecznosc
        {
            get
            {
                return zrecznosc;
            }
            set
            {
                zrecznosc = value;
            }
        }

        public int Witalnosc
        {
            get
            {
                return witalnosc;
            }
            set
            {
                witalnosc = value;
            }
        }

        public int Inteligencja
        {
            get
            {
                return inteligencja;
            }
            set
            {
                inteligencja = value;
            }
        }

        public int Punkty
        {
            get
            {
                return punkty;
            }
            set
            {
                punkty = value;
            }
        }
    }
}
