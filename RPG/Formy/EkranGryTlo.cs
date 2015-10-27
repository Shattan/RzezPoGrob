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

    public partial class EkranGryTlo : Form
    {
        int przesuniecie = 0;
        Bitmap plansza= new Bitmap("Resources/Mapy/Trawa.png");

        #region Zmienne
        GlownyEkran glownyEkran;
        #endregion

        public EkranGryTlo(GlownyEkran glownyEkran)
        {
            InitializeComponent();
            this.glownyEkran = glownyEkran;

            BackgroundImage = plansza;
            UstawElementyNaEkranie();
            timer1.Start();
        }

        #region Metody
        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło menu.png");

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

             PictureBoxTrawa.Size = new Size(plansza.Width,plansza.Height);
             PictureBoxTrawa.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
             PictureBoxTrawa.Image = plansza;

            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = glownyEkran.ekranGry.ShowDialog(glownyEkran);
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBoxTrawa.Location = new Point(przesuniecie - plansza.Width / 2, 0 - plansza.Height / 3);
            przesuniecie += 5;
        }
    }
}



