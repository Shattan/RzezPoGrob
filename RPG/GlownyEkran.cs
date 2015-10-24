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
            odtwarzaczMuzyki.Volume = 0.5;
            ZmienGlosnoscOdtwarzaczyEfektow(0.5);
            OdtworzDzwiek(odtwarzaczMuzyki, "Resources/Dźwięki/VC-HOfaH.wav");

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
            else
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
            else if (TopMost != false)
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

        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 2 / 3 + powiekszenieX, PictureBoxWyjscie.Height * 2 / 3 + powiekszenieY);
            }
            PictureBoxOpcje.Bounds = new Rectangle(PictureBoxOpcje.Location.X - powiekszenieX / 2, PictureBoxOpcje.Location.Y - powiekszenieY / 2, PictureBoxOpcje.Width + powiekszenieX, PictureBoxOpcje.Height + powiekszenieY);
            PictureBoxRuszaj.Bounds = new Rectangle(PictureBoxRuszaj.Location.X - powiekszenieX / 2, PictureBoxRuszaj.Location.Y - powiekszenieY / 2, PictureBoxRuszaj.Width + powiekszenieX, PictureBoxRuszaj.Height + powiekszenieY);
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            int powiekszenieX = -Width * 1 / 100;
            int powiekszenieY = -Width * 1 / 100;
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 2 / 3 + powiekszenieX, PictureBoxWyjscie.Height * 2 / 3 + powiekszenieY);
            }
            PictureBoxOpcje.Bounds = new Rectangle(PictureBoxOpcje.Location.X - powiekszenieX / 2, PictureBoxOpcje.Location.Y - powiekszenieY / 2, PictureBoxOpcje.Width + powiekszenieX, PictureBoxOpcje.Height + powiekszenieY);
            PictureBoxRuszaj.Bounds = new Rectangle(PictureBoxRuszaj.Location.X - powiekszenieX / 2, PictureBoxRuszaj.Location.Y - powiekszenieY / 2, PictureBoxRuszaj.Width + powiekszenieX, PictureBoxRuszaj.Height + powiekszenieY);
        }
    }
}
