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
        #endregion

        public EkranGryTloMapa(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;   

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();   
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

            Program.UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(PictureBoxTrawa, "Resources/Mapy/Trawa.png");

            PictureBoxTrawa.Size = new Size(PictureBoxTrawa.Width, PictureBoxTrawa.Height);
            PictureBoxTrawa.Location = new Point(0 - PictureBoxTrawa.Width / 2, 0 - PictureBoxTrawa.Height / 2);
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
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



