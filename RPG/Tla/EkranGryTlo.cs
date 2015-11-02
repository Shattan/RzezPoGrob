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
        #region Zmienne
        EkranGry ekranGry;

        Bitmap plansza = new Bitmap("Resources/Mapy/Trawa.png");
        #endregion

        public EkranGryTlo(EkranGry ekranGry)
        {
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            this.ekranGry = ekranGry;
                   
            
            UstawElementyNaEkranie();           
        }

        #region Metody
        void UstawElementyNaEkranie()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            BackgroundImage = plansza;

            PictureBoxTrawa.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxTrawa.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxTrawa.Image = plansza;

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
            DialogResult = ekranGry.ShowDialog();
        }
        #endregion
    }
}



