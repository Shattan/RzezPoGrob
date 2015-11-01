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
        EkranGlowny ekranGlowny;
        EkranGry ekranGry;
        EkranGryTlo ekranGryTlo;
        List<String> postacieDoWyboru = new List<String>();
        static int wybranyBohater = 0;
        enum Statystki
        {
            Pkt = 0,
            Sila = 1,
            Zrecznosc = 2,
            Witalnosc = 3,
            Inteligencja = 4
        };
        #if DEBUG
                //(int punkty, int sila, int zrecznosc, int witalnosc, int inteligencja)
                // OdswiezStatystyki(10, 10, 15, 5, 23);
                Postac postac = new Postac("Witek");
        #endif
        #endregion

        #region Metody
        void RozmiescElementy()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

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

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");


            //Ustawienie przycisków od bohatera
            PictureBoxWyjscie.Size = new Size(Width * 5 / 100, Height * 5 / 100);
            PictureBoxWyjscie.Location = new Point(Width * 5 / 100, Height * 5 / 100);

            PictureBoxPoprzedniBohater.Size = new Size(Width * 2 / 100, Height * 10/ 100);
            PictureBoxBohater.Size = new Size(Width * 10 / 100, PictureBoxPoprzedniBohater.Height);
            PictureBoxNastepnyBohater.Size = new Size(PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Height);

            PictureBoxPoprzedniBohater.Location = new Point(Width * 50 / 100 - (PictureBoxPoprzedniBohater.Width + PictureBoxBohater.Width + PictureBoxNastepnyBohater.Width)/2, Height * 50 / 100 - PictureBoxPoprzedniBohater.Height);
            PictureBoxBohater.Location = new Point(PictureBoxPoprzedniBohater.Location.X + PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Location.Y);
            PictureBoxNastepnyBohater.Location = new Point(PictureBoxBohater.Location.X + PictureBoxBohater.Width, PictureBoxPoprzedniBohater.Location.Y);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjscie, "Resources/Grafiki menu/Wyjdź.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPoprzedniBohater, "Resources/Grafiki menu/Przycisk poprzedni standard.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxBohater, "Resources/Grafiki menu/Tło opcji.png");
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBoxBohater.Image = new Bitmap("Resources/Grafiki postaci na mapie/0/dół.gif");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxNastepnyBohater, "Resources/Grafiki menu/Przycisk następny standard.png");


            //Ustawienie wpisywania nazwy
            TextBoxNazwa.Width = PictureBoxBohater.Width;
            PictureBoxPotwierdz.Size = new Size(TextBoxNazwa.Width, TextBoxNazwa.Height);

            TextBoxNazwa.Location = new Point(PictureBoxBohater.Location.X, PictureBoxBohater.Location.Y + PictureBoxBohater.Height);
            PictureBoxPotwierdz.Location = new Point(PictureBoxBohater.Location.X, TextBoxNazwa.Location.Y + TextBoxNazwa.Height);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz,"Resources/Grafiki menu/Zapisz opcje.png");

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
            if (postac.Punkty > 0)
            {
                switch (statystki)
                {
                    case Statystki.Sila:
                        postac.Sila += ile;
                        break;
                    case Statystki.Zrecznosc:
                        postac.Zrecznosc += ile;
                        break;
                    case Statystki.Witalnosc:
                        postac.Witalnosc += ile;
                        break;
                    case Statystki.Inteligencja:
                        postac.Inteligencja += ile;
                        break;
                    default:
                        break;
                }

                postac.Punkty -= ile;
                OdswiezStatystyki(postac.Punkty, postac.Sila, postac.Zrecznosc, postac.Witalnosc, postac.Inteligencja);
            }
        }

        void OdejmijPunkt(Statystki statystki, int ile)
        {
            const int minminalnaWartosc = 0;
            switch (statystki)
            {
                case Statystki.Sila:
                    if (postac.Sila > minminalnaWartosc)
                    {
                        postac.Sila -= ile;
                        postac.Punkty += ile;
                    }
                    break;
                case Statystki.Zrecznosc:
                    if (postac.Zrecznosc > minminalnaWartosc)
                    {
                        postac.Zrecznosc -= ile;
                        postac.Punkty += ile;
                    }
                    break;
                case Statystki.Witalnosc:
                    if (postac.Zrecznosc > minminalnaWartosc)
                    {
                        postac.Zrecznosc -= ile;
                        postac.Punkty += ile;
                    }
                    break;
                case Statystki.Inteligencja:
                    if (postac.Inteligencja > minminalnaWartosc)
                    {
                        postac.Inteligencja -= ile;
                        postac.Punkty += ile;
                    }
                    break;
                default:
                    break;
            }
            OdswiezStatystyki(postac.Punkty, postac.Sila, postac.Zrecznosc, postac.Witalnosc, postac.Inteligencja);
        }
        #endregion

        public EkranNowaGra(EkranGlowny ekranGlowny, EkranGry ekranGry, EkranGryTlo ekranGryTlo)
        {
            InitializeComponent();

            this.ekranGlowny = ekranGlowny;
            this.ekranGry = ekranGry;
            this.ekranGryTlo = ekranGryTlo;

            postacieDoWyboru.Add("Resources/Grafiki postaci na mapie/0/");
            postacieDoWyboru.Add("Resources/Grafiki postaci na mapie/11/");
            postacieDoWyboru.Add("Resources/Grafiki postaci na mapie/12/");
            postacieDoWyboru.Add("Resources/Grafiki postaci na mapie/13/");
            PictureBoxBohater.Image = new Bitmap(postacieDoWyboru[wybranyBohater] + "dół.gif");

            RozmiescElementy();
            #if DEBUG
                //(int punkty, int sila, int zrecznosc, int witalnosc, int inteligencja)
                // OdswiezStatystyki(10, 10, 15, 5, 23);
                postac = new Postac("Witek");
                postac.Punkty = 10;
                postac.Sila = 10;
                postac.Zrecznosc = 15;
                postac.Witalnosc = 5;
                postac.Inteligencja = 23;
            #endif
            OdswiezStatystyki(postac.Punkty, postac.Sila, postac.Zrecznosc, postac.Witalnosc, postac.Inteligencja);
        }


        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            //Zapisz Elementy do EkranGlowny.ekranGry.gra
            ekranGry.ZapiszNazwe(TextBoxNazwa.Text);
            ekranGryTlo.ShowDialog();
            
            //DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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
        #endregion

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

        private void PictureBoxPoprzedniBohater_Click(object sender, EventArgs e)
        {
            if (wybranyBohater > 0)
            {
                PictureBoxBohater.Image = new Bitmap(postacieDoWyboru[--wybranyBohater] + "dół.gif");
            }
            else if (wybranyBohater == 0)
            {
                wybranyBohater = postacieDoWyboru.Count - 1;
                PictureBoxBohater.Image = new Bitmap(postacieDoWyboru[wybranyBohater] + "dół.gif");
            }
        }

        private void PictureBoxNastepnyBohater_Click(object sender, EventArgs e)
        {
            if (wybranyBohater < postacieDoWyboru.Count-1)
            {
                PictureBoxBohater.Image = new Bitmap(postacieDoWyboru[++wybranyBohater] + "dół.gif");
            }
            else if (wybranyBohater == postacieDoWyboru.Count - 1)
            {
                wybranyBohater = 0;
                PictureBoxBohater.Image = new Bitmap(postacieDoWyboru[wybranyBohater] + "dół.gif");
            }
        }

        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        /*
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        //Nie pojawia sie w alt+tab
        private void EkranOpcje_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        //Usuwamy ramke (nie pojawia sie w alt+tab)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        */
        #endregion

    }
}
