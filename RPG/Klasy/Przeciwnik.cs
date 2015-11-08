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
        public int BonusDoObrazen { get { return SilaPodstawa / 5; } }
        public int BonusDoPancerza { get { return ZrecznoscPodstawa / 5; } }
        public int BonusDoHP { get { return WitalnoscPodstawa * 5; } }
        public int BonusDoEnergii { get { return InteligencjaPodstawa * 5; } }
        public int BonusDoSzansyNaTrafienie { get { return ZrecznoscPodstawa / 10; } }
        public int BonusDoSzansyNaKrytyczne { get { return ZrecznoscPodstawa / 10; } }


        //statystyki po obliczeniu bonusów 
        public int Sila { get { return SilaPodstawa; } }
        public int Zrecznosc { get { return ZrecznoscPodstawa; } }
        public int Witalnosc { get { return WitalnoscPodstawa; } }
        public int Inteligencja { get { return InteligencjaPodstawa; } }
        public int Obrazenia { get { return ObrazeniaPodstawa + BonusDoObrazen; } }
        public int Pancerz { get { return PancerzPodstawa + BonusDoPancerza; } }
        public int HP { get { return HPPodstawa + BonusDoHP; } }
        public int Energia { get { return EnergiaPodstawa + BonusDoEnergii; } }
        public int SzansaNaTrafienie { get { return SzansaNaTrafieniePodstawa + BonusDoSzansyNaTrafienie; } }
        public int SzansaNaKrytyczne { get { return SzansaNaKrytycznePodstawa + BonusDoSzansyNaKrytyczne; } }


        public int SumaStatystyk { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }
        public int Poziom { get { return SumaStatystyk / iloscPunktowDoRozdaniaCoPoziom; } }
        public int ZlotoZaZabicie { get
        {
            Random Losowanie = new Random();
            return Losowanie.Next(50, 150) / 100 * SumaStatystyk;
        }}
        public int DoswiadczenieZaZabicie { get { return SumaStatystyk; } }


        
        
        //Konstruktor domyślny
        public Przeciwnik()
        {
            Nazwa = "Nieustawiony potwór";
            ObrazekNaMapie = "Resources/Grafiki postaci na mapie/2/";
            ObrazekMowienia = "Resources/Grafiki postaci mówiących/Mówca1.png";
            ObrazekWalki = "Resources/Grafiki postaci walczących/szczur.png";

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

            UmiejetnosciFizyczne = new List<Umiejetnosc>();
            UmiejetnosciMagiczne = new List<Umiejetnosc>();
        }

        public Przeciwnik(String nazwa, String obrazekMowienia, String obrazekNaMapie, String obrazekWalki, int sila, int zrecznosc, int witalnosc, int inteligencja, int bazoweObrazenia, int bazowyPancerz, int bazoweHP, int bazowaEnergia, int bazowaSzansaNaTrafienie, int bazowaSzansaNaKrytyczne,List<Umiejetnosc> umiejetnosciFizyczne,List<Umiejetnosc> umiejetnosciMagiczne)
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



            this.UmiejetnosciFizyczne = new List<Umiejetnosc>();
            if (kopiowanyNPC.UmiejetnosciFizyczne != null)
            {
                foreach (Umiejetnosc umiejetnosc in kopiowanyNPC.UmiejetnosciFizyczne)
                {
                    this.UmiejetnosciFizyczne.Add(new Umiejetnosc(umiejetnosc));
                }
            }

            this.UmiejetnosciMagiczne = new List<Umiejetnosc>();
            if (kopiowanyNPC.UmiejetnosciMagiczne != null)
            {
                foreach (Umiejetnosc umiejetnosc in kopiowanyNPC.UmiejetnosciMagiczne)
                {
                    this.UmiejetnosciMagiczne.Add(new Umiejetnosc(umiejetnosc));
                }
            }
        }
    }
}
