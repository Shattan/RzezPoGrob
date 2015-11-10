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

using System.Media;
using System.Threading;
using System.Windows.Media;
#endregion

namespace RPG
{
    public partial class EkranGlowny : Form
    {
        #region Zmienne
        EkranGlownyTlo ekranGlownyTlo;
        //Publiczne wskazywanie z ktrego odtwarzacza chcemy skorzystac
        //Zalecam zmienienie ich na prywatne i zrobienia publicznych metod "OdtworzMuzyke" "OdtworzOtoczenie" itd
        public List<MediaPlayer> odtwarzaczeDzwieku { get; set; }
        public List<double> poprzedniStanGlosnosciOdtwarzaczy = new List<double>();
        public List<double> aktualnyStanGlosnosciOdtwarzaczy = new List<double>();
        public List<bool> wolneOdtwarzacze = new List<bool>();

        public Gra gra = new Gra();
        //Dostep dla tej formy
        //Od najwyżej do najzniszej położonej warstwy Form:
        //EkranGry
        //EkranGryUITlo
        //EkranGryObiektyTlo
        //EkranGryMapaTlo
        #endregion

        public EkranGlowny(EkranGlownyTlo ekranGlownyTlo)
        {
            this.ekranGlownyTlo = ekranGlownyTlo;
            UtworzOdtwarzacze();

            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            OdtworzDzwiek("Resources/Dźwięki/VC-HOfaH.wav");
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            //Zmaksymalizowanie okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);
            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "Witaj w grze!";

            PictureBoxObrazWczytywania.Size = new Size(Width, Height);
            PictureBoxObrazWczytywania.Location = new Point(0, 0);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxObrazWczytywania, "Resources/Grafiki menu/Obraz wczytywania.png");

            //Ustawienie wielkości przycisków
            int szerokoscPrzyciskow = Width * 7 / 100;
            int wysokoscPrzyciskow = Height * 15 / 100;
            PictureBoxWyjdz.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxOpcje.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxWczytaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);
            PictureBoxRuszaj.Size = new Size(szerokoscPrzyciskow, wysokoscPrzyciskow);

            //Ustawienie pozycji przycisków
            const int odlegloscMiedzyPrzyciskami = 15;
            const int podniesieniePrzyciskow = 10;
            PictureBoxWyjdz.Location = new Point(odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxOpcje.Location = new Point(PictureBoxWyjdz.Location.X + PictureBoxOpcje.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxWczytaj.Location = new Point(PictureBoxOpcje.Location.X + PictureBoxWczytaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X + PictureBoxRuszaj.Width + odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);

            //Przeniesienie przyciskow na prawa strone:
            //PictureBoxWyjdz.Location = new Point(Width - PictureBoxOpcje.Width - 10, -10);
            //PictureBoxOpcje.Location = new Point(PictureBoxWyjdz.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            //PictureBoxWczytaj.Location = new Point(PictureBoxOpcje.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
            //PictureBoxRuszaj.Location = new Point(PictureBoxWczytaj.Location.X - PictureBoxRuszaj.Width - odlegloscMiedzyPrzyciskami, -podniesieniePrzyciskow);
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            //Obrazy dla przycisków
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }
        void UtworzOdtwarzacze()
        {
            //Inicjalizacje MediaPlayery w tablicy
            odtwarzaczeDzwieku = new List<MediaPlayer>();
            const int iloscOdtwarzaczy = 10;
            aktualnyStanGlosnosciOdtwarzaczy.Clear();
            for (int i = 0; i < iloscOdtwarzaczy; i++)
            {
                MediaPlayer odtwarzacz = new MediaPlayer();
                odtwarzacz.Volume = 0.5;
                aktualnyStanGlosnosciOdtwarzaczy.Add(0.5);
                odtwarzaczeDzwieku.Add(odtwarzacz);
            }
        }

        public void OdswiezWolneOdtwarzacze()
        {
            wolneOdtwarzacze.Clear();
            foreach (MediaPlayer odtwarzacz in odtwarzaczeDzwieku)
            {
                if (odtwarzacz.HasAudio)
                {
                    if (odtwarzacz.NaturalDuration == odtwarzacz.Position)
                    {
                        wolneOdtwarzacze.Add(true);
                    }
                    else
                    {
                        wolneOdtwarzacze.Add(false);
                    }
                }
                else
                {
                    wolneOdtwarzacze.Add(true);
                }
            }
        }

        public void OdtworzDzwiek(String sciezka)
        {
            OdswiezWolneOdtwarzacze();
            int indexWolnegoOdtwarzacza = wolneOdtwarzacze.FindIndex(x => x == true);
            if (indexWolnegoOdtwarzacza >= 0)
            {
                odtwarzaczeDzwieku[indexWolnegoOdtwarzacza].Open(new Uri(sciezka, UriKind.Relative));
                odtwarzaczeDzwieku[indexWolnegoOdtwarzacza].Play();
            }
        }

        public void ZatrzymajDzwiek(string sciezkaDzwieku)
        {
            MediaPlayer odtwarzaczDoZatrzymania = odtwarzaczeDzwieku.Find(x => x.Source.Equals(sciezkaDzwieku));
            odtwarzaczDoZatrzymania.Stop();
        }
        public void ZatrzymajWszystkieOdtwarzacze()
        {
            foreach (MediaPlayer odtwarzacz in odtwarzaczeDzwieku)
            {
                odtwarzacz.Stop();
            }
        }

        //Metoda do zmiany głośności grających odtwarzaczy (przyciszenie wszystkiego, gdy chcemy zaakcentować na przykład rozmowę)
        public void ZmienGlosnoscGrajacychOdtwarzaczy(double glosnosc)
        {
            OdswiezWolneOdtwarzacze();
            int i = 0;
            foreach (MediaPlayer odtwarzacz in odtwarzaczeDzwieku)
            {
                if (wolneOdtwarzacze[i] == false)
                {
                    poprzedniStanGlosnosciOdtwarzaczy[i]=odtwarzacz.Volume;
                    odtwarzacz.Volume = glosnosc;
                    aktualnyStanGlosnosciOdtwarzaczy[i]=glosnosc;
                }
                aktualnyStanGlosnosciOdtwarzaczy[i]=aktualnyStanGlosnosciOdtwarzaczy[i];
                poprzedniStanGlosnosciOdtwarzaczy[i]=poprzedniStanGlosnosciOdtwarzaczy[i];
                i++;
            }
        }
        //Metoda do przywrócenia poprzedniej głośności
        public void PrzywrocGlosnoscOdtwarzaczy()
        {
            int i = 0;
            foreach (MediaPlayer odtwarzacz in odtwarzaczeDzwieku)
            {
                if (wolneOdtwarzacze[i] == false)
                {
                    odtwarzacz.Volume = poprzedniStanGlosnosciOdtwarzaczy[i];
                    aktualnyStanGlosnosciOdtwarzaczy[i] = odtwarzacz.Volume;
                }
                i++;
            }
        }
        //Metoda do zmiany głośności pojedynczego odtwarzacza
        public void ZmienGlosnoscKonkretnegoOdtwarzacza(MediaPlayer odtwarzacz, double glosnosc)
        {
            odtwarzacz.Volume = glosnosc;
        }

        void PrzeskalujPrzycisk(bool powiekszanie, PictureBox przycisk, String obrazPrzycisku)
        {
            int powiekszenie;
            if (powiekszanie == true)
            {
                powiekszenie = Width * 1 / 100;
            }
            else
            {
                powiekszenie = -Width * 1 / 100;
            }
            przycisk.Size = new Size(przycisk.Width + powiekszenie, przycisk.Height + powiekszenie);
            przycisk.Location = new Point(przycisk.Location.X - powiekszenie / 2, przycisk.Location.Y - powiekszenie / 2);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(przycisk, obrazPrzycisku);
        }

        private void Deserializuj()
        {
            //[TODO] Deserializacja z pliku xml
        }

        private void UruchomGre()
        {
            ZatrzymajWszystkieOdtwarzacze();
            PictureBoxObrazWczytywania.Visible = true;
            EkranGryMapaTlo ekranGryMapaTlo = new EkranGryMapaTlo(this);
            ekranGryMapaTlo.ShowDialog();
            
            if (ekranGryMapaTlo.DialogResult == DialogResult.OK)
            {
                PictureBoxObrazWczytywania.Visible = false;
                OdtworzDzwiek("Resources/Dźwięki/VC-HOfaH.wav");
                //DialogResult = DialogResult.OK;
            }
            else if (ekranGryMapaTlo.DialogResult == DialogResult.Cancel)
            {
                PictureBoxObrazWczytywania.Visible = false;
                OdtworzDzwiek("Resources/Dźwięki/VC-HOfaH.wav");
                //DialogResult = DialogResult.Cancel;
            }
            else if (ekranGryMapaTlo.DialogResult == DialogResult.Abort)
            {
                PictureBoxObrazWczytywania.Visible = false;
                OdtworzDzwiek("Resources/Dźwięki/VC-HOfaH.wav");
                //DialogResult = DialogResult.Abort;
            }
        }
        #endregion
     
        #region Zdarzenia
        private void PictureBoxOpcje_Click(object sender, EventArgs e)
        {
            EkranOpcjeTlo ekranOpcjeTlo = new EkranOpcjeTlo(this);
            ekranOpcjeTlo.ShowDialog();
            if (ekranOpcjeTlo.DialogResult == DialogResult.OK)//Jeżeli kliknięto "Zapisz Opcje"
            {
                MessageBox.Show("Ustawienia zapisane pomyślnie");
            }
            else if (ekranOpcjeTlo.DialogResult == DialogResult.Ignore)//Jeżeli kliknięto "Odrzuć Opcje"
            {
                MessageBox.Show("Przywrócono ustawienia sprzed zmian");
            }
            else
            {
                MessageBox.Show("Proszę używać przycisków");
            }
        }

        private void PictureBoxRuszaj_Click(object sender, EventArgs e)
        {
            PictureBoxObrazWczytywania.Visible = true;
            EkranEkranNowaGraTlo ekranNowaGraTlo = new EkranEkranNowaGraTlo(this);
            ekranNowaGraTlo.ShowDialog();
            if (ekranNowaGraTlo.DialogResult == DialogResult.OK)
            {
                UruchomGre();
            }
            else
            {
                PictureBoxObrazWczytywania.Visible = false;
            }
        }

        private void PictureBoxWczytaj_Click(object sender, EventArgs e)
        {
            Deserializuj();
            UruchomGre();
        }

        private void PictureBoxWyjscie_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        #region Powiekszanie przyciskow
        private void PictureBoxWyjscie_MouseEnter(object sender, EventArgs e)
        {
            OdtworzDzwiek("Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Wyjdź z gry.";
            PrzeskalujPrzycisk(true,PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
        }

        private void PictureBoxWyjscie_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false,PictureBoxWyjdz, "Resources/Grafiki menu/Wiej.png");
        }

        private void PictureBoxWczytaj_MouseEnter(object sender, EventArgs e)
        {
            OdtworzDzwiek("Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Wczytaj poprzednio zaczętą przygodę.";
            PrzeskalujPrzycisk(true, PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
        }

        private void PictureBoxWczytaj_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxWczytaj, "Resources/Grafiki menu/Wczytaj.png");
        }

        private void PictureBoxOpcje_MouseEnter(object sender, EventArgs e)
        {
            OdtworzDzwiek("Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Dostosuj grę do swoich potrzeb.";
            PrzeskalujPrzycisk(true, PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
        }

        private void PictureBoxOpcje_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxOpcje, "Resources/Grafiki menu/Opcje.png");
        }

        private void PictureBoxRuszaj_MouseEnter(object sender, EventArgs e)
        {
            OdtworzDzwiek("Resources/Dźwięki/szyld.wav");
            LabelInformacje.Text = "Rozpocznij nową przygodę!";
            PrzeskalujPrzycisk(true, PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }

        private void PictureBoxRuszaj_MouseLeave(object sender, EventArgs e)
        {
            LabelInformacje.Text = "Witaj! Rozgość się.";
            PrzeskalujPrzycisk(false, PictureBoxRuszaj, "Resources/Grafiki menu/Do boju.png");
        }
        #endregion

        private void EkranGlowny_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        #endregion
    }
}

