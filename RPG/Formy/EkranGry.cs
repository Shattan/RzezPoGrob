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
#endregion

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;

        //Tworzenie zmiennej losującej przeciwnika i planszę
     



        //Nasz rdzen gry, dostepny dla wszystkich form zwiazanych z gra
        public Gra gra = new Gra();
        
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
            this.gra = ekranGlowny.gra;
            obszarGry = ManagerObszarow.WczytajObszar("mapa");
            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();
            DodajZdarzeniaDlaPrawegoMenu();
            //Dzwiek zakomentowany na czas debugowania
            //ekranOpcje.OdtwrzaczManager.Odtworz(odtwarzacz, sciezka);

            //Pamietaj! 
            //Zatrzymaj czas przy wchodzeniu do innej formy lub uzywaj ShowDialog()!
            timerPrzeplywCzasu.Interval = 10;
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
            ListaObrazkow.Add("Resources/Grafiki menu/Cdark.png");
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
            praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseClick);
            praweMenu[2].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseEnter);
            praweMenu[2].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuOpcji_MouseLeave);
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

           
            bool bylaKolizja = false;
            Ruch? kierunekRuchuGracz=null;
      
            int px=0;
            int py=0;
            if(CzyWczysnieto(Keys.Up))
            {
                kierunekRuchuGracz = Ruch.Gora;
                py-=SzybkoscRuchow;
                gra.gracz.AktualnyObrazek = "góra.gif";
            }
            else if(CzyWczysnieto(Keys.Down))
            {
                kierunekRuchuGracz = Ruch.Dol;
                  py+=SzybkoscRuchow;
                  gra.gracz.AktualnyObrazek = "dół.gif";
            }
            else if(CzyWczysnieto(Keys.Left))
            {
                kierunekRuchuGracz = Ruch.Lewo;
                  px-=SzybkoscRuchow;
                  gra.gracz.AktualnyObrazek = "lewo.gif";
            }
            else if (CzyWczysnieto(Keys.Right))
            {
                kierunekRuchuGracz = Ruch.Prawo;
                  px+=SzybkoscRuchow;
                  gra.gracz.AktualnyObrazek = "prawo.gif";
            }
            if(!kierunekRuchuGracz.HasValue)
            {

                gra.gracz.AktualnyObrazek = null;
                return;
            }
            Rectangle graczmapa=new Rectangle(pozycjaGracza[0]+px,pozycjaGracza[1]+py,gra.gracz.Szerokosc,gra.gracz.Wysokosc);//gdzie były gracz gdyby się przesunął
            for (int i = 0; i < obszarGry.Mapa.GetLength(0); i++)
            {
                for (int j = 0; j < obszarGry.Mapa.GetLength(1); j++)
                {
                    ElementMapy element = obszarGry.Mapa[i, j];
                    if(!element.PowodujeKolizje)
                    {
                        continue;
                    }
                    Rectangle pozycjaelemnt = new Rectangle(i * obszarGry.Rozmiar, j * obszarGry.Rozmiar, obszarGry.Rozmiar, obszarGry.Rozmiar);
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
                            element.IntegracjaGracz(ekranGlowny.gra.gracz, i, j, this);
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
            this.Refresh();
        }
        int idxklatki = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            float wsp=(float)Width/(float)Height;
            int xgracz = Width / 2 - gra.gracz.Szerokosc/2;
            int ygracz = Height / 2 - gra.gracz.Wysokosc / 2;
            Graphics g = e.Graphics;
            System.Drawing.Pen objpen = new System.Drawing.Pen(System.Drawing.Brushes.Red);

            // Set the pen's width.
            objpen.Width = 1.0F;

            // Set the LineJoin property.
            objpen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            for (int i = 0; i < obszarGry.Mapa.GetLength(0); i++)
            {
                for (int j = 0; j < obszarGry.Mapa.GetLength(1); j++)
                {

                  //  int x = xgracz - (i * obszarGry.Rozmiar)-pozycjaGracza[0];
                    var x = i * obszarGry.Rozmiar +xgracz -pozycjaGracza[0];
                    int y = j * obszarGry.Rozmiar + ygracz - pozycjaGracza[1];

                    Rectangle r = new Rectangle(x,y, obszarGry.Rozmiar, obszarGry.Rozmiar);
                    if (obszarGry.Mapa[i, j].Tlo != null)
                    {
                        g.DrawImage(MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].Tlo), r);
                    }
                    if (obszarGry.Mapa[i, j].ObrazekNaMapie != null)
                    {
                        g.DrawImage(MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].ObrazekNaMapie), r);
                        //if (obszarGry.Mapa[i, j].PowodujeKolizje)
                        //{
                        //    g.DrawRectangle(objpen, r);
                        //}
                    }
                }
            }
            Image graczimg = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + (gra.gracz.AktualnyObrazek??"dół.png"));
            FrameDimension dimension = new FrameDimension(graczimg.FrameDimensionsList[0]);
            // Number of frames
            int frameCount = graczimg.GetFrameCount(dimension);
            // Return an Image at a certain index
            if(idxklatki>=frameCount)
            {
                idxklatki = 0;
            }

            graczimg.SelectActiveFrame(dimension, idxklatki);
            idxklatki++;
            Rectangle pozycjagracz = new Rectangle(xgracz, ygracz, gra.gracz.Szerokosc, gra.gracz.Wysokosc);
            g.DrawImage(graczimg, pozycjagracz);
            // Create a new pen.
            //System.Drawing.Pen skyBluePen = new System.Drawing.Pen(System.Drawing.Brushes.DeepSkyBlue);

            //// Set the pen's width.
            //skyBluePen.Width = 1.0F;

            //// Set the LineJoin property.
            //skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            //g.DrawRectangle(skyBluePen, pozycjagracz);
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

        private void PictureBoxPraweMenuOpcji_MouseClick(object sender, EventArgs e)
        {
            MessageBox.Show("Brak elementu do wyświetlenia");
            PokazMenuWyboru();
        }
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
        private void PictureBoxPraweMenuOpcji_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[2], "Resources/Grafiki menu/Clight.png");
        }
        private void PictureBoxPraweMenuOpcji_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[2], "Resources/Grafiki menu/Cdark.png");
        }

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
