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

using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

namespace RPG
{
    public partial class EkranGlowny : Form
    {
        #region Zmienne
        //Dostep dla tej formy
        private EkranGlownyTlo ekranGlownyTlo;
        private EkranEkranOpcjeTlo ekranEkranOpcjeTlo;

        //Dostepne dla "EkranGry"
        public EkranGryTloMapa ekranGryTloMapa;
        public EkranGryTloObiekty ekranGryTloObiekty;
        public EkranGryTloUI ekranGryTloUI;

        /* Od najwyżej do najzniszej położonej warstwy Form:
         * EkranGry
         * EkranGryUI
         * EkranGryTloObiekty
         * EkranGryTloMapa
         */

        //Dostep dla EkgranGryTlo*
        public EkranGry ekranGry;

        //Dostępne dla wszystkich "Ekran-ów"
        public EkranOpcje ekranOpcje;
        #endregion

        public EkranGlowny(EkranGlownyTlo ekranGlownyTlo)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            //Inicjalizacja Form
            this.ekranGlownyTlo = ekranGlownyTlo;
            this.ekranOpcje = new EkranOpcje(this);
            this.ekranEkranOpcjeTlo = new EkranEkranOpcjeTlo(ekranOpcje);

            //Dzwiek zakmentowany ze wzgledow ciaglego debugowania
            //ekranOpcje.OdtworzDzwiek(ekranOpcje.odtwarzaczMuzyki, "Resources/Dźwięki/VC-HOfaH.wav");

        }

        #region Metody
        void RozmiescElementy()
        {
            //Zmaksymalizowanie okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "";

            //Ustawienie wielkości przycisków
            int szerokoscPrzyciskow = Width * 7 / 100;
            int wysokoscPrzyciskow = Height * 15 / 100;
            PictureBoxWyjdz.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxOpcje.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxWczytaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxRuszaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);

            //Ustawienie pozycji przycisków
            const int odlegloscMiedzyPrzyciskami = 15;
            const int podniesieniePrzyciskow = 10;
            PictureBoxWyjdz.Location = new Point(odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxOpcje.Location = new Point(PictureBoxWyjdz.Location.X + PictureBoxOpcje.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxWczytaj.Location = new Point(PictureBoxOpcje.Location.X + PictureBoxWczytaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X + PictureBoxRuszaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);

            //Przeniesienie przyciskow na prawa strone:
            //PictureBoxWyjdz.Location = new Point(Width - PictureBoxOpcje.Width - 10, -10);
            //PictureBoxOpcje.Location = new Point(PictureBoxWyjdz.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            //PictureBoxWczytaj.Location = new Point(PictureBoxOpcje.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            //PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Obrazy dla przycisków
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }

        void PrzeskalujPrzycisk(bool powiekszanie, PictureBox przycisk, String obrazPrzycisku)
        {
            int powiekszenie;
            if (powiekszanie == true)
            {
                powiekszenie = Width * 1 / 100;
            }
            else
            {
                powiekszenie = -Width * 1 / 100;
            }
            przycisk.Size = new Size(przycisk.Width + powiekszenie, przycisk.Height + powiekszenie);
            przycisk.Location = new Point(przycisk.Location.X - powiekszenie / 2, przycisk.Location.Y - powiekszenie / 2);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(przycisk, obrazPrzycisku);
        }
        #endregion
     
        #region Zdarzenia
        private void PictureBoxOpcje_Click(object sender, EventArgs e)
        {
            ekranEkranOpcjeTlo.ShowDialog();
        }

        private void PictureBoxRuszaj_Click(object sender, EventArgs e)
        {
            //Uruchomienie EkranGry.ShowDialog() zostanie wywloane w EkranNowaGra
            ekranGry = new EkranGry(this, ekranOpcje);
            ekranGryTloMapa = new EkranGryTloMapa(this);
            ekranGryTloObiekty = new EkranGryTloObiekty(this);
            ekranGryTloUI = new EkranGryTloUI(this);

            EkranNowaGra ekranNowaGra = new EkranNowaGra(this, ekranGry, ekranGryTloMapa);
            EkranEkranNowaGraTlo ekranNowaGraTlo = new EkranEkranNowaGraTlo(ekranNowaGra);
            ekranNowaGraTlo.ShowDialog();
        }
       
        private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        {
            ekranGry = new EkranGry(this, ekranOpcje);
            ekranGryTloMapa = new EkranGryTloMapa(this);
            ekranGryTloObiekty = new EkranGryTloObiekty(this);
            ekranGryTloUI = new EkranGryTloUI(this);

            //Deserializuj z XML 
            //i zapisz dane w ekranGry.WczytajDaneXML()
            ekranGryTloMapa.ShowDialog();
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
        
        #region Powiekszanie przyciskow
        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            ekranOpcje.OdtworzEfekt(1, "Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Wyjdź z gry.";
            PrzeskalujPrzycisk(true,PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false,PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
        }

        private void PictureBoxWczytaj_MouseEnter(object sender, EventArgs e)
        {
            ekranOpcje.OdtworzEfekt(2, "Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Wczytaj poprzednio zaczętą przygodę.";
            PrzeskalujPrzycisk(true, PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
        }

        private void PictureBoxWczytaj_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
        }

        private void PictureBoxOpcje_MouseEnter(object sender, EventArgs e)
        {
            ekranOpcje.OdtworzEfekt(3, "Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Dostosuj grę do swoich potrzeb.";
            PrzeskalujPrzycisk(true, PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
        }

        private void PictureBoxOpcje_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
        }

        private void PictureBoxRuszaj_MouseEnter(object sender, EventArgs e)
        {
            ekranOpcje.OdtworzEfekt(4, "Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Rozpocznij nową przygodę!";
            PrzeskalujPrzycisk(true, PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }

        private void PictureBoxRuszaj_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }
        #endregion

        #endregion

    }
}

