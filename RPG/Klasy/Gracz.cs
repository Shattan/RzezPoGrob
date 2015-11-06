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
                               
        //statystyki bez przedmiotow    
        public int SilaPodstawa{ get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public int ObrazeniaPodstawa;
        public int PancerzPodstawa;
        public int HPPodstawa;
        public int EnergiaPodstawa;
        public int SzansaNaTrafieniePodstawa;
        public int SzansaNaKrytycznePodstawa;

        //statystyki z przedmiotami
        public int SilaSuma { get { return SilaPodstawa + ZalozonaBron.Sila + ZalozonyPancerz.Sila + ZalozonaTarcza.Sila; } }
        public int ZrecznoscSuma { get { return ZrecznoscPodstawa + ZalozonaBron.Zrecznosc + ZalozonyPancerz.Zrecznosc + ZalozonaTarcza.Zrecznosc; } }
        public int WitalnoscSuma { get { return WitalnoscPodstawa + ZalozonaBron.Witalnosc + ZalozonyPancerz.Witalnosc + ZalozonaTarcza.Witalnosc; } }
        public int InteligencjaSuma { get { return InteligencjaPodstawa + ZalozonaBron.Inteligencja + ZalozonyPancerz.Inteligencja + ZalozonaTarcza.Inteligencja; } }
        public int ObrazeniaSuma { get { return ObrazeniaPodstawa + ZalozonaBron.Obrazenia + ZalozonyPancerz.Obrazenia + ZalozonaTarcza.Obrazenia; } }
        public int PancerzSuma { get { return PancerzPodstawa + ZalozonaBron.Pancerz + ZalozonyPancerz.Pancerz + ZalozonaTarcza.Pancerz; } }
        public int HPSuma { get { return HPPodstawa + ZalozonaBron.HP + ZalozonyPancerz.HP + ZalozonaTarcza.HP; } }
        public int EnergiaSuma { get { return EnergiaPodstawa + ZalozonaBron.Energia + ZalozonyPancerz.Energia + ZalozonaTarcza.Energia; } }
        public int SzansaNaTrafienieSuma { get { return SzansaNaTrafieniePodstawa + ZalozonaBron.SzansaNaTrafienie + ZalozonyPancerz.SzansaNaTrafienie + ZalozonaTarcza.SzansaNaTrafienie; } }
        public int SzansaNaKrytyczneSuma { get { return SzansaNaKrytycznePodstawa + ZalozonaBron.SzansaNaKrytyczne + ZalozonyPancerz.SzansaNaKrytyczne + ZalozonaTarcza.SzansaNaKrytyczne; } }




        public int DoswiadczenieDoNastepnegoPoziomu { get { return 1000 * Poziom * Poziom; ;} }
        public int Obrazenia { get { return ObrazeniaPodstawa + SilaSuma / 5; } }
        public int Pancerz { get { return PancerzPodstawa + ZrecznoscSuma / 5; } }
        public int HP { get { return HPSuma + WitalnoscSuma * 5; } }
        public int Energia { get { return EnergiaPodstawa + InteligencjaSuma * 5; } }
        public int SzansaNaTrafienie { get { return SzansaNaTrafienieSuma + ZrecznoscSuma / 10; } }
        public int SzansaNaKrytyczne { get { return SzansaNaKrytyczneSuma + ZrecznoscSuma / 10; } }

        public Ekwipunek ZalozonaBron { get; set; }
        public Ekwipunek ZalozonyPancerz { get; set; }
        public Ekwipunek ZalozonaTarcza { get; set; }

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
            SilaPodstawa = 10;
            ZrecznoscPodstawa = 10;
            WitalnoscPodstawa = 10;
            InteligencjaPodstawa = 10;
            ObrazeniaPodstawa = 10;
            PancerzPodstawa = 10;
            HPPodstawa = 10;
            EnergiaPodstawa = 10;
            SzansaNaTrafieniePodstawa = 75;
            SzansaNaKrytycznePodstawa = 5;

            ZalozonaBron = new Ekwipunek("Nóż do masła", "Resources/Grafiki ekwipunku/bron1hNóż do masła.png", 1, 1, 0, 0, 1, 0, 0, 0, 0, 0);
            ZalozonyPancerz = new Ekwipunek("Stara tunika", "Resources/Grafiki ekwipunku/pancerzStara tunika.png", 0, 0, 1, 0, 0, 1, 5, 0, 0, 0);
            ZalozonaTarcza = new Ekwipunek("Pochodnia", "Resources/Grafiki ekwipunku/tarczaPochodnia.png", 0, 0, 0, 1, 0, 0, 0, 5, 1, 0);

            plecakGracza = new List<Ekwipunek>();
            zadaniaGracza = new List<Zadanie>();
        }
        public Gracz(Gracz kopiowanyBohater)
        {
            this.Nazwa = kopiowanyBohater.Nazwa;
            this.ObrazekNaMapie = kopiowanyBohater.ObrazekNaMapie;
            this.ObrazekMowienia = kopiowanyBohater.ObrazekMowienia;
            this.Poziom = kopiowanyBohater.Poziom;
            this.Doswiadczenie = kopiowanyBohater.Doswiadczenie;
            this.Punkty = kopiowanyBohater.Punkty;
            this.Zloto = kopiowanyBohater.Zloto;
            this.SilaPodstawa = kopiowanyBohater.SilaPodstawa;
            this.ZrecznoscPodstawa = kopiowanyBohater.ZrecznoscPodstawa;
            this.WitalnoscPodstawa = kopiowanyBohater.WitalnoscPodstawa;
            this.InteligencjaPodstawa = kopiowanyBohater.InteligencjaPodstawa;
            this.ObrazeniaPodstawa = kopiowanyBohater.ObrazeniaPodstawa;
            this.PancerzPodstawa = kopiowanyBohater.PancerzPodstawa;
            this.HPPodstawa = kopiowanyBohater.HPPodstawa;
            this.EnergiaPodstawa = kopiowanyBohater.EnergiaPodstawa;
            this.SzansaNaTrafieniePodstawa = kopiowanyBohater.SzansaNaTrafieniePodstawa;
            this.SzansaNaKrytycznePodstawa = kopiowanyBohater.SzansaNaKrytycznePodstawa;


            this.ZalozonaBron = new Ekwipunek(kopiowanyBohater.ZalozonaBron);
            this.ZalozonyPancerz = new Ekwipunek(kopiowanyBohater.ZalozonyPancerz);
            this.ZalozonaTarcza = new Ekwipunek(kopiowanyBohater.ZalozonaTarcza);

            this.plecakGracza = new List<Ekwipunek>();
            if (kopiowanyBohater.plecakGracza != null)
            {
                foreach (Ekwipunek przedmiot in kopiowanyBohater.plecakGracza)
                {
                    this.plecakGracza.Add(new Ekwipunek(przedmiot));
                }
            }

            this.zadaniaGracza = new List<Zadanie>();
            foreach (Zadanie zadanie in kopiowanyBohater.zadaniaGracza)
            {
                this.zadaniaGracza.Add(new Zadanie(zadanie));
            }
        }
    }

}
