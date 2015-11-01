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
        #region Zmienne
        EkranGlowny ekranGlowny;
        EkranGry ekranGry;
        EkranGryTlo ekranGryTlo;
        #endregion

        #region Metody
        void RozmiescElementy()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "Aby rozpocząć należy wybrać postać i ją nazwać.";

            //Ustawienie przycisków
            PictureBoxWyjscie.Size = new Size(Width * 5 / 100, Height * 5 / 100);
            PictureBoxWyjscie.Location = new Point(Width * 5 / 100, Height * 5 / 100);

            PictureBoxPoprzedniBohater.Size = new Size(Width * 2 / 100, Height * 10/ 100);
            PictureBoxBohater.Size = new Size(Width * 10 / 100, PictureBoxPoprzedniBohater.Height);
            PictureBoxNastepnyBohater.Size = new Size(PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Height);

            PictureBoxPoprzedniBohater.Location = new Point(Width * 50 / 100 - (PictureBoxPoprzedniBohater.Width + PictureBoxBohater.Width + PictureBoxNastepnyBohater.Width)/2, Height * 50 / 100 - PictureBoxPoprzedniBohater.Height);
            PictureBoxBohater.Location = new Point(PictureBoxPoprzedniBohater.Location.X + PictureBoxPoprzedniBohater.Width, PictureBoxPoprzedniBohater.Location.Y);
            PictureBoxNastepnyBohater.Location = new Point(PictureBoxBohater.Location.X + PictureBoxBohater.Width, PictureBoxPoprzedniBohater.Location.Y);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjscie, "Resources/Grafiki menu/Wyjdź.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPoprzedniBohater, "Resources/Grafiki menu/Przycisk poprzedni standard.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxBohater, "Resources/Grafiki menu/Tło opcji.png");
            PictureBoxBohater.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBoxBohater.Image = new Bitmap("Resources/Grafiki postaci na mapie/0/dół.gif");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxNastepnyBohater, "Resources/Grafiki menu/Przycisk następny standard.png");


            //Ustawienie wpisywania nazwy
            TextBoxNazwa.Width = PictureBoxBohater.Width;
            PictureBoxPotwierdz.Size = new Size(TextBoxNazwa.Width, TextBoxNazwa.Height);

            TextBoxNazwa.Location = new Point(PictureBoxBohater.Location.X, PictureBoxBohater.Location.Y + PictureBoxBohater.Height);
            PictureBoxPotwierdz.Location = new Point(PictureBoxBohater.Location.X, TextBoxNazwa.Location.Y + TextBoxNazwa.Height);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz,"Resources/Grafiki menu/Zapisz opcje.png");

        }
        #endregion


        public EkranNowaGra(EkranGlowny ekranGlowny, EkranGry ekranGry, EkranGryTlo ekranGryTlo)
        {
            InitializeComponent();

            this.ekranGlowny = ekranGlowny;
            this.ekranGry = ekranGry;
            this.ekranGryTlo = ekranGryTlo;

            RozmiescElementy();      
        }


        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            //Zapisz Elementy do EkranGlowny.ekranGry.gra
            ekranGry.ZapiszNazwe(TextBoxNazwa.Text);
            ekranGryTlo.ShowDialog();
            
            //DialogResult = DialogResult.OK;
            this.Close();
        }

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
