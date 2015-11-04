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
            Zegar.Start();
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
            PictureBoxPotwierdz.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxPotwierdz.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);

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

            int szerokoscIkon = Screen.PrimaryScreen.Bounds.Width * 5 / 100;
            int wysokoscIkon = Screen.PrimaryScreen.Bounds.Height * 8 / 100;
            pictureBox1.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox2.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox3.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox4.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox5.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox6.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox7.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox8.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox9.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox10.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox11.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox12.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox13.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox14.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox15.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox16.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox17.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox18.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox17.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox18.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox19.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox20.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox21.Size = new Size(szerokoscIkon, wysokoscIkon);
            pictureBox22.Size = new Size(szerokoscIkon, wysokoscIkon);

        }
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz, "Resources/Grafiki menu/Wyjdź.png");

            //Przyciski do rozdawania statystyk
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");

            //Obrazki Tymczasowe
            Program.UstawObrazEkwipunku(pictureBox1, ekranGry.gra.listaEkwipunek[0].Obrazek);
            Program.UstawObrazEkwipunku(pictureBox2, "Resources/Grafiki ekwipunku/bron2hDługiMieczUmarłegoRycerza.PNG");
            Program.UstawObrazEkwipunku(pictureBox3, "Resources/Grafiki ekwipunku/bron2hHalabarda.PNG");
            Program.UstawObrazEkwipunku(pictureBox4, "Resources/Grafiki ekwipunku/bron2hWłócznia.PNG");
            Program.UstawObrazEkwipunku(pictureBox5, "Resources/Grafiki ekwipunku/bron2hKosaPowiewŚmierci.PNG");
            Program.UstawObrazEkwipunku(pictureBox6, "Resources/Grafiki ekwipunku/bron2hKosturBiałegoMaga.PNG");
            Program.UstawObrazEkwipunku(pictureBox7, "Resources/Grafiki ekwipunku/bron2hKosturCienia.PNG");
            Program.UstawObrazEkwipunku(pictureBox8, "Resources/Grafiki ekwipunku/bron2hKosturNowicjusza.PNG");
            Program.UstawObrazEkwipunku(pictureBox9, "Resources/Grafiki ekwipunku/bron2hKosturOgnia.PNG");
            Program.UstawObrazEkwipunku(pictureBox10, "Resources/Grafiki ekwipunku/bron2hKosturŚmierci.PNG");
            Program.UstawObrazEkwipunku(pictureBox11, "Resources/Grafiki ekwipunku/bron2hKosturŚwiatła.PNG");
            Program.UstawObrazEkwipunku(pictureBox12, "Resources/Grafiki ekwipunku/bron2hKosturWody.PNG");
            Program.UstawObrazEkwipunku(pictureBox13, "Resources/Grafiki ekwipunku/tarczaTarczaKróla.PNG");
            Program.UstawObrazEkwipunku(pictureBox14, "Resources/Grafiki ekwipunku/bron2hŁukDługiElficki.PNG");
            Program.UstawObrazEkwipunku(pictureBox15, "Resources/Grafiki ekwipunku/tarczaTarczaUmarłegoRycerza.PNG");
            Program.UstawObrazEkwipunku(pictureBox16, "Resources/Grafiki ekwipunku/bron2hŁukZKrainPołudnia.PNG");
            Program.UstawObrazEkwipunku(pictureBox17, "Resources/Grafiki ekwipunku/bron2hŁukZKrainPółnocy.PNG");
            Program.UstawObrazEkwipunku(pictureBox18, "Resources/Grafiki ekwipunku/bron2hMłotBojowy.PNG");
            Program.UstawObrazEkwipunku(pictureBox17, "Resources/Grafiki ekwipunku/bron2hTopórBojowy.PNG");
            Program.UstawObrazEkwipunku(pictureBox18, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");
            Program.UstawObrazEkwipunku(pictureBox19, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");
            Program.UstawObrazEkwipunku(pictureBox20, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");
            Program.UstawObrazEkwipunku(pictureBox21, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");
            Program.UstawObrazEkwipunku(pictureBox22, "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG");

            Program.UstawObrazEkwipunku(PictureBoxBron, "Resources/Grafiki ekwipunku/bron2hKatana.PNG");
            Program.UstawObrazEkwipunku(PictureBoxPancerz, "Resources/Grafiki ekwipunku/tarczaDużaTarcza.PNG");
            Program.UstawObrazEkwipunku(PictureBoxTarcza, "Resources/Grafiki ekwipunku/tarczaMałaTarcza.PNG");
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

        void WczytajStatystykiOdGracza()
        {
            tymczasowyBohater = new Bohater(ekranGry.gra.bohater);
            OdswiezStatystyki();
        }

        void ZapiszStatystykiDoGracza()
        {
            ekranGry.gra.bohater = new Bohater(tymczasowyBohater);
        }

        void DodanieDragAndDropDlaObrazkow()
        {
            //Dodawanie operacji Drop and Drag dla wszystkich PictureBox z FlowLayoutPanelPancerze
            foreach (PictureBox obiekt in FlowLayoutPanelPancerze.Controls.OfType<PictureBox>())
            {
                obiekt.AllowDrop = true;
                if (obiekt.ImageLocation.Contains("bron"))
                {
                    obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnterBron);
                    obiekt.DragDrop += new DragEventHandler(przedmiot_DragDropBron);
                    obiekt.MouseDown += przedmiot_MouseDownBron;
                }
                if (obiekt.ImageLocation.Contains("pancerz"))
                {
                    obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnterPancerz);
                    obiekt.DragDrop += new DragEventHandler(przedmiot_DragDropPancerz);
                    obiekt.MouseDown += przedmiot_MouseDownPancerz;
                }
                if (obiekt.ImageLocation.Contains("tarcza"))
                {
                    obiekt.DragEnter += new DragEventHandler(przedmiot_DragEnterTarcza);
                    obiekt.DragDrop += new DragEventHandler(przedmiot_DragDropTarcza);
                    obiekt.MouseDown += przedmiot_MouseDownTarcza;
                }
            }

            //Dodawanie operacji Drop and Drag dla PictureBox Bron/Pancerz/Tarcza
            PictureBoxBron.AllowDrop = true;
            PictureBoxPancerz.AllowDrop = true;
            PictureBoxTarcza.AllowDrop = true;

            PictureBoxBron.DragEnter += new DragEventHandler(przedmiot_DragEnterBron);
            PictureBoxPancerz.DragEnter += new DragEventHandler(przedmiot_DragEnterPancerz);
            PictureBoxTarcza.DragEnter += new DragEventHandler(przedmiot_DragEnterTarcza);

            PictureBoxBron.DragDrop += new DragEventHandler(przedmiot_DragDropBron);
            PictureBoxPancerz.DragDrop += new DragEventHandler(przedmiot_DragDropPancerz);
            PictureBoxTarcza.DragDrop += new DragEventHandler(przedmiot_DragDropTarcza);

            PictureBoxBron.MouseDown += przedmiot_MouseDownBron;
            PictureBoxPancerz.MouseDown += przedmiot_MouseDownPancerz;
            PictureBoxTarcza.MouseDown += przedmiot_MouseDownTarcza;

            //pictureBoxWybrany.Visible = false;
        }
        #endregion

        #region Zdarzenia
        private void przedmiot_DragEnterBron(object sender, DragEventArgs e)
        {
            pictureBoxPrzenoszony.Image = (sender as PictureBox).Image;
            e.Effect = DragDropEffects.Move;
        }
        private void przedmiot_DragDropBron(object sender, DragEventArgs e)
        {
            PictureBox pb = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (pb != null)
            {
                ((PictureBox)sender).Image = pb.Image;
                pb.Image = pictureBoxPrzenoszony.Image;
            }
        }
        void przedmiot_MouseDownBron(object sender, MouseEventArgs e)
        {
            DoDragDrop(sender, DragDropEffects.Move);
            pictureBoxPrzenoszony.Location = new Point(MousePosition.X, MousePosition.Y);
        }



        private void przedmiot_DragEnterTarcza(object sender, DragEventArgs e)
        {
            pictureBoxPrzenoszony.Image = (sender as PictureBox).Image;
            e.Effect = DragDropEffects.Move;
        }
        private void przedmiot_DragDropTarcza(object sender, DragEventArgs e)
        {
            PictureBox pb = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (pb != null)
            {
                ((PictureBox)sender).Image = pb.Image;
                pb.Image = pictureBoxPrzenoszony.Image;
            }
        }
        void przedmiot_MouseDownTarcza(object sender, MouseEventArgs e)
        {
            DoDragDrop(sender, DragDropEffects.Move);
            pictureBoxPrzenoszony.Location = new Point(MousePosition.X, MousePosition.Y);
        }



        private void przedmiot_DragEnterPancerz(object sender, DragEventArgs e)
        {
            pictureBoxPrzenoszony.Image = (sender as PictureBox).Image;
            e.Effect = DragDropEffects.Move;
        }
        private void przedmiot_DragDropPancerz(object sender, DragEventArgs e)
        {
            PictureBox pb = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (pb != null)
            {
                ((PictureBox)sender).Image = pb.Image;
                pb.Image = pictureBoxPrzenoszony.Image;
            }
        }
        void przedmiot_MouseDownPancerz(object sender, MouseEventArgs e)
        {
            DoDragDrop(sender, DragDropEffects.Move);
            pictureBoxPrzenoszony.Location = new Point(MousePosition.X, MousePosition.Y);
        }









        private void EkranEkwipunek_Load(object sender, EventArgs e)
        {
            WczytajStatystykiOdGracza();
        }


        private void Zegar_Tick(object sender, EventArgs e)
        {
            pictureBoxPrzenoszony.Location = new Point(MousePosition.X+10, MousePosition.Y);
        }


        #region Przyciski do modyfikowania statystyk
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

        #region Zamykanie forma
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            ZapiszStatystykiDoGracza();
            Close();
        }

        private void EkranEkwipunek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zegar.Stop();
        }
        #endregion



        #endregion

    }
}
