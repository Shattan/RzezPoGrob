using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class OpcjeTlo : Form
    {
        public Opcje opcjePrzezroczystosc;
        GlownyEkran glownyEkran;
        public OpcjeTlo(GlownyEkran Eg)
        {
            InitializeComponent();

            opcjePrzezroczystosc = new Opcje(Eg);

            glownyEkran = Eg;
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
            //PictureBoxUstawienia.Image = new Bitmap("Resources/Grafiki menu/Tło opcji.png");

        }

        private void OpcjeTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = opcjePrzezroczystosc.ShowDialog(glownyEkran);
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
    }
}
