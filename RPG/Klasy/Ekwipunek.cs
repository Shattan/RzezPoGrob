using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Ekwipunek
    {
        public string Nazwa { get; set; }
        public string Obrazek { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Witalnosc { get; set; }
        public int Inteligencja { get; set; }
        public double Obrazenia { get; set; }
        public double Pancerz { get; set; }
        public double HP { get; set; }
        public double Energia { get; set; }
        public double SzansaNaTrafienie { get; set; }
        public double SzansaNaKrytyczne { get; set; }
        
        const double przemnoznikStatystyk = 5;
        const double przemnoznikCechEkwipunku = 2;
        const double przemnoznikHPIEnergii = 1;
        const double przemnoznikTrafieniaIKrytycznego = 20;

        public int Cena
        {
            get
            {
                return (int)(
                    Sila * przemnoznikStatystyk
                    + Zrecznosc * przemnoznikStatystyk
                    + Witalnosc * przemnoznikStatystyk
                    + Inteligencja * przemnoznikStatystyk
                    + Obrazenia * przemnoznikCechEkwipunku
                    + Pancerz * przemnoznikCechEkwipunku
                    + HP * przemnoznikHPIEnergii
                    + Energia * przemnoznikHPIEnergii
                    + SzansaNaTrafienie * przemnoznikTrafieniaIKrytycznego
                    + SzansaNaKrytyczne * przemnoznikTrafieniaIKrytycznego
                    );
            }
        }

        public Ekwipunek()
        {
            Nazwa = "Brak";
            Obrazek = null;
            Sila = 0;
            Zrecznosc = 0;
            Witalnosc = 0;
            Inteligencja = 0;
            Obrazenia = 0;
            Pancerz = 0;
            HP = 0;
            Energia = 0;
            SzansaNaTrafienie = 0;
            SzansaNaKrytyczne = 0;
        }

        public Ekwipunek(string _nazwa, string _obrazek, int _sila, int _zrecznosc, int _witalnosc, int _inteligencja, int _obrazenia, int _pancerz, int _hp, int _energia, int _szansaNaTrafienie, int _szansaNaKrytyczne)
        {
            Nazwa = _nazwa;
            Obrazek = _obrazek;
            Sila = _sila;
            Zrecznosc = _zrecznosc;
            Witalnosc = _witalnosc;
            Inteligencja = _inteligencja;
            Obrazenia = _obrazenia;
            Pancerz = _pancerz;
            HP = _hp;
            Energia = _energia;
            SzansaNaTrafienie = _szansaNaTrafienie;
            SzansaNaKrytyczne = _szansaNaKrytyczne;
        }

        public Ekwipunek(Ekwipunek kopiowanyEkwipunek)
        {
            this.Nazwa = kopiowanyEkwipunek.Nazwa;
            this.Obrazek = kopiowanyEkwipunek.Obrazek;
            this.Sila = kopiowanyEkwipunek.Sila;
            this.Zrecznosc = kopiowanyEkwipunek.Zrecznosc;
            this.Witalnosc = kopiowanyEkwipunek.Witalnosc;
            this.Inteligencja = kopiowanyEkwipunek.Inteligencja;
            this.Obrazenia = kopiowanyEkwipunek.Obrazenia;
            this.Pancerz = kopiowanyEkwipunek.Pancerz;
            this.HP = kopiowanyEkwipunek.HP;
            this.Energia = kopiowanyEkwipunek.Energia;
            this.SzansaNaTrafienie = kopiowanyEkwipunek.SzansaNaTrafienie;
            this.SzansaNaKrytyczne = kopiowanyEkwipunek.SzansaNaKrytyczne;
        }
    }
}
