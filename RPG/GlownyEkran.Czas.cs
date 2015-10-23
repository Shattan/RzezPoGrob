using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//dodane przeze mnie
using System.Media;
using System.Threading;
using System.Windows.Media;

namespace RPG
{
    partial class GlownyEkran
    {
        #region Akcje związane z upływem czasu (bądź zapętleniem)

        private void Zegar_Tick(object sender, EventArgs e)
        {
            UstawGlosnosc();
            OdswiezMenu();
            /*
            LabelInformacje.Text = pozycjaEkranuX + "  \t";
            LabelInformacje.Text += pozycjaEkranuY + "  \n";
            LabelInformacje.Text += szerokoscEkranu + "  \t";
            LabelInformacje.Text += wysokoscEkranu + "  \n";*/
            //LabelInformacyjny.Text = "Pozycja myszki: " + MousePosition.ToString() + "\n";
            //LabelInformacyjny.Text += MouseButtons.ToString() + "\n";
        }

        #endregion

    }

}