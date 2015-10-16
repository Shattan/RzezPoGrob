#region Biblioteki systemowe
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

#region Pozostałe biblioteki
#endregion


namespace RPG
{
    public partial class GlownyEkran : Form
    {
        #region Klasy
        class Postac
        {
            public string nazwa;

            public Postac(String _nazwa) 
            {
                nazwa = _nazwa;
            }
        }
        class Umiejetnosc
        {
            public string nazwa;

            public Umiejetnosc(String _nazwa)
            {
                nazwa = _nazwa;
            }
        }
        class Ekwipunek
        {
            public string nazwa;

            public Ekwipunek(String _nazwa)
            {
                nazwa = _nazwa;
            }
        }
        class Przeszkoda
        {
            public string nazwa;

            public Przeszkoda(String _nazwa)
            {
                nazwa = _nazwa;
            }
        }
        #endregion

        #region Funkcje
        void UstawPoczatkoweWartosci()
        {
            Image obrazekTla = new Bitmap("Grafiki menu/Tło menu.png");
            Graphics tlo = Graphics.FromImage(obrazekTla);
            Wyswietlacz.BackgroundImage = PictureBoxWyjdz.BackgroundImage = new Bitmap("Grafiki menu/Tło menu.png");
            PictureBoxWyjdz.Image = new Bitmap("Grafiki menu/Szyld z cieniem.png");
        }

        void UtworzPostacie()
        {
            postac.Add(new Postac("Lord Krwawy Mati"));                     //index 0
            postac.Add(new Postac("Lord Seba"));                            //index 1
        }
        void UtworzUmiejetnosci()
        {
            umiejetnosc.Add(new Umiejetnosc("Wymachiwanie"));               //index 0
        }
        void UtworzPrzedmiotyEkwipunku()
        {
            ekwipunek.Add(new Ekwipunek("Cywilne ubranie"));                //index 0
        }
        void UtworzPrzeszkody()
        {
            przeszkoda.Add(new Przeszkoda("Drzewo"));                       //index 0
        }
        #endregion

        #region Zmienne i obiekty globalne
        List<Postac> postac = new List<Postac>();
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();
        #endregion

        public GlownyEkran()
        {
            InitializeComponent();
            UstawPoczatkoweWartosci();
        }

        #region Obsługa przycisków
        #endregion

        private void PictureBoxWyjdz_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
