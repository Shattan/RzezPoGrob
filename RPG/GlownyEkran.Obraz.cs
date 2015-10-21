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
    partial class GlownyEkran
    {
        #region Zmienne i obiekty globalne
        //zmienne z wartością
        static int pozycjaEkranuX = Screen.PrimaryScreen.Bounds.X;
        static int pozycjaEkranuY = Screen.PrimaryScreen.Bounds.Y;
        static int szerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
        static int wysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;
        static int proporcjeEkranu = Screen.PrimaryScreen.Bounds.Height / Screen.PrimaryScreen.Bounds.Width;

        //zmienne sterujące
        int obecnaGrafikaWMenu = 0;
        MouseButtons poprzedniStanMyszy = MouseButtons.None;
        bool pokazOpcje = false;
        bool pelnyEkran = true;
        bool zawszeNaWierzchu = true;
        int obecnaSzerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
        int obecnaWysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;

        //przyciski
        Rectangle przyciskWyjdzObszar;
        Rectangle przyciskOpcjeObszar;
        Rectangle przyciskRuszajObszar;
        #endregion

        #region Funkcje
        void UstawEkran()
        {
            if (CheckBoxZawszeNaWierzchu.Checked == true && zawszeNaWierzchu != true)
            {
                TopMost = true;
                zawszeNaWierzchu = true;
            }
            else if (CheckBoxZawszeNaWierzchu.Checked == false && zawszeNaWierzchu != false)
            {
                TopMost = false;
                zawszeNaWierzchu = false;
            }

            if (CheckBoxPelnyEkran.Checked == true && pelnyEkran != true)
            {
                if (FormBorderStyle != FormBorderStyle.None)
                    FormBorderStyle = FormBorderStyle.None;
                if (WindowState != FormWindowState.Maximized)
                    WindowState = FormWindowState.Maximized;
                pozycjaEkranuX = Screen.PrimaryScreen.Bounds.X;
                pozycjaEkranuY = Screen.PrimaryScreen.Bounds.Y;
                szerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
                wysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;

                UstawPozycjeIWielkoscPrzyciskow(pozycjaEkranuX, pozycjaEkranuY, szerokoscEkranu, wysokoscEkranu);
                OdswiezMenu(0);
                RozmiescElementy();
                pelnyEkran = true;

                //obecnaSzerokoscEkranu = Width;
                //obecnaWysokoscEkranu = Height;
            }
            else
            {
                if (CheckBoxPelnyEkran.Checked == false)
                {
                    if (WindowState != FormWindowState.Normal)
                        WindowState = FormWindowState.Normal;
                    if (FormBorderStyle != FormBorderStyle.Sizable)
                        FormBorderStyle = FormBorderStyle.Sizable;
                    if (obecnaSzerokoscEkranu != szerokoscEkranu || obecnaWysokoscEkranu != wysokoscEkranu)
                    {
                        //Width = Screen.PrimaryScreen.Bounds.Width * 5 / 6;
                        //Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
                        //Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width * 5 / 6) / 2, (Screen.PrimaryScreen.Bounds.Height - Height * 5 / 6) / 2);

                        //pozycjaEkranuX = Location.X;
                        //pozycjaEkranuY = Location.Y;
                        //szerokoscEkranu = Width;
                        //wysokoscEkranu = Height;
                        //obecnaSzerokoscEkranu = Width;
                        //obecnaWysokoscEkranu = Height;

                        UstawPozycjeIWielkoscPrzyciskow(pozycjaEkranuX, pozycjaEkranuY, szerokoscEkranu, wysokoscEkranu);
                        OdswiezMenu(0);
                        RozmiescElementy();
                        pelnyEkran = false;
                    }
                }
            }
        }
        void UstawPozycjeIWielkoscPrzyciskow(int pozycjaEkranuX, int pozycjaEkranuY, int szerokoscEkranu, int wysokoscEkranu)
        {
            //przyciski
            przyciskWyjdzObszar = new Rectangle(pozycjaEkranuX + szerokoscEkranu * 2 / 100, pozycjaEkranuY - wysokoscEkranu * 5 / 100, szerokoscEkranu * 6 / 100, wysokoscEkranu * 15 / 100);
            przyciskOpcjeObszar = new Rectangle(pozycjaEkranuX + szerokoscEkranu * 2 / 100 + szerokoscEkranu * 6 / 100, pozycjaEkranuY - wysokoscEkranu * 5 / 100, szerokoscEkranu * 6 / 100, wysokoscEkranu * 15 / 100);
            przyciskRuszajObszar = new Rectangle(pozycjaEkranuX + szerokoscEkranu * 2 / 100 + szerokoscEkranu * 6 / 100 * 2, pozycjaEkranuY - wysokoscEkranu * 5 / 100, szerokoscEkranu * 6 / 100, wysokoscEkranu * 15 / 100);
        }
        void RozmiescElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            PanelInformacje.Size = new Size(szerokoscEkranu, wysokoscEkranu / 8);
            PanelInformacje.Location = new Point(0, wysokoscEkranu - PanelInformacje.Size.Height);
            PanelOpcje.Location = new Point(0, przyciskWyjdzObszar.Height + wysokoscEkranu / 50);
            PanelOpcje.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }
        void OdswiezMenu(int numerPrzycisku)
        {
            int powiekszenieSzerokosc = przyciskWyjdzObszar.Width * 10 / 100;
            int powiekszenieWysokosc = przyciskWyjdzObszar.Height * 10 / 100;

            Image obrazekTla = new Bitmap("Resources/Grafiki menu/Tło menu.png");
            Bitmap tlo = new Bitmap(obrazekTla, szerokoscEkranu, wysokoscEkranu);

            Image przyciskWyjdzObrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png");
            Image przyciskOpcjeObrazek = new Bitmap("Resources/Grafiki menu/Opcje.png");
            Image przyciskRuszajObrazek = new Bitmap("Resources/Grafiki menu/Ruszaj.png");
            Graphics GrafikaMenu = Graphics.FromImage(tlo);

            switch (numerPrzycisku)
            {
                case 0:
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.TranslateTransform(-pozycjaEkranuX, -pozycjaEkranuY);
                    GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    GrafikaMenu.TranslateTransform(pozycjaEkranuX, pozycjaEkranuY);
                    LabelInformacje.Text = "Witaj w grze Rzeź Po Grób!";
                    break;
                case 1:
                    OdtworzDzwiek(odtwarzacz2, "Resources/Dźwięki/szyld.wav");
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.TranslateTransform(-pozycjaEkranuX, -pozycjaEkranuY);
                    GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X - powiekszenieSzerokosc / 2, przyciskWyjdzObszar.Y - powiekszenieWysokosc / 2, przyciskWyjdzObszar.Width + powiekszenieSzerokosc, przyciskWyjdzObszar.Height + powiekszenieWysokosc);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    GrafikaMenu.TranslateTransform(pozycjaEkranuX, pozycjaEkranuY);
                    LabelInformacje.Text = "Na pewno chcesz już wyjść?";
                    break;
                case 2:
                    OdtworzDzwiek(odtwarzacz3, "Resources/Dźwięki/szyld.wav");
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.TranslateTransform(-pozycjaEkranuX, -pozycjaEkranuY);
                    GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X - powiekszenieSzerokosc / 2, przyciskOpcjeObszar.Y - powiekszenieWysokosc / 2, przyciskOpcjeObszar.Width + powiekszenieSzerokosc, przyciskOpcjeObszar.Height + powiekszenieWysokosc);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                    GrafikaMenu.TranslateTransform(pozycjaEkranuX, pozycjaEkranuY);
                    LabelInformacje.Text = "O tak, dobre przygotowanie to dobry początek wyprawy!";
                    break;
                case 3:
                    OdtworzDzwiek(odtwarzacz4, "Resources/Dźwięki/szyld.wav");
                    GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                    GrafikaMenu.TranslateTransform(-pozycjaEkranuX, -pozycjaEkranuY);
                    GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                    GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                    GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X - powiekszenieSzerokosc / 2, przyciskRuszajObszar.Y - powiekszenieWysokosc / 2, przyciskRuszajObszar.Width + powiekszenieSzerokosc, przyciskRuszajObszar.Height + powiekszenieWysokosc);
                    GrafikaMenu.TranslateTransform(pozycjaEkranuX, pozycjaEkranuY);
                    LabelInformacje.Text = "Ruszajmy do boju!";
                    break;
            }

            Wyswietlacz.Image = tlo;
            GrafikaMenu.Dispose();
        }
        #endregion
    }
}
