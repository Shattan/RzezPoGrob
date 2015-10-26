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
    public partial class OpcjePrzezroczystosc : Form
    {
        #region Zmienne i obiekty globalne
        //zmienna umozliwiajaca odtwarzanie muzyki
        public MediaPlayer odtwarzaczMuzyki = new MediaPlayer();
        public MediaPlayer odtwarzaczOtoczenia = new MediaPlayer();
        public MediaPlayer odtwarzaczDialogow = new MediaPlayer();
        public MediaPlayer odtwarzaczEfektowSpecjalnych = new MediaPlayer();

        //zmienne sterujące
        public double obecnyPoziomGlosnosciMuzyki = 0.5;
        public double obecnyPoziomGlosnosciEfektow = 0.5;
        #endregion


        GlownyEkran glownyEkran;

        public OpcjePrzezroczystosc(GlownyEkran Eg)
        {
            InitializeComponent();
            glownyEkran = Eg;

            //Ustawienia panelu opcji
            //PictureBoxUstawienia.Image = new Bitmap("Resources/Grafiki menu/Tło opcji.png");


            PictureBoxGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/30/dół.gif");
            PictureBoxGracz.Size = new Size(PictureBoxGracz.Image.Width, PictureBoxGracz.Image.Height);

            PictureBoxOdrzuc.Image = new Bitmap("Resources/Grafiki menu/Odrzuć opcje.png");
            PictureBoxZapisz.Image = new Bitmap("Resources/Grafiki menu/Zapisz opcje.png");


            //Ustawienia dzwieku
            odtwarzaczMuzyki.Volume = obecnyPoziomGlosnosciMuzyki;
            ZmienGlosnoscOdtwarzaczyEfektow(0.5);
        }

      

        #region Funkcje
       public void OdtworzDzwiek(MediaPlayer odtwarzacz, String sciezka)
        {
            odtwarzacz.Open(new Uri(sciezka, UriKind.Relative));
            odtwarzacz.Play();
        }

        public void ZatrzymajDzwiek(MediaPlayer odtwarzacz)
        {
            odtwarzacz.Stop();
        }

        public void ZmienGlosnoscOdtwarzaczyEfektow(double glosnosc)
        {
            odtwarzaczOtoczenia.Volume = glosnosc;
            odtwarzaczDialogow.Volume = glosnosc;
            odtwarzaczEfektowSpecjalnych.Volume = glosnosc;
        }


        private void CheckBoxWylaczMuzyke_CheckedChanged(object sender, EventArgs e)
        {
            //Wylaczamy muzyke
            if (CheckBoxWylaczMuzyke.Checked && obecnyPoziomGlosnosciMuzyki != 0.0)
            {
                odtwarzaczMuzyki.Volume = 0.0;
                obecnyPoziomGlosnosciMuzyki = 0.0;

                if (RadioButtonGlosnoscMuzyki1.Enabled)
                {
                    foreach (var rB in GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>())
                    {
                        rB.Enabled = false;
                    }
                }
            }

            //Wlaczamy muzyke
            if (!CheckBoxWylaczMuzyke.Checked)
            {
                if (!RadioButtonGlosnoscMuzyki1.Enabled)
                {
                    foreach (var rB in GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>())
                    {
                        rB.Enabled = true;
                    }
                }

                UstawGlosnoscMuzyki();
            }
        }


        private void CheckBoxWylaczEfektyDzwiekowe_CheckedChanged(object sender, EventArgs e)
        {
            #region Ustawienia Efektów Dźwiękowych (odtwarzacze 2-6)
            //Wylaczamy dziweki
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == true && obecnyPoziomGlosnosciEfektow != 0.0)
            {
                odtwarzaczOtoczenia.Volume = 0.0;
                ZmienGlosnoscOdtwarzaczyEfektow(0.0);
                obecnyPoziomGlosnosciEfektow = 0.0;

                if (RadioButtonGlosnoscEfektowDzwiekowych1.Enabled == true)
                {
                    foreach (var rB in GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>())
                    {
                        rB.Enabled = false;
                    }
                }
            }

            //Wlaczamy dzwieki
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == false)
            {
                if (RadioButtonGlosnoscEfektowDzwiekowych1.Enabled == false)
                {
                    foreach (var rB in GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>())
                    {
                        rB.Enabled = true;
                    }
                }

                UstawGlosnoscEfektyDzwiekowe();
            }

            #endregion
        }

        private void RadioButtonGlosnoscMuzyki_CheckedChanged(object sender, EventArgs e)
        {
            UstawGlosnoscMuzyki();
        }

        private void RadioButtonGlosnoscEfektowDzwiekowych_CheckedChanged(object sender, EventArgs e)
        {
            UstawGlosnoscEfektyDzwiekowe();
        }

        private void UstawGlosnoscMuzyki()
        {
            if (RadioButtonGlosnoscMuzyki1.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.1)
            {
                odtwarzaczMuzyki.Volume = 0.1;
                obecnyPoziomGlosnosciMuzyki = 0.1;
            }
            if (RadioButtonGlosnoscMuzyki2.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.2)
            {
                odtwarzaczMuzyki.Volume = 0.2;
                obecnyPoziomGlosnosciMuzyki = 0.2;
            }
            if (RadioButtonGlosnoscMuzyki3.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.3)
            {
                odtwarzaczMuzyki.Volume = 0.3;
                obecnyPoziomGlosnosciMuzyki = 0.3;
            }
            if (RadioButtonGlosnoscMuzyki4.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.4)
            {
                odtwarzaczMuzyki.Volume = 0.4;
                obecnyPoziomGlosnosciMuzyki = 0.4;
            }
            if (RadioButtonGlosnoscMuzyki5.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.5)
            {
                odtwarzaczMuzyki.Volume = 0.5;
                obecnyPoziomGlosnosciMuzyki = 0.5;
            }
            if (RadioButtonGlosnoscMuzyki6.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.6)
            {
                odtwarzaczMuzyki.Volume = 0.6;
                obecnyPoziomGlosnosciMuzyki = 0.6;
            }
            if (RadioButtonGlosnoscMuzyki7.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.7)
            {
                odtwarzaczMuzyki.Volume = 0.7;
                obecnyPoziomGlosnosciMuzyki = 0.7;
            }
            if (RadioButtonGlosnoscMuzyki8.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.8)
            {
                odtwarzaczMuzyki.Volume = 0.8;
                obecnyPoziomGlosnosciMuzyki = 0.8;
            }
            if (RadioButtonGlosnoscMuzyki9.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.9)
            {
                odtwarzaczMuzyki.Volume = 0.9;
                obecnyPoziomGlosnosciMuzyki = 0.9;
            }
            if (RadioButtonGlosnoscMuzyki10.Checked == true && obecnyPoziomGlosnosciMuzyki != 1.0)
            {
                odtwarzaczMuzyki.Volume = 1.0;
                obecnyPoziomGlosnosciMuzyki = 1.0;
            }
        }


        private void UstawGlosnoscEfektyDzwiekowe()
        {

            if (RadioButtonGlosnoscEfektowDzwiekowych1.Checked == true && obecnyPoziomGlosnosciEfektow != 0.1)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.1);
                obecnyPoziomGlosnosciEfektow = 0.1;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych2.Checked == true && obecnyPoziomGlosnosciEfektow != 0.2)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.2);
                obecnyPoziomGlosnosciEfektow = 0.2;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych3.Checked == true && obecnyPoziomGlosnosciEfektow != 0.3)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.3);
                obecnyPoziomGlosnosciEfektow = 0.3;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych4.Checked == true && obecnyPoziomGlosnosciEfektow != 0.4)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.4);
                obecnyPoziomGlosnosciEfektow = 0.4;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych5.Checked == true && obecnyPoziomGlosnosciEfektow != 0.5)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.5);
                obecnyPoziomGlosnosciEfektow = 0.5;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych6.Checked == true && obecnyPoziomGlosnosciEfektow != 0.6)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.6);
                obecnyPoziomGlosnosciEfektow = 0.6;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych7.Checked == true && obecnyPoziomGlosnosciEfektow != 0.7)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.7);
                obecnyPoziomGlosnosciEfektow = 0.7;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych8.Checked == true && obecnyPoziomGlosnosciEfektow != 0.8)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.8);
                obecnyPoziomGlosnosciEfektow = 0.8;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych9.Checked == true && obecnyPoziomGlosnosciEfektow != 0.9)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(0.9);
                obecnyPoziomGlosnosciEfektow = 0.9;
            }
            if (RadioButtonGlosnoscEfektowDzwiekowych10.Checked == true && obecnyPoziomGlosnosciEfektow != 1.0)
            {
                ZmienGlosnoscOdtwarzaczyEfektow(1.0);
                obecnyPoziomGlosnosciEfektow = 1.0;
            }
        }

        #endregion

        private void CheckBoxZawszeNaWierzchu_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxZawszeNaWierzchu.Checked == true && glownyEkran.TopMost != true)
            {
                glownyEkran.TopMost = true;
            }
            else if (glownyEkran.TopMost != false)
            {
                glownyEkran.TopMost = false;
            }
        }

        private void CheckBoxPelnyEkran_CheckedChanged(object sender, EventArgs e)
        {
            if (glownyEkran.WindowState != FormWindowState.Maximized)
            {
                if (glownyEkran.FormBorderStyle != FormBorderStyle.None)
                    glownyEkran.FormBorderStyle = FormBorderStyle.None;
                glownyEkran.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (glownyEkran.WindowState != FormWindowState.Normal)
                {
                    glownyEkran.WindowState = FormWindowState.Normal;
                    if (glownyEkran.FormBorderStyle != FormBorderStyle.Sizable)
                        glownyEkran.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
        }


        #region sprawiamy, ze okno jest niewidoczne w alt+tab

        //Obsluga wychodzenia - zakaz alt+f4
        private void Opcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Do dialogu nie może być tego zabezpieczenia. Dialog w razie alt+F4 zwraca po prostu Abort, albo jakoś tak.
            //e.Cancel = true;
            //Tu (w FormClosing) należy robić .Dispose() , żeby zwolnić zasoby dla innych formów
        }

        //Nie pojawia sie w alt+tab
        private void Opcje_Load(object sender, EventArgs e)
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

        private void PictureBoxOdrzuc_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

//Notatki

/* Tutaj masz inna wersje tych funkcji wyzej, mniej miejsca zajmuje, ale wymaga konwersji ze stringa. Jak wolisz ta pierwsza wersje to tą wywal, a jak nie to zamien

        private void UstawGlosnoscMuzyki()
        {
            var checkedButton = GroupBoxGlosnoscMuzyki.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Checked);

            odtwarzaczMuzyki.Volume = Convert.ToDouble("0," + checkedButton.Text);
            obecnyPoziomGlosnosciMuzyki = Convert.ToDouble("0," + checkedButton.Text);
        }


        private void UstawGlosnoscEfektyDzwiekowe()
        {
            var checkedButton = GroupBoxGlosnoscEfektowDzwiekowych.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            ZmienGlosnoscOdtwarzaczyEfektow(Convert.ToDouble("0," + checkedButton.Text));
            obecnyPoziomGlosnosciEfektow = Convert.ToDouble("0," + checkedButton.Text);
        }
 * 
*/
