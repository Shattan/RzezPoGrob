using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Postac
    {
        List<Umiejetnosc> umiejetnosciFizyczne = new List<Umiejetnosc>();
        List<Umiejetnosc> umiejetosciMagiczne = new List<Umiejetnosc>();
        protected Postac()
        {
            Nazwa = "Gracz nienazwany";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/0/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";
            
            Zloto = 1;
            SilaPodstawa = 1;
            ZrecznoscPodstawa = 1;
            WitalnoscPodstawa = 1;
            InteligencjaPodstawa = 1;
            ObrazeniaPodstawa = 1;
            PancerzPodstawa = 1;
            HPPodstawa = 1;
            EnergiaPodstawa = 1;
            SzansaNaTrafieniePodstawa = 1;
            SzansaNaKrytycznePodstawa = 1;
        }
        protected Postac(string nazwa,int zloto,string obrazekMapa,string obrazekMowienia,string obrazekWalka,int sila,int zrecznosc,int witalnosc,int inteligencja,
            double obrazenia,double pancerz,double hp,double energia,double trafinie,double krytyk)
        {
            Nazwa = nazwa;
            Zloto = zloto;
            ObrazekNaMapie = obrazekMapa;
            ObrazekMowienia = obrazekMowienia;
            ObrazekWalki = obrazekWalka;
            SilaPodstawa = sila;
            ZrecznoscPodstawa = zrecznosc;
            WitalnoscPodstawa = witalnosc;
            InteligencjaPodstawa = inteligencja;
            ObrazeniaPodstawa = obrazenia;
            PancerzPodstawa = pancerz;
            HPPodstawa = hp;
            EnergiaPodstawa = energia;
            SzansaNaTrafieniePodstawa = trafinie;
            SzansaNaKrytycznePodstawa = krytyk;

        }
        public string Nazwa { get; set; }
        public int Zloto { get; set; }

        public string ObrazekNaMapie { get; set; }
        public string ObrazekMowienia { get; set; }
        public string ObrazekWalki { get; set; }


        //statystyki bez przedmiotow    
        public int SilaPodstawa { get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public double ObrazeniaPodstawa { get; set; }
        public double PancerzPodstawa { get; set; }
        public double HPPodstawa { get; set; }
        public double EnergiaPodstawa { get; set; }
        public double SzansaNaTrafieniePodstawa { get; set; }
        public double SzansaNaKrytycznePodstawa { get; set; }


        public int iloscPunktowDoRozdaniaCoPoziom { get { return 4; } }

        public int SumaStatystykPodstawowych { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }

        public List<Umiejetnosc> UmiejetnosciFizyczne { get { return umiejetnosciFizyczne; } }
        public List<Umiejetnosc> UmiejetnosciMagiczne { get { return umiejetosciMagiczne; } }

        /// <summary>
        /// Całkowita siła
        /// </summary>

        public abstract int Sila { get ;} 
        public abstract int Zrecznosc { get ;} 
        public abstract int Witalnosc { get ;} 
        public abstract int Inteligencja { get ;} 
        public abstract double Obrazenia { get ;} 
        public abstract double Pancerz { get ;} 
        public abstract double HP{ get ;} 
        public abstract double Energia{ get ;} 
        public abstract double SzansaNaTrafienie{ get ;} 
        public abstract double SzansaNaKrytyczne { get ;} 


    }
}
