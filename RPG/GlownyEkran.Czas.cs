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
            if (obecnaSzerokoscEkranu != Width - Location.X || obecnaWysokoscEkranu != Height - Location.Y || !pelnyEkran.Equals(CheckBoxPelnyEkran.Checked))
            {
                OdswiezMenu(0);
                UstawEkran();
                obecnaSzerokoscEkranu = Width - Location.X;
                obecnaWysokoscEkranu = Height - Location.Y;
            }

            if (pokazOpcje == true && PanelOpcje.Visible == false)
            {
                PanelOpcje.Visible = true;
            }
            if (pokazOpcje == false && PanelOpcje.Visible == true)
            {
                PanelOpcje.Visible = false;
            }

            if (przyciskWyjdzObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 1)
            {
                OdswiezMenu(1);
                obecnaGrafikaWMenu = 1;
            }
            else if (przyciskOpcjeObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 2)
            {
                OdswiezMenu(2);
                obecnaGrafikaWMenu = 2;
            }
            else if (przyciskRuszajObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 3)
            {
                OdswiezMenu(3);
                obecnaGrafikaWMenu = 3;
            }
            else if (!przyciskOpcjeObszar.Contains(MousePosition) && !przyciskRuszajObszar.Contains(MousePosition) && !przyciskWyjdzObszar.Contains(MousePosition) && obecnaGrafikaWMenu != 0)
            {
                OdswiezMenu(0);
                obecnaGrafikaWMenu = 0;
            }


            if (obecnaGrafikaWMenu == 1 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {
                Close();
            }
            else if (obecnaGrafikaWMenu == 2 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {
                if (pokazOpcje == false)
                {
                    pokazOpcje = true;
                }
                else
                {
                    pokazOpcje = false;
                }
            }
            else if (obecnaGrafikaWMenu == 3 && MouseButtons == MouseButtons.None && poprzedniStanMyszy == MouseButtons.Left)
            {

            }

            poprzedniStanMyszy = MouseButtons;


            if (pozycjaEkranuX != Location.X)
            {
                pozycjaEkranuX = Location.X;
            }
            if (pozycjaEkranuY != Location.Y)
            {
                pozycjaEkranuY = Location.Y;
            }
            if (szerokoscEkranu != Width)
            {
                szerokoscEkranu = Width;
            }
            if (wysokoscEkranu != Height)
            {
                wysokoscEkranu = Height;
            }
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