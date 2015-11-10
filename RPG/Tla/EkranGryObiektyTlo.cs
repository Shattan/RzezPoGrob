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
    public partial class EkranGryObiektyTlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        EkranGryMapaTlo ekranGryMapaTlo;
        #endregion

        public EkranGryObiektyTlo(EkranGlowny ekranGlowny, EkranGryMapaTlo ekranGryMapaTlo)
        {
            this.ekranGlowny = ekranGlowny;
            this.ekranGryMapaTlo = ekranGryMapaTlo;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();        
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTloObiekty_Shown(object sender, EventArgs e)
        {
            EkranGryUITlo ekranGryUITlo = new EkranGryUITlo(ekranGlowny, ekranGryMapaTlo, this);
            DialogResult = ekranGryUITlo.ShowDialog();
            DialogResult = ekranGryUITlo.DialogResult;
        }
        #endregion

        private void EkranGryObiektyTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}



