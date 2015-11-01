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
        EkranGry ekranGry;
        PictureBox ZapisanyObrazek;

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
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow);
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
        #endregion

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            RozmiescElementy();

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZamknij, "Resources/Grafiki menu/Wyjdź.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");


            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox1, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox2, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox3, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox4, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox5, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox6, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox7, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox8, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox9, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox10, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox11, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox12, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox13, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox14, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox15, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox16, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxBron, "Resources/Grafiki ekwipunku/Axe13.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxPancerz, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxTarcza, "Resources/Grafiki ekwipunku/ShieldCrestedSkull.PNG");

            //FlowLayoutPanelPancerze.DragEnter += new DragEventHandler(FlowLayoutPanelPancerze_DragEnter);
            //FlowLayoutPanelPancerze.DragDrop += new DragEventHandler(FlowLayoutPanelPancerz_DragDrop);
       
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

            foreach (PictureBox obiekt in FlowLayoutPanelPancerze.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            {
                obiekt.AllowDrop = true;
                obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnter);
                obiekt.DragDrop += new DragEventHandler(przedmiot_DragDrop);
                obiekt.MouseDown += przedmiot_MouseDown;
            //    obiekt.MouseUp += przedmiot_MouseUp;
            }

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
           // PictureBoxBron.MouseUp += przedmiot_MouseUp;
          //  PictureBoxPancerz.MouseUp += przedmiot_MouseUp;
         //   PictureBoxTarcza.MouseUp += przedmiot_MouseUp;
        }

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

        void przedmiot_MouseUp(object sender, MouseEventArgs e)
        {
           // pictureBoxWybrany = sender as PictureBox;
        }

        //private void FlowLayoutPanelPancerze_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.All;
        //}

        //void FlowLayoutPanelPancerz_DragDrop(object sender, DragEventArgs e)
        //{
        //    PictureBox data = (PictureBox)e.Data.GetData(typeof(PictureBox));
        //    FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
        //    FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

        //    if (_source != _destination)
        //    {
        //        // Add control to panel
        //        _destination.Controls.Add(data);
        //        data.Size = new Size(_destination.Width, 50);
        
        //        // Reorder
        //        Point p = _destination.PointToClient(new Point(e.X, e.Y));
        //        var item = _destination.GetChildAtPoint(p);
        //        int index = _destination.Controls.GetChildIndex(item, false);
        //        _destination.Controls.SetChildIndex(data, index);

        //        // Invalidate to paint!
        //        _destination.Invalidate();
        //        _source.Invalidate();
        //    }
        //    else
        //    {
        //        // Just add the control to the new panel.
        //        // No need to remove from the other panel,
        //        // this changes the Control.Parent property.
        //        Point p = _destination.PointToClient(new Point(e.X, e.Y));
        //        var item = _destination.GetChildAtPoint(p);
        //        int index = _destination.Controls.GetChildIndex(item, false);
        //        _destination.Controls.SetChildIndex(data, index);
        //        _destination.Invalidate();
        //    }
        //}

        private void EkranEkwipunek_Load(object sender, EventArgs e)
        {
            //Tutaj powinny być wczytane statystyki z postaci gracza
            //Ogólnie to najlepiej jakby całego gracza tutaj przekazywało, a funkcja sobie z niego wyciągała to, czego potrzeba
            //np. label.text = "Sila:" + gracz.Sila; itd.
            OdswiezStatystyki(postac.Punkty, postac.Sila, postac.Zrecznosc, postac.Witalnosc, postac.Inteligencja);
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

        private void PictureBoxZamknij_Click(object sender, EventArgs e)
        {
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
    }
}
