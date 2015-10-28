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
            this.ekranNowaGra = ekranNowaGra;

            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }

        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranNowaGra.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion
    }
}
