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
        //Zmienne dla menu głównego

        #endregion

        #region Funkcje


        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            //Ustawienie tła rysowanego w menu
            PanelWyswietlacza.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło menu.png");

            //Ustawienia dolnego panelu z informacjami
            PanelInformacje.Size = new Size(Width, Height / 8);
            PanelInformacje.Location = new Point(0, Width - PanelInformacje.Size.Height);
            
            //Ustawienia panelu opcji
            PanelOpcje.Location = new Point(0, Height * 5 / 100);
            PanelOpcje.BackgroundImage = new Bitmap("Resources/Grafiki menu/Tło opcji.png");

            //Ustawienie przycisków
            PanelZPictureBoxWyjdz.Location = new Point(10, 0);
            PanelZPictureBoxWyjdz.BackgroundImage = new Bitmap("Resources/Grafiki menu/Wyjście.png");
            PictureBoxOpcje.Image = new Bitmap("Resources/Grafiki menu/Opcje.png");
            PictureBoxRuszaj.Image = new Bitmap("Resources/Grafiki menu/Ruszaj.png");
        }

        #endregion
    }
}
