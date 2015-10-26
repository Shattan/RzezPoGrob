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
    public partial class GlownyEkran : Form
    {
        public OpcjeTlo opcjeTlo;
        public Gra gra;

        //int przesuniecie = 0;
        //Bitmap plansza= new Bitmap("Resources/Plansza.png");

        public GlownyEkran()
        {
            InitializeComponent();

            opcjeTlo = new OpcjeTlo(this);
            //opcje.OdtworzDzwiek(opcje.odtwarzaczMuzyki, "Resources/Dźwięki/VC-HOfaH.wav");
            LabelInformacje.Text = "";
            //Obraz
            UstawElementyNaEkranie();

            //Gra

            timer1.Start();
        }


        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło menu.png");

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);

           /* PictureBoxMgla.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxMgla.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxMgla.Image = plansza;*/

            
            //Ustawienie przycisków
            PictureBoxWyjscie.Location = new Point(10, -30);
            PictureBoxOpcje.Location = new Point(20 + PictureBoxWyjscie.Width, -30);
            PictureBoxRuszaj.Location = new Point(30 + PictureBoxWyjscie.Width + PictureBoxOpcje.Width, -30);
            PictureBoxWczytaj.Location = new Point(40 + PictureBoxWyjscie.Width + PictureBoxOpcje.Width + PictureBoxRuszaj.Width, -30);

            PictureBoxWyjscie.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Wyjście.png"), PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);
            PictureBoxOpcje.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Opcje.png"), PictureBoxOpcje.Width * 5 / 8, PictureBoxOpcje.Height * 7 / 8);
            PictureBoxRuszaj.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Ruszaj.png"), PictureBoxRuszaj.Width * 5 / 8, PictureBoxRuszaj.Height * 7 / 8);
            PictureBoxWczytaj.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Wczytaj.png"), PictureBoxWczytaj.Width * 5 / 8, PictureBoxWczytaj.Height * 7 / 8);

            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
        }


        //Metoda obslugujaca zdarzenie klikniecia na przycisk "Opcje"
        private void PictureBoxOpcje_Click(object sender, EventArgs e)
        {
            if (opcjeTlo.Visible == false)
            {
                opcjeTlo.ShowDialog();
            }
            else
            {
                opcjeTlo.Visible = false;
            }
        }


        private void PictureBoxRuszaj_Click(object sender, EventArgs e)
        {
            gra = new Gra(this, false);         //Uruchamiamy gre; false - nowa gra
            gra.Visible = true;                 //pokazujemy plansze gry
            this.Visible = false;               //Ukrywamy to okno menu
        }

       
        private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        {
            gra = new Gra(this, true);          //Uruchamiamy gre; true - wycztauj dane 
            gra.Visible = true;                 //pokazujemy plansze gry
            this.Visible = false;               //Ukrywamy to okno menu
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          /*  using (Graphics grafikaGracza = Graphics.FromImage(PictureBoxMgla.Image))
            {
                grafikaGracza.DrawImage(new Bitmap("Resources/Grafiki gracza/W dół.gif"), PictureBoxMgla.Width / 2, PictureBoxMgla.Height / 2);
                PictureBoxMgla.Image = PictureBoxMgla.Image;
            }
            PictureBoxMgla.Location = new Point(przesuniecie - plansza.Width / 2, 0 - plansza.Height / 3);*/
            /*
            panel1.Location = new Point(panel1.Location.X,przesunięcie);
            */
            //przesuniecie+=5;
        }


        #region Powiekszanie przyciskow
        //Moim zdaniem, lepiej zasotoswac funkcje Hover - obsluguje zarowno MouseEnter jak i MouseLeave - 
        //i wszystki te funkcje mozna by zastapic jedna, poprzez obsluge sender-a.
        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Wyjscie z Gry";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8 + powiekszenieX, PictureBoxWyjscie.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);
            }
            LabelInformacje.Text = "";
        }

        private void PictureBoxWczytaj_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
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

        private void PictureBoxOpcje_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Opcje.png"))
            {
                PictureBoxOpcje.BackgroundImage = new Bitmap(obrazek, PictureBoxOpcje.Width * 5 / 8 + powiekszenieX, PictureBoxOpcje.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxOpcje_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Opcje.png"))
            {
                PictureBoxOpcje.BackgroundImage = new Bitmap(obrazek, PictureBoxOpcje.Width * 5 / 8, PictureBoxOpcje.Height * 7 / 8);
            }
        }

        private void PictureBoxRuszaj_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Ruszaj.png"))
            {
                PictureBoxRuszaj.BackgroundImage = new Bitmap(obrazek, PictureBoxRuszaj.Width * 5 / 8 + powiekszenieX, PictureBoxRuszaj.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxRuszaj_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Ruszaj.png"))
            {
                PictureBoxRuszaj.BackgroundImage = new Bitmap(obrazek, PictureBoxRuszaj.Width * 5 / 8, PictureBoxRuszaj.Height * 7 / 8);
            }
        }
        #endregion
    }
}

