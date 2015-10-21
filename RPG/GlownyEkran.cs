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
    public partial class GlownyEkran : Form
    {
        public GlownyEkran()
        {
            InitializeComponent();

            //Obraz
            RozmiescElementy();
            UstawPozycjeIWielkoscPrzyciskow(pozycjaEkranuX, pozycjaEkranuY, szerokoscEkranu, wysokoscEkranu);
            OdswiezMenu(0);

            //Gra
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();

            //Dzwiek
            odtwarzacz1.Volume = 0.5;
            ZmienGlosnoscOdtwarzaczyEfektow(0.5);
            OdtworzDzwiek(odtwarzacz1, "Resources/Dźwięki/VC-HOfaH.wav");

            //Czas
            Zegar.Start();
        }
    }
}
