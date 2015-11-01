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
        private EkranGlownyTlo ekranGlownyTlo;
        private EkranEkranOpcjeTlo ekranEkranOpcjeTlo;
        public EkranGryTlo ekranGryTlo;

        public EkranOpcje ekranOpcje;
        #endregion

        public EkranGlowny(EkranGlownyTlo ekranGlownyTlo)
        {
            InitializeComponent();
            this.ekranGlownyTlo = ekranGlownyTlo;

            ekranOpcje = new EkranOpcje(this);
            ekranEkranOpcjeTlo = new EkranEkranOpcjeTlo(ekranOpcje);

            //ekranOpcje.OdtworzDzwiek(ekranOpcje.odtwarzaczMuzyki, "Resources/Dźwięki/VC-HOfaH.wav");
            UstawElementyNaEkranie();

            //#if DEBUG
            ////Przyspieszenie dostania sie na ekran z walka, 
            //EkranGry ekranGry = new EkranGry(this, ekranOpcje);
            //ekranGryTlo = new EkranGryTlo(ekranGry);

            ////Deserializuj z XML i wpisz do je ekranGry
            //ekranGryTlo.ShowDialog();
            //#endif
        }

        #region Metody
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

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");


            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "";

           /* PictureBoxMgla.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxMgla.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxMgla.Image = plansza;*/


            //Ustawienie przycisków
            int szerokoscPrzyciskow = Screen.PrimaryScreen.Bounds.Width * 7 / 100;
            int wysokoscPrzyciskow = Screen.PrimaryScreen.Bounds.Height * 15 / 100;
            PictureBoxWyjdz.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxOpcje.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxWczytaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxRuszaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);

            const int odlegloscMiedzyPrzyciskami = 15;
            const int podniesieniePrzyciskow = 10;
            PictureBoxWyjdz.Location = new Point(odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxOpcje.Location = new Point(PictureBoxWyjdz.Location.X + PictureBoxOpcje.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxWczytaj.Location = new Point(PictureBoxOpcje.Location.X + PictureBoxWczytaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X + PictureBoxRuszaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            //Przeniesienie przyciskow na prawa strone:
            //PictureBoxWczytaj.Location = new Point(Screen.PrimaryScreen.Bounds.Width -PictureBoxEkranOpcje.Width- 10, -10);
            //PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X - PictureBoxRuszaj.Width - 10, -10);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }
        #endregion

        #region Obsluga zdarzen przyciskow
        private void PictureBoxEkranOpcje_Click(object sender, EventArgs e)
        {
            ekranEkranOpcjeTlo.ShowDialog();
        }

        private void PictureBoxRuszaj_Click(object sender, EventArgs e)
        {
            EkranGry ekranGry = new EkranGry(this, ekranOpcje);
            ekranGryTlo = new EkranGryTlo(ekranGry);

            EkranNowaGra ekranNowaGra = new EkranNowaGra(this, ekranGry, ekranGryTlo);
            EkranEkranNowaGraTlo ekranNowaGraTlo = new EkranEkranNowaGraTlo(ekranNowaGra);
            ekranNowaGraTlo.ShowDialog();
        }
       
        private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        {
            EkranGry ekranGry = new EkranGry(this, ekranOpcje);
            ekranGryTlo = new EkranGryTlo(ekranGry);

            //Deserializuj z XML i wpisz do je ekranGry
            ekranGryTlo.ShowDialog();
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
        #endregion

        #region Powiekszanie przyciskow
        //Moim zdaniem, lepiej zasotoswac funkcje Hover - obsluguje zarowno MouseEnter jak i MouseLeave - 
        //i wszystki te funkcje mozna by zastapic jedna, poprzez obsluge sender-a.
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

        private void PictureBoxEkranOpcje_MouseEnter(object sender, EventArgs e)
        {
            ekranOpcje.OdtworzEfekt(3, "Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Dostosuj grę do swoich potrzeb.";
            PrzeskalujPrzycisk(true, PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
        }

        private void PictureBoxEkranOpcje_MouseLeave(object sender, EventArgs e)
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
        
    }
}

