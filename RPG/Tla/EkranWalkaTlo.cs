#region Biblioteki systemowe
using RPG.Narzedzia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace RPG
{
    public partial class EkranWalkaTlo : Form
    {
        #region Zmienne
        String wylosowanyTeren = "";
        Przeciwnik wylosowanyPrzeciwnik;
        EkranGry ekranGry;
        #endregion

        public EkranWalkaTlo(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            this.wylosowanyTeren = ekranGry.wylosowanyTeren;
            this.wylosowanyPrzeciwnik = ManagerDostepnychPrzeciwnikow.LosujPrzeciwnika();
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie paneli z informacjami o graczu i przeciwniku
            PanelDanychGracza.Size = PanelDanychPrzeciwnika.Size = new Size(Width * 30 / 100, Height * 10 / 100);

            PanelDanychPrzeciwnika.Location = new Point(Width - PanelDanychPrzeciwnika.Width, 0);
            PanelDanychGracza.Location = new Point(0, 0);

            PictureBoxPasekHPGracza.Size = PictureBoxPasekHPPrzeciwnika.Size = PictureBoxPasekEnergiiGracza.Size = PictureBoxPasekEnergiiPrzeciwnika.Size = new Size(PanelDanychGracza.Width * 80 / 100, PanelDanychGracza.Height * 10 / 100);

            PictureBoxPasekHPGracza.Location = new Point(PanelDanychGracza.Width * 10 / 100, PanelDanychGracza.Height * 10 / 100);
            PictureBoxPasekEnergiiGracza.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);
            PictureBoxPasekHPPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y);
            PictureBoxPasekEnergiiPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);
        }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            Program.UstawObrazPolaBitwy(this, wylosowanyTeren, wylosowanyPrzeciwnik.ObrazekWalki);

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PanelDanychGracza, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PanelDanychPrzeciwnika, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPGracza, "Resources/Grafiki menu/Pasek tło.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPPrzeciwnika, "Resources/Grafiki menu/Pasek tło.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiGracza, "Resources/Grafiki menu/Pasek tło.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiPrzeciwnika, "Resources/Grafiki menu/Pasek tło.png");
        }
        #endregion
        #region Obsluga zdarzeń
        private void EkranNowaGraTlo_Shown(object sender, EventArgs e)
        {
            EkranWalka ekranWalka = new EkranWalka(ekranGry, wylosowanyPrzeciwnik);
            ekranWalka.ShowDialog();
            DialogResult = ekranWalka.DialogResult;
        }
        #endregion

        private void EkranWalkaTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
