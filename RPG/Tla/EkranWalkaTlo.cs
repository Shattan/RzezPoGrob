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
    public partial class EkranWalkaTlo : Form
    {
        #region Zmienne
        EkranWalka ekranWalka;
        #endregion

        public EkranWalkaTlo(EkranWalka ekranWalka)
        {
            InitializeComponent();
            this.ekranWalka = ekranWalka;

            Program.UstawObrazPolaBitwy(this, "Resources/Grafiki tła walki/0.png", "Resources/Grafiki postaci walczących/goblin.png");
        }

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranWalka.ShowDialog();
        }
        #endregion
    }
}
