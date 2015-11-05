using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gracz
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

        public Ekwipunek obecnaBronGracza { get; set; }
        public Ekwipunek obecnyPancerzGracza { get; set; }
        public Ekwipunek obecnaTarczaGracza { get; set; }

        public List<Ekwipunek> plecakGracza {get;set;}
        public List<Zadanie> zadaniaGracza {get;set;}



        public Gracz()
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

            obecnaBronGracza = new Ekwipunek("Nóż do masła", "Resources/Grafiki ekwipunku/bron1hNóż do masła.png", 1, 1, 0, 0, 1, 0, 0, 0, 0, 0);
            obecnyPancerzGracza = new Ekwipunek("Stara tunika", "Resources/Grafiki ekwipunku/pancerzStara tunika.png", 0, 0, 1, 0, 0, 1, 5, 0, 0, 0);
            obecnaTarczaGracza = new Ekwipunek("Pochodnia", "Resources/Grafiki ekwipunku/tarczaPochodnia.png", 0, 0, 0, 1, 0, 0, 0, 5, 1, 0);

            plecakGracza = new List<Ekwipunek>();
            zadaniaGracza = new List<Zadanie>();
        }
        public Gracz(Gracz nowyBohater)
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


            this.obecnaBronGracza = obecnaBronGracza;
            this.obecnyPancerzGracza = obecnyPancerzGracza;
            this.obecnaTarczaGracza = obecnaTarczaGracza;

            this.plecakGracza = nowyBohater.plecakGracza;
            this.zadaniaGracza = nowyBohater.zadaniaGracza;
        }
    }

}
