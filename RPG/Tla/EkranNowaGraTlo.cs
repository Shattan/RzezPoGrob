#region Biblioteki systemowe
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace RPG
{
    public partial class EkranEkranNowaGraTlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        #endregion

        public EkranEkranNowaGraTlo(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;

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
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Tło tworzenie postaci.png");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            EkranNowaGra ekranNowaGra = new EkranNowaGra(ekranGlowny);
            DialogResult = ekranNowaGra.ShowDialog();
            if (ekranNowaGra.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (ekranNowaGra.DialogResult == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion

        private void EkranEkranNowaGraTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
