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
        //zmienna umozliwiajaca odtwarzanie muzyki
        MediaPlayer odtwarzacz1 = new MediaPlayer();
        MediaPlayer odtwarzacz2 = new MediaPlayer();
        MediaPlayer odtwarzacz3 = new MediaPlayer();
        MediaPlayer odtwarzacz4 = new MediaPlayer();
        MediaPlayer odtwarzacz5 = new MediaPlayer();
        MediaPlayer odtwarzacz6 = new MediaPlayer();
       
        //zmienne sterujące
        double obecnyPoziomGlosnosciMuzyki = 0.5;
        double obecnyPoziomGlosnosciEfektow = 0.5;
        #endregion

        #region Funkcje
        void OdtworzDzwiek(MediaPlayer odtwarzacz, String sciezka)
        {
            odtwarzacz.Open(new Uri(sciezka, UriKind.Relative));
            odtwarzacz.Play();
        }

        void ZatrzymajDzwiek(MediaPlayer odtwarzacz)
        {
            odtwarzacz.Stop();
        }

        void UstawGlosnosc()
        {
            #region Ustawienia Muzyki (odtwarzacz 1)
            if (CheckBoxWylaczMuzyke.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.0)
            {
                odtwarzacz1.Volume = 0.0;
                if (RadioButtonGlosnoscMuzyki1.Enabled == true)
                {
                    RadioButtonGlosnoscMuzyki1.Enabled = false;
                    RadioButtonGlosnoscMuzyki2.Enabled = false;
                    RadioButtonGlosnoscMuzyki3.Enabled = false;
                    RadioButtonGlosnoscMuzyki4.Enabled = false;
                    RadioButtonGlosnoscMuzyki5.Enabled = false;
                    RadioButtonGlosnoscMuzyki6.Enabled = false;
                    RadioButtonGlosnoscMuzyki7.Enabled = false;
                    RadioButtonGlosnoscMuzyki8.Enabled = false;
                    RadioButtonGlosnoscMuzyki9.Enabled = false;
                    RadioButtonGlosnoscMuzyki10.Enabled = false;
                }
                obecnyPoziomGlosnosciMuzyki = 0.0;
            }

            if (CheckBoxWylaczMuzyke.Checked == false)
            {
                if (RadioButtonGlosnoscMuzyki1.Enabled == false)
                {
                    RadioButtonGlosnoscMuzyki1.Enabled = true;
                    RadioButtonGlosnoscMuzyki2.Enabled = true;
                    RadioButtonGlosnoscMuzyki3.Enabled = true;
                    RadioButtonGlosnoscMuzyki4.Enabled = true;
                    RadioButtonGlosnoscMuzyki5.Enabled = true;
                    RadioButtonGlosnoscMuzyki6.Enabled = true;
                    RadioButtonGlosnoscMuzyki7.Enabled = true;
                    RadioButtonGlosnoscMuzyki8.Enabled = true;
                    RadioButtonGlosnoscMuzyki9.Enabled = true;
                    RadioButtonGlosnoscMuzyki10.Enabled = true;
                }

                if (RadioButtonGlosnoscMuzyki1.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.1)
                {
                    odtwarzacz1.Volume = 0.1;
                    obecnyPoziomGlosnosciMuzyki = 0.1;
                }
                if (RadioButtonGlosnoscMuzyki2.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.2)
                {
                    odtwarzacz1.Volume = 0.2;
                    obecnyPoziomGlosnosciMuzyki = 0.2;
                }
                if (RadioButtonGlosnoscMuzyki3.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.3)
                {
                    odtwarzacz1.Volume = 0.3;
                    obecnyPoziomGlosnosciMuzyki = 0.3;
                }
                if (RadioButtonGlosnoscMuzyki4.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.4)
                {
                    odtwarzacz1.Volume = 0.4;
                    obecnyPoziomGlosnosciMuzyki = 0.4;
                }
                if (RadioButtonGlosnoscMuzyki5.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.5)
                {
                    odtwarzacz1.Volume = 0.5;
                    obecnyPoziomGlosnosciMuzyki = 0.5;
                }
                if (RadioButtonGlosnoscMuzyki6.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.6)
                {
                    odtwarzacz1.Volume = 0.6;
                    obecnyPoziomGlosnosciMuzyki = 0.6;
                }
                if (RadioButtonGlosnoscMuzyki7.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.7)
                {
                    odtwarzacz1.Volume = 0.7;
                    obecnyPoziomGlosnosciMuzyki = 0.7;
                }
                if (RadioButtonGlosnoscMuzyki8.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.8)
                {
                    odtwarzacz1.Volume = 0.8;
                    obecnyPoziomGlosnosciMuzyki = 0.8;
                }
                if (RadioButtonGlosnoscMuzyki9.Checked == true && obecnyPoziomGlosnosciMuzyki != 0.9)
                {
                    odtwarzacz1.Volume = 0.9;
                    obecnyPoziomGlosnosciMuzyki = 0.9;
                }
                if (RadioButtonGlosnoscMuzyki10.Checked == true && obecnyPoziomGlosnosciMuzyki != 1.0)
                {
                    odtwarzacz1.Volume = 1.0;
                    obecnyPoziomGlosnosciMuzyki = 1.0;
                }
            }
            #endregion

            #region Ustawienia Efektów Dźwiękowych (odtwarzacze 2-6)
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == true && obecnyPoziomGlosnosciEfektow != 0.0)
            {
                odtwarzacz2.Volume = 0.0;
                ZmienGlosnoscOdtwarzaczyEfektow(0.0);
                obecnyPoziomGlosnosciEfektow = 0.0;

                if (RadioButtonGlosnoscEfektowDzwiekowych1.Enabled == true)
                {
                    RadioButtonGlosnoscEfektowDzwiekowych1.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych2.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych3.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych4.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych5.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych6.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych7.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych8.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych9.Enabled = false;
                    RadioButtonGlosnoscEfektowDzwiekowych10.Enabled = false;
                }
            }
            if (CheckBoxWylaczEfektyDzwiekowe.Checked == false)
            {
                if (RadioButtonGlosnoscEfektowDzwiekowych1.Enabled == false)
                {
                    RadioButtonGlosnoscEfektowDzwiekowych1.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych2.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych3.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych4.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych5.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych6.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych7.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych8.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych9.Enabled = true;
                    RadioButtonGlosnoscEfektowDzwiekowych10.Enabled = true;
                }

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
        }

        void ZmienGlosnoscOdtwarzaczyEfektow(double glosnosc)
        {
            odtwarzacz2.Volume = glosnosc;
            odtwarzacz3.Volume = glosnosc;
            odtwarzacz4.Volume = glosnosc;
            odtwarzacz5.Volume = glosnosc;
            odtwarzacz6.Volume = glosnosc;
        }
        #endregion
    }
}
