using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace RPG
{
    public partial class EkranEkwipunek : Form
    {
        EkranGry ekranGry;

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            InitializeComponent();

            //pictureBox7.AllowDrop = true;
            pictureBox1.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainMail.PNG");
            pictureBox2.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainMailDouble.PNG");
            pictureBox3.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainmailGolden.PNG");
            pictureBox4.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainmailGreen.PNG");
            pictureBox5.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            pictureBox6.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainMailRusty.PNG");
            
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pictureBox2.Image = bmp;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var img = pictureBox1.Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                pictureBox1.Image = null;
            }
        }
    }
}
