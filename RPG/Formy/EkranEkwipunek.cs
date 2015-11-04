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
        EkranGry ekranGry;      
        Bohater tymczasowyBohater = new Bohater();
        #endregion

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            DodanieDragAndDropDlaObrazkow();
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

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
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow*2);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);


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
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZamknij, "Resources/Grafiki menu/Wyjdź.png");

            //Przyciski do rozdawania statystyk
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");


#if DEBUG
            //Obrazki Tymczasowe
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox1, ekranGry.gra.listaEkwipunek[0].Obrazek);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox2, "Resources/Grafiki ekwipunku/bron2hDługiMieczUmarłegoRycerza.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox3, "Resources/Grafiki ekwipunku/bron2hHalabarda.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox4, "Resources/Grafiki ekwipunku/bron2hWłócznia.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox5, "Resources/Grafiki ekwipunku/bron2hKosaPowiewŚmierci.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox6, "Resources/Grafiki ekwipunku/bron2hKosturBiałegoMaga.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox7, "Resources/Grafiki ekwipunku/bron2hKosturCienia.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox8, "Resources/Grafiki ekwipunku/bron2hKosturNowicjusza.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox9, "Resources/Grafiki ekwipunku/bron2hKosturOgnia.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox10, "Resources/Grafiki ekwipunku/bron2hKosturŚmierci.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox11, "Resources/Grafiki ekwipunku/bron2hKosturŚwiatła.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox12, "Resources/Grafiki ekwipunku/bron2hKosturWody.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox13, "Resources/Grafiki ekwipunku/tarczaTarczaKróla.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox14, "Resources/Grafiki ekwipunku/bron2hŁukDługiElficki.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox15, "Resources/Grafiki ekwipunku/tarczaTarczaUmarłegoRycerza.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox16, "Resources/Grafiki ekwipunku/bron2hŁukZKrainPołudnia.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/bron2hŁukZKrainPółnocy.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/bron2hMłotBojowy.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox17, "Resources/Grafiki ekwipunku/bron2hTopórBojowy.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(pictureBox18, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxBron, "Resources/Grafiki ekwipunku/bron2hKatana.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxPancerz, "Resources/Grafiki ekwipunku/tarczaDużaTarcza.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxTarcza, "Resources/Grafiki ekwipunku/tarczaMałaTarcza.PNG");
#endif
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
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.Sila + "\n";                 //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.Zrecznosc + "\n";            //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.Witalnosc + "\n";            //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.Inteligencja + "\n";         //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.Obrazenia + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.Pancerz + "\n";              //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HP + "\n";                   //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.Energia + "\n";              //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienie + "%\n";   //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczne + "%\n";   //Szansa na trafienie krytyczne
        }

        void WczytajStatystykiBohater()
        {
            //Zapisujemy wybrane statystyki z klasy bohater
            //Bazowe statystyki zapisane sa w konstruktorze klasy bohater)
            tymczasowyBohater = new Bohater(ekranGry.gra.bohater);

            OdswiezStatystyki();
        }

        void ZapiszGre()
        {
            ekranGry.gra.bohater = new Bohater(tymczasowyBohater);
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
            if (tymczasowyBohater.Sila > ekranGry.gra.bohater.Sila)
            {
                tymczasowyBohater.Sila--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Sila++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Zrecznosc > ekranGry.gra.bohater.Zrecznosc)
            {
                tymczasowyBohater.Zrecznosc--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Zrecznosc++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Witalnosc > ekranGry.gra.bohater.Witalnosc)
            {
                tymczasowyBohater.Witalnosc--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Witalnosc++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Inteligencja > ekranGry.gra.bohater.Inteligencja)
            {
                tymczasowyBohater.Inteligencja--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.Inteligencja++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }
        #endregion
    }
}
