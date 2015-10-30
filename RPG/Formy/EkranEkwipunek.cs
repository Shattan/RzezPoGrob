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
            pictureBox6.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");
            pictureBox7.Image = new Bitmap("Resources/Grafiki ekwipunku/ArmorChainmailMithril.PNG");


            //pictureBox1.AllowDrop = true;
            //pictureBox2.AllowDrop = true;
            //pictureBox3.AllowDrop = true;
            //pictureBox4.AllowDrop = true;
            //pictureBox5.AllowDrop = true;
            //pictureBox6.AllowDrop = true;
            pictureBox7.AllowDrop = true;

            pictureBox1.MouseDown += PobierzObrazek_MouseDown;
            pictureBox2.MouseDown += PobierzObrazek_MouseDown;
            pictureBox3.MouseDown += PobierzObrazek_MouseDown;
            pictureBox4.MouseDown += PobierzObrazek_MouseDown;
            pictureBox5.MouseDown += PobierzObrazek_MouseDown;
            pictureBox6.MouseDown += PobierzObrazek_MouseDown;
            pictureBox7.MouseDown += PobierzObrazek_MouseDown;   


            pictureBox1.DragEnter += pictureBox1_DragEnter;
            pictureBox2.DragEnter += pictureBox1_DragEnter;
            pictureBox3.DragEnter += pictureBox1_DragEnter;
            pictureBox4.DragEnter += pictureBox1_DragEnter;
            pictureBox5.DragEnter += pictureBox1_DragEnter;
            pictureBox6.DragEnter += pictureBox1_DragEnter;
            pictureBox7.DragEnter += pictureBox1_DragEnter;

            pictureBox1.DragDrop += pictureBox7_DragDrop;
            pictureBox2.DragDrop += pictureBox7_DragDrop;
            pictureBox3.DragDrop += pictureBox7_DragDrop;
            pictureBox4.DragDrop += pictureBox7_DragDrop;
            pictureBox5.DragDrop += pictureBox7_DragDrop;
            pictureBox6.DragDrop += pictureBox7_DragDrop;
            pictureBox7.DragDrop += pictureBox7_DragDrop;

        }

        private void PobierzObrazek_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox obrazek = sender as PictureBox;
            var img = obrazek.Image;

            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                obrazek.Image = null;
            }
            if (DoDragDrop(img, DragDropEffects.Copy) == DragDropEffects.Copy)
            {

            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox obrazek = sender as PictureBox;
            var img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);

            obrazek.Image = img;
        }


    }
}
