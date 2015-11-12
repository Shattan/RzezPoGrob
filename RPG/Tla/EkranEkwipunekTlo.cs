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
    public partial class EkranEkwipunekTlo : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        #endregion

        public EkranEkwipunekTlo(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

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
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Karta postaci.png");
        }
        #endregion

        #region Zdarzenia
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            EkranEkwipunek ekranEkwipunek = new EkranEkwipunek(ekranGry);
            DialogResult = ekranEkwipunek.ShowDialog();
            DialogResult = ekranEkwipunek.DialogResult;
        }
        #endregion

        private void EkranEkwipunekTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
