using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;

namespace RPG
{
    public partial class EkranWalka : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        #endregion

        public EkranWalka(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            InitializeComponent();
            RozmiescElementy();
        }

        #region Metody
        void RozmiescElementy()
        {
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie przycisków
            PictureBoxUcieczka.Size = new Size(Width/3,30);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxUcieczka,"Resources/Grafiki menu/Przykładowy przycisk.png");

            foreach (PictureBox przycisk in FlowLayoutPanelWyboru.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach (PictureBox przycisk in FlowLayoutPanelWyborAtakuFizycznego.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach (PictureBox przycisk in FlowLayoutPanelWyborAtakuMagicznego.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach (PictureBox przycisk in FlowLayoutPanelWyborMikstury.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }

            //Ustawienie FlowLayoutPaneli
            FlowLayoutPanelWyboru.Size = new Size(FlowLayoutPanelWyboru.Controls[0].Width+20, FlowLayoutPanelWyboru.Controls.Count * (PictureBoxUcieczka.Height + 6));
            FlowLayoutPanelWyborAtakuFizycznego.Size = FlowLayoutPanelWyboru.Size;
            FlowLayoutPanelWyborAtakuMagicznego.Size = FlowLayoutPanelWyboru.Size;
            FlowLayoutPanelWyborMikstury.Size = FlowLayoutPanelWyboru.Size;

            FlowLayoutPanelWyboru.Location = new Point(0, Height-FlowLayoutPanelWyboru.Height);
            FlowLayoutPanelWyborAtakuFizycznego.Location = FlowLayoutPanelWyboru.Location;
            FlowLayoutPanelWyborAtakuMagicznego.Location = FlowLayoutPanelWyboru.Location;
            FlowLayoutPanelWyborMikstury.Location = FlowLayoutPanelWyboru.Location;


            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width -FlowLayoutPanelWyboru.Width, FlowLayoutPanelWyboru.Height);
            LabelInformacje.Location = new Point(Width-LabelInformacje.Width, Height - LabelInformacje.Height);
            LabelInformacje.Text = "Rozpoczęłą się walka!";

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

        }
        #endregion

        #region Zdarzenia
        private void buttonWygralem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonPrzegralem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #region Panel początkowy tury
        private void PictureBoxAtakFizyczny_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuFizycznego.Visible = true;
        }

        private void PictureBoxAtakMagiczny_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuMagicznego.Visible = true;
        }

        private void PictureBoxEkwipunek_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborMikstury.Visible = true;
        }

        private void PictureBoxUcieczka_Click(object sender, EventArgs e)
        {
            Random Losuj = new Random();
            int wylosowana = Losuj.Next(0, 100);

            if (wylosowana < 50)
            {
                LabelInformacje.Text = "Próba ucieczki nieudana!";
            }
            else
            {
                LabelInformacje.Text = "Udało Ci się uciec!";
                TimerDoZamkniecia.Start();
            }
        }
        #endregion

        #region Panel ataków fizycznych
        private void PictureBoxWyjdzZAtakowFizycznych_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuFizycznego.Visible = false;
        }
        #endregion

        #region Panel ataków magicznych
        private void pictureBoxWyjdzZAtakowMagicznych_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuMagicznego.Visible = false;
        }
        #endregion

        #region Panel ekwipunku
        private void pictureBoxWyjdzZEkwipunku_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborMikstury.Visible = false;
        }
        #endregion

        private void TimerDoZamkniecia_Tick(object sender, EventArgs e)
        {
            LabelInformacje.Text = "HA! Chciałbyś, żeby się form zamknął, co?!? :D";
        }


        /*
        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        //Obsluga wychodzenia - zakaz alt+f4


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
        */
        #endregion
    }
}
