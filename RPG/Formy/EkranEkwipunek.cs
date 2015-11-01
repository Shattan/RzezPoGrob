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

        #region Metody
        void RozmiescElementy()
        {
            //Rozmieszczanie statystyk
            LabelStatystykiSzczegoly.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 40 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);

            LabelStatystyki.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 8 / 100);
            LabelStatystykiSzczegoly.Location = new Point(LabelStatystyki.Location.X, LabelStatystyki.Location.Y+LabelStatystyki.Height);

            //Rozmieszczanie przycisków
            PictureBoxZamknij.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxZamknij.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);

            const int wielkoscPrzyciskow = 30;
            PictureBoxSilaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxSilaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);

            const int odleglosciMiedzyPrzyciskamiX = 5;
            const int odleglosciMiedzyPrzyciskamiY = 50;
            PictureBoxSilaMinus.Location = new Point(LabelStatystykiSzczegoly.Location.X + 120, LabelStatystykiSzczegoly.Location.Y + 10);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X+wielkoscPrzyciskow+odleglosciMiedzyPrzyciskamiX,PictureBoxSilaMinus.Location.Y);
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

        void OdswiezStatystyki(int sila, int zrecznosc, int witalnosc, int inteligencja)
        {
            LabelStatystykiSzczegoly.Text = "Siła:\n" + sila;
            LabelStatystykiSzczegoly.Text += "\nZręczność:\n" + zrecznosc;
            LabelStatystykiSzczegoly.Text += "\nWitalność:\n" + witalnosc;
            LabelStatystykiSzczegoly.Text += "\nInteligencja:\n" + inteligencja;
            LabelStatystykiSzczegoly.Text += "\nObrażenia:\n"+sila*5;
            LabelStatystykiSzczegoly.Text += "\nSzansa na trafienie:\n"+(int)zrecznosc/3;
            LabelStatystykiSzczegoly.Text += "\nSzansa na trafienie Krytyczne:\n" + (int)zrecznosc / 5;
            LabelStatystykiSzczegoly.Text += "\nPancerz:\n" + (int)zrecznosc / 5;
            LabelStatystykiSzczegoly.Text += "\nZdrowie:\n"+witalnosc*5;
            LabelStatystykiSzczegoly.Text += "\nEnergia:\n"+inteligencja*5;
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



            //pictureBox7.AllowDrop = true;
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox1,"Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox2, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox3, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox4, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox5, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox6, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox7, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox8, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox9, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox10, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox11, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox12, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox13, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox14, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox15, "Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox16, "Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox17, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox18, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox17, "Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBox18, "Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxBron, "Resources/Grafiki ekwipunku/Axe13.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPancerz, "Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxTarcza, "Resources/Grafiki ekwipunku/ShieldCrestedSkull.PNG");


            //pictureBox1.AllowDrop = true;
            //pictureBox2.AllowDrop = true;
            //pictureBox3.AllowDrop = true;
            //pictureBox4.AllowDrop = true;
            //pictureBox5.AllowDrop = true;
            //pictureBox6.AllowDrop = true;
            PictureBoxBron.AllowDrop = true;

            pictureBox1.MouseDown += PobierzObrazek_MouseDown;
            pictureBox2.MouseDown += PobierzObrazek_MouseDown;
            pictureBox3.MouseDown += PobierzObrazek_MouseDown;
            pictureBox4.MouseDown += PobierzObrazek_MouseDown;
            pictureBox5.MouseDown += PobierzObrazek_MouseDown;
            pictureBox6.MouseDown += PobierzObrazek_MouseDown;
            PictureBoxBron.MouseDown += PobierzObrazek_MouseDown;   


            pictureBox1.DragEnter += pictureBox1_DragEnter;
            pictureBox2.DragEnter += pictureBox1_DragEnter;
            pictureBox3.DragEnter += pictureBox1_DragEnter;
            pictureBox4.DragEnter += pictureBox1_DragEnter;
            pictureBox5.DragEnter += pictureBox1_DragEnter;
            pictureBox6.DragEnter += pictureBox1_DragEnter;
            PictureBoxBron.DragEnter += pictureBox1_DragEnter;

            pictureBox1.DragDrop += pictureBox7_DragDrop;
            pictureBox2.DragDrop += pictureBox7_DragDrop;
            pictureBox3.DragDrop += pictureBox7_DragDrop;
            pictureBox4.DragDrop += pictureBox7_DragDrop;
            pictureBox5.DragDrop += pictureBox7_DragDrop;
            pictureBox6.DragDrop += pictureBox7_DragDrop;
            PictureBoxBron.DragDrop += pictureBox7_DragDrop;

        }

        private void PobierzObrazek_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox obrazek = sender as PictureBox;
            var img = obrazek.Image;

            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                obrazek.Image = null;
            }
            if (DoDragDrop(img, DragDropEffects.Copy) == DragDropEffects.Copy)
            {

            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox obrazek = sender as PictureBox;
            var img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);

            obrazek.Image = img;
        }

        private void FlowLayoutPanelPancerze_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void EkranEkwipunek_Load(object sender, EventArgs e)
        {
            //Tutaj powinny być wczytane statystyki z postaci gracza
            //Ogólnie to najlepiej jakby całego gracza tutaj przekazywało, a funkcja sobie z niego wyciągała to, czego potrzeba
            //np. label.text = "Sila:" + gracz.Sila; itd.
            OdswiezStatystyki(10, 15, 5, 23);
        }

        private void PictureBoxZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
