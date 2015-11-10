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
    public partial class EkranDziennikZadanTlo : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        #endregion

        public EkranDziennikZadanTlo(EkranGry ekranGry)
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
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(this, "Resources/Grafiki menu/Dziennik zadań.png");
        }
        #endregion

        #region Zdarzenia
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            EkranDziennikZadan ekranDziennikZadan = new EkranDziennikZadan(ekranGry);
            ekranDziennikZadan.ShowDialog();
            DialogResult = ekranDziennikZadan.DialogResult;
        }
        #endregion

        private void EkranEkranDziennikZadanTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
