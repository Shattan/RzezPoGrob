using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Postac
    {
        public string Nazwa { get; set; }
        public int Zloto { get; set; }

        public string ObrazekNaMapie { get; set; }
        public string ObrazekMowienia { get; set; }
        public string ObrazekWalki { get; set; }
        public int iloscPunktowDoRozdaniaCoPoziom { get { return 4; } }

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

        public int SumaStatystykPodstawowych { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }

        public List<Umiejetnosc> UmiejetnosciFizyczne { get; set; }
        public List<Umiejetnosc> UmiejetnosciMagiczne { get; set; }

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
