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
using RPG.Narzedzia;
#endregion

namespace RPG
{
    public partial class EkranOpcje : Form
    {
        #region Zmienne
        
        //Dostep do Formy EkranGlowny dla zdarzen:
        //ZawszeNaWierzchu, PelnyEkran
        EkranGlowny ekranGlowny;
        #endregion  

        public EkranOpcje(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
            UstawRadiobuttony();
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
            double glosnosc = Ustawienia.GlosnoscMuzyki;
            if (glosnosc == 0.0)
            {
                CheckBoxWylaczMuzyke.Checked = true;
                AktywacjaPrzyciskiMuzyki(false);
            }
            else
            {
                string glosnoscstr = ((int)glosnosc).ToString();
                RadioButton ustawianyRadiobutton;
                //Buttony głośności muzyki

                ustawianyRadiobutton = GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>().First(x => x.Text.Equals(glosnoscstr));
                ustawianyRadiobutton.Checked = true;
            }
            //Buttony głośności efektów dźwiękowych
            glosnosc = Ustawienia.GlosnoscDzwiekow;
            if (glosnosc == 0.0)
            {
                CheckBoxWylaczEfektyDzwiekowe.Checked = true;
                AktywacjaPrzyciskiEfektowDzwiekowych(false);
            }
            else
            {
                string glosnoscstr = ((int)glosnosc).ToString();
                RadioButton ustawianyRadiobutton;
                //Buttony głośności muzyki

                ustawianyRadiobutton = GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>().First(x => x.Text.Equals(glosnoscstr));
                ustawianyRadiobutton.Checked = true;
            }
            //Buttony g
            
        }
        #endregion

        #region Kontrola głośności muzyki (odtwarzacze 0-1)
        private double AktualnaGlosnoscMuzyki()
        {
        
            double glosnosc = 0;
            if (CheckBoxWylaczMuzyke.Checked)
            {
                glosnosc = 0;
            }
            else
            {
                foreach (RadioButton poziom in GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>())
                {
                    if (poziom.Checked)
                    {
                        glosnosc = int.Parse(poziom.Text);
                        break;
                    }
                }

            }
            return glosnosc;
        }
        private void UstawGlosnoscMuzyki()
        {
            double glosnosc = AktualnaGlosnoscMuzyki();
            for (int i = 0; i < 2; i++)
            {
                OdtwrzaczManager.UstawGlosnosc(0, glosnosc);
                OdtwrzaczManager.UstawGlosnosc(1, glosnosc);
            }
        }
        #endregion

        #region Kontrola głośności efektów dźwiękowych (odtwarzacze 2-ostatni)
        private double AktualnaGlosnoscDzwieki()
        {

            double glosnosc = 0;
            if (CheckBoxWylaczEfektyDzwiekowe.Checked)
            {
                glosnosc = 0;
            }
            else
            {
                foreach (RadioButton poziom in GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>())
                {
                    if (poziom.Checked)
                    {
                        glosnosc = int.Parse(poziom.Text);
                        break;
                    }
                }

            }
            return glosnosc;
        }
        private void UstawGlosnoscEfektyDzwiekowe()
        {
            double glosnosc = AktualnaGlosnoscDzwieki();
            for (int i = 2; i < OdtwrzaczManager.LiczbaOdtwarzaczy; i++)
            {
                OdtwrzaczManager.UstawGlosnosc(i, glosnosc);
            }

        }
        #endregion
        #endregion
        #region Zdarzenia

        private void PictureBoxZapisz_Click(object sender, EventArgs e)
        {
            Ustawienia.GlosnoscDzwiekow = AktualnaGlosnoscDzwieki();
            Ustawienia.GlosnoscMuzyki = AktualnaGlosnoscMuzyki();
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
            OdtwrzaczManager.UstawDomyslneGlosnosci();
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
            UstawGlosnoscMuzyki();
            AktywacjaPrzyciskiMuzyki(!CheckBoxWylaczMuzyke.Checked);
        }

        private void CheckBoxWylaczEfektyDzwiekowe_CheckedChanged(object sender, EventArgs e)
        {
            UstawGlosnoscEfektyDzwiekowe();
            AktywacjaPrzyciskiEfektowDzwiekowych(!CheckBoxWylaczEfektyDzwiekowe.Checked);
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
