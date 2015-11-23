using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Przeciwnik :Postac
    {
        public int BonusDoSily { get { return 0; } }
        public int BonusDoZrecznosci { get { return 0; } }
        public int BonusDoWitalnosci { get { return 0; } }
        public int BonusDoInteligencji { get { return 0; } }
        public double BonusDoObrazen { get { return SilaPodstawa / 5; } }
        public double BonusDoPancerza { get { return ZrecznoscPodstawa / 5; } }
        public double BonusDoHP { get { return WitalnoscPodstawa * 5; } }
        public double BonusDoEnergii { get { return InteligencjaPodstawa * 5; } }
        public double BonusDoSzansyNaTrafienie { get { return ZrecznoscPodstawa / 10; } }
        public double BonusDoSzansyNaKrytyczne { get { return ZrecznoscPodstawa / 10; } }


        //statystyki po obliczeniu bonusów 
        public override int Sila { get { return SilaPodstawa; } }
        public override int Zrecznosc { get { return ZrecznoscPodstawa; } }
        public override int Witalnosc { get { return WitalnoscPodstawa; } }
        public override int Inteligencja { get { return InteligencjaPodstawa; } }
        public override double Obrazenia { get { return ObrazeniaPodstawa + BonusDoObrazen; } }
        public override double Pancerz { get { return PancerzPodstawa + BonusDoPancerza; } }
        public override double HP { get { return HPPodstawa + BonusDoHP; } }
        public override double Energia { get { return EnergiaPodstawa + BonusDoEnergii; } }
        public override double SzansaNaTrafienie { get { return SzansaNaTrafieniePodstawa + BonusDoSzansyNaTrafienie; } }
        public override double SzansaNaKrytyczne { get { return SzansaNaKrytycznePodstawa + BonusDoSzansyNaKrytyczne; } }


        public int Poziom { get { return SumaStatystykPodstawowych / iloscPunktowDoRozdaniaCoPoziom; } }
        public int ZlotoZaZabicie { get
        {
            Random Losowanie = new Random();
            return Losowanie.Next(50, 150) / 100 * SumaStatystykPodstawowych;
        }}
        public int DoswiadczenieZaZabicie { get { return SumaStatystykPodstawowych; } }



        
        
        //Konstruktor domyślny
        public Przeciwnik()
        {
            Nazwa = "Nieustawiony potwór";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/2/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";
            ObrazekWalki = "Resources/Grafiki postaci walczących/szczur.png";
            UstawHp();
        }

        public Przeciwnik(String nazwa, String obrazekMowienia, String obrazekNaMapie, String obrazekWalki, int sila, int zrecznosc, int witalnosc, int inteligencja, double bazoweObrazenia, double bazowyPancerz, double bazoweHP, double bazowaEnergia, double bazowaSzansaNaTrafienie, double bazowaSzansaNaKrytyczne,
            List<Umiejetnosc> umiejetnosci)
            : base(nazwa, 0, obrazekNaMapie, obrazekMowienia, obrazekWalki, sila, zrecznosc, witalnosc, inteligencja, bazoweObrazenia, bazowyPancerz, bazoweHP, bazowaEnergia
      , bazowaSzansaNaTrafienie, bazowaSzansaNaKrytyczne)
        {
            _zdolnosci = new List<Umiejetnosc>(umiejetnosci);

            UstawHp();
         
        }

        public Przeciwnik(Przeciwnik kopiowanyNPC)
        {
            this.Nazwa = kopiowanyNPC.Nazwa;
            this.ObrazekMowienia = kopiowanyNPC.ObrazekMowienia;
            this.ObrazekNaMapie = kopiowanyNPC.ObrazekNaMapie;
            this.ObrazekWalki = kopiowanyNPC.ObrazekWalki;
            this.SilaPodstawa = kopiowanyNPC.SilaPodstawa;
            this.ZrecznoscPodstawa = kopiowanyNPC.ZrecznoscPodstawa;
            this.WitalnoscPodstawa = kopiowanyNPC.WitalnoscPodstawa;
            this.InteligencjaPodstawa = kopiowanyNPC.InteligencjaPodstawa;
            this.ObrazeniaPodstawa = kopiowanyNPC.ObrazeniaPodstawa;
            this.PancerzPodstawa = kopiowanyNPC.PancerzPodstawa;
            this.HPPodstawa = kopiowanyNPC.HPPodstawa;
            this.EnergiaPodstawa = kopiowanyNPC.EnergiaPodstawa;
            this.SzansaNaTrafieniePodstawa = kopiowanyNPC.SzansaNaTrafieniePodstawa;
            this.SzansaNaKrytycznePodstawa = kopiowanyNPC.SzansaNaKrytycznePodstawa;

            if (kopiowanyNPC._zdolnosci != null)
            {
                _zdolnosci = new List<Umiejetnosc>(kopiowanyNPC._zdolnosci);
            }
            UstawHp();

        }
        private List<Umiejetnosc> _zdolnosci;
        public override List<Umiejetnosc> Umiejetnosci()
        {
            return _zdolnosci;
        }

        internal Umiejetnosc PobierzUmiejetnosc()
        {
            Random r = new Random();
            Umiejetnosc u= _zdolnosci[r.Next(0, _zdolnosci.Count)];
            if(u.KosztEnergi>Energia)//jak nie stać to używamy wymachiwania
            {
                return new Wymachiwanie();
            }
            return u;
        }
    }
}
