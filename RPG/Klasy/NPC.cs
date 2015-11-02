using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class NPC
    {
        public string Nazwa { get; set; }
        public string ObrazekMowienia { get; set; }
        public string ObrazekNaMapie { get; set; }
        public string ObrazekWalki { get; set; }
                               
        //statystyki bazowe    
        public int Sila{ get; set; }
        public int Zrecznosc{ get; set; }
        public int Witalnosc{ get; set; }
        public int Inteligencja { get; set; }
        public int BazoweObrazenia { get; set; }
        public int BazowyPancerz { get; set; }
        public int BazoweHP { get; set; }
        public int BazowaEnergia { get; set; }
        public int BazowaSzansaNaTrafienie { get; set; }
        public int BazowaSzansaNaKrytyczne { get; set; }

        public int Obrazenia { get; set; }
        public int Pancerz { get; set; }
        public int HP { get; set; }
        public int Energia { get; set; }
        public int SzansaNaTrafienie { get; set; }
        public int SzansaNaKrytyczne { get; set; }

        public int SumaPunktow { get; set; }
        public int Poziom { get; set; }
        public int ZlotoZaZabicie { get; set; }
        public int DoswiadczenieZaZabicie { get; set; }


        public NPC()
        {
            Nazwa = "Gracz";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/2/";
            ObrazekWalki = "Resources/Grafiki postaci walczących/szczur.png";
            Sila = 10;
            Zrecznosc = 10;
            Witalnosc = 10;
            Inteligencja = 10;
            BazoweObrazenia = 10;
            BazowyPancerz = 10;
            BazoweHP = 10;
            BazowaEnergia = 10;
            BazowaSzansaNaTrafienie = 75;
            BazowaSzansaNaKrytyczne = 5;

            Obrazenia = BazoweObrazenia + Sila / 5;
            Pancerz = BazowyPancerz + Zrecznosc / 5;
            HP = BazoweHP + Witalnosc*5;
            Energia = BazowaEnergia + Inteligencja*5;
            SzansaNaTrafienie = BazowaSzansaNaTrafienie + Zrecznosc/5;
            SzansaNaKrytyczne = BazowaSzansaNaKrytyczne + Zrecznosc / 5;

            SumaPunktow = Sila + Zrecznosc + Witalnosc + Inteligencja;
            Poziom = SumaPunktow/4;
            Random Losowanie = new Random();
            ZlotoZaZabicie = Losowanie.Next(50,150)/100*SumaPunktow;
            DoswiadczenieZaZabicie = SumaPunktow;
        }

        public NPC(String nazwa, String obrazekMowienia, String obrazekNaMapie, String obrazekWalki, int sila, int zrecznosc, int witalnosc, int inteligencja, int bazoweObrazenia, int bazowyPancerz, int bazoweHP, int bazowaEnergia, int bazowaSzansaNaTrafienie, int bazowaSzansaNaKrytyczne)
        {
            Nazwa = nazwa;
            ObrazekMowienia = obrazekMowienia;
            ObrazekNaMapie = obrazekNaMapie;
            ObrazekWalki = obrazekWalki;

            Sila = sila;
            Zrecznosc = zrecznosc;
            Witalnosc = witalnosc;
            Inteligencja = inteligencja;
            BazoweObrazenia = bazoweObrazenia;
            BazowyPancerz = bazowyPancerz;
            BazoweHP = bazoweHP;
            BazowaEnergia = bazowaEnergia;
            BazowaSzansaNaTrafienie = bazowaSzansaNaTrafienie;
            BazowaSzansaNaKrytyczne = bazowaSzansaNaKrytyczne;

            Obrazenia = BazoweObrazenia + Sila / 5;
            Pancerz = BazowyPancerz + Zrecznosc / 5;
            HP = BazoweHP + Witalnosc * 5;
            Energia = BazowaEnergia + Inteligencja * 5;
            SzansaNaTrafienie = BazowaSzansaNaTrafienie + Zrecznosc / 5;
            SzansaNaKrytyczne = BazowaSzansaNaKrytyczne + Zrecznosc / 5;

            SumaPunktow = Sila + Zrecznosc + Witalnosc + Inteligencja;
            Poziom = SumaPunktow / 4;
            Random Losowanie = new Random();
            ZlotoZaZabicie = Losowanie.Next(50, 150) / 100 * SumaPunktow;
            DoswiadczenieZaZabicie = SumaPunktow;
        }
    }
}
