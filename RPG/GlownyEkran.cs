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
    public partial class GlownyEkran : Form
    {
        public GlownyEkran()
        {
            InitializeComponent();
        }

        private void PrzyciskWyjdz_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
