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
        #region Zmienne i obiekty globalne
        //zmienne z wartością
        static int szerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
        static int wysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;

        //listy
        List<Postac> postac = new List<Postac>();
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();

        //zmienne sterujące
        int obecnaGrafikaWMenu = 0;
        MouseButtons poprzedniStanMyszy = MouseButtons.None;
        bool pokazOpcje=false;

        //przyciski
        Rectangle przyciskWyjdzObszar = new Rectangle(10, -30, szerokoscEkranu* 8/ 100, wysokoscEkranu *15/ 100);
        Rectangle przyciskOpcjeObszar = new Rectangle(10 + szerokoscEkranu * 8 / 100, -30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        Rectangle przyciskRuszajObszar = new Rectangle(10 + szerokoscEkranu * 8 / 100 * 2, -30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        #endregion

        #region Funkcje
        void RozmiescElementy()
        {
            PanelInformacje.Size = new Size(szerokoscEkranu,wysokoscEkranu/8);
            PanelInformacje.Location = new Point(0, wysokoscEkranu-PanelInformacje.Size.Height);
            PanelOpcje.Location = new Point(0, przyciskWyjdzObszar.Height + 50);
            PanelOpcje.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }
        void OdswiezMenu(int numerPrzycisku)
        {
            int powiekszenieSzerokosc = przyciskWyjdzObszar.Width * 10 / 100;
            int powiekszenieWysokosc = przyciskWyjdzObszar.Height * 10 / 100;

            Image obrazekTla = new Bitmap("Resources/Grafiki menu/Tło menu.png");
            Bitmap tlo = new Bitmap(obrazekTla, szerokoscEkranu, wysokoscEkranu);

            Image przyciskWyjscieObrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png");
            Image przyciskOpcjeObrazek = new Bitmap("Resources/Grafiki menu/Opcje.png");
            Image przyciskRuszajObrazek = new Bitmap("Resources/Grafiki menu/Ruszaj.png");
            Graphics GrafikaMenu = Graphics.FromImage(tlo);
            
            switch (numerPrzycisku)
            {
                case 0:
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.DrawImage(przyciskWyjscieObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    LabelInformacje.Text = "Witaj w grze Rzeź Ponad Grabież!";
                    break;
                case 1:
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.DrawImage(przyciskWyjscieObrazek, przyciskWyjdzObszar.X - powiekszenieSzerokosc / 2, przyciskWyjdzObszar.Y - powiekszenieWysokosc / 2, przyciskWyjdzObszar.Width + powiekszenieSzerokosc, przyciskWyjdzObszar.Height + powiekszenieWysokosc);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    LabelInformacje.Text = "Na pewno chcesz już wyjść?";
                    break;
                case 2:
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.DrawImage(przyciskWyjscieObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X - powiekszenieSzerokosc / 2, przyciskOpcjeObszar.Y - powiekszenieWysokosc / 2, przyciskOpcjeObszar.Width + powiekszenieSzerokosc, przyciskOpcjeObszar.Height + powiekszenieWysokosc);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    LabelInformacje.Text = "O tak, dobre przygotowanie to dobry początek wyprawy!";
                    break;
                case 3:
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.DrawImage(przyciskWyjscieObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X - powiekszenieSzerokosc / 2, przyciskRuszajObszar.Y - powiekszenieWysokosc / 2, przyciskRuszajObszar.Width + powiekszenieSzerokosc, przyciskRuszajObszar.Height + powiekszenieWysokosc);
                    LabelInformacje.Text = "Ruszajmy do boju!";
                    break;
            }
            Wyswietlacz.Image = tlo;
            GrafikaMenu.Dispose();
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

        public GlownyEkran()
        {
            InitializeComponent();
            RozmiescElementy();
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();
            OdswiezMenu(0);
            Zegar.Start();
        }

        #region Akcje związane z upływem czasu (bądź zapętleniem)

        private void Zegar_Tick(object sender, EventArgs e)
        {
            if (pokazOpcje == true)
                PanelOpcje.Visible = true;
            else
                PanelOpcje.Visible = false;

            if (przyciskWyjdzObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 1)
            {
                OdswiezMenu(1);
                obecnaGrafikaWMenu = 1;
            }
            else if (przyciskOpcjeObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 2)
            {
                OdswiezMenu(2);
                obecnaGrafikaWMenu = 2;
            }
            else if (przyciskRuszajObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 3)
            {
                OdswiezMenu(3);
                obecnaGrafikaWMenu = 3;
            }
            else if (!przyciskOpcjeObszar.Contains(MousePosition) && !przyciskRuszajObszar.Contains(MousePosition) && !przyciskWyjdzObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 0)
            {
                    OdswiezMenu(0);
                    obecnaGrafikaWMenu = 0;
            }


            if (obecnaGrafikaWMenu == 1 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {
                Close();
            }
            else if (obecnaGrafikaWMenu == 2 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {
                if (pokazOpcje == false)
                {
                    pokazOpcje = true;
                }
                else
                {
                    pokazOpcje = false;
                }
            }
            else if (obecnaGrafikaWMenu == 3 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {

            }

            poprzedniStanMyszy = MouseButtons;

            //LabelInformacyjny.Text = "Pozycja myszki: " + MousePosition.ToString() + "\n";
            //LabelInformacyjny.Text += MouseButtons.ToString() + "\n";
        }

        #endregion
    }
}
