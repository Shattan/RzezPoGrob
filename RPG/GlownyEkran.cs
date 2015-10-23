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
            RozmiescElementy();


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

        private void PictureBoxWyjdz_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBoxWyjdz.Location = new Point(0,0);

            PictureBoxWyjdz.Size = new Size(100,100);
        }
    }
}
