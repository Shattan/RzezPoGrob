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
        //int przesuniecie = 0;
        Bitmap plansza= new Bitmap("Resources/Mapy/Trawa.png");


        #region Zmienne
        EkranGry ekranGry;
        PictureBox[] praweMenu;
        #endregion

        public EkranGryTlo(EkranGry ekranGry)
        {
            InitializeComponent();
            this.ekranGry = ekranGry;
           
        
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

            //Wczytanie Right Menu Panel
            List<Image> ListaObrazkow = new List<Image>();
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Adark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Bdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Cdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/D.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/E.png"));

            const int wielkoscPrzyciskow = 80;
            const int odlegloscMiedzyPrzyciskami = 20;
            int iloscPrzyciskow = ListaObrazkow.Count();

            panelPraweMenu.Location = new Point(Screen.PrimaryScreen.Bounds.Width - wielkoscPrzyciskow, Screen.PrimaryScreen.Bounds.Y);
            panelPraweMenu.Size = new Size(wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami, wielkoscPrzyciskow * iloscPrzyciskow);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(panelPraweMenu, "Resources/Grafiki menu/Panel pod przyciski.png");
            praweMenu = new PictureBox[iloscPrzyciskow];
            for (int index = 0; index < praweMenu.Length; index++)
            {
                praweMenu[index] = new PictureBox();
                panelPraweMenu.Controls.Add(praweMenu[index]);
                praweMenu[index].Location = new Point(0, index * wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami);
                praweMenu[index].Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
                praweMenu[index].BackgroundImage = new Bitmap(ListaObrazkow[index], wielkoscPrzyciskow, wielkoscPrzyciskow);
                //praweMenu[index].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenu_MouseEnter);
                //praweMenu[index].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenu_MouseLeave);
            }

            praweMenu[0].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[0].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseEnter);
            praweMenu[0].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseLeave);
            praweMenu[1].Click += new System.EventHandler(this.PictureBoxPraweMenuEkranDziennikZadan_MouseClick);
            //praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[3].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);

            PictureBoxTrawa.Size = new Size(plansza.Width,plansza.Height);
            PictureBoxTrawa.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
            PictureBoxTrawa.Image = plansza;

            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
        }

        #region Obsluga zdarzeń
        private void PictureBoxPraweMenuEkwipunek_MouseClick(object sender, EventArgs e)
        {
           // ekranEkwipunekTlo.ShowDialog();
        }
        private void PictureBoxPraweMenuEkwipunek_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Alight.png");
        }
        private void PictureBoxPraweMenuEkwipunek_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Adark.png");
        }
        private void PictureBoxPraweMenuEkranDziennikZadan_MouseClick(object sender, EventArgs e)
        {
           // ekranEkranDziennikZadanTlo.ShowDialog();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            //ekranEkranDziennikZadanTlo.ShowDialog();
        }
        #endregion

        public void RuchPowierzchniMapy(int pozycja, int dystans)
        {
            switch (pozycja)
            {
                case 0:
                    PictureBoxTrawa.Left += dystans;
                    break;
                case 1:
                    PictureBoxTrawa.Left -= dystans;
                    break;
                case 2:
                    PictureBoxTrawa.Top += dystans;
                    break;
                case 3:
                    PictureBoxTrawa.Top -= dystans;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranGry.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                Close();
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //PictureBoxTrawa.Location = new Point(przesuniecie - plansza.Width / 2, 0 - plansza.Height / 3);
            //przesuniecie += 5;
        }
    }
}



