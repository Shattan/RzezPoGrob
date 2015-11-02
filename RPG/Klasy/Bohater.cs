﻿using System;
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
        public int DoswiadczenieDoNastepnegoPoziomu { get; set; }
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

        public int Obrazenia { get; set; }
        public int Pancerz { get; set; }
        public int HP { get; set; }
        public int Energia { get; set; }
        public int SzansaNaTrafienie { get; set; }
        public int SzansaNaKrytyczne { get; set; }

        
        public Bohater()
        {
            Nazwa = "Gracz";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/2/";
            ObrazekMowienia = "Resources/Grafiki postaci na mapie/2/dół.png";

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

            Obrazenia = BazoweObrazenia + Sila / 5;
            Pancerz = BazowyPancerz + Zrecznosc / 5;
            HP = BazoweHP + Witalnosc*5;
            Energia = BazowaEnergia + Inteligencja*5;
            SzansaNaTrafienie = BazowaSzansaNaTrafienie + Zrecznosc/5;
            SzansaNaKrytyczne = BazowaSzansaNaKrytyczne + Zrecznosc/5;

            DoswiadczenieDoNastepnegoPoziomu = 1000 * Poziom * Poziom;
        }

        public void OdswiezStatystyki()
        {
            Obrazenia = BazoweObrazenia + Sila / 5;
            Pancerz = BazowyPancerz + Zrecznosc / 5;
            HP = BazoweHP + Witalnosc * 5;
            Energia = BazowaEnergia + Inteligencja * 5;
            SzansaNaTrafienie = BazowaSzansaNaTrafienie + Zrecznosc / 5;
            SzansaNaKrytyczne = BazowaSzansaNaKrytyczne + Zrecznosc / 5;

            DoswiadczenieDoNastepnegoPoziomu = 1000 * Poziom * Poziom;
        }
    }

}
