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
    public partial class EkranEkwipunek : Form
    {
        #region Zmienne
        EkranGry ekranGry;      //Dostep do: - ekranGry.opcje
                                //ekranGry.gra;
        enum Statystki
        {
            Pkt = 0,
            Sila = 1,
            Zrecznosc = 2,
            Witalnosc = 3,
            Inteligencja = 4
        };
        int[] wybraneStatystyki = new int[5];
        #endregion

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            RozmiescElementy();

#if DEBUG
            //Obrazki Tymaczasowe
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox1, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox2, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox3, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox4, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox5, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox6, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox7, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox8, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox9, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox10, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox11, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox12, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox13, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox14, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox15, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox16, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainMailDouble.PNG");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxBron, "Resources/Grafiki ekwipunku/Bron1h/Axe13.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxPancerz, "Resources/Grafiki ekwipunku/Pancerz/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxTarcza, "Resources/Grafiki ekwipunku/Tarcza/ShieldCrestedSkull.PNG");
#endif

            DodanieDragAndDropDlaObrazkow();
        }

        #region Metody
        void RozmiescElementy()
        {
            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 23 / 100, Height * 80 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);

            LabelStatystyki.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 8 / 100);
            LabelNazwyStatystyk.Location = new Point(LabelStatystyki.Location.X, LabelStatystyki.Location.Y + LabelStatystyki.Height);
            LabelWartosciStatystyk.Location = new Point(LabelStatystyki.Location.X + LabelNazwyStatystyk.Width, LabelStatystyki.Location.Y + LabelStatystyki.Height);

            //Rozmieszczanie przycisków
            PictureBoxZamknij.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxZamknij.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZamknij, "Resources/Grafiki menu/Wyjdź.png");

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
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow*2);
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


            //Rozmieszczanie ekwipunku
            FlowLayoutPanelPancerze.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 22 / 100, Screen.PrimaryScreen.Bounds.Height * 60 / 100);
            PictureBoxBron.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 8 / 100);
            PictureBoxPancerz.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);
            PictureBoxTarcza.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);

            FlowLayoutPanelPancerze.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 71 / 100, Screen.PrimaryScreen.Bounds.Height * 10 / 100);
            PictureBoxBron.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 45 / 100, Screen.PrimaryScreen.Bounds.Height * 28 / 100);
            PictureBoxPancerz.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 51 / 100, Screen.PrimaryScreen.Bounds.Height * 23 / 100);
            PictureBoxTarcza.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 57 / 100, Screen.PrimaryScreen.Bounds.Height * 23 / 100);
        }

        void DodanieDragAndDropDlaObrazkow()
        {
            //Dodawanie operacji Drop and Drag dla wszystkich PictureBox z FlowLayoutPanelPancerze
            foreach (PictureBox obiekt in FlowLayoutPanelPancerze.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            {
                obiekt.AllowDrop = true;
                obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnter);
                obiekt.DragDrop += new DragEventHandler(przedmiot_DragDrop);
                obiekt.MouseDown += przedmiot_MouseDown;
            }

            //Dodawanie operacji Drop and Drag dla PictureBox Bron/Pancerz/Tarcza
            PictureBoxBron.AllowDrop = true;
            PictureBoxPancerz.AllowDrop = true;
            PictureBoxTarcza.AllowDrop = true;

            PictureBoxBron.DragEnter += new DragEventHandler(przedmiot_DragEnter);
            PictureBoxPancerz.DragEnter += new DragEventHandler(przedmiot_DragEnter);
            PictureBoxTarcza.DragEnter += new DragEventHandler(przedmiot_DragEnter);

            PictureBoxBron.DragDrop += new DragEventHandler(przedmiot_DragDrop);
            PictureBoxPancerz.DragDrop += new DragEventHandler(przedmiot_DragDrop);
            PictureBoxTarcza.DragDrop += new DragEventHandler(przedmiot_DragDrop);

            PictureBoxBron.MouseDown += przedmiot_MouseDown;
            PictureBoxPancerz.MouseDown += przedmiot_MouseDown;
            PictureBoxTarcza.MouseDown += przedmiot_MouseDown;

            pictureBoxWybrany.Visible = false;
        }

        void OdswiezStatystyki(int punkty, int sila, int zrecznosc, int witalnosc, int inteligencja)
        {
            LabelNazwyStatystyk.Text = ekranGry.gra.bohater.Nazwa + "\n";   
            LabelNazwyStatystyk.Text += "Pozostałe punkty do rozdania:\n";
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

            LabelWartosciStatystyk.Text = "\n";
            LabelWartosciStatystyk.Text += punkty + "\n";               //Pozostałe punkty do rozdania
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

        void WczytajStatystykiBohater()
        {
            //Zapisujemy wybrane statystyki z klasy bohater
            //Bazowe statystyki zapisane sa w konstruktorze klasy bohater)
            wybraneStatystyki[(int)Statystki.Pkt] = ekranGry.gra.bohater.Punkty;
            wybraneStatystyki[(int)Statystki.Sila] = ekranGry.gra.bohater.Sila;
            wybraneStatystyki[(int)Statystki.Zrecznosc] = ekranGry.gra.bohater.Zrecznosc;
            wybraneStatystyki[(int)Statystki.Witalnosc] = ekranGry.gra.bohater.Witalnosc;
            wybraneStatystyki[(int)Statystki.Inteligencja] = ekranGry.gra.bohater.Inteligencja;

            OdswiezStatystyki(wybraneStatystyki[(int)Statystki.Pkt], wybraneStatystyki[(int)Statystki.Sila], wybraneStatystyki[(int)Statystki.Zrecznosc], wybraneStatystyki[(int)Statystki.Witalnosc], wybraneStatystyki[(int)Statystki.Inteligencja]);
        }

        void ZapiszGre()
        {
            ekranGry.gra.bohater.Punkty = wybraneStatystyki[(int)Statystki.Pkt];
            ekranGry.gra.bohater.Sila = wybraneStatystyki[(int)Statystki.Sila];
            ekranGry.gra.bohater.Zrecznosc = wybraneStatystyki[(int)Statystki.Zrecznosc];
            ekranGry.gra.bohater.Witalnosc = wybraneStatystyki[(int)Statystki.Witalnosc];
            ekranGry.gra.bohater.Inteligencja = wybraneStatystyki[(int)Statystki.Inteligencja];

        }
        #endregion

        #region Zdarzenia
        private void przedmiot_DragEnter(object sender, DragEventArgs e)
        {
            pictureBoxWybrany.Image = (sender as PictureBox).Image; ;
            e.Effect = DragDropEffects.Move;      
        }

        private void przedmiot_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (pb != null)
            {
                ((PictureBox)sender).Image = pb.Image;
                pb.Image = pictureBoxWybrany.Image;
            }
        }

        void przedmiot_MouseDown(object sender, MouseEventArgs e)
        {         
            DoDragDrop(sender, DragDropEffects.Move);            
        }

        private void EkranEkwipunek_Load(object sender, EventArgs e)
        {
            WczytajStatystykiBohater();
        }

        private void PictureBoxZamknij_Click(object sender, EventArgs e)
        {
            ZapiszGre();
            Close();
        }

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
    }
}
