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

        Gracz gracz = new Gracz();
        Przeciwnik przeciwnik = new Przeciwnik();

        double obecnyPoziomHPGracza = 0;
        double obecnyPoziomHPPrzeciwnika = 0;
        double obecnyPoziomEnergiiGracza = 0;
        double obecnyPoziomEnergiiPrzeciwnika = 0;
        double maksymalnyPoziomHPGracza = 0;
        double maksymalnyPoziomHPPrzeciwnika = 0;
        double maksymalnyPoziomEnergiiGracza = 0;
        double maksymalnyPoziomEnergiiPrzeciwnika = 0;
        #endregion

        public EkranWalka(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();

            RozmiescElementy();
            KolorujElementy();
            WczytajPrzeciwnikaIGracza();
            OdswiezDane();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie przycisków
            PictureBoxUcieczka.Size = new Size(Width*30/100,Height*5/100);

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

            //Ustawienie paneli z informacjami o graczu i przeciwniku
            PanelDanychGracza.Size = PanelDanychPrzeciwnika.Size = new Size(Width * 30 / 100, Height * 10 / 100);

            PanelDanychPrzeciwnika.Location = new Point(Width - PanelDanychPrzeciwnika.Width, 0);
            PanelDanychGracza.Location = new Point(0, 0);

            PictureBoxPasekHPGracza.Size = PictureBoxPasekHPPrzeciwnika.Size = PictureBoxPasekEnergiiGracza.Size = PictureBoxPasekEnergiiPrzeciwnika.Size = new Size(PanelDanychGracza.Width * 80 / 100, PanelDanychGracza.Height * 10 / 100);

            PictureBoxPasekHPGracza.Location = new Point(PanelDanychGracza.Width * 10 / 100, PanelDanychGracza.Height * 10 / 100);
            PictureBoxPasekEnergiiGracza.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);
            PictureBoxPasekHPPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y);
            PictureBoxPasekEnergiiPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);

            LabelDaneGracza.Size = new Size(PictureBoxPasekEnergiiGracza.Width, PanelDanychGracza.Height - PictureBoxPasekEnergiiGracza.Location.Y - PictureBoxPasekEnergiiGracza.Height);
            LabelDanePrzeciwnika.Size = new Size(PictureBoxPasekEnergiiPrzeciwnika.Width, PanelDanychPrzeciwnika.Height - PictureBoxPasekEnergiiPrzeciwnika.Location.Y - PictureBoxPasekEnergiiPrzeciwnika.Height);
            LabelDaneGracza.Location = new Point(PictureBoxPasekEnergiiGracza.Location.X, PictureBoxPasekEnergiiGracza.Location.Y + PictureBoxPasekEnergiiGracza.Height);
            LabelDanePrzeciwnika.Location = new Point(PictureBoxPasekEnergiiPrzeciwnika.Location.X, PictureBoxPasekEnergiiPrzeciwnika.Location.Y + PictureBoxPasekEnergiiPrzeciwnika.Height);

            obecnyPoziomHPGracza = PictureBoxPasekHPGracza.Width;
            obecnyPoziomHPPrzeciwnika = PictureBoxPasekHPPrzeciwnika.Width;
            obecnyPoziomEnergiiGracza = PictureBoxPasekEnergiiGracza.Width;
            obecnyPoziomEnergiiPrzeciwnika = PictureBoxPasekEnergiiPrzeciwnika.Width;
            maksymalnyPoziomHPGracza = PictureBoxPasekHPGracza.Width;
            maksymalnyPoziomHPPrzeciwnika = PictureBoxPasekHPPrzeciwnika.Width;
            maksymalnyPoziomEnergiiGracza = PictureBoxPasekEnergiiGracza.Width;
            maksymalnyPoziomEnergiiPrzeciwnika = PictureBoxPasekEnergiiPrzeciwnika.Width;
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(LabelInformacje, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Panele sterujące
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyboru, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborAtakuFizycznego, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborAtakuMagicznego, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborMikstury, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");

            //Przyciski sterujące
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxAtakFizyczny, "Resources/Grafiki menu/Przykładowy przycisk.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxAtakMagiczny, "Resources/Grafiki menu/Przykładowy przycisk.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxEkwipunek, "Resources/Grafiki menu/Przykładowy przycisk.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxUcieczka, "Resources/Grafiki menu/Przykładowy przycisk.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdzZAtakowFizycznych, "Resources/Grafiki menu/Przykładowy przycisk.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBoxWyjdzZAtakowMagicznych, "Resources/Grafiki menu/Przykładowy przycisk.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBoxWyjdzZEkwipunku, "Resources/Grafiki menu/Przykładowy przycisk.png");


            //Okienka informacyjne
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPGracza, "Resources/Grafiki menu/Pasek HP.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPPrzeciwnika, "Resources/Grafiki menu/Pasek HP.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiGracza, "Resources/Grafiki menu/Pasek energii.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiPrzeciwnika, "Resources/Grafiki menu/Pasek energii.png");
        }

        void WczytajPrzeciwnikaIGracza()
        {
            gracz = new Gracz(ekranGry.gra.gracz);
            przeciwnik = new Przeciwnik(ekranGry.wylosowanyPrzeciwnik);
        }

        void OdswiezDane()
        {
            //obecnyPoziomHP i obecnyPoziomEnergii bedziemy edytowac w trakcie przeliczania walki, te 4 linijki są tylko dla sprawdzenia i będą do usunięcia
            obecnyPoziomHPGracza = gracz.HP - 15;
            obecnyPoziomEnergiiGracza = gracz.Energia - 10;
            obecnyPoziomHPPrzeciwnika = przeciwnik.HP - 20;
            obecnyPoziomEnergiiPrzeciwnika = przeciwnik.Energia - 5;

            double procentHPGracza = obecnyPoziomHPGracza / gracz.HP;
            double procentHPPrzeciwnika = obecnyPoziomHPPrzeciwnika / przeciwnik.HP;
            double procentEnergiiGracza = obecnyPoziomEnergiiGracza / gracz.Energia;
            double procentEnergiiPrzeciwnika = obecnyPoziomEnergiiPrzeciwnika / przeciwnik.Energia;

            LabelDaneGracza.Text = gracz.Nazwa;
            LabelDaneGracza.Text += "\nPoziom:" + gracz.Poziom;
            LabelDaneGracza.Text += "\nPunkty życia: " + gracz.HP * procentHPGracza + "/" + gracz.HP;
            LabelDaneGracza.Text += "\nEnergia: " + gracz.Energia * procentEnergiiGracza + "/" + gracz.Energia;

            LabelDanePrzeciwnika.Text = przeciwnik.Nazwa;
            LabelDanePrzeciwnika.Text += "\nPoziom: " + przeciwnik.Poziom;
            LabelDanePrzeciwnika.Text += "\nPunkty życia: " + przeciwnik.HP * procentHPPrzeciwnika + "/" + przeciwnik.HP;
            LabelDanePrzeciwnika.Text += "\nEnergia: " + przeciwnik.Energia * procentEnergiiPrzeciwnika + "/" + przeciwnik.Energia;

            UstawPoziomPaska(PictureBoxPasekHPGracza, procentHPGracza);
            UstawPoziomPaska(PictureBoxPasekEnergiiGracza, procentEnergiiGracza);
            UstawPoziomPaska(PictureBoxPasekHPPrzeciwnika, procentHPPrzeciwnika);
            UstawPoziomPaska(PictureBoxPasekEnergiiPrzeciwnika, procentEnergiiPrzeciwnika);
        }
        void UstawPoziomPaska(PictureBox pasek, double procentPozostalo)
        {
            if (pasek.Parent.Name == "PanelDanychPrzeciwnika")
            {
                pasek.Width = (int)(procentPozostalo * pasek.Width);
            }
            else
            {
                pasek.Width = (int)(procentPozostalo * pasek.Width);
            }
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
            TimerDoZamkniecia.Stop();
            DialogResult = DialogResult.OK;
        }

        private void EkranWalka_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
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
