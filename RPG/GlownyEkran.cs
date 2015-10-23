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

//dodane przeze mnie
using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

#region Pozostałe biblioteki
#endregion


namespace RPG
{
    public partial class GlownyEkran : Form
    {
        public GlownyEkran()
        {
            //Dzwiek
            odtwarzacz1.Volume = 0.5;
            ZmienGlosnoscOdtwarzaczyEfektow(0.5);
            OdtworzDzwiek(odtwarzacz1, "Resources/Dźwięki/VC-HOfaH.wav");

            InitializeComponent();

            //Gra
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();
            UtworzZestawyPrzeciwnikow();

            //Obraz
            UstawElementyNaEkranie();


            //Czas
            Zegar.Start();
        }

        private void PictureBoxOpcje_Click(object sender, EventArgs e)
        {

            if (PanelOpcje.Visible == false)
            {
                PanelOpcje.Visible = true;
            }
            if (PanelOpcje.Visible == true)
            {
                PanelOpcje.Visible = false;
            }
        }

        private void CheckBoxZawszeNaWierzchu_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxZawszeNaWierzchu.Checked == true && TopMost != true)
            {
                TopMost = true;
            }
            else if (CheckBoxZawszeNaWierzchu.Checked == false && TopMost != false)
            {
                TopMost = false;
            }
        }

        private void CheckBoxPelnyEkran_CheckedChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                if (FormBorderStyle != FormBorderStyle.None)
                    FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (WindowState != FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Normal;
                    if (FormBorderStyle != FormBorderStyle.Sizable)
                        FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
        }


        private void PanelZPictureBoxWyjdz_MouseEnter(object sender, EventArgs e)
        {

            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;

            PanelZPictureBoxWyjdz.Bounds = new Rectangle(PanelZPictureBoxWyjdz.Location.X - powiekszenieX / 2, PanelZPictureBoxWyjdz.Location.Y - powiekszenieY / 2, PanelZPictureBoxWyjdz.Width + powiekszenieX, PanelZPictureBoxWyjdz.Height + powiekszenieY);
        }

        private void PanelZPictureBoxWyjdz_MouseLeave(object sender, EventArgs e)
        {

            int powiekszenieX = -Width * 1 / 100;
            int powiekszenieY = -Height * 1 / 100;
            PanelZPictureBoxWyjdz.Bounds = new Rectangle(PanelZPictureBoxWyjdz.Location.X - powiekszenieX / 2, PanelZPictureBoxWyjdz.Location.Y - powiekszenieY / 2, PanelZPictureBoxWyjdz.Width + powiekszenieX, PanelZPictureBoxWyjdz.Height + powiekszenieY);
        }
        
    }
}
