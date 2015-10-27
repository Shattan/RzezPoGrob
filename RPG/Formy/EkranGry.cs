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

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        GlownyEkran glownyEkran;

        Gra gra;

        DziennikZadan dziennikZadan;
        EkranEkwipunek ekranEkwipunek;
        #endregion

        public EkranGry(GlownyEkran glownyEkran) 
        {
            this.glownyEkran = glownyEkran;
            //glownyEkran.opcje.OdtworzDzwiek(odtwarzacz, sciezka);

            gra = new Gra();
            dziennikZadan = new DziennikZadan();
            ekranEkwipunek = new EkranEkwipunek();

            InitializeComponent();
            UstawElementyNaEkranie();
        }

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Chodzacy ludek
            PictureBoxGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/lewo.gif");
            PictureBoxGracz.Size = new Size(PictureBoxGracz.Image.Width, PictureBoxGracz.Image.Height);

            //Wczytanie Right Menu Panel
            const int wielkoscPrzyciskow = 100;
            panelPraweMenu.Location = new Point(Screen.PrimaryScreen.Bounds.Width - wielkoscPrzyciskow, Screen.PrimaryScreen.Bounds.Y + 30);
            panelPraweMenu.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow*5);

            List<Image> ListaObrazkow = new List<Image>();
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/A.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/B.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/C.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/D.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/E.png"));


            PictureBox[] praweMenu = new PictureBox[5];
            for (int index = 0; index < praweMenu.Length; index++)
            {
                praweMenu[index] = new PictureBox();
                panelPraweMenu.Controls.Add(praweMenu[index]);
                praweMenu[index].Location = new Point(0, index * wielkoscPrzyciskow + 20);
                praweMenu[index].Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
                praweMenu[index].Image = new Bitmap(ListaObrazkow[index], wielkoscPrzyciskow, wielkoscPrzyciskow);
                //praweMenu[index].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenu_MouseEnter);
                //praweMenu[index].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenu_MouseLeave);
            }

            praweMenu[0].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[1].Click += new System.EventHandler(this.PictureBoxPraweMenuDziennikZadan_MouseClick);
            praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[3].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[4].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);



            //using (Graphics grafikaGracza = Graphics.FromImage(PictureBoxMgla.Image))
            //{
            //    //grafikaGracza.DrawImage(new Bitmap("Resources/Grafiki postaci na mapie/2/lewo.gif"), PictureBoxMgla.Width / 2, PictureBoxMgla.Height / 2);
            //}
        }

        public void ZapiszNazwe(string nazwa)
        {
            label1.Text = nazwa;
        }

        //Tutaj dzieki zdarzeniom bedziemy tylko wywolywac metody z klasy Gra
        //Dzieki temu mamy oddzielona gre od warstwy srodowiska

        #region Obsluga zdarzeń

        private void PictureBoxPraweMenuEkwipunek_MouseClick(object sender, EventArgs e)
        {
            ekranEkwipunek.ShowDialog();
        }

        private void PictureBoxPraweMenuDziennikZadan_MouseClick(object sender, EventArgs e)
        {
            dziennikZadan.ShowDialog();
        }
        

        //private void PictureBoxPraweMenu_MouseEnter(object sender, EventArgs e)
        //{
        //    PictureBox pictureBox = sender as PictureBox;
        //    int powiekszenieX = Width * 1 / 100;
        //    int powiekszenieY = Height * 1 / 100;

        //    using (Bitmap obrazek = new Bitmap(pictureBox.Image))
        //    {
        //        pictureBox.BackgroundImage = new Bitmap(obrazek, pictureBox.Width * 5 / 8 + powiekszenieX, pictureBox.Height * 7 / 8 + powiekszenieY);
        //    }
        //}

        //private void PictureBoxPraweMenu_MouseLeave(object sender, EventArgs e)
        //{
        //    PictureBox pictureBox = sender as PictureBox;
        //    using (Bitmap obrazek = new Bitmap(pictureBox.Image))
        //    {
        //        pictureBox.BackgroundImage = new Bitmap(pictureBox.Image, pictureBox.Width * 5 / 8, pictureBox.Height * 7 / 8);
        //    }
        //}

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (dziennikZadan.Visible == false)
            {
                dziennikZadan.Visible = true;
                dziennikZadan.BringToFront();
            }
            else
            {
                dziennikZadan.Visible = false;
            }
        }
        #endregion

        #region sprawiamy, ze okno jest niewidoczne w alt+tab

        //Obsluga wychodzenia - zakaz alt+f4
        private void Opcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        //Nie pojawia sie w alt+tab
        private void Opcje_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        //Usuwamy ramke (nie pojawia sie w alt+tab)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        #endregion
    }
}
