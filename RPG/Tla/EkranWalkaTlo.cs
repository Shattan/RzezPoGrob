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
#endregion

namespace RPG
{
    public partial class EkranWalkaTlo : Form
    {
        #region Zmienne
        EkranWalka ekranWalka;

        Random losowanie = new Random();
        #endregion

        public EkranWalkaTlo(EkranWalka ekranWalka)
        {
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            this.ekranWalka = ekranWalka;
        }

        #region Metody
        void RozmiescElementy()
        {
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
            string plansza = losowanie.Next(0, 10).ToString();
            string sciezkaPlanszy = "Resources/Grafiki tła walki/" + plansza + ".png";
            //Do losowania postaci potrzeba tu dostępu do obiektu Postac, zeby po indexach wczytywać
            //string postac = ekranGry.gra.listaPostaci[losowanie.Next(0, ekranGry.gra.listaPostaci.count)];
            string sciezkaPostaci = "Resources/Grafiki tła walki/" + plansza + ".png";
            Program.UstawObrazPolaBitwy(this, sciezkaPlanszy, "Resources/Grafiki postaci walczących/cyklop.png");


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
            DialogResult = ekranWalka.ShowDialog();
        }
        #endregion

        private void EkranWalkaTlo_Load(object sender, EventArgs e)
        {
            //Tutaj jeszcze raz, żeby co przeciwnika losowało sobie nową planszę
            KolorujElementy();
        }
    }
}
