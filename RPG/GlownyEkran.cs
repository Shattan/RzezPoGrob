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
        #region Zmienne i obiekty globalne
        //zmienna umozliwiajaca odtwarzanie muzyki
        MediaPlayer odtwarzacz1 = new MediaPlayer();
        MediaPlayer odtwarzacz2 = new MediaPlayer();
        MediaPlayer odtwarzacz3 = new MediaPlayer();
        MediaPlayer odtwarzacz4 = new MediaPlayer();
        MediaPlayer odtwarzacz5 = new MediaPlayer();
        MediaPlayer odtwarzacz6 = new MediaPlayer();

        //zmienne z wartością
        static int pozycjaEkranuX = Screen.PrimaryScreen.Bounds.X;
        static int pozycjaEkranuY = Screen.PrimaryScreen.Bounds.Y;
        static int szerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
        static int wysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;
        static int proporcjeEkranu = Screen.PrimaryScreen.Bounds.Height / Screen.PrimaryScreen.Bounds.Width;

        //listy
        List<Postac> postac = new List<Postac>();
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();

        //zmienne sterujące
        int obecnaGrafikaWMenu = 0;
        double obecnyPoziomGlosnosciMuzyki = 0.5;
        double obecnyPoziomGlosnosciEfektow = 0.5;
        MouseButtons poprzedniStanMyszy = MouseButtons.None;
        bool pokazOpcje = false;
        bool pelnyEkran = true;
        bool zawszeNaWierzchu = true;
        int obecnaSzerokoscEkranu = 0;
        int obecnaWysokoscEkranu = 0;

        //przyciski
        Rectangle przyciskWyjdzObszar = new Rectangle(pozycjaEkranuX + 10, pozycjaEkranuY - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        Rectangle przyciskOpcjeObszar = new Rectangle(pozycjaEkranuX + 10 + szerokoscEkranu * 8 / 100, pozycjaEkranuY - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        Rectangle przyciskRuszajObszar = new Rectangle(pozycjaEkranuX + 10 + szerokoscEkranu * 8 / 100 * 2, pozycjaEkranuY - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        #endregion

        #region Funkcje
        void OdtworzDzwiek(MediaPlayer odtwarzacz, String sciezka)
        {
            odtwarzacz.Open(new Uri(sciezka, UriKind.Relative));
            odtwarzacz.Play();
        }
        void ZatrzymajDzwiek(MediaPlayer odtwarzacz)
        {
            odtwarzacz.Stop();
        }
        void UstawGlosnosc()
        {
            #region Ustawienia Muzyki (odtwarzacz 1)
            if (CheckBoxWylaczMuzyke.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.0)
            {
                odtwarzacz1.Volume = 0.0;
                RadioButtonGlosnoscMuzyki1.Enabled = false;
                RadioButtonGlosnoscMuzyki2.Enabled = false;
                RadioButtonGlosnoscMuzyki3.Enabled = false;
                RadioButtonGlosnoscMuzyki4.Enabled = false;
                RadioButtonGlosnoscMuzyki5.Enabled = false;
                RadioButtonGlosnoscMuzyki6.Enabled = false;
                RadioButtonGlosnoscMuzyki7.Enabled = false;
                RadioButtonGlosnoscMuzyki8.Enabled = false;
                RadioButtonGlosnoscMuzyki9.Enabled = false;
                RadioButtonGlosnoscMuzyki10.Enabled = false;
                obecnyPoziomGlosnosciMuzyki = 0.0;
            }

            if (CheckBoxWylaczMuzyke.Checked == false)
            {
                RadioButtonGlosnoscMuzyki1.Enabled = true;
                RadioButtonGlosnoscMuzyki2.Enabled = true;
                RadioButtonGlosnoscMuzyki3.Enabled = true;
                RadioButtonGlosnoscMuzyki4.Enabled = true;
                RadioButtonGlosnoscMuzyki5.Enabled = true;
                RadioButtonGlosnoscMuzyki6.Enabled = true;
                RadioButtonGlosnoscMuzyki7.Enabled = true;
                RadioButtonGlosnoscMuzyki8.Enabled = true;
                RadioButtonGlosnoscMuzyki9.Enabled = true;
                RadioButtonGlosnoscMuzyki10.Enabled = true;

                if (RadioButtonGlosnoscMuzyki1.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.1)
                {
                    odtwarzacz1.Volume = 0.1;
                    obecnyPoziomGlosnosciMuzyki = 0.1;
                }
                if (RadioButtonGlosnoscMuzyki2.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.2)
                {
                    odtwarzacz1.Volume = 0.2;
                    obecnyPoziomGlosnosciMuzyki = 0.2;
                }
                if (RadioButtonGlosnoscMuzyki3.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.3)
                {
                    odtwarzacz1.Volume = 0.3;
                    obecnyPoziomGlosnosciMuzyki = 0.3;
                }
                if (RadioButtonGlosnoscMuzyki4.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.4)
                {
                    odtwarzacz1.Volume = 0.4;
                    obecnyPoziomGlosnosciMuzyki = 0.4;
                }
                if (RadioButtonGlosnoscMuzyki5.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.5)
                {
                    odtwarzacz1.Volume = 0.5;
                    obecnyPoziomGlosnosciMuzyki = 0.5;
                }
                if (RadioButtonGlosnoscMuzyki6.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.6)
                {
                    odtwarzacz1.Volume = 0.6;
                    obecnyPoziomGlosnosciMuzyki = 0.6;
                }
                if (RadioButtonGlosnoscMuzyki7.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.7)
                {
                    odtwarzacz1.Volume = 0.7;
                    obecnyPoziomGlosnosciMuzyki = 0.7;
                }
                if (RadioButtonGlosnoscMuzyki8.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.8)
                {
                    odtwarzacz1.Volume = 0.8;
                    obecnyPoziomGlosnosciMuzyki = 0.8;
                }
                if (RadioButtonGlosnoscMuzyki9.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.9)
                {
                    odtwarzacz1.Volume = 0.9;
                    obecnyPoziomGlosnosciMuzyki = 0.9;
                }
                if (RadioButtonGlosnoscMuzyki10.Checked == true && obecnyPoziomGlosnosciMuzyki != 1.0)
                {
                    odtwarzacz1.Volume = 1.0;
                    obecnyPoziomGlosnosciMuzyki = 1.0;
                }
            }
            #endregion

            #region Ustawienia Efektów Dźwiękowych (odtwarzacze 2-6)
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == true && obecnyPoziomGlosnosciEfektow != 0.0)
            {
                odtwarzacz2.Volume = 0.0;
                ZmienGlosnoscOdtwarzaczyEfektow(0.0);
                obecnyPoziomGlosnosciEfektow = 0.0;

                RadioButtonGlosnoscEfektowDzwiekowych1.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych2.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych3.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych4.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych5.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych6.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych7.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych8.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych9.Enabled = false;
                RadioButtonGlosnoscEfektowDzwiekowych10.Enabled = false;
            }
            else
            {
                RadioButtonGlosnoscEfektowDzwiekowych1.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych2.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych3.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych4.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych5.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych6.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych7.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych8.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych9.Enabled = true;
                RadioButtonGlosnoscEfektowDzwiekowych10.Enabled = true;

                if (RadioButtonGlosnoscEfektowDzwiekowych1.Checked == true && obecnyPoziomGlosnosciEfektow != 0.1)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.1);
                    obecnyPoziomGlosnosciEfektow = 0.1;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych2.Checked == true && obecnyPoziomGlosnosciEfektow != 0.2)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.2);
                    obecnyPoziomGlosnosciEfektow = 0.2;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych3.Checked == true && obecnyPoziomGlosnosciEfektow != 0.3)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.3);
                    obecnyPoziomGlosnosciEfektow = 0.3;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych4.Checked == true && obecnyPoziomGlosnosciEfektow != 0.4)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.4);
                    obecnyPoziomGlosnosciEfektow = 0.4;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych5.Checked == true && obecnyPoziomGlosnosciEfektow != 0.5)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.5);
                    obecnyPoziomGlosnosciEfektow = 0.5;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych6.Checked == true && obecnyPoziomGlosnosciEfektow != 0.6)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.6);
                    obecnyPoziomGlosnosciEfektow = 0.6;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych7.Checked == true && obecnyPoziomGlosnosciEfektow != 0.7)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.7);
                    obecnyPoziomGlosnosciEfektow = 0.7;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych8.Checked == true && obecnyPoziomGlosnosciEfektow != 0.8)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.8);
                    obecnyPoziomGlosnosciEfektow = 0.8;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych9.Checked == true && obecnyPoziomGlosnosciEfektow != 0.9)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(0.9);
                    obecnyPoziomGlosnosciEfektow = 0.9;
                }
                if (RadioButtonGlosnoscEfektowDzwiekowych10.Checked == true && obecnyPoziomGlosnosciEfektow != 1.0)
                {
                    ZmienGlosnoscOdtwarzaczyEfektow(1.0);
                    obecnyPoziomGlosnosciEfektow = 1.0;
                }
            }
            #endregion
        }
        void ZmienGlosnoscOdtwarzaczyEfektow(double glosnosc)
        {
            odtwarzacz2.Volume = glosnosc;
            odtwarzacz3.Volume = glosnosc;
            odtwarzacz4.Volume = glosnosc;
            odtwarzacz5.Volume = glosnosc;
            odtwarzacz6.Volume = glosnosc;
        }
        void UstawEkran()
        {
            if (CheckBoxZawszeNaWierzchu.Checked == true && zawszeNaWierzchu!=true)
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
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                pozycjaEkranuX = Screen.PrimaryScreen.Bounds.X;
                pozycjaEkranuY = Screen.PrimaryScreen.Bounds.Y;
                szerokoscEkranu = Screen.PrimaryScreen.Bounds.Width;
                wysokoscEkranu = Screen.PrimaryScreen.Bounds.Height;

                UstawPozycjeIWielkoscPrzyciskow(pozycjaEkranuX, pozycjaEkranuY, szerokoscEkranu, wysokoscEkranu);
                OdswiezMenu(0);
                RozmiescElementy();
                pelnyEkran = true;
            }
            else if (CheckBoxPelnyEkran.Checked == false && (obecnaSzerokoscEkranu != szerokoscEkranu || obecnaWysokoscEkranu != wysokoscEkranu))
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
                Width = Screen.PrimaryScreen.Bounds.Width * 5 / 6;
                Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width * 5 / 6) / 2, (Screen.PrimaryScreen.Bounds.Height - Height * 5 / 6) / 2);

                pozycjaEkranuX = Location.X;
                pozycjaEkranuY = Location.Y;
                obecnaSzerokoscEkranu = szerokoscEkranu = Width;
                obecnaWysokoscEkranu = wysokoscEkranu = Height;

                UstawPozycjeIWielkoscPrzyciskow(pozycjaEkranuX, pozycjaEkranuY, szerokoscEkranu, wysokoscEkranu);
                OdswiezMenu(0);
                RozmiescElementy();
                pelnyEkran = false;
            }
        }
        void UstawPozycjeIWielkoscPrzyciskow(int pozycjaEkranuX, int pozycjaEkranuY, int szerokoscEkranu, int wysokoscEkranu)
        {
            przyciskWyjdzObszar = new Rectangle(0, - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
            przyciskOpcjeObszar = new Rectangle(0 + szerokoscEkranu * 8 / 100,  - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
            przyciskRuszajObszar = new Rectangle(0 + szerokoscEkranu * 8 / 100 * 2, - 30, szerokoscEkranu * 8 / 100, wysokoscEkranu * 15 / 100);
        }
        void RozmiescElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            PanelInformacje.Size = new Size(szerokoscEkranu, wysokoscEkranu / 8);
            PanelInformacje.Location = new Point(0, wysokoscEkranu - PanelInformacje.Size.Height);
            PanelOpcje.Location = new Point(0, przyciskWyjdzObszar.Height + wysokoscEkranu/50);
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

            if (pelnyEkran == true)
            {
            }
            else
            {
                GrafikaMenu.TranslateTransform(0, 0);
            }
                switch (numerPrzycisku)
                {
                    case 0:
                        GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                        GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                        GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                        GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                        LabelInformacje.Text = "Witaj w grze Rzeź Po Grób!";
                        break;
                    case 1:
                        OdtworzDzwiek(odtwarzacz2, "Resources/Dźwięki/szyld.wav");
                        GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                        GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X - powiekszenieSzerokosc / 2, przyciskWyjdzObszar.Y - powiekszenieWysokosc / 2, przyciskWyjdzObszar.Width + powiekszenieSzerokosc, przyciskWyjdzObszar.Height + powiekszenieWysokosc);
                        GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X, przyciskOpcjeObszar.Y, przyciskOpcjeObszar.Width, przyciskOpcjeObszar.Height);
                        GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                        LabelInformacje.Text = "Na pewno chcesz już wyjść?";
                        break;
                    case 2:
                        OdtworzDzwiek(odtwarzacz3, "Resources/Dźwięki/szyld.wav");
                        GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                        GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
                        GrafikaMenu.DrawImage(przyciskOpcjeObrazek, przyciskOpcjeObszar.X - powiekszenieSzerokosc / 2, przyciskOpcjeObszar.Y - powiekszenieWysokosc / 2, przyciskOpcjeObszar.Width + powiekszenieSzerokosc, przyciskOpcjeObszar.Height + powiekszenieWysokosc);
                        GrafikaMenu.DrawImage(przyciskRuszajObrazek, przyciskRuszajObszar.X, przyciskRuszajObszar.Y, przyciskRuszajObszar.Width, przyciskRuszajObszar.Height);
                        LabelInformacje.Text = "O tak, dobre przygotowanie to dobry początek wyprawy!";
                        break;
                    case 3:
                        OdtworzDzwiek(odtwarzacz4, "Resources/Dźwięki/szyld.wav");
                        GrafikaMenu.DrawImage(tlo, 0, 0, szerokoscEkranu, wysokoscEkranu);
                        GrafikaMenu.DrawImage(przyciskWyjdzObrazek, przyciskWyjdzObszar.X, przyciskWyjdzObszar.Y, przyciskWyjdzObszar.Width, przyciskWyjdzObszar.Height);
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

            odtwarzacz1.Volume = 0.5;
            ZmienGlosnoscOdtwarzaczyEfektow(0.5);

            OdtworzDzwiek(odtwarzacz1, "Resources/Dźwięki/VC-HOfaH.wav");
            Zegar.Start();
        }

        #region Akcje związane z upływem czasu (bądź zapętleniem)

        private void Zegar_Tick(object sender, EventArgs e)
        {
            UstawEkran();
            UstawGlosnosc();
            if (obecnaSzerokoscEkranu != Width || obecnaWysokoscEkranu != Height)
            {
                UstawEkran();
            }

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
