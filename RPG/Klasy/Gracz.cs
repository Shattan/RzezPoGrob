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
        public int Doswiadczenie { get; set; }
        public int PunktyStatystykDoRozdania{ get; set; }
        public int Zloto { get; set; }
                               
        //statystyki bez przedmiotow    
        public int SilaPodstawa{ get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public int ObrazeniaPodstawa { get; set; }
        public int PancerzPodstawa { get; set; }
        public int HPPodstawa { get; set; }
        public int EnergiaPodstawa { get; set; }
        public int SzansaNaTrafieniePodstawa { get; set; }
        public int SzansaNaKrytycznePodstawa { get; set; }

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

        public int DoswiadczenieDoNastepnegoPoziomu { get { return 1000 * Poziom * Poziom; ;} }

        public int Sila { get { return SilaZPrzedmiotami; } }
        public int Zrecznosc { get { return ZrecznoscZPrzedmiotami; } }
        public int Witalnosc { get { return WitalnoscZPrzedmiotami; } }
        public int Inteligencja { get { return InteligencjaZPrzedmiotami; } }
        public int Obrazenia { get { return ObrazeniaPodstawa + Sila / 5; } }
        public int Pancerz { get { return PancerzPodstawa + Zrecznosc / 5; } }
        public int HP { get { return HPZPrzedmiotami + Witalnosc * 5; } }
        public int Energia { get { return EnergiaPodstawa + Inteligencja * 5; } }
        public int SzansaNaTrafienie { get { return SzansaNaTrafienieZPrzedmiotami + Zrecznosc / 10; } }
        public int SzansaNaKrytyczne { get { return SzansaNaKrytyczneZPrzedmiotami + Zrecznosc / 10; } }

        public int Poziom { get{return (SilaPodstawa +ZrecznoscPodstawa +WitalnoscPodstawa +InteligencjaPodstawa)/4;} }

        public Ekwipunek ZalozonaBron { get; set; }
        public Ekwipunek ZalozonyPancerz { get; set; }
        public Ekwipunek ZalozonaTarcza { get; set; }

        public List<Umiejetnosc> Umiejetnosci { get; set; }
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
            PunktyStatystykDoRozdania = 1;
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

            ZalozonaBron = new Ekwipunek();
            ZalozonyPancerz = new Ekwipunek();
            ZalozonaTarcza = new Ekwipunek();

            Umiejetnosci = new List<Umiejetnosc>();
            Plecak = new List<Ekwipunek>();
            MiksturyIPozywienie = new List<Strawa>();
            Zadania = new List<Zadanie>();
        }

        //Konstruktor z parametrami
        public Gracz(string nazwa, string obrazekNaMapie, string obrazekMowienia, int doswiadczenie, int punktyStatystykDoRozdania, int zloto, int silaPodstawa, int zrecznoscPodstawa,int witalnoscPodstawa, int inteligencjaPodstawa, int obrazeniaPodstawa, int pancerzPodstawa, int hPPodstawa, int energiaPodstawa, int szansaNaTrafieniePodstawa, int szansaNaKrytycznePodstawa,Ekwipunek zalozonaBron, Ekwipunek zalozonyPancerz,Ekwipunek zalozonaTarcza, List<Umiejetnosc> umiejetnosci, List<Ekwipunek>plecak,List<Zadanie>zadania,List<Strawa> miksturyIPozywienie)
        {
            Nazwa = nazwa;
            ObrazekNaMapie = obrazekNaMapie;
            ObrazekMowienia = obrazekMowienia;

            Doswiadczenie = doswiadczenie;
            PunktyStatystykDoRozdania = punktyStatystykDoRozdania;
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

            if (zalozonaBron != null)
            {
                ZalozonaBron = new Ekwipunek(zalozonaBron);
            }
            else
            {
                ZalozonaBron = new Ekwipunek();
            }
            if (zalozonyPancerz != null)
            {
                ZalozonyPancerz = new Ekwipunek(zalozonyPancerz);
            }
            else
            {
                ZalozonyPancerz = new Ekwipunek();
            }

            if (zalozonaTarcza != null)
            {
                ZalozonaTarcza = new Ekwipunek(zalozonaTarcza);
            }
            else
            {
                ZalozonaTarcza = new Ekwipunek();
            }

            if (umiejetnosci != null)
            {
                Umiejetnosci = new List<Umiejetnosc>(umiejetnosci);
            }
            else
            {
                Umiejetnosci = new List<Umiejetnosc>();
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
            this.PunktyStatystykDoRozdania = kopiowanyBohater.PunktyStatystykDoRozdania;
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

            this.Umiejetnosci = new List<Umiejetnosc>();
            if (kopiowanyBohater.Umiejetnosci != null)
            {
                foreach (Umiejetnosc umiejetnosc in kopiowanyBohater.Umiejetnosci)
                {
                    this.Umiejetnosci.Add(new Umiejetnosc(umiejetnosc));
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
