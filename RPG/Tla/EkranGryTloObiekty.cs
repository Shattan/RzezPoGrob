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
    public partial class EkranGryTloObiekty : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        #endregion

        public EkranGryTloObiekty(EkranGlowny ekranGlowny)
        {
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            this.ekranGlowny = ekranGlowny;
            //BackgroundImage =  new Bitmap("Resources/Mapy/Trawa.png");               
        }

        #region Metody
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTloObiekty_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranGlowny.ekranGryTloUI.ShowDialog();
        }
        #endregion
    }
}



