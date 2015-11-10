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
    public partial class EkranGryUITlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        EkranGryMapaTlo ekranGryMapaTlo;
        EkranGryObiektyTlo ekranGryObiektyTlo;
        #endregion

        public EkranGryUITlo(EkranGlowny ekranGlowny, EkranGryMapaTlo ekranGryMapaTlo, EkranGryObiektyTlo ekranGryObiektyTlo)
        {
            this.ekranGlowny = ekranGlowny;    
            this.ekranGryMapaTlo = ekranGryMapaTlo;
            this.ekranGryObiektyTlo = ekranGryObiektyTlo;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();     
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            Program.DopasujRozmiarFormyDoEkranu(this);
        }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
        }

        public void UstawPanelPrawy(Size size, Point point, String sciezkaGrafiki)
        {
            panelPraweMenu.Size = size;
            panelPraweMenu.Location = point;
            panelPraweMenu.BackgroundImage = new Bitmap(sciezkaGrafiki);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(panelPraweMenu, sciezkaGrafiki);
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTloUI_Shown(object sender, EventArgs e)
        {
            EkranGry ekranGry = new EkranGry(ekranGlowny, ekranGryMapaTlo, ekranGryObiektyTlo, this);
            ekranGry.ShowDialog();
            DialogResult = ekranGry.DialogResult;
        }
        #endregion

        private void EkranGryUITlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}



