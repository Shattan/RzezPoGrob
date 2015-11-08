using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

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
        Gracz tymczasowyBohater = new Gracz();
        #endregion

        public EkranNowaGra(EkranGlowny ekranGlowny, EkranGry ekranGry, EkranGryTloMapa EkranGryTloMapa)
        {
            InitializeComponent();

            this.ekranGlowny = ekranGlowny;
            this.ekranGry = ekranGry;
            this.EkranGryTloMapa = EkranGryTloMapa;

            RozstawElementy();
            KolorujElementy();

            WczytajStatystykiOdGracza();
            DodajSkinyPostaci();
        }

        #region Metody
        void RozstawElementy()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "Dostosuj swego bohatera!";

            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 23 / 100, Height * 60 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);

            LabelStatystyki.Location = new Point(Width * 2 / 100, Height * 20 / 100);
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
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow * 2);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);

            //Ustawienie przycisków od bohatera
            PictureBoxPoprzedniBohater.Size = new Size(Width * 2 / 100, Height * 15/ 100);
            PictureBoxBohater.Size = new Size(Width * 10 / 100, PictureBoxPoprzedniBohater.Height);
            PictureBoxNastepnyBohater.Size = new Size(PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Height);

            PictureBoxPoprzedniBohater.Location = new Point(Width * 45 / 100 - (PictureBoxPoprzedniBohater.Width + PictureBoxBohater.Width + PictureBoxNastepnyBohater.Width)/2, Height * 40 / 100 - PictureBoxPoprzedniBohater.Height);
            PictureBoxBohater.Location = new Point(PictureBoxPoprzedniBohater.Location.X + PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Location.Y);
            PictureBoxNastepnyBohater.Location = new Point(PictureBoxBohater.Location.X + PictureBoxBohater.Width, PictureBoxPoprzedniBohater.Location.Y);

            PictureBoxBohater.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.Zoom;

            PictureBoxWstecz.Size = new Size(Width * 8 / 100, Height * 8 / 100);
            PictureBoxWstecz.Location = new Point(0, 0);

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
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxBohater, "Resources/Grafiki menu/Tło wyboru bohatera.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxNastepnyBohater, "Resources/Grafiki menu/Przycisk następny standard.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz, "Resources/Grafiki menu/Potwierdź postać.png");

            //Przycisk wychodzenia
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWstecz, "Resources/Grafiki menu/Wyjdź.png");
        }

        void DodajSkinyPostaci()
        {
            for (int i = 0; i <= Directory.GetDirectories("Resources/Grafiki postaci na mapie/").Count()-1; i++)
            {
                ListaPostaci.Add("Resources/Grafiki postaci na mapie/"+i+"/");
            }
            //Ustawienie domyslnego obrazka
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxBohater.Image = new Bitmap(ListaPostaci[wybranyBohater] + "dół.gif");
        }

        void OdswiezStatystyki()
        {
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";
            LabelNazwyStatystyk.Text += "Pozostałe punkty do rozdania:\n";
            LabelNazwyStatystyk.Text += "Siła:\n";
            LabelNazwyStatystyk.Text += "Zręczność:\n";
            LabelNazwyStatystyk.Text += "Witalność:\n";
            LabelNazwyStatystyk.Text += "Inteligencja:\n";
            LabelNazwyStatystyk.Text += "Obrażenia:\n";
            LabelNazwyStatystyk.Text += "Pancerz:\n";
            LabelNazwyStatystyk.Text += "Zdrowie:\n";
            LabelNazwyStatystyk.Text += "Energia:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie krytyczne:\n";

            LabelWartosciStatystyk.Text = "\n";
            LabelWartosciStatystyk.Text += tymczasowyBohater.PunktyStatystykDoRozdania + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.SilaPodstawa + "\n";                 //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.ZrecznoscPodstawa + "\n";            //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.WitalnoscPodstawa + "\n";            //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.InteligencjaPodstawa + "\n";         //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.Obrazenia + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.Pancerz + "\n";              //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HP + "\n";                   //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.Energia + "\n";              //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienie + "%\n";   //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczne + "%\n";   //Szansa na trafienie krytyczne
        }

        void WczytajStatystykiOdGracza()
        {
            tymczasowyBohater = new Gracz(ekranGry.gra.gracz);
            OdswiezStatystyki();
        }

        void ZapiszStatystykiDoGracza()
        {
            ekranGry.gra.gracz = new Gracz(tymczasowyBohater);
        }
        #endregion

        #region Zdarzenia
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            tymczasowyBohater.ObrazekNaMapie = ListaPostaci[wybranyBohater];
            //Zapisz dane do klasy gra
            ZapiszStatystykiDoGracza();

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

        #region Przyciski do modyfikowania statystyk
        private void PictureBoxSilaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.SilaPodstawa > ekranGry.gra.gracz.SilaPodstawa)
            {
                tymczasowyBohater.SilaPodstawa--;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.PunktyStatystykDoRozdania > 0)
            {
                tymczasowyBohater.SilaPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.ZrecznoscPodstawa > ekranGry.gra.gracz.ZrecznoscPodstawa)
            {
                tymczasowyBohater.ZrecznoscPodstawa--;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.PunktyStatystykDoRozdania > 0)
            {
                tymczasowyBohater.ZrecznoscPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.WitalnoscPodstawa > ekranGry.gra.gracz.WitalnoscPodstawa)
            {
                tymczasowyBohater.WitalnoscPodstawa--;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.PunktyStatystykDoRozdania > 0)
            {
                tymczasowyBohater.WitalnoscPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.InteligencjaPodstawa > ekranGry.gra.gracz.InteligencjaPodstawa)
            {
                tymczasowyBohater.InteligencjaPodstawa--;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.PunktyStatystykDoRozdania > 0)
            {
                tymczasowyBohater.InteligencjaPodstawa++;
                OdswiezStatystyki();
            }
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
        private void TextBoxNazwa_TextChanged(object sender, EventArgs e)
        {
            tymczasowyBohater.Nazwa = TextBoxNazwa.Text;
            OdswiezStatystyki();
        }
        #endregion

    }
}
