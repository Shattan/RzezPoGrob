using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Umiejetnosc
    {
        public String Nazwa { get; set; }
        public String ObrazekPrzycisku { get; set; }
        public String ObrazekWWalce { get; set; } 
        public String WymaganyTypPrzedmiotu{ get; set; } 
        public String GlownaStatystyka{ get; set; }
        public int WymaganaSila{ get; set; } 
        public int WymaganaZrecznosc{ get; set; } 
        public int WymaganaWitalnosc{ get; set; } 
        public int WymaganaInteligencja{ get; set; }
        public int IloscTur { get; set; }
        public double Obrazenia{ get; set; } 
        public double ObrazeniaNaTure{ get; set; }
        public double KosztEnergii { get; set; }
        public bool RedukowanePrzezPancerz { get; set; }
        public bool Ogluszanie { get; set; } 
        public bool Krwawienie { get; set; }
        public bool Podpalenie { get; set; }
        public bool Zatrucie { get; set; }


        public Umiejetnosc()
        {
            Nazwa = "Umiejętność nieprzypisana";
            ObrazekPrzycisku = "Resources/Grafiki przycisków umiejętności/Przykładowy przycisk.png";
            ObrazekWWalce = "Resources/Grafiki umiejętności/Eksplozja.png";
            WymaganyTypPrzedmiotu = "Brak";
            GlownaStatystyka = "Brak";
            WymaganaSila = 0;
            WymaganaZrecznosc = 0;
            WymaganaWitalnosc = 0;
            WymaganaInteligencja = 0;
            IloscTur = 0;
            Obrazenia = 1;
            ObrazeniaNaTure = 0;
            KosztEnergii = 1;
            RedukowanePrzezPancerz = false;
            Ogluszanie = false;
            Krwawienie = false;
            Podpalenie = false;
            Zatrucie = false;
        }

        public Umiejetnosc(string nazwa, string obrazekPrzycisku, string obrazekWWalce, string wymaganyTypPrzedmiotu, string glownaStatystyka, int wymaganaSila, int wymaganaZrecznosc, int wymaganaWitalnosc, int wymaganaInteligencja, int iloscTur, double obrazenia, double obrazeniaNaTure, double kosztEnergii, bool redukowanePrzezPancerz, bool ogluszanie, bool krwawienie, bool podpalenie, bool zatrucie)
        {
            Nazwa = nazwa;
            ObrazekPrzycisku = obrazekPrzycisku;
            ObrazekWWalce = ObrazekWWalce;
            WymaganyTypPrzedmiotu = wymaganyTypPrzedmiotu;
            GlownaStatystyka = glownaStatystyka;
            WymaganaSila = wymaganaSila;
            WymaganaZrecznosc = wymaganaZrecznosc;
            WymaganaWitalnosc = wymaganaWitalnosc;
            WymaganaInteligencja = wymaganaInteligencja;
            IloscTur = iloscTur;
            Obrazenia = obrazenia;
            ObrazeniaNaTure = obrazeniaNaTure;
            KosztEnergii = kosztEnergii;
            RedukowanePrzezPancerz = redukowanePrzezPancerz;
            Ogluszanie = ogluszanie;
            Krwawienie = krwawienie;
            Podpalenie = podpalenie;
            Zatrucie = zatrucie;
        }

        public Umiejetnosc(Umiejetnosc kopiowanaUmiejetnosc)
        {
            Nazwa = kopiowanaUmiejetnosc.Nazwa;
            ObrazekPrzycisku = kopiowanaUmiejetnosc.ObrazekPrzycisku;
            ObrazekWWalce = kopiowanaUmiejetnosc.ObrazekWWalce;
            WymaganyTypPrzedmiotu = kopiowanaUmiejetnosc.WymaganyTypPrzedmiotu;
            GlownaStatystyka = kopiowanaUmiejetnosc.GlownaStatystyka;
            WymaganaSila = kopiowanaUmiejetnosc.WymaganaSila;
            WymaganaZrecznosc = kopiowanaUmiejetnosc.WymaganaZrecznosc;
            WymaganaWitalnosc = kopiowanaUmiejetnosc.WymaganaWitalnosc;
            WymaganaInteligencja = kopiowanaUmiejetnosc.WymaganaInteligencja;
            IloscTur = kopiowanaUmiejetnosc.IloscTur;
            Obrazenia = kopiowanaUmiejetnosc.Obrazenia;
            ObrazeniaNaTure = kopiowanaUmiejetnosc.ObrazeniaNaTure;
            KosztEnergii = kopiowanaUmiejetnosc.KosztEnergii;
            RedukowanePrzezPancerz = kopiowanaUmiejetnosc.RedukowanePrzezPancerz;
            Ogluszanie = kopiowanaUmiejetnosc.Ogluszanie;
            Krwawienie = kopiowanaUmiejetnosc.Krwawienie;
            Podpalenie = kopiowanaUmiejetnosc.Podpalenie;
            Zatrucie = kopiowanaUmiejetnosc.Zatrucie;
        }
    }
}
