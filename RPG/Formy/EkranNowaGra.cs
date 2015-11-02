using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class EkranNowaGra : Form
    {
        #region Zmienne
        //Dostepne tylko dla tej formy
        private EkranGlowny ekranGlowny;        //Dostep do ekranGlowny.opcje
        private EkranGry ekranGry;              //Dostep do ekranGry.Gry
        private EkranGryTloMapa EkranGryTloMapa;        //Uzywamy do rozpoczenia EkranGryTloMapa.Dialog()

        //Lista sciezek obrazkow dostepnych do wybory dla tworzonej postaci
        List<String> ListaPostaci = new List<String>();
        static int wybranyBohater = 0;

        //Można stworzyc zamiast tego klase "Statystyki", bedzie czytelniej   
        enum Statystki
        {
            Pkt = 0,
            Sila = 1,
            Zrecznosc = 2,
            Witalnosc = 3,
            Inteligencja = 4
        };
        //Zapamietujemy tutaj wybrane statystyki, jak damy "OK", to zapisza sie w gra.bohater
        int[] wybraneStatystyki = new int[5];

        #endregion

        public EkranNowaGra(EkranGlowny ekranGlowny, EkranGry ekranGry, EkranGryTloMapa EkranGryTloMapa)
        {
            InitializeComponent();

            this.ekranGlowny = ekranGlowny;
            this.ekranGry = ekranGry;
            this.EkranGryTloMapa = EkranGryTloMapa;

            RozstawElementy();
            KolorujElementy();
            DodajSkinyPostaci();         

            WczytajStatystykiBohater();
        }

        #region Metody
        void RozstawElementy()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "Aby rozpocząć należy wybrać postać i ją nazwać.";

            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 23 / 100, Height * 80 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);

            LabelStatystyki.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Height * 20 / 100);
            LabelNazwyStatystyk.Location = new Point(LabelStatystyki.Location.X, LabelStatystyki.Location.Y + LabelStatystyki.Height);
            LabelWartosciStatystyk.Location = new Point(LabelStatystyki.Location.X+LabelNazwyStatystyk.Width, LabelStatystyki.Location.Y + LabelStatystyki.Height);

            //Rozmieszczanie przycisków
            const int wielkoscPrzyciskow = 25;
            PictureBoxSilaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxSilaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);

            const int odleglosciMiedzyPrzyciskamiX = 5;
            const int odleglosciMiedzyPrzyciskamiY = wielkoscPrzyciskow;
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y+ wielkoscPrzyciskow);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);

            //Ustawienie przycisków od bohatera
            PictureBoxWyjscie.Size = new Size(Width * 5 / 100, Height * 5 / 100);
            PictureBoxWyjscie.Location = new Point(Width * 5 / 100, Height * 5 / 100);

            PictureBoxPoprzedniBohater.Size = new Size(Width * 2 / 100, Height * 10/ 100);
            PictureBoxBohater.Size = new Size(Width * 10 / 100, PictureBoxPoprzedniBohater.Height);
            PictureBoxNastepnyBohater.Size = new Size(PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Height);

            PictureBoxPoprzedniBohater.Location = new Point(Width * 50 / 100 - (PictureBoxPoprzedniBohater.Width + PictureBoxBohater.Width + PictureBoxNastepnyBohater.Width)/2, Height * 50 / 100 - PictureBoxPoprzedniBohater.Height);
            PictureBoxBohater.Location = new Point(PictureBoxPoprzedniBohater.Location.X + PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Location.Y);
            PictureBoxNastepnyBohater.Location = new Point(PictureBoxBohater.Location.X + PictureBoxBohater.Width, PictureBoxPoprzedniBohater.Location.Y);

            PictureBoxBohater.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.Zoom;

            //Ustawienie wpisywania nazwy
            TextBoxNazwa.Width = PictureBoxBohater.Width;
            PictureBoxPotwierdz.Size = new Size(TextBoxNazwa.Width, TextBoxNazwa.Height);

            TextBoxNazwa.Location = new Point(PictureBoxBohater.Location.X, PictureBoxBohater.Location.Y + PictureBoxBohater.Height);
            PictureBoxPotwierdz.Location = new Point(PictureBoxBohater.Location.X, TextBoxNazwa.Location.Y + TextBoxNazwa.Height);
        }

        void KolorujElementy()
        {
            //Ustawienie ikony dla trybu okienkowego
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Przyciski Statystyk
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPoprzedniBohater, "Resources/Grafiki menu/Przycisk poprzedni standard.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxBohater, "Resources/Grafiki menu/Tło opcji.png");
            
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxNastepnyBohater, "Resources/Grafiki menu/Przycisk następny standard.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz, "Resources/Grafiki menu/Zapisz opcje.png");

            //Przycisk wychodzenia
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjscie, "Resources/Grafiki menu/Wyjdź.png");
        }

        void DodajSkinyPostaci()
        {
            ListaPostaci.Add(ekranGry.gra.bohater.ObrazekNaMapie);
            for (int i = 0; i <= 55; i++)
            {
                ListaPostaci.Add("Resources/Grafiki postaci na mapie/"+i+"/");
            }
            //Ustawienie domyslnego obrazka
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxBohater.Image = new Bitmap(ListaPostaci[wybranyBohater] + "dół.gif");
        }

        void OdswiezStatystyki(int punkty, int sila, int zrecznosc, int witalnosc, int inteligencja)
        {
            LabelNazwyStatystyk.Text = "Pozostałe punkty do rozdania:\n";
            LabelNazwyStatystyk.Text += "Siła:\n";
            LabelNazwyStatystyk.Text += "Zręczność:\n";
            LabelNazwyStatystyk.Text += "Witalność:\n";
            LabelNazwyStatystyk.Text += "Inteligencja:\n";
            LabelNazwyStatystyk.Text += "Obrażenia:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie krytyczne:\n";
            LabelNazwyStatystyk.Text += "Pancerz:\n";
            LabelNazwyStatystyk.Text += "Zdrowie:\n";
            LabelNazwyStatystyk.Text += "Energia:\n";

            LabelWartosciStatystyk.Text = punkty + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += sila + "\n";                //Siła
            LabelWartosciStatystyk.Text += zrecznosc + "\n";           //Zręczność
            LabelWartosciStatystyk.Text += witalnosc + "\n";           //Witalność
            LabelWartosciStatystyk.Text += inteligencja + "\n";        //Inteligencja
            LabelWartosciStatystyk.Text += sila * 5 + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += (int)zrecznosc / 3 + "%\n";  //Szansa na trafienie
            LabelWartosciStatystyk.Text += (int)zrecznosc / 5 + "%\n";  //Szansa na trafienie krytyczne
            LabelWartosciStatystyk.Text += (int)zrecznosc / 5 + "\n";  //Pancerz
            LabelWartosciStatystyk.Text += witalnosc * 5 + "\n";       //Zdrowie
            LabelWartosciStatystyk.Text += inteligencja * 5 + "\n";    //Energia
        }

        void DodajPunkt(Statystki statystki, int ile)
        {
            if (wybraneStatystyki[(int)Statystki.Pkt] > 0)
            {
                switch (statystki)
                {
                    case Statystki.Sila:                     
                            wybraneStatystyki[(int)Statystki.Sila] += ile;
                        break;
                    case Statystki.Zrecznosc:
                        
                            wybraneStatystyki[(int)Statystki.Zrecznosc] += ile;
                        break;
                    case Statystki.Witalnosc:
                       
                            wybraneStatystyki[(int)Statystki.Witalnosc] += ile;
                        break;
                    case Statystki.Inteligencja:
                     
                            wybraneStatystyki[(int)Statystki.Inteligencja] += ile;
                        break;
                    default:
                        break;
                }

                wybraneStatystyki[(int)Statystki.Pkt] -= ile;
                OdswiezStatystyki(wybraneStatystyki[(int)Statystki.Pkt], wybraneStatystyki[(int)Statystki.Sila], wybraneStatystyki[(int)Statystki.Zrecznosc], wybraneStatystyki[(int)Statystki.Witalnosc], wybraneStatystyki[(int)Statystki.Inteligencja]);
            }
        }

        void OdejmijPunkt(Statystki statystki, int ile)
        {
            switch (statystki)
            {
                case Statystki.Sila:
                    if (wybraneStatystyki[(int)Statystki.Sila] > ekranGry.gra.bohater.Sila)
                    {
                        wybraneStatystyki[(int)Statystki.Sila] -= ile;
                        wybraneStatystyki[(int)Statystki.Pkt] += ile;
                    }
                    break;
                case Statystki.Zrecznosc:
                    if (wybraneStatystyki[(int)Statystki.Zrecznosc] > ekranGry.gra.bohater.Zrecznosc)
                    {
                        wybraneStatystyki[(int)Statystki.Zrecznosc] -= ile;
                        wybraneStatystyki[(int)Statystki.Pkt] += ile;
                    }
                    break;
                case Statystki.Witalnosc:
                    if (wybraneStatystyki[(int)Statystki.Witalnosc] > ekranGry.gra.bohater.Witalnosc)
                    {
                        wybraneStatystyki[(int)Statystki.Witalnosc] -= ile;
                        wybraneStatystyki[(int)Statystki.Pkt] += ile;
                    }
                    break;
                case Statystki.Inteligencja:
                    if (wybraneStatystyki[(int)Statystki.Inteligencja] > ekranGry.gra.bohater.Inteligencja)
                    {
                        wybraneStatystyki[(int)Statystki.Inteligencja] -= ile;
                        wybraneStatystyki[(int)Statystki.Pkt] += ile;
                    }
                    break;
                default:
                    break;
            }
            OdswiezStatystyki(wybraneStatystyki[(int)Statystki.Pkt], wybraneStatystyki[(int)Statystki.Sila], wybraneStatystyki[(int)Statystki.Zrecznosc], wybraneStatystyki[(int)Statystki.Witalnosc], wybraneStatystyki[(int)Statystki.Inteligencja]);
        }

        void ZapiszGre()
        {
            ekranGry.gra.bohater.Punkty = wybraneStatystyki[(int)Statystki.Pkt];
            ekranGry.gra.bohater.Sila = wybraneStatystyki[(int)Statystki.Sila];
            ekranGry.gra.bohater.Zrecznosc = wybraneStatystyki[(int)Statystki.Zrecznosc];
            ekranGry.gra.bohater.Witalnosc = wybraneStatystyki[(int)Statystki.Witalnosc];
            ekranGry.gra.bohater.Inteligencja = wybraneStatystyki[(int)Statystki.Inteligencja];

            ekranGry.gra.bohater.ObrazekNaMapie = ListaPostaci[wybranyBohater];
            ekranGry.gra.bohater.Nazwa = TextBoxNazwa.Text;
        }

        void WczytajStatystykiBohater()
        {
            //Wczytujemy statystyki bazowe bohatera (inicjowane sa w konstruktorze klasy bohater)
            wybraneStatystyki[(int)Statystki.Pkt] = ekranGry.gra.bohater.Punkty;
            wybraneStatystyki[(int)Statystki.Sila] = ekranGry.gra.bohater.Sila;
            wybraneStatystyki[(int)Statystki.Zrecznosc] = ekranGry.gra.bohater.Zrecznosc;
            wybraneStatystyki[(int)Statystki.Witalnosc] = ekranGry.gra.bohater.Witalnosc;
            wybraneStatystyki[(int)Statystki.Inteligencja] = ekranGry.gra.bohater.Inteligencja;

            OdswiezStatystyki(ekranGry.gra.bohater.Sila, wybraneStatystyki[(int)Statystki.Sila], wybraneStatystyki[(int)Statystki.Zrecznosc], wybraneStatystyki[(int)Statystki.Witalnosc], wybraneStatystyki[(int)Statystki.Inteligencja]);
        }
        #endregion

        #region Zdarzenia
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            //Zapisz dane do klasy gra
            ZapiszGre();

            //Wczytaj zapisane dane w ekranGra
            ekranGry.WczytajNowaGre();

            //Uruchom Dialog
            EkranGryTloMapa.ShowDialog();
            
            //Zamknij Forme
            //DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Powiekszanie przyciskow
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
        #endregion

        #region Minus/Plus przyciski
        private void PictureBoxSilaMinus_Click(object sender, EventArgs e)
        {
            OdejmijPunkt(Statystki.Sila, 1);
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            DodajPunkt(Statystki.Sila, 1);
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            OdejmijPunkt(Statystki.Zrecznosc, 1);
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            DodajPunkt(Statystki.Zrecznosc, 1);
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            OdejmijPunkt(Statystki.Witalnosc, 1);
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            DodajPunkt(Statystki.Witalnosc, 1);
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            OdejmijPunkt(Statystki.Inteligencja, 1);
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            DodajPunkt(Statystki.Inteligencja, 1);
        }
        #endregion

        private void PictureBoxPoprzedniBohater_Click(object sender, EventArgs e)
        {
            if (wybranyBohater > 0)
            {
                PictureBoxBohater.Image = new Bitmap(ListaPostaci[--wybranyBohater] + "dół.gif");
            }
            else if (wybranyBohater == 0)
            {
                wybranyBohater = ListaPostaci.Count - 1;
                PictureBoxBohater.Image = new Bitmap(ListaPostaci[wybranyBohater] + "dół.gif");
            }
        }

        private void PictureBoxNastepnyBohater_Click(object sender, EventArgs e)
        {
            if (wybranyBohater < ListaPostaci.Count - 1)
            {
                PictureBoxBohater.Image = new Bitmap(ListaPostaci[++wybranyBohater] + "dół.gif");
            }
            else if (wybranyBohater == ListaPostaci.Count - 1)
            {
                wybranyBohater = 0;
                PictureBoxBohater.Image = new Bitmap(ListaPostaci[wybranyBohater] + "dół.gif");
            }
        }
        #endregion
    }
}
