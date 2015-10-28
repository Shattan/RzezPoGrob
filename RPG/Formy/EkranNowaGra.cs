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
    public partial class EkranNowaGra : Form
    {
        EkranGlowny ekranGlowny;
        EkranGry ekranGry;
        EkranGryTlo ekranGryTlo;

        public EkranNowaGra(EkranGlowny ekranGlowny, EkranGry ekranGry, EkranGryTlo ekranGryTlo)
        {
            InitializeComponent();

            this.ekranGlowny = ekranGlowny;
            this.ekranGry = ekranGry;
            this.ekranGryTlo = ekranGryTlo;

            UstawElementyNaEkranie();      
        }


        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            //Zapisz Elementy do EkranGlowny.ekranGry.gra
            ekranGry.ZapiszNazwe(textBox1.Text);
            ekranGryTlo.ShowDialog();
            
            //DialogResult = DialogResult.OK;
            this.Close();
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
            //BackgroundImage = tlo;

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "";

            /* PictureBoxMgla.Size = new Size(plansza.Width,plansza.Height);
             PictureBoxMgla.Location = new Point(0-plansza.Width/2,0-plansza.Height/2);
             PictureBoxMgla.Image = plansza;*/


            //Ustawienie przycisków
            PictureBoxWyjscie.Location = new Point(10, -30);

            PictureBoxWyjscie.BackgroundImage = new Bitmap(new Bitmap("Resources/Grafiki menu/Wyjście.png"), PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);


            //PictureBoxMgla.Image = new Bitmap("Resources/Grafiki gracza/W dół.gif");
        }
        #endregion

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Powiekszanie przyciskow
        //Moim zdaniem, lepiej zasotoswac funkcje Hover - obsluguje zarowno MouseEnter jak i MouseLeave - 
        //i wszystki te funkcje mozna by zastapic jedna, poprzez obsluge sender-a.
        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            int powiekszenieX = Width * 1 / 100;
            int powiekszenieY = Height * 1 / 100;
            LabelInformacje.Text = "Wyjscie z Gry";
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8 + powiekszenieX, PictureBoxWyjscie.Height * 7 / 8 + powiekszenieY);
            }
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap obrazek = new Bitmap("Resources/Grafiki menu/Wyjście.png"))
            {
                PictureBoxWyjscie.BackgroundImage = new Bitmap(obrazek, PictureBoxWyjscie.Width * 5 / 8, PictureBoxWyjscie.Height * 7 / 8);
            }
            LabelInformacje.Text = "";
        }
        #endregion
              
        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        /*
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        //Nie pojawia sie w alt+tab
        private void EkranOpcje_Load(object sender, EventArgs e)
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
        */
        #endregion

    }
}
