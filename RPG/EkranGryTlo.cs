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
    //int przesuniecie = 0;
    //Bitmap plansza= new Bitmap("Resources/Trawa.png");


    public partial class EkranGryTlo : Form
    {
        public EkranGryTlo()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*  using (Graphics grafikaGracza = Graphics.FromImage(PictureBoxMgla.Image))
              {
                  grafikaGracza.DrawImage(new Bitmap("Resources/Grafiki gracza/W dół.gif"), PictureBoxMgla.Width / 2, PictureBoxMgla.Height / 2);
                  PictureBoxMgla.Image = PictureBoxMgla.Image;
              }
              PictureBoxMgla.Location = new Point(przesuniecie - plansza.Width / 2, 0 - plansza.Height / 3);*/
            /*
            panel1.Location = new Point(panel1.Location.X,przesunięcie);
            */
            //przesuniecie+=5;
        }
    }
}
