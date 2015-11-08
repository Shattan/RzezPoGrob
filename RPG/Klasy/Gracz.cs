using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gracz:Postac
    {     
        public int Doswiadczenie { get; set; }

        private int sumaPoczatkowychStatystyk;

        //statystyki z przedmiotami
        public int SilaZPrzedmiotami { get { return SilaPodstawa + ZalozonaBron.Sila + ZalozonyPancerz.Sila + ZalozonaTarcza.Sila; } }
        public int ZrecznoscZPrzedmiotami {  get { return ZrecznoscPodstawa + ZalozonaBron.Zrecznosc + ZalozonyPancerz.Zrecznosc + ZalozonaTarcza.Zrecznosc; } }
        public int WitalnoscZPrzedmiotami {  get { return WitalnoscPodstawa + ZalozonaBron.Witalnosc + ZalozonyPancerz.Witalnosc + ZalozonaTarcza.Witalnosc; } }
        public int InteligencjaZPrzedmiotami {  get { return InteligencjaPodstawa + ZalozonaBron.Inteligencja + ZalozonyPancerz.Inteligencja + ZalozonaTarcza.Inteligencja; } }
        public int ObrazeniaZPrzedmiotami {  get { return ObrazeniaPodstawa + ZalozonaBron.Obrazenia + ZalozonyPancerz.Obrazenia + ZalozonaTarcza.Obrazenia; } }
        public int PancerzZPrzedmiotami {  get { return PancerzPodstawa + ZalozonaBron.Pancerz + ZalozonyPancerz.Pancerz + ZalozonaTarcza.Pancerz; } }
        public int HPZPrzedmiotami {  get { return HPPodstawa + ZalozonaBron.HP + ZalozonyPancerz.HP + ZalozonaTarcza.HP; } }
        public int EnergiaZPrzedmiotami {  get { return EnergiaPodstawa + ZalozonaBron.Energia + ZalozonyPancerz.Energia + ZalozonaTarcza.Energia; } }
        public int SzansaNaTrafienieZPrzedmiotami {  get { return SzansaNaTrafieniePodstawa + ZalozonaBron.SzansaNaTrafienie + ZalozonyPancerz.SzansaNaTrafienie + ZalozonaTarcza.SzansaNaTrafienie; } }
        public int SzansaNaKrytyczneZPrzedmiotami {  get { return SzansaNaKrytycznePodstawa + ZalozonaBron.SzansaNaKrytyczne + ZalozonyPancerz.SzansaNaKrytyczne + ZalozonaTarcza.SzansaNaKrytyczne; } }

        public int BonusDoSily { get { return 0; } }
        public int BonusDoZrecznosci { get { return 0; } }
        public int BonusDoWitalnosci { get { return 0; } }
        public int BonusDoInteligencji { get { return 0; } }
        public int BonusDoObrazen { get { return SilaZPrzedmiotami / 5; } }
        public int BonusDoPancerza { get { return ZrecznoscZPrzedmiotami / 5; } }
        public int BonusDoHP { get { return WitalnoscZPrzedmiotami * 5; } }
        public int BonusDoEnergii { get { return InteligencjaZPrzedmiotami * 5; } }
        public int BonusDoSzansyNaTrafienie { get { return ZrecznoscZPrzedmiotami / 10; } }
        public int BonusDoSzansyNaKrytyczne { get { return ZrecznoscZPrzedmiotami / 10; } }

        public int Sila { get { return SilaZPrzedmiotami + BonusDoSily; } }
        public int Zrecznosc { get { return ZrecznoscZPrzedmiotami + BonusDoZrecznosci; } }
        public int Witalnosc { get { return WitalnoscZPrzedmiotami + BonusDoWitalnosci; } }
        public int Inteligencja { get { return InteligencjaZPrzedmiotami + BonusDoInteligencji; } }
        public int Obrazenia { get { return ObrazeniaPodstawa + BonusDoObrazen; } }
        public int Pancerz { get { return PancerzPodstawa + BonusDoPancerza; } }
        public int HP { get { return HPZPrzedmiotami + BonusDoHP; } }
        public int Energia { get { return EnergiaPodstawa + BonusDoEnergii; } }
        public int SzansaNaTrafienie { get { return SzansaNaTrafienieZPrzedmiotami + BonusDoSzansyNaTrafienie; } }
        public int SzansaNaKrytyczne { get { return SzansaNaKrytyczneZPrzedmiotami + BonusDoSzansyNaKrytyczne; } }

        private int obecnyPoziom=1;

        public List<int> DoswiadczenieWymaganeNaKonkretnyPoziom{ get { 
            List<int> listaDoswiadczenia = new List<int>();
            listaDoswiadczenia.Clear(); 
            const int ograniczeniePoziomu = 40; 
            for (int i = 1; i <= ograniczeniePoziomu; i++) 
            { listaDoswiadczenia.Add(1000 * i * i); } 
            return listaDoswiadczenia; 
        } }

        public int Poziom { get {
            if (DoswiadczenieWymaganeNaKonkretnyPoziom[obecnyPoziom-1] - Doswiadczenie < 0)
            {
                int roznicaDoswiadczenia = Doswiadczenie;
                int i = 0;
                while(roznicaDoswiadczenia>0)
                {
                    roznicaDoswiadczenia = roznicaDoswiadczenia - DoswiadczenieWymaganeNaKonkretnyPoziom[i];
                    i++;
                }
                obecnyPoziom = i;
            }
            return obecnyPoziom; 
        } }

        public int PunktyStatystykDoRozdania { get { return obecnyPoziom * iloscPunktowDoRozdaniaCoPoziom - SumaStatystykPodstawowych + sumaPoczatkowychStatystyk; } }
        
        public Ekwipunek ZalozonaBron { get; set; }
        public Ekwipunek ZalozonyPancerz { get; set; }
        public Ekwipunek ZalozonaTarcza { get; set; }

        public List<Ekwipunek> Plecak { get; set; }
        public List<Strawa> MiksturyIPozywienie { get; set; }
        public List<Zadanie> Zadania {get;set;}


        //Konstruktor domyślny
        public Gracz()
        {
            Nazwa = "Gracz nienazwany";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/0/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";

            Doswiadczenie = 1;
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

            sumaPoczatkowychStatystyk = SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa;

            ZalozonaBron = new Ekwipunek();
            ZalozonyPancerz = new Ekwipunek();
            ZalozonaTarcza = new Ekwipunek();

            UmiejetnosciFizyczne = new List<Umiejetnosc>();
            UmiejetnosciMagiczne = new List<Umiejetnosc>();
            Plecak = new List<Ekwipunek>();
            MiksturyIPozywienie = new List<Strawa>();
            Zadania = new List<Zadanie>();
        }

        //Konstruktor z parametrami
        public Gracz(string nazwa, string obrazekNaMapie, string obrazekMowienia, int doswiadczenie, int zloto, int silaPodstawa, int zrecznoscPodstawa,int witalnoscPodstawa, int inteligencjaPodstawa, int obrazeniaPodstawa, int pancerzPodstawa, int hPPodstawa, int energiaPodstawa, int szansaNaTrafieniePodstawa, int szansaNaKrytycznePodstawa,Ekwipunek zalozonaBron, Ekwipunek zalozonyPancerz,Ekwipunek zalozonaTarcza, List<Umiejetnosc> umiejetnosciFizyczne,List<Umiejetnosc> umiejetnosciMagiczne, List<Ekwipunek>plecak,List<Zadanie>zadania,List<Strawa> miksturyIPozywienie)
        {
            Nazwa = nazwa;
            ObrazekNaMapie = obrazekNaMapie;
            ObrazekMowienia = obrazekMowienia;

            Doswiadczenie = doswiadczenie;
            Zloto = zloto;
            SilaPodstawa = silaPodstawa;
            ZrecznoscPodstawa = zrecznoscPodstawa;
            WitalnoscPodstawa = witalnoscPodstawa;
            InteligencjaPodstawa = inteligencjaPodstawa;
            ObrazeniaPodstawa = obrazeniaPodstawa;
            PancerzPodstawa = pancerzPodstawa;
            HPPodstawa = hPPodstawa;
            EnergiaPodstawa = energiaPodstawa;
            SzansaNaTrafieniePodstawa = szansaNaTrafieniePodstawa;
            SzansaNaKrytycznePodstawa = szansaNaKrytycznePodstawa;

            sumaPoczatkowychStatystyk = SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa;

            if (zalozonaBron != null)
            {
                ZalozonaBron = new Ekwipunek(zalozonaBron);
            }
            else
            {
                ZalozonaBron = null;
            }
            if (zalozonyPancerz != null)
            {
                ZalozonyPancerz = new Ekwipunek(zalozonyPancerz);
            }
            else
            {
                ZalozonyPancerz = null;
            }

            if (zalozonaTarcza != null)
            {
                ZalozonaTarcza = new Ekwipunek(zalozonaTarcza);
            }
            else
            {
                ZalozonaTarcza = null;
            }

            if (umiejetnosciFizyczne != null)
            {
                UmiejetnosciFizyczne = new List<Umiejetnosc>(umiejetnosciFizyczne);
            }
            else
            {
                UmiejetnosciFizyczne = new List<Umiejetnosc>();
            }

            if (umiejetnosciMagiczne != null)
            {
                UmiejetnosciMagiczne = new List<Umiejetnosc>(umiejetnosciMagiczne);
            }
            else
            {
                UmiejetnosciMagiczne = new List<Umiejetnosc>();
            }

            if (plecak != null)
            {
                Plecak = new List<Ekwipunek>(plecak);
            }
            else
            {
                Plecak = new List<Ekwipunek>();
            }
            if (miksturyIPozywienie != null)
            {
                MiksturyIPozywienie = new List<Strawa>(miksturyIPozywienie);
            }
            else
            {
                MiksturyIPozywienie = new List<Strawa>();
            }
            if (zadania != null)
            {
                Zadania = new List<Zadanie>(zadania);
            }
            else
            {
                Zadania = new List<Zadanie>();
            }
        }

        //Konstruktor kopiujący
        public Gracz(Gracz kopiowanyBohater)
        {
            this.Nazwa = kopiowanyBohater.Nazwa;
            this.ObrazekNaMapie = kopiowanyBohater.ObrazekNaMapie;
            this.ObrazekMowienia = kopiowanyBohater.ObrazekMowienia;
            this.Doswiadczenie = kopiowanyBohater.Doswiadczenie;
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
            this.sumaPoczatkowychStatystyk = kopiowanyBohater.sumaPoczatkowychStatystyk;

            this.ZalozonaBron = new Ekwipunek(kopiowanyBohater.ZalozonaBron);
            this.ZalozonyPancerz = new Ekwipunek(kopiowanyBohater.ZalozonyPancerz);
            this.ZalozonaTarcza = new Ekwipunek(kopiowanyBohater.ZalozonaTarcza);

            this.UmiejetnosciFizyczne = new List<Umiejetnosc>();
            if (kopiowanyBohater.UmiejetnosciFizyczne != null)
            {
                foreach (Umiejetnosc umiejetnosc in kopiowanyBohater.UmiejetnosciFizyczne)
                {
                    this.UmiejetnosciFizyczne.Add(new Umiejetnosc(umiejetnosc));
                }
            }

            this.UmiejetnosciMagiczne = new List<Umiejetnosc>();
            if (kopiowanyBohater.UmiejetnosciMagiczne != null)
            {
                foreach (Umiejetnosc umiejetnosc in kopiowanyBohater.UmiejetnosciMagiczne)
                {
                    this.UmiejetnosciMagiczne.Add(new Umiejetnosc(umiejetnosc));
                }
            }

            this.Plecak = new List<Ekwipunek>();
            if (kopiowanyBohater.Plecak != null)
            {
                foreach (Ekwipunek przedmiot in kopiowanyBohater.Plecak)
                {
                    this.Plecak.Add(new Ekwipunek(przedmiot));
                }
            }

            this.MiksturyIPozywienie = new List<Strawa>();
            if (kopiowanyBohater.MiksturyIPozywienie != null)
            {
                foreach (Strawa strawa in kopiowanyBohater.MiksturyIPozywienie)
                {
                    this.MiksturyIPozywienie.Add(new Strawa(strawa));
                }
            }

            this.Zadania = new List<Zadanie>();
            foreach (Zadanie zadanie in kopiowanyBohater.Zadania)
            {
                this.Zadania.Add(new Zadanie(zadanie));
            }
        }
    }
}
