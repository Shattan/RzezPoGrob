using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG.Formy
{
    public partial class FormZwyciestwo : Form
    {
        public FormZwyciestwo()
        {
            Timer t = new Timer();
            t.Interval = 10000;
            t.Tick += t_Tick;
            InitializeComponent();
        }

        void t_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
