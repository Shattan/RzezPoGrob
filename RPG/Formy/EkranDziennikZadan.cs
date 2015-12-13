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
        EkranGry ekranGry;      //Dostep do:-ekranGry.opcje
                                //          -Gra;

        #endregion

        public EkranDziennikZadan(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            Program.DopasujRozmiarFormyDoEkranu(this);

            LabelZadania.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 40 / 100, Screen.PrimaryScreen.Bounds.Height * 10 / 100);
            LabelOpis.Size = new Size(LabelZadania.Width, LabelZadania.Height);
            ListBoxZadania.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 35 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);
            LabelOpisZadania.Size = new Size(ListBoxZadania.Width, ListBoxZadania.Height);

            LabelZadania.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 5 / 100);
            LabelOpis.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 50 / 100, LabelZadania.Location.Y);
            ListBoxZadania.Location = new Point(LabelZadania.Location.X, LabelZadania.Location.Y + LabelZadania.Height);
            LabelOpisZadania.Location = new Point(LabelOpis.Location.X, LabelOpis.Location.Y + LabelOpis.Height);


            PictureBoxZamknij.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxZamknij.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 70 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);
         }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZamknij, "Resources/Grafiki menu/Wyjdź.png");
        }

        void UstawOpisZadania(Zadanie zadanie)
        {
            LabelOpisZadania.Text = "Zleceniodawca:\n\t" + zadanie.Zleceniodawca;
            LabelOpisZadania.Text += "\n\nCel:\n\t" + zadanie.Cel;
            LabelOpisZadania.Text += "\n\nNagroda:\n\t" + zadanie.Nagroda;
            LabelOpisZadania.Text += "\n\nOpis:\n\t" + zadanie.Opis;
        }

        void OdswiezListeZadan()
        {
            ListBoxZadania.Items.Clear();

            foreach (Zadanie zadanie in Gra.gracz.Zadania)
            {          
                ListBoxZadania.Items.Add(zadanie.Nazwa);
            }
        }
        #endregion

        #region Zdarzenia 
        private void ListBoxZadania_SelectedIndexChanged(object sender, EventArgs e)
        {
            UstawOpisZadania(Gra.gracz.Zadania[ListBoxZadania.SelectedIndex]);  
        }

        private void EkranDziennikZadan_Load(object sender, EventArgs e)
        {
            OdswiezListeZadan();
        }

        private void PictureBoxZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
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
        #endregion
    }
}
