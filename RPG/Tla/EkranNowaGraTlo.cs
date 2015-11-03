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
        EkranNowaGra ekranNowaGra;

        #endregion

        public EkranEkranNowaGraTlo(EkranNowaGra ekranNowaGra)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            this.ekranNowaGra = ekranNowaGra;
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Tło tworzenie postaci.png");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranNowaGra.ShowDialog();
            Close();
        }
        #endregion
    }
}
