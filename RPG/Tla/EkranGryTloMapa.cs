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

    public partial class EkranGryTloMapa : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;

        Bitmap plansza = new Bitmap("Resources/Mapy/Trawa.png");
        #endregion

        public EkranGryTloMapa(EkranGlowny ekranGlowny)
        {
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            this.ekranGlowny = ekranGlowny;
                            
            UstawElementyNaEkranie();           
        }

        #region Metody
        void UstawElementyNaEkranie()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            //BackgroundImage = plansza;

            PictureBoxTrawa.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxTrawa.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxTrawa.Image = plansza;
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
        private void EkranGryTloMapa_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranGlowny.ekranGryTloObiekty.ShowDialog();
        }
        #endregion
    }
}



