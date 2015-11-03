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
            RozmiescElementy();
            KolorujElementy();

            this.ekranGlowny = ekranGlowny;          
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTloObiekty_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranGlowny.ekranGryTloUI.ShowDialog();
        }
        #endregion
    }
}



