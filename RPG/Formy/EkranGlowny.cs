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
        }

        #region Metody
        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "";

           /* PictureBoxMgla.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxMgla.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxMgla.Image = plansza;*/

            
            //Ustawienie przycisków
            PictureBoxWyjscie.Location = new Point(10, -10);
            PictureBoxEkranOpcje.Location = new Point(20 + PictureBoxWyjscie.Width, -10);
            PictureBoxWczytaj.Location = new Point(30 + PictureBoxWyjscie.Width + PictureBoxEkranOpcje.Width, -10);
            PictureBoxRuszaj.Location = new Point(40 + PictureBoxWyjscie.Width + PictureBoxEkranOpcje.Width + PictureBoxRuszaj.Width, -10);

            PictureBoxWyjscie.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Wiej.png"), PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);
            PictureBoxEkranOpcje.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Opcje.png"), PictureBoxEkranOpcje.Width * 5 / 8, PictureBoxEkranOpcje.Height * 7 / 8);
            PictureBoxRuszaj.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Do boju.png"), PictureBoxRuszaj.Width * 5 / 8, PictureBoxRuszaj.Height * 7 / 8);
            PictureBoxWczytaj.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Wczytaj.png"), PictureBoxWczytaj.Width * 5 / 8, PictureBoxWczytaj.Height * 7 / 8);

            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
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
            EkranGryTlo ekranGryTlo = new EkranGryTlo(ekranGry);

            EkranNowaGra ekranNowaGra = new EkranNowaGra(this, ekranGry, ekranGryTlo);
            EkranEkranNowaGraTlo ekranNowaGraTlo = new EkranEkranNowaGraTlo(ekranNowaGra);
            ekranNowaGraTlo.ShowDialog();
        }
       
        private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        {
            EkranGry ekranGry = new EkranGry(this, ekranOpcje);
            EkranGryTlo ekranGryTlo = new EkranGryTlo(ekranGry);

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
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Wyjdź z gry.";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wiej.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8 + powiekszenieX, PictureBoxWyjscie.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wiej.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);
            }
            LabelInformacje.Text = "";
        }

        private void PictureBoxWczytaj_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Wczytaj poprzednio zaczętą przygodę.";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wczytaj.png"))
            {
                PictureBoxWczytaj.BackgroundImage = new Bitmap(obrazek, PictureBoxWczytaj.Width * 5 / 8 + powiekszenieX, PictureBoxWczytaj.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxWczytaj_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wczytaj.png"))
            {
                PictureBoxWczytaj.BackgroundImage = new Bitmap(obrazek, PictureBoxWczytaj.Width * 5 / 8, PictureBoxWczytaj.Height * 7 / 8);
            }
        }

        private void PictureBoxEkranOpcje_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Dostosuj grę do swoich potrzeb.";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Opcje.png"))
            {
                PictureBoxEkranOpcje.BackgroundImage = new Bitmap(obrazek, PictureBoxEkranOpcje.Width * 5 / 8 + powiekszenieX, PictureBoxEkranOpcje.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxEkranOpcje_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Opcje.png"))
            {
                PictureBoxEkranOpcje.BackgroundImage = new Bitmap(obrazek, PictureBoxEkranOpcje.Width * 5 / 8, PictureBoxEkranOpcje.Height * 7 / 8);
            }
        }

        private void PictureBoxRuszaj_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Rozpocznij nową przygodę!";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Do boju.png"))
            {
                PictureBoxRuszaj.BackgroundImage = new Bitmap(obrazek, PictureBoxRuszaj.Width * 5 / 8 + powiekszenieX, PictureBoxRuszaj.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxRuszaj_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Do boju.png"))
            {
                PictureBoxRuszaj.BackgroundImage = new Bitmap(obrazek, PictureBoxRuszaj.Width * 5 / 8, PictureBoxRuszaj.Height * 7 / 8);
            }
        }
        #endregion
        
    }
}

