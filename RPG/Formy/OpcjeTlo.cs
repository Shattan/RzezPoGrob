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
    public partial class OpcjeTlo : Form
    {
        #region Zmienne
        GlownyEkran glownyEkran;
        #endregion

        public OpcjeTlo(GlownyEkran glownyEkran)
        {
            InitializeComponent();
            this.glownyEkran = glownyEkran;
           
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }

        #region Obsluga zdarzeń
        private void OpcjeTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = glownyEkran.opcje.ShowDialog(glownyEkran);
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion
    }
}
