using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Ekwipunek
    {
        public string Obrazek { get; set; }
        public string Nazwa { get; set; }
        public int Sila { get; set; }
        public int zrecznosc { get; set; }
        public int Witalnosc { get; set; }
        public int Inteligencja { get; set; }
        public int Obrazenia { get; set; }
        public int Pancerz { get; set; }
        public int HP { get; set; }
        public int Energia { get; set; }
        public int SzansaNaTrafienie { get; set; }
        public int SzansaNaKrytyczne { get; set; }
        
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
                    + zrecznosc * przemnoznikStatystyk
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

        public Ekwipunek(string _nazwa, string _obrazek, int _sila, int _zrecznosc, int _witalnosc, int _inteligencja, int _obrazenia, int _pancerz, int _hp, int _energia, int _szansaNaTrafienie, int _szansaNaKrytyczne)
        {
            Nazwa = _nazwa;
            Obrazek = _obrazek;
            Sila = _sila;
            zrecznosc = _zrecznosc;
            Witalnosc = _witalnosc;
            Inteligencja = _inteligencja;
            Obrazenia = _obrazenia;
            Pancerz = _pancerz;
            HP = _hp;
            Energia = _energia;
            SzansaNaTrafienie = _szansaNaTrafienie;
            SzansaNaKrytyczne = _szansaNaKrytyczne;
        }
    }
}
