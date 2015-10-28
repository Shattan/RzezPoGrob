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

    public partial class EkranGlownyTlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;

        readonly Bitmap tlo = new Bitmap("Resources/Grafiki menu/Tło menu.png");
        #endregion

        public EkranGlownyTlo()
        {
            InitializeComponent();
            ekranGlowny = new EkranGlowny(this);
            BackColor = System.Drawing.Color.Black;

            BackgroundImage = tlo;
        }

        #region Obsluga zdarzeń
        private void EkranGlownyTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranGlowny.ShowDialog();
            if (dr == DialogResult.Abort)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}
