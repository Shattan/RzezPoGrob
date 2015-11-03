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
    public partial class EkranEkranDziennikZadanTlo : Form
    {
        #region Zmienne
        EkranDziennikZadan ekranDziennikZadan;
        #endregion

        public EkranEkranDziennikZadanTlo(EkranDziennikZadan ekranDziennikZadan)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            this.ekranDziennikZadan = ekranDziennikZadan;
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Dziennik zadań.png");
        }
        #endregion

        #region Zdarzenia
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranDziennikZadan.ShowDialog();
        }
        #endregion
    }
}
