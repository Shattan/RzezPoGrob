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

    public partial class EkranGlownyTlo : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;

        static readonly Image obrazTla = new Bitmap("Resources/Grafiki menu/Tło menu.png");
        readonly Bitmap tlo = new Bitmap(obrazTla, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        #endregion

        public EkranGlownyTlo()
        {

            InitializeComponent();

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            ekranGlowny = new EkranGlowny(this);
            BackColor = System.Drawing.Color.Black;

            BackgroundImage = tlo;            
        }

        #region Obsluga zdarzeń
        private void EkranGlownyTlo_Shown(object sender, EventArgs e)
        {
            DialogResult dr = ekranGlowny.ShowDialog();
            if (dr == DialogResult.Abort)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}



/*   #region sprawiamy, ze okno jest niewidoczne w alt+tab

   //Obsluga wychodzenia - zakaz alt+f4
   private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
   {
       e.Cancel = true;
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
}
 */