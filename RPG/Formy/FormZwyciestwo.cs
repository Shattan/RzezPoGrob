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
         
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            try
            {

       
            Application.Exit();
                     }
            catch(Exception)
            {

            }
        }


    }
}
