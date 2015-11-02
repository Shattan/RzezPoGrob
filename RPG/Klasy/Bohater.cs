using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Bohater
    {     
        string nazwa;
        string obrazek;
        int punkty;

        //statystyki bazowe
        int sila;
        int zrecznosc;
        int witalnosc;
        int inteligencja;
        
        public Bohater(string _nazwa)
        {
            nazwa = _nazwa;
            obrazek = "Resources/Grafiki postaci na mapie/2/";

            punkty = 10;
            sila = 10;
            zrecznosc = 10;
            witalnosc = 10;
            inteligencja = 10;
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

        public String Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                nazwa = value;
            }
        }

        public String Obrazek
        {
            get
            {
                return obrazek;
            }
            set
            {
                obrazek = value;
            }
        }
    }

}
