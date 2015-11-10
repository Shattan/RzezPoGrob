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
    public partial class EkranOpcje : Form
    {
        #region Zmienne
        
        //Dostep do Formy EkranGlowny dla zdarzen:
        //ZawszeNaWierzchu, PelnyEkran
        EkranGlowny ekranGlowny;
        List<double> glosnosciPrzedUstawianiem = new List<double>();
        #endregion  

        public EkranOpcje(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
            UstawRadiobuttony();
            ZapiszGlosnosci();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
        }

        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            //UstawNaEkranie
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOdrzuc,"Resources/Grafiki menu/Odrzuć opcje.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZapisz,"Resources/Grafiki menu/Zapisz opcje.png");
        }

        #region Zapis i wczytywanie wartości przed zmianami
        void ZapiszGlosnosci()
        {
            glosnosciPrzedUstawianiem.Clear();
            foreach (MediaPlayer player in ekranGlowny.odtwarzaczeDzwieku)
            {
                glosnosciPrzedUstawianiem.Add(player.Volume);
            }
        }
        void WczytajGlosnosci()
        {
            int i = 0;
            foreach (MediaPlayer player in ekranGlowny.odtwarzaczeDzwieku)
            {
                player.Volume = glosnosciPrzedUstawianiem[i];
                i++;
            }
        }
        #endregion

        #region Sterowanie radiobuttonami
        private void AktywacjaPrzyciskiMuzyki(bool aktywowac)
        {
            if (!CheckBoxWylaczMuzyke.Checked)
            {
                if (!RadioButtonGlosnoscMuzyki1.Enabled)
                {
                    foreach (var poziomGlosnosci in GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>())
                    {
                        poziomGlosnosci.Enabled = aktywowac;
                    }
                }
            }
        }

        private void AktywacjaPrzyciskiEfektowDzwiekowych(bool aktywowac)
        {
            //Deaktywujemy przyciski
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == false)
            {
                if (RadioButtonGlosnoscEfektowDzwiekowych1.Enabled == false)
                {
                    foreach (var poziomGlosnosci in GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>())
                    {
                        poziomGlosnosci.Enabled = aktywowac;
                    }
                }
            }
        }

        private void UstawRadiobuttony()
        {
            string glosnosc;
            RadioButton ustawianyRadiobutton;
            //Buttony głośności muzyki
            int calkowita = (int)ekranGlowny.odtwarzaczeDzwieku[0].Volume;
            int dziesietna = (int)((ekranGlowny.odtwarzaczeDzwieku[0].Volume - calkowita) * 10);
            glosnosc = dziesietna.ToString();

            ustawianyRadiobutton = GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>().First(x => x.Name.EndsWith(glosnosc));
            ustawianyRadiobutton.Checked = true;

            //Buttony głośności efektów dźwiękowych
            calkowita = (int)ekranGlowny.odtwarzaczeDzwieku[2].Volume;
            dziesietna = (int)((ekranGlowny.odtwarzaczeDzwieku[2].Volume - calkowita) * 10);
            glosnosc = dziesietna.ToString();

            ustawianyRadiobutton = GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>().First(x => x.Name.EndsWith(glosnosc));
            ustawianyRadiobutton.Checked = true;
            
        }
        #endregion

        #region Kontrola głośności muzyki (odtwarzacze 0-1)
        private void WyciszMuzyke()
        {
            for (int i = 0; i < 2; i++)//Odtwarzacze 0-1 zajmować się będą muzyką
            {
                if (ekranGlowny.odtwarzaczeDzwieku[i].Volume != 0.0)
                {
                    ekranGlowny.odtwarzaczeDzwieku[i].Volume = 0.0;
                }
            }
        }

        private void UstawGlosnoscMuzyki()
        {
            string nazwaAktywnegoPoziomu = "0";

            foreach (RadioButton poziom in GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>())
            {
                if (poziom.Checked)
                {
                    nazwaAktywnegoPoziomu = poziom.Name;
                }
            }

            double glosnosc = Convert.ToDouble("0," + nazwaAktywnegoPoziomu.Substring(nazwaAktywnegoPoziomu.Length - 1));
            if (glosnosc == 0.0)
            {
                glosnosc = 1.0;
            }
            for (int i = 0; i < 2; i++)
            {
                if (ekranGlowny.odtwarzaczeDzwieku[i].Volume != glosnosc)
                    ekranGlowny.odtwarzaczeDzwieku[i].Volume = glosnosc;
            }
        }
        #endregion

        #region Kontrola głośności efektów dźwiękowych (odtwarzacze 2-ostatni)
        private void WyciszEfektyDzwiekowe()
        {
            for (int i = 2; i < ekranGlowny.odtwarzaczeDzwieku.Count; i++)//Odtwarzacze od 2 zajmować się będą dialogami i efektami
            {
                if (ekranGlowny.odtwarzaczeDzwieku[i].Volume != 0.0)
                {
                    ekranGlowny.odtwarzaczeDzwieku[i].Volume = 0.0;
                }
            }
        }

        private void UstawGlosnoscEfektyDzwiekowe()
        {
            string nazwaAktywnegoPoziomu = "0";
            foreach (RadioButton poziom in GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>())
            {
                if (poziom.Checked)
                {
                    nazwaAktywnegoPoziomu = poziom.Name;
                }
            }

            double glosnosc = Convert.ToDouble("0," + nazwaAktywnegoPoziomu.Substring(nazwaAktywnegoPoziomu.Length - 1));
            if (glosnosc == 0.0)
            {
                glosnosc = 1.0;
            }
            for (int i = 2; i < ekranGlowny.odtwarzaczeDzwieku.Count; i++)
            {
                if (ekranGlowny.odtwarzaczeDzwieku[i].Volume != glosnosc)
                    ekranGlowny.odtwarzaczeDzwieku[i].Volume = glosnosc;
            }

        }
        #endregion
        #endregion

        #region Zdarzenia

        private void PictureBoxZapisz_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void PictureBoxZapisz_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZapisz, "Resources/Grafiki menu/Zapisz opcje najechany.png");
        }
        private void PictureBoxZapisz_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZapisz, "Resources/Grafiki menu/Zapisz opcje.png");
        }

        private void PictureBoxOdrzuc_Click(object sender, EventArgs e)
        {
            WczytajGlosnosci();
            UstawRadiobuttony(); 
            UstawGlosnoscMuzyki();
            UstawGlosnoscEfektyDzwiekowe();
            DialogResult = DialogResult.Ignore;
        }
        private void PictureBoxOdrzuc_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOdrzuc, "Resources/Grafiki menu/Odrzuć opcje najechany.png");
        }
        private void PictureBoxOdrzuc_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxOdrzuc, "Resources/Grafiki menu/Odrzuć opcje.png");
        }

        private void CheckBoxWylaczMuzyke_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxWylaczMuzyke.Checked)
            {
                WyciszMuzyke();
                AktywacjaPrzyciskiMuzyki(false);
            }
            else
            {
                UstawGlosnoscMuzyki();
                AktywacjaPrzyciskiMuzyki(true);
            }
        }

        private void CheckBoxWylaczEfektyDzwiekowe_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxWylaczEfektyDzwiekowe.Checked)
            {
                WyciszEfektyDzwiekowe();
                AktywacjaPrzyciskiEfektowDzwiekowych(false);
            }
            else
            {
                UstawGlosnoscEfektyDzwiekowe();
                AktywacjaPrzyciskiEfektowDzwiekowych(true);
            }
        }

        private void RadioButtonGlosnoscMuzyki_CheckedChanged(object sender, EventArgs e)
        {
            UstawGlosnoscMuzyki();
        }

        private void RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged(object sender, EventArgs e)
        {
            UstawGlosnoscEfektyDzwiekowe();
        }

        private void CheckBoxZawszeNaWierzchu_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Opcja chwilowo niedostępna.");
            //Opcja tymczasowo nieaktywna
            /*
            if (CheckBoxZawszeNaWierzchu.Checked == true && ekranGlowny.TopMost != true)
            {
                ekranGlowny.TopMost = true;
            }
            else if (ekranGlowny.TopMost != false)
            {
                ekranGlowny.TopMost = false;
            }
            */
        }

        private void CheckBoxPelnyEkran_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Opcja chwilowo niedostępna.");
            //Opcja tymczasowo nieaktywna
            /*
            if (ekranGlowny.WindowState != FormWindowState.Maximized)
            {
                if (ekranGlowny.FormBorderStyle != FormBorderStyle.None)
                    ekranGlowny.FormBorderStyle = FormBorderStyle.None;
                ekranGlowny.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (ekranGlowny.WindowState != FormWindowState.Normal)
                {
                    ekranGlowny.WindowState = FormWindowState.Normal;
                    if (ekranGlowny.FormBorderStyle != FormBorderStyle.Sizable)
                        ekranGlowny.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
            */
        }

        #region Obsluga widocznosci okna
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            //Do dialogu nie może być tego zabezpieczenia. Dialog w razie alt+F4 zwraca po prostu Abort, albo jakoś tak.
            //e.Cancel = true;
            //Tu (w FormClosing) należy robić .Dispose() , żeby zwolnić zasoby dla innych formów
        }

        //Nie pojawia sie w alt+tab
        private void EkranOpcje_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.ShowInTaskbar = false;
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

        #endregion
    }
}
