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
    public partial class EkranDziennikZadan : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        #endregion

        #region Metody
        void RozmiescElementy()
        {
            LabelZadania.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 40 / 100, Screen.PrimaryScreen.Bounds.Height * 10 / 100);
            LabelOpis.Size = new Size(LabelZadania.Width, LabelZadania.Height);
            ListBoxZadania.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 35 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);
            LabelOpisZadania.Size = new Size(ListBoxZadania.Width, ListBoxZadania.Height);

            LabelZadania.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 5 / 100);
            LabelOpis.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 50 / 100, LabelZadania.Location.Y);
            ListBoxZadania.Location = new Point(LabelZadania.Location.X, LabelZadania.Location.Y + LabelZadania.Height);
            LabelOpisZadania.Location = new Point(LabelOpis.Location.X, LabelOpis.Location.Y + LabelOpis.Height);


            PictureBoxZamknij.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxZamknij.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);
         }

        void UstawOpisZadania(string odKodoZadanie, string cel, string nagroda, string tresc)
        {
            LabelOpisZadania.Text = "Zleceniodawca:\n\t" + odKodoZadanie;
            LabelOpisZadania.Text += "\n\nCel:\n\t" + cel;
            LabelOpisZadania.Text += "\n\nNagroda:\n\t" + nagroda;
            LabelOpisZadania.Text += "\n\nOpis:\n\t" + tresc;
        }
        void OdswiezListeZadan()
        {//tak to widzę, ale nie potrawię przekazać gry
          /* 
            foreach (Zadanie zadanie in this.gra.zadanie)
            {
                ListBoxZadania.Items.Clear();
                ListBoxZadania.Items.Add();
            }*/
        }
        #endregion

        public EkranDziennikZadan(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            RozmiescElementy();

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZamknij, "Resources/Grafiki menu/Wyjdź.png");

        }

        #region sprawiamy, ze okno jest niewidoczne w alt+tab

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
        #endregion

        private void ListBoxZadania_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxZadania.SelectedIndex == 0)
            {
                UstawOpisZadania
                    (
                        "Wieśniaczka Laura",
                        "Zabij wilki nieopodal strumienia",
                        "Niezapomniana noc z Laurą",
                        "No rusz się stary bydlaku, nie będziemy czekać wiecznie, aż wykonasz to zadanie!"
                    );
            }
        }

        private void EkranDziennikZadan_Load(object sender, EventArgs e)
        {
            OdswiezListeZadan();
        }

        private void PictureBoxZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
