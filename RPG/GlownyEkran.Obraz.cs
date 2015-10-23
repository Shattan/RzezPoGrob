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

//dodane przeze mnie
using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

#region Pozostałe biblioteki
#endregion

namespace RPG
{
    partial class GlownyEkran
    {
        #region Zmienne i obiekty globalne
        int pozycjaMgly = 0;

        #endregion

        #region Funkcje
        void UstawEkran()
        {
            if (CheckBoxZawszeNaWierzchu.Checked == true && TopMost != true)
            {
                TopMost = true;
            }
            else if (CheckBoxZawszeNaWierzchu.Checked == false && TopMost != false)
            {
                TopMost = false;
            }

            if (CheckBoxPelnyEkran.Checked == true && WindowState != FormWindowState.Maximized)
            {
                if (FormBorderStyle != FormBorderStyle.None)
                    FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;

                RozmiescElementy();
            }
            else
            {
                if (CheckBoxPelnyEkran.Checked == false && WindowState != FormWindowState.Normal)
                {
                        WindowState = FormWindowState.Normal;
                    if (FormBorderStyle != FormBorderStyle.Sizable)
                        FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
        }
        void RozmiescElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            PanelInformacje.Size = new Size(Width, Height / 8);
            PanelInformacje.Location = new Point(0, Width - PanelInformacje.Size.Height);
            PanelOpcje.Location = new Point(0, Height * 5 / 100);
            PanelOpcje.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");
            PictureBoxMglaZPrawej.Location = new Point(0, 0);
            PictureBoxMglaZPrawej.Size = new Size(Width * 2, Height);
            PictureBoxMglaZPrawej.Image = new Bitmap("Resources/Grafiki menu/Mgła.png");
        }
        void PrzesunMgle(int predkosc)
        {
            PictureBoxMglaZPrawej.Location = new Point(- pozycjaMgly, 0);
            pozycjaMgly += 1;

            if (pozycjaMgly <= Width-PictureBoxMglaZPrawej.Width)
                pozycjaMgly = 0;
        }
        void OdswiezMenu()
        {
            PrzesunMgle(-1);
        }
        #endregion
    }
}
