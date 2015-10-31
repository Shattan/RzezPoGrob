using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Dodane
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace RPG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static void DopasujRozmiarFormyDoEkranu(Form formularz)
        {
            formularz.StartPosition = FormStartPosition.CenterParent;
            formularz.WindowState = FormWindowState.Maximized;
            formularz.Location = new Point(0, 0);
            formularz.Size = new Size (Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
        }


        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBox Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek,Kontrolka.Width,Kontrolka.Height);
            }
        }

        
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(PictureBox Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Panel Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Panel Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Button Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Button Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(TextBox Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(TextBox Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Label Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Label Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Form Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Form Kontrolka, string sciezkaDoObrazu)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                Kontrolka.Width = obrazek.Width;
                Kontrolka.Height = obrazek.Height;
                Kontrolka.BackgroundImage = new Bitmap(obrazek);
            }
        }
        public static void UstawObrazOsobyMowiacej(PictureBox Kontrolka, string sciezkaDoObrazu, bool przerzucWPoziomie)
        {
            using (Image obrazek = new Bitmap(sciezkaDoObrazu))
            {
                if (przerzucWPoziomie == true)
                    obrazek.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
            }
        }
        public static void UstawObrazPolaBitwy(Form Kontrolka, string sciezkaDoObrazuTla, string sciezkaDoObrazuPrzeciwnika)
        {
            using (Image obrazekTlaWalki = new Bitmap(sciezkaDoObrazuTla))
            {
                Bitmap obrazekDoWstawienia = new Bitmap(obrazekTlaWalki, Kontrolka.Width, Kontrolka.Height);
                using (Graphics grafikaWalki = Graphics.FromImage(obrazekDoWstawienia))
                {
                    using (Image obrazekPrzeciwnika = new Bitmap(sciezkaDoObrazuPrzeciwnika))
                    {
                        int szerokoscPrzeciwnika = Kontrolka.Width * 30 / 100;
                        int wysokoscPrzeciwnika = Kontrolka.Height * 50 / 100;
                        int pozycjaPrzeciwnikaX = Kontrolka.Width / 2 - szerokoscPrzeciwnika / 2;
                        int pozycjaPrzeciwnikaY = Kontrolka.Height/3;
                        grafikaWalki.DrawImage(obrazekPrzeciwnika, pozycjaPrzeciwnikaX, pozycjaPrzeciwnikaY, szerokoscPrzeciwnika, wysokoscPrzeciwnika);
                        Kontrolka.BackgroundImage = obrazekDoWstawienia;
                    }

                }
            }
        }

        //[STAThreadAttribute]
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EkranGlownyTlo());
        }
    }
}
