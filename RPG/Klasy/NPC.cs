using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class NPC
    {
        public string Nazwa { get; private set; }
        public string ObrazekNaMapie { get; private set; }
        public string ObrazekMowienia { get; private set; }
        public string ObrazekWalki { get; private set; }
        public int Zloto { get; private set; }

        //statystyki bez obliczeń bonusów 
        public int SilaPodstawa { get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public int ObrazeniaPodstawa { get; set; }
        public int PancerzPodstawa { get; set; }
        public int HPPodstawa { get; set; }
        public int EnergiaPodstawa { get; set; }
        public int SzansaNaTrafieniePodstawa { get; set; }
        public int SzansaNaKrytycznePodstawa { get; set; }

        //statystyki po obliczeniu bonusów 
        public int Sila { get { return SilaPodstawa; } }
        public int Zrecznosc { get { return ZrecznoscPodstawa; } }
        public int Witalnosc { get { return WitalnoscPodstawa; } }
        public int Inteligencja { get { return InteligencjaPodstawa; } }
        public int Obrazenia { get { return ObrazeniaPodstawa + Sila / 5; } }
        public int Pancerz { get { return PancerzPodstawa + Zrecznosc / 5; } }
        public int HP { get { return 1 + WitalnoscPodstawa * 5; } }//tu jest błąd stack overflow
        public int Energia { get { return EnergiaPodstawa + Inteligencja * 5; } }
        public int SzansaNaTrafienie { get { return SzansaNaTrafieniePodstawa + Zrecznosc / 10; } }
        public int SzansaNaKrytyczne { get { return SzansaNaKrytycznePodstawa + Zrecznosc / 10; } }


        public int SumaPunktow { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }
        public int Poziom { get { return SumaPunktow / 4; } }
        public int ZlotoZaZabicie { get
        {
            Random Losowanie = new Random();
            return Losowanie.Next(50,150)/100*SumaPunktow;
        }}
        public int DoswiadczenieZaZabicie { get { return SumaPunktow; } }

        public List<Umiejetnosc> umiejetnosci { get; set; }

        
        
        //Konstruktor domyślny
        public NPC()
        {
            Nazwa = "Nieustawiony potwór";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/2/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";
            ObrazekWalki = "Resources/Grafiki postaci walczących/szczur.png";

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

            umiejetnosci = new List<Umiejetnosc>();
        }

        public NPC(String nazwa, String obrazekMowienia, String obrazekNaMapie, String obrazekWalki, int sila, int zrecznosc, int witalnosc, int inteligencja, int bazoweObrazenia, int bazowyPancerz, int bazoweHP, int bazowaEnergia, int bazowaSzansaNaTrafienie, int bazowaSzansaNaKrytyczne)
        {
            Nazwa = nazwa;
            ObrazekMowienia = obrazekMowienia;
            ObrazekNaMapie = obrazekNaMapie;
            ObrazekWalki = obrazekWalki;

            SilaPodstawa = sila;
            ZrecznoscPodstawa = zrecznosc;
            WitalnoscPodstawa = witalnosc;
            InteligencjaPodstawa = inteligencja;
            ObrazeniaPodstawa = bazoweObrazenia;
            PancerzPodstawa = bazowyPancerz;
            HPPodstawa = bazoweHP;
            EnergiaPodstawa = bazowaEnergia;
            SzansaNaTrafieniePodstawa = bazowaSzansaNaTrafienie;
            SzansaNaKrytycznePodstawa = bazowaSzansaNaKrytyczne;
        }

        public NPC(NPC kopiowanyNPC)
        {
        }
    }
}
