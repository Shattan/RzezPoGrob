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
using RPG.Narzedzia;
using System.Runtime.InteropServices;
using RPG.Klasy;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
#endregion

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        public string Komunikat = "";
        public int CzasWyswietlanieKomunikatu;
        //Zmienne dla przyciskow
        PictureBox[] praweMenu;
        const int SzybkoscRuchow = 5;
        public enum Ruch
        {
            Lewo = 0,
            Prawo = 1,
            Gora = 2,
            Dol = 3,
        }
        #endregion
      public  Obszar obszarGry;
      int[] pozycjaGracza;
        public EkranGry(EkranGlowny ekranGlowny)
        {
            this.ekranGlowny = ekranGlowny;
         
            obszarGry = ManagerObszarow.WczytajObszar("mapa");
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
            DodajZdarzeniaDlaPrawegoMenu();
            timerPrzeplywCzasu.Interval = 15;
            timerPrzeplywCzasu.Start();
            pozycjaGracza = new int[] { obszarGry.PozycjaStartowaGracza[0] * 32, obszarGry.PozycjaStartowaGracza[1] * 48 };
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Wczytanie Right Menu Panel
            List<string> ListaObrazkow = new List<string>();
            ListaObrazkow.Add("Resources/Grafiki menu/Adark.png");
            ListaObrazkow.Add("Resources/Grafiki menu/Bdark.png");
           // ListaObrazkow.Add("Resources/Grafiki menu/Cdark.png");
            //ListaObrazkow.Add("Resources/Grafiki menu/D.png");
            //ListaObrazkow.Add("Resources/Grafiki menu/E.png");

            const int wielkoscPrzyciskow = 80;
            const int odlegloscMiedzyPrzyciskami = 20;
            int iloscPrzyciskow = ListaObrazkow.Count();

            panelPraweMenu.Size = new Size(wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami, wielkoscPrzyciskow * iloscPrzyciskow + odlegloscMiedzyPrzyciskami * iloscPrzyciskow);
            panelPraweMenu.Location = new Point(Screen.PrimaryScreen.Bounds.Width - panelPraweMenu.Width, 0);

            praweMenu = new PictureBox[iloscPrzyciskow];
            for (int index = 0; index < praweMenu.Length; index++)
            {
                praweMenu[index] = new PictureBox();
                panelPraweMenu.Controls.Add(praweMenu[index]);
                praweMenu[index].Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
                praweMenu[index].Location = new Point(odlegloscMiedzyPrzyciskami, index * wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami);
                Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[index], ListaObrazkow[index]);
                //praweMenu[index].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenu_MouseEnter);
                //praweMenu[index].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenu_MouseLeave);
            }

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(Wstecz, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
        }

        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

        }

        void DodajZdarzeniaDlaPrawegoMenu()
        {
            praweMenu[0].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[0].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseEnter);
            praweMenu[0].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseLeave);
            praweMenu[1].Click += new System.EventHandler(this.PictureBoxPraweMenuEkranDziennikZadan_MouseClick);
            praweMenu[1].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuDziennikZadan_MouseEnter);
            praweMenu[1].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuDziennikZadan_MouseLeave);
            //praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseClick);
            //praweMenu[2].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseEnter);
            //praweMenu[2].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseLeave);
            //praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[3].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[4].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
        }
       public void UniewidocznijGre()
        {
            Hide();
        }
       public void UwidocznijGre()
        {
            Show();
        }
       [DllImport("user32.dll")]
       public extern static Int16 GetKeyState(Int16 nVirtKey);

        /// <summary>
        /// Czy wcisnięto określony klawissz
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
       public static bool CzyWczysnieto(Keys key)
       {
           return (GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;
       }
        private void PokazEkwipunek()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            EkranEkwipunek ekranEkwipunekTlo = new EkranEkwipunek(this);
            ekranEkwipunekTlo.ShowDialog();

                UwidocznijGre();
                timerPrzeplywCzasu.Start();
         
        }

        private void PokazDziennikZadan()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            EkranDziennikZadan ekranEkranDziennikZadanTlo = new EkranDziennikZadan(this);
            ekranEkranDziennikZadanTlo.ShowDialog();

                UwidocznijGre();
                timerPrzeplywCzasu.Start();
          
        }

        private void PokazMenuWyboru()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            timerPrzeplywCzasu.Start();
            UwidocznijGre();
        }
        #endregion

        #region Zdarzenia
        private void timerPrzeplywCzasu_Tick(object sender, EventArgs e)
        {
            bool odswierzamy=false;
            if (!string.IsNullOrEmpty(Komunikat))
            {
                if (CzasWyswietlanieKomunikatu > 0)
                {
                    CzasWyswietlanieKomunikatu -= timerPrzeplywCzasu.Interval;
                }
                if (CzasWyswietlanieKomunikatu <= 0)
                {
                    odswierzamy = true;
                    Komunikat = null;
                    CzasWyswietlanieKomunikatu = 0;
                }
            }
            bool bylaKolizja = false;
            Ruch? kierunekRuchuGracz=null;
      
            int px=0;
            int py=0;
            if(CzyWczysnieto(Keys.Up))
            {
                kierunekRuchuGracz = Ruch.Gora;
                py-=SzybkoscRuchow;
                Gra.gracz.AktualnyObrazek = "góra.gif";
                idxklatki++;
            }
            else if(CzyWczysnieto(Keys.Down))
            {
                kierunekRuchuGracz = Ruch.Dol;
                  py+=SzybkoscRuchow;
                  Gra.gracz.AktualnyObrazek = "dół.gif";
                  idxklatki++;
            }
            else if(CzyWczysnieto(Keys.Left))
            {
                kierunekRuchuGracz = Ruch.Lewo;
                  px-=SzybkoscRuchow;
                  Gra.gracz.AktualnyObrazek = "lewo.gif";
                  idxklatki++;
            }
            else if (CzyWczysnieto(Keys.Right))
            {
                kierunekRuchuGracz = Ruch.Prawo;
                  px+=SzybkoscRuchow;
                  Gra.gracz.AktualnyObrazek = "prawo.gif";
                  idxklatki++;
            }
            if (!kierunekRuchuGracz.HasValue)
            {
                Gra.gracz.AktualnyObrazek = null;
            }
            else
            {
                Rectangle graczmapa = new Rectangle(pozycjaGracza[0] + px, pozycjaGracza[1] + py, Gra.gracz.Szerokosc, Gra.gracz.Wysokosc);//gdzie były gracz gdyby się przesunął
                for (int i = 0; i < obszarGry.Mapa.GetLength(0); i++)
                {
                    for (int j = 0; j < obszarGry.Mapa.GetLength(1); j++)
                    {
                        ElementMapy element = obszarGry.Mapa[i, j];
                        if (element == null || !element.PowodujeKolizje)
                        {
                            continue;
                        }
                        Rectangle pozycjaelemnt = new Rectangle(j * obszarGry.Rozmiar, i * obszarGry.Rozmiar, obszarGry.Rozmiar, obszarGry.Rozmiar);
                        if (graczmapa.IntersectsWith(pozycjaelemnt))
                        {
                            if (kierunekRuchuGracz == Ruch.Lewo && pozycjaelemnt.Right >= graczmapa.Left)
                            {
                                bylaKolizja = true;
                            }
                            else if (kierunekRuchuGracz == Ruch.Prawo && pozycjaelemnt.Left <= graczmapa.Right)
                            {
                                bylaKolizja = true;
                            }
                            else if (kierunekRuchuGracz == Ruch.Gora && pozycjaelemnt.Bottom >= graczmapa.Top)
                            {
                                bylaKolizja = true;
                            }
                            else if (kierunekRuchuGracz == Ruch.Dol && pozycjaelemnt.Top <= graczmapa.Bottom)
                            {
                                bylaKolizja = true;
                            }
                            if (bylaKolizja)
                            {
                                timerPrzeplywCzasu.Stop();
                                element.IntegracjaGracz(Gra.gracz, i, j, this);
                                timerPrzeplywCzasu.Start();
                                break;
                            }
                        }
                    }
                    if (bylaKolizja)
                    {
                        break;
                    }
                }
                if (!bylaKolizja)
                {
                    pozycjaGracza[0] += px;
                    pozycjaGracza[1] += py;
                }
                odswierzamy = true;
            }
            if (odswierzamy)
            {
                this.Invalidate();
            }
        }
        int idxklatki = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int xgracz = Width / 2 - Gra.gracz.Szerokosc / 2;
            int ygracz = Height / 2 - Gra.gracz.Wysokosc / 2;
            Graphics g = e.Graphics;
            for (int i = 0; i < obszarGry.Mapa.GetLength(0); i++)
            {
                for (int j = 0; j < obszarGry.Mapa.GetLength(1); j++)
                {
                    var x = j * obszarGry.Rozmiar +xgracz -pozycjaGracza[0];
                    int y = i * obszarGry.Rozmiar + ygracz - pozycjaGracza[1];

                    Rectangle r = new Rectangle(x,y, obszarGry.Rozmiar, obszarGry.Rozmiar);
                    if(!r.IntersectsWith(e.ClipRectangle))
                    {
                        continue;// nie rysujemy elelementów które nie są widoczne
                    }
                    if (obszarGry.Mapa[i, j]==null)
                    {
                        continue;
                    }
                    if (obszarGry.Mapa[i, j].Tlo != null)
                    {
                        using (var ia = new ImageAttributes())
                        {
                            ia.SetWrapMode(WrapMode.TileFlipXY);
                            g.DrawImage(MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].Tlo), r, 0, 0, obszarGry.Rozmiar, obszarGry.Rozmiar, GraphicsUnit.Pixel, ia);
                        }
                    }
                    if (obszarGry.Mapa[i, j].ObrazekNaMapie != null)
                    {
                        g.DrawImage(MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].ObrazekNaMapie), r);
                    }
                }
            }
            Image graczimg = MenagerZasobow.PobierzBitmape(Gra.gracz.ObrazekNaMapie + (Gra.gracz.AktualnyObrazek ?? "dół.png"));
            FrameDimension dimension = new FrameDimension(graczimg.FrameDimensionsList[0]);
            int frameCount = graczimg.GetFrameCount(dimension);
            if(idxklatki>=frameCount)
            {
                idxklatki = 0;
            }

            graczimg.SelectActiveFrame(dimension, idxklatki);
        
            Rectangle pozycjagracz = new Rectangle(xgracz, ygracz, Gra.gracz.Szerokosc, Gra.gracz.Wysokosc);
            g.DrawImage(graczimg, pozycjagracz);
            if(!string.IsNullOrEmpty(Komunikat))
            {
                Rectangle pozycjatekstu=new Rectangle(0,(int)(Height*0.9),Width,(int)(Height*0.1f));
                g.DrawString(Komunikat, new Font("Segoe Script", 20), new SolidBrush(System.Drawing.Color.Gold), pozycjatekstu);
            }
        }

        private void PictureBoxPraweMenuEkwipunek_MouseClick(object sender, EventArgs e)
        {
            timerPrzeplywCzasu.Stop();
            PokazEkwipunek();
        }
        private void PictureBoxPraweMenuEkwipunek_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Alight.png");
        }
        private void PictureBoxPraweMenuEkwipunek_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Adark.png");
        }

        //private void PictureBoxPraweMenuOpcji_MouseClick(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Brak elementu do wyświetlenia");
        //    PokazMenuWyboru();
        //}
        private void PictureBoxPraweMenuDziennikZadan_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[1], "Resources/Grafiki menu/Blight.png");
        }
        private void PictureBoxPraweMenuDziennikZadan_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[1], "Resources/Grafiki menu/Bdark.png");
        }

        private void PictureBoxPraweMenuEkranDziennikZadan_MouseClick(object sender, EventArgs e)
        {
            timerPrzeplywCzasu.Stop();
            PokazDziennikZadan();
        }
        //private void PictureBoxPraweMenuOpcji_MouseEnter(object sender, EventArgs e)
        //{
        //    Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[2], "Resources/Grafiki menu/Clight.png");
        //}
        //private void PictureBoxPraweMenuOpcji_MouseLeave(object sender, EventArgs e)
        //{
        //    Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[2], "Resources/Grafiki menu/Cdark.png");
        //}

        private void PictureBox_Click(object sender, EventArgs e)
        {
            //Później trzeba to usunąć, bo w przypadku zamykania chcemy pokazac Menu
            DialogResult = DialogResult.Cancel;
        }




        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        //Nie pojawia sie w alt+tab
        private void EkranOpcje_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
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
