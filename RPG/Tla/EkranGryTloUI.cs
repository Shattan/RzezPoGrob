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
    public partial class EkranGryTloUI : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        #endregion

        public EkranGryTloUI(EkranGlowny ekranGlowny)
        {
            InitializeComponent();
            Program.DopasujRozmiarFormyDoEkranu(this);
            this.ekranGlowny = ekranGlowny;
            //BackgroundImage =  new Bitmap("Resources/Mapy/Trawa.png");               
        }

        #region Metody
        public void UstawPanelPrawy(Point point, Size size, String sciezkaGrafiki)
        {
            panelPraweMenu.Location = point;
            panelPraweMenu.Size = size;
            panelPraweMenu.BackgroundImage = new Bitmap(sciezkaGrafiki);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(panelPraweMenu, sciezkaGrafiki);
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranGryTloUI_Shown(object sender, EventArgs e)
        {
            DialogResult = ekranGlowny.ekranGry.ShowDialog();
        }
        #endregion
    }
}



