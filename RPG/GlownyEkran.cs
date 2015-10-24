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

//dodane przeze mnie
using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

#region Pozostałe biblioteki
#endregion


namespace RPG
{
    public partial class GlownyEkran : Form
    {
        //GlownyEkran jest nasza podstawa, poki gra dziala, dziala i on
        //Opcje sa zawsze uruchomione w tle, odpowiadaja m.in. za dziwiek
        //Do opcji w inncyh formach dostajemy sie poprzez EkranGlowny, dlatego jest publiczny;
        
        public Opcje opcje;
        public Gra gra;

        public GlownyEkran()
        {
            InitializeComponent();

            opcje = new Opcje(this);
            //opcje.OdtworzDzwiek(opcje.odtwarzaczMuzyki, "Resources/Dźwięki/VC-HOfaH.wav");

            //Obraz
            UstawElementyNaEkranie();

            //Gra

            //Czas
            Zegar.Start();
        }

        //Moim zdaniem zegar do wywalenia z Menu, damy go w grze
        private void Zegar_Tick(object sender, EventArgs e)
        {

        }


        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            PanelWyswietlacza.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło menu.png");

            //Ustawienia dolnego panelu z informacjami
            PanelInformacje.Size = new Size(Width, Height / 8);
            PanelInformacje.Location = new Point(0, Width - PanelInformacje.Size.Height);


            //Ustawienie przycisków
            PictureBoxWyjscie.Location = new Point(10, -30);
            PictureBoxOpcje.Location = new Point(20 + PictureBoxWyjscie.Width, -10);
            PictureBoxRuszaj.Location = new Point(30 + PictureBoxWyjscie.Width + PictureBoxOpcje.Width, -10);
            Image obrazekWyjdz = new Bitmap("Resources/Grafiki menu/Szyld.png");
            PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazekWyjdz, PictureBoxWyjscie.Width * 2 / 3, PictureBoxWyjscie.Height * 2 / 3);
            PictureBoxOpcje.Image = new Bitmap(obrazekWyjdz, PictureBoxOpcje.Width, PictureBoxOpcje.Height);
            PictureBoxRuszaj.Image = new Bitmap(obrazekWyjdz, PictureBoxRuszaj.Width, PictureBoxRuszaj.Height);
        }

        //Metoda obslugujaca zdarzenie klikniecia na przycisk "Opcje"
        private void PictureBoxOpcje_Click(object sender, EventArgs e)
        {
            if (opcje.Visible == false)
            {
                opcje.Visible = true;
                opcje.BringToFront();
            }
            else
            {
                opcje.Visible = false;
            }
        }

        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 2 / 3 + powiekszenieX, PictureBoxWyjscie.Height * 2 / 3 + powiekszenieY);
            }
            PictureBoxOpcje.Bounds = new Rectangle(PictureBoxOpcje.Location.X - powiekszenieX / 2, PictureBoxOpcje.Location.Y - powiekszenieY / 2, PictureBoxOpcje.Width + powiekszenieX, PictureBoxOpcje.Height + powiekszenieY);
            PictureBoxRuszaj.Bounds = new Rectangle(PictureBoxRuszaj.Location.X - powiekszenieX / 2, PictureBoxRuszaj.Location.Y - powiekszenieY / 2, PictureBoxRuszaj.Width + powiekszenieX, PictureBoxRuszaj.Height + powiekszenieY);
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            int powiekszenieX = -Width * 1 / 100;
            int powiekszenieY = -Width * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 2 / 3 + powiekszenieX, PictureBoxWyjscie.Height * 2 / 3 + powiekszenieY);
            }
            PictureBoxOpcje.Bounds = new Rectangle(PictureBoxOpcje.Location.X - powiekszenieX / 2, PictureBoxOpcje.Location.Y - powiekszenieY / 2, PictureBoxOpcje.Width + powiekszenieX, PictureBoxOpcje.Height + powiekszenieY);
            PictureBoxRuszaj.Bounds = new Rectangle(PictureBoxRuszaj.Location.X - powiekszenieX / 2, PictureBoxRuszaj.Location.Y - powiekszenieY / 2, PictureBoxRuszaj.Width + powiekszenieX, PictureBoxRuszaj.Height + powiekszenieY);
        }

        private void PictureBoxRuszaj_Click(object sender, EventArgs e)
        {
            //Uruchamiamy kreatore nowej gry
            NowaGra nowaGra = new NowaGra(this);
            nowaGra.Visible = true;
            this.Visible = false;
            
        }

        //NIE MA JESZCZE TEGO BUTTONU: WCZYTAJ
        //private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        //{
        //    //Wczytujemy gre
        //    gra = new Gra(this);

        //}

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

