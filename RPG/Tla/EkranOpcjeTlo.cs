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
    public partial class EkranEkranOpcjeTlo : Form
    {
        #region Zmienne
        EkranOpcje ekranOpcje;
        #endregion

        public EkranEkranOpcjeTlo(EkranOpcje ekranOpcje)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            this.ekranOpcje = ekranOpcje;
        }

        #region Metody
        void RozmiescElementy()
        {
        }
        void KolorujElementy()
        {
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranEkranOpcjeTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranOpcje.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion
    }
}
