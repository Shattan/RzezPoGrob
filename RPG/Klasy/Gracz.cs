using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gracz:Postac
    {
        private string _nazwa = "",_obrazekMapa="";
        public int Zloto { get; set; }

        public string ObrazekMowienia { get; set; }
        public string ObrazekWalki { get; set; }
        public override string Nazwa
        {
            get { return _nazwa; }
        }
        public void UstawImie(String imie)
        {
            _nazwa = imie;
        }
        public void UstawObrazek(String obrazek)
        {
            _obrazekMapa = obrazek;
        }
        
        //statystyki bez przedmiotow    
        public int SilaPodstawa { get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public double ObrazeniaPodstawa { get; set; }
        public double PancerzPodstawa { get; set; }
        public double HPPodstawa { get; set; }
        public double EnergiaPodstawa { get; set; }
        public double SzansaNaTrafieniePodstawa { get; set; }
        public double SzansaNaKrytycznePodstawa { get; set; }


        public int iloscPunktowDoRozdaniaCoPoziom { get { return 4; } }

        public int SumaStatystykPodstawowych { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }
        public int Doswiadczenie { get; set; }

        private int sumaPoczatkowychStatystyk;

        //statystyki z przedmiotami
        public int SilaZPrzedmiotami
        {
            get
            {
                return SilaPodstawa
                    + (ZalozonaBron != null ? ZalozonaBron.Sila : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Sila : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Sila : 0);
            }
        }
        public int ZrecznoscZPrzedmiotami { get { return ZrecznoscPodstawa +  
                    + (ZalozonaBron != null ? ZalozonaBron.Zrecznosc : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Zrecznosc : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Zrecznosc : 0);
            } 
        }
        public int WitalnoscZPrzedmiotami
        {
            get
            {
                return WitalnoscPodstawa +(ZalozonaBron != null ? ZalozonaBron.Witalnosc : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Witalnosc : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Witalnosc : 0);
            }
        }
        public int InteligencjaZPrzedmiotami
        {
            get
            {
                return InteligencjaPodstawa +(ZalozonaBron != null ? ZalozonaBron.Inteligencja : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Inteligencja : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Inteligencja : 0);
            }
        }
        public double ObrazeniaZPrzedmiotami
        {
            get
            {
                return ObrazeniaPodstawa +(ZalozonaBron != null ? ZalozonaBron.Sila : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Sila : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Sila : 0);
            }
        }
        public double PancerzZPrzedmiotami
        {
            get
            {
                return PancerzPodstawa +(ZalozonaBron != null ? ZalozonaBron.Obrazenia : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Obrazenia : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Obrazenia : 0);
            }
        }
        public double HPZPrzedmiotami
        {
            get
            {
                return HPPodstawa +(ZalozonaBron != null ? ZalozonaBron.HP : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.HP : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.HP : 0);
            }
        }
        public double EnergiaZPrzedmiotami
        {
            get
            {
                return EnergiaPodstawa +(ZalozonaBron != null ? ZalozonaBron.Energia : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.Energia : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.Energia : 0);
            }
        }
        public double SzansaNaTrafienieZPrzedmiotami
        {
            get
            {
                return SzansaNaTrafieniePodstawa +(ZalozonaBron != null ? ZalozonaBron.SzansaNaTrafienie : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.SzansaNaTrafienie : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.SzansaNaTrafienie : 0);
            }
        }
        public double SzansaNaKrytyczneZPrzedmiotami
        {
            get
            {
                return SzansaNaKrytycznePodstawa +(ZalozonaBron != null ? ZalozonaBron.SzansaNaKrytyczne : 0)
                    + (ZalozonaTarcza != null ? ZalozonaTarcza.SzansaNaKrytyczne : 0)
                    + (ZalozonyPancerz != null ? ZalozonyPancerz.SzansaNaKrytyczne : 0);
            }
        }

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

        public override int Sila { get { return SilaZPrzedmiotami + BonusDoSily; } }
        public override int Zrecznosc { get { return ZrecznoscZPrzedmiotami + BonusDoZrecznosci; } }
        public override int Witalnosc { get { return WitalnoscZPrzedmiotami + BonusDoWitalnosci; } }
        public override int Inteligencja { get { return InteligencjaZPrzedmiotami + BonusDoInteligencji; } }
        public override double Obrazenia { get { return ObrazeniaPodstawa + BonusDoObrazen; } }
        public override double Pancerz { get { return PancerzPodstawa + BonusDoPancerza; } }
        public override double HP { get { return HPZPrzedmiotami + BonusDoHP; } }
        public override double Energia { get { return EnergiaPodstawa + BonusDoEnergii; } }
        public override double SzansaNaTrafienie { get { return SzansaNaTrafienieZPrzedmiotami + BonusDoSzansyNaTrafienie; } }
        public override double SzansaNaKrytyczne { get { return SzansaNaKrytyczneZPrzedmiotami + BonusDoSzansyNaKrytyczne; } }

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
        public List<Zadanie> Zadania {get;set;}
        //Konstruktor domyślny

        //Konstruktor z parametrami
        public Gracz(string nazwa, string obrazekNaMapie, string obrazekMowienia, int doswiadczenie, int zloto, int silaPodstawa, int zrecznoscPodstawa, int witalnoscPodstawa, int inteligencjaPodstawa,
            double obrazeniaPodstawa, double pancerzPodstawa, double hPPodstawa, double energiaPodstawa,
            double szansaNaTrafieniePodstawa, double szansaNaKrytycznePodstawa,
            Ekwipunek zalozonaBron, Ekwipunek zalozonyPancerz, Ekwipunek zalozonaTarcza,
            List<Ekwipunek> plecak, List<Zadanie> zadania)
            : base()
        {
            _obrazekMapa = obrazekNaMapie;
            _nazwa = nazwa;
            Zloto = zloto;
            ObrazekMowienia = obrazekMowienia;
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
            ZalozonaBron = zalozonaBron;
            ZalozonyPancerz = zalozonyPancerz;

            ZalozonaTarcza = zalozonaTarcza;

            if (plecak != null)
            {
                Plecak = new List<Ekwipunek>(plecak);
            }
            else
            {
                Plecak = new List<Ekwipunek>();
            }
            if (zadania != null)
            {
                Zadania = new List<Zadanie>(zadania);
            }
            else
            {
                Zadania = new List<Zadanie>();
            }

            sumaPoczatkowychStatystyk = silaPodstawa + zrecznoscPodstawa + inteligencjaPodstawa + witalnoscPodstawa;
        }

        //Konstruktor kopiujący
   


        public override List<Umiejetnosc> Umiejetnosci()
        {
            List<Umiejetnosc> wynik = new List<Umiejetnosc>();
            List<Type> typy = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Umiejetnosc))).ToList();//Pobieramy wszystkie klasy dziedziczące po klasie Umiejetnosc
            foreach(Type t in typy)
            {
              Umiejetnosc testowana=(Umiejetnosc)  Activator.CreateInstance(t);//Tworzymy instancje klasy na podstawie typu - używamy konstruktora domyślnego tej klasy
                if(testowana.JestDostepna(this))
                {
                    wynik.Add(testowana);
                }
            }
            return wynik;
         
         
        }
        public string AktualnyObrazek { get; set; }
        public int Szerokosc = 32;
        public int Wysokosc = 48;

        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGry gra)
        {
           
        }
       
        public override string ObrazekNaMapie
        {
            get { return _obrazekMapa; }
        }
    }
}
