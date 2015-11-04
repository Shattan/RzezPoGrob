using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Bohater
    {     
        public string Nazwa { get; set; }
        public string ObrazekNaMapie { get; set; }
        public string ObrazekMowienia { get; set; }
        public int Poziom { get; set; }
        public int Doswiadczenie { get; set; }
        public int Punkty{ get; set; }
        public int Zloto { get; set; }
                               
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

        public int DoswiadczenieDoNastepnegoPoziomu { get { return 1000 * Poziom * Poziom; ;} }
        public int Obrazenia { get { return BazoweObrazenia + Sila / 5; } }
        public int Pancerz { get { return BazowyPancerz + Zrecznosc / 5; } }
        public int HP { get { return BazoweHP + Witalnosc * 5; } }
        public int Energia { get { return BazowaEnergia + Inteligencja * 5; } }
        public int SzansaNaTrafienie { get { return BazowaSzansaNaTrafienie + Zrecznosc / 10; } }
        public int SzansaNaKrytyczne { get { return BazowaSzansaNaKrytyczne + Zrecznosc / 10; } }

        
        public Bohater()
        {
            Nazwa = "Gracz";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/0/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";

            Poziom = 1;
            Doswiadczenie = 0;
            Punkty = 10;
            Zloto = 100;
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
            /*
            Obrazenia = BazoweObrazenia + Sila / 5;
            Pancerz = BazowyPancerz + Zrecznosc / 5;
            HP = BazoweHP + Witalnosc*5;
            Energia = BazowaEnergia + Inteligencja*5;
            SzansaNaTrafienie = BazowaSzansaNaTrafienie + Zrecznosc/5;
            SzansaNaKrytyczne = BazowaSzansaNaKrytyczne + Zrecznosc/5;

            DoswiadczenieDoNastepnegoPoziomu = 1000 * Poziom * Poziom;*/
        }
        public Bohater(Bohater nowyBohater)
        {
            this.Nazwa = nowyBohater.Nazwa;
            this.ObrazekNaMapie = nowyBohater.ObrazekNaMapie;
            this.ObrazekMowienia = nowyBohater.ObrazekMowienia;
            this.Poziom = nowyBohater.Poziom;
            this.Doswiadczenie = nowyBohater.Doswiadczenie;
            this.Punkty = nowyBohater.Punkty;
            this.Zloto = nowyBohater.Zloto;
            this.Sila = nowyBohater.Sila;
            this.Zrecznosc = nowyBohater.Zrecznosc;
            this.Witalnosc = nowyBohater.Witalnosc;
            this.Inteligencja = nowyBohater.Inteligencja;
            this.BazoweObrazenia = nowyBohater.BazoweObrazenia;
            this.BazowyPancerz = nowyBohater.BazowyPancerz;
            this.BazoweHP = nowyBohater.BazoweHP;
            this.BazowaEnergia = nowyBohater.BazowaEnergia;
            this.BazowaSzansaNaTrafienie = nowyBohater.BazowaSzansaNaTrafienie;
            this.BazowaSzansaNaKrytyczne = nowyBohater.BazowaSzansaNaKrytyczne;
            }
    }

}
