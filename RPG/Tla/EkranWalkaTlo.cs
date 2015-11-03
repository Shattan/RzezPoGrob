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
        }
        void KolorujElementy()
        {
            string plansza = losowanie.Next(0, 10).ToString();
            string sciezkaPlanszy = "Resources/Grafiki tła walki/" + plansza + ".png";
            //Do losowania postaci potrzeba tu dostępu do obiektu Postac, zeby po indexach wczytywać
            //string postac = losowanie.Next(0, 0).ToString();
            //string sciezkaPostaci = "Resources/Grafiki tła walki/" + plansza + ".png";
            Program.UstawObrazPolaBitwy(this, sciezkaPlanszy, "Resources/Grafiki postaci walczących/cyklop.png");
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
