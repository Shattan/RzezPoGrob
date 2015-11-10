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
    public partial class EkranOpcjeTlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        #endregion

        public EkranOpcjeTlo(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
        }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
        }
        #endregion

        #region Obsluga zdarzeń
        private void EkranEkranOpcjeTlo_Shown(object sender, EventArgs e)
        {
            EkranOpcje ekranOpcje = new EkranOpcje(ekranGlowny);
            ekranOpcje.ShowDialog();
            DialogResult = ekranOpcje.DialogResult;//Przekazanie wyniku dialogu dalej
        }
        #endregion

        private void EkranOpcjeTlo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
