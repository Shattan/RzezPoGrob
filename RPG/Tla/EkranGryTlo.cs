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

    public partial class EkranGryTlo : Form
    {
        //int przesuniecie = 0;
        Bitmap plansza= new Bitmap("Resources/Mapy/Trawa.png");

        #region Zmienne
        EkranGry ekranGry;

        #endregion

        public EkranGryTlo(EkranGry ekranGry)
        {
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            this.ekranGry = ekranGry;
                   
            BackgroundImage = plansza;
            UstawElementyNaEkranie();
            timer1.Start();
            
        }

        #region Metody
        void UstawElementyNaEkranie()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            //BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło menu.png");

            PictureBoxTrawa.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxTrawa.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxTrawa.Image = plansza;

            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
        }

        public void UstawPanelPrawy(Point point, Size size, String sciezkaGrafiki)
        {
            //panelPraweMenu.Location = point;
            //panelPraweMenu.Size = size;
            //panelPraweMenu.BackgroundImage = new Bitmap(sciezkaGrafiki);
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(panelPraweMenu, sciezkaGrafiki);

            //pbPanelPraweMenu.Location = point;
            //pbPanelPraweMenu.Size = size;
            //pbPanelPraweMenu.BackgroundImage = new Bitmap(sciezkaGrafiki);
        }

        public void RuchPowierzchniMapy(int pozycja, int dystans)
        {
            switch (pozycja)
            {
                case 0:
                    PictureBoxTrawa.Left += dystans;
                    break;
                case 1:
                    PictureBoxTrawa.Left -= dystans;
                    break;
                case 2:
                    PictureBoxTrawa.Top += dystans;
                    break;
                case 3:
                    PictureBoxTrawa.Top -= dystans;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranGry.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //PictureBoxTrawa.Location = new Point(przesuniecie - plansza.Width / 2, 0 - plansza.Height / 3);
            //przesuniecie += 5;
        }
    }
}



