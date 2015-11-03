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
        EkranEkwipunek ekranEkwipunek;
        #endregion

        public EkranEkwipunekTlo(EkranEkwipunek ekranEkwipunek)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            this.ekranEkwipunek = ekranEkwipunek;
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Karta postaci.png");
        }
        #endregion

        #region Zdarzenia
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranEkwipunek.ShowDialog();
        }
        #endregion
    }
}
