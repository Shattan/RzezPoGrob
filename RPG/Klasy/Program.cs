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
            formularz.WindowState = FormWindowState.Maximized;
            formularz.Location = new Point(0, 0);
            formularz.Size = new Size (Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
        }


        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBox Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBox Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.SizeMode = PictureBoxSizeMode.Zoom;
                Kontrolka.Image = new Bitmap(sciezkaDoObrazu);
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.Image = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public static void UstawObrazEkwipunku(PictureBox Kontrolka, Ekwipunek przedmiot)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                Kontrolka.SizeMode = PictureBoxSizeMode.Zoom;
                
                using (Image obrazekTla = new Bitmap("Resources/Grafiki menu/Tło przedmiotu.png"))
                {
              
                    Kontrolka.BackgroundImage = new Bitmap(obrazekTla, Kontrolka.Width, Kontrolka.Height);
                    if (przedmiot != null)
                    {
                        Kontrolka.Image = new Bitmap(przedmiot.Obrazek);
                    }
 
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.Image = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + przedmiot!=null?przedmiot.Obrazek:"brak przedmiotu", "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(PictureBox Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Panel Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Panel Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Button Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Button Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(TextBox Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(TextBox Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Label Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Label Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Form Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Kontrolka, "Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazZDopasowaniemWielkosciKontrolkiDoObrazu(Form Kontrolka, string sciezkaDoObrazu)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    Kontrolka.Width = obrazek.Width;
                    Kontrolka.Height = obrazek.Height;
                    Kontrolka.BackgroundImage = new Bitmap(obrazek);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message, "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }
        public static void UstawObrazOsobyMowiacej(PictureBox Kontrolka, string sciezkaDoObrazu, bool przerzucWPoziomie)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazek = new Bitmap(sciezkaDoObrazu))
                {
                    if (przerzucWPoziomie == true)
                        obrazek.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    Kontrolka.BackgroundImage = new Bitmap(obrazek, Kontrolka.Width, Kontrolka.Height);
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu:\n" + sciezkaDoObrazu, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public static void UstawObrazPolaBitwy(Form Kontrolka, string sciezkaDoObrazuTla, string sciezkaDoObrazuPrzeciwnika)
        {
            try
            {
                Kontrolka.BackgroundImageLayout = ImageLayout.None;
                using (Image obrazekTlaWalki = new Bitmap(sciezkaDoObrazuTla))
                {
                    Bitmap obrazekDoWstawienia = new Bitmap(obrazekTlaWalki, Kontrolka.Bounds.Width, Kontrolka.Bounds.Height);
                    using (Graphics grafikaWalki = Graphics.FromImage(obrazekDoWstawienia))
                    {
                        using (Image obrazekPrzeciwnika = new Bitmap(sciezkaDoObrazuPrzeciwnika))
                        {
                            int szerokoscPrzeciwnika = Kontrolka.Bounds.Width * 30 / 100;
                            int wysokoscPrzeciwnika = Kontrolka.Bounds.Height * 50 / 100;
                            int pozycjaPrzeciwnikaX = Kontrolka.Bounds.Width / 2 - szerokoscPrzeciwnika / 2;
                            int pozycjaPrzeciwnikaY = Kontrolka.Bounds.Height / 4;
                            grafikaWalki.DrawImage(obrazekPrzeciwnika, pozycjaPrzeciwnikaX, pozycjaPrzeciwnikaY, szerokoscPrzeciwnika, wysokoscPrzeciwnika);
                            Kontrolka.BackgroundImage = obrazekDoWstawienia;
                        }

                    }
                }
            }
            catch (System.ArgumentException e)
            {
                Kontrolka.BackgroundImage = new Bitmap("Resources/Grafiki menu/Błędny obraz.png");
                MessageBox.Show(e.Message + "\nŚcieżka do obrazu tła:\n" + sciezkaDoObrazuTla + "\nŚcieżka do obrazu przeciwnika:\n" + sciezkaDoObrazuPrzeciwnika, "Błąd wczytywania obrazu", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
