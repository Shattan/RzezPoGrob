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
#endregion

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
       
        EkranGryObiektyTlo ekranGryObiektyTlo;
        EkranGryUITlo ekranGryUITlo;

        //Tworzenie zmiennej losującej przeciwnika i planszę
     



        //Nasz rdzen gry, dostepny dla wszystkich form zwiazanych z gra
        public Gra gra = new Gra();
        
        //Zmienne dla przyciskow
        PictureBox[] praweMenu;

        //Poruszanie sie bohaterem
        int index = 0;
        const int SzybkoscRuchow = 5;
        public enum Ruch
        {
            Lewo = 0,
            Prawo = SzybkoscRuchow,
            Gora = 2,
            Dol = 3,
        }
        #endregion
        Obszar obszarGry;
        public EkranGry(EkranGlowny ekranGlowny,  EkranGryObiektyTlo ekranGryObiektyTlo, EkranGryUITlo ekranGryUITlo)
        {
            this.ekranGlowny = ekranGlowny;
            this.ekranGryObiektyTlo = ekranGryObiektyTlo;
            this.ekranGryUITlo = ekranGryUITlo;
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
            timerPrzeplywCzasu.Start();
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

            ekranGryUITlo.UstawPanelPrawy(panelPraweMenu.Size, panelPraweMenu.Location, "Resources/Grafiki menu/Panel pod przyciski.png");
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
            ekranGryUITlo.Hide();
            ekranGryObiektyTlo.Hide();
        }
       public void UwidocznijGre()
        {
            ekranGryObiektyTlo.Show();
            ekranGryUITlo.Show();
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
            EkranEkwipunekTlo ekranEkwipunekTlo = new EkranEkwipunekTlo(this);
            ekranEkwipunekTlo.ShowDialog();

            if (ekranEkwipunekTlo.DialogResult == DialogResult.OK)//Jeżeli gracz zamknął ekwipunek
            {
                UwidocznijGre();
                timerPrzeplywCzasu.Start();
            }
            else
            {
                UwidocznijGre();
                //Ktos zamknal na sile forme, zamykamy wiec gre, chociaz powinniosmy po prostu ukarac gracza
                DialogResult = DialogResult.Cancel;
            }
        }

        private void PokazDziennikZadan()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            EkranDziennikZadanTlo ekranEkranDziennikZadanTlo = new EkranDziennikZadanTlo(this);
            ekranEkranDziennikZadanTlo.ShowDialog();
            if (ekranEkranDziennikZadanTlo.DialogResult == DialogResult.OK)
            {
                UwidocznijGre();
                timerPrzeplywCzasu.Start();
            }
            else
            {
                UwidocznijGre();
            }
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

            index++;
            const int czasOdnawiania = 4; //Gifa

            bool bylaKolizja = false;
            Ruch? kierunekRuchuGracz=null;
      
            int px=0;
            int py=0;
            if(CzyWczysnieto(Keys.Up))
            {
                kierunekRuchuGracz = Ruch.Gora;
                py-=SzybkoscRuchow;
            }
            else if(CzyWczysnieto(Keys.Down))
            {
                kierunekRuchuGracz = Ruch.Dol;
                  py+=SzybkoscRuchow;
            }
            else if(CzyWczysnieto(Keys.Left))
            {
                kierunekRuchuGracz = Ruch.Lewo;
                  px-=SzybkoscRuchow;
            }
            else if (CzyWczysnieto(Keys.Right))
            {
                kierunekRuchuGracz = Ruch.Prawo;
                  px+=SzybkoscRuchow;
            }
            if(!kierunekRuchuGracz.HasValue)
            {
                ekranGryObiektyTlo.pBGracz.Image = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + "dół.png");
                return;
            }
            Rectangle graczmapa=new Rectangle(ekranGryObiektyTlo.pBGracz.Left+px,ekranGryObiektyTlo.pBGracz.Top+py,ekranGryObiektyTlo.pBGracz.Width,ekranGryObiektyTlo.pBGracz.Height);//gdzie były gracz gdyby się przesunął
         
            foreach (PictureBox obiekt in ekranGryObiektyTlo.panelMapa.Controls.OfType<PictureBox>().ToList())
            {
                if (obiekt.Name != ekranGryObiektyTlo.pBGracz.Name)
                {
                    if (graczmapa.IntersectsWith(obiekt.Bounds))
                    {
                        ElementMapy element = (ElementMapy)obiekt.Tag;
                        if (kierunekRuchuGracz == Ruch.Lewo && obiekt.Right >= graczmapa.Left)
                        {
                            bylaKolizja = element.PowodujeKolizje;
                        }
                        else if (kierunekRuchuGracz == Ruch.Prawo && obiekt.Left <= graczmapa.Right)
                        {
                            bylaKolizja = element.PowodujeKolizje;
                        }
                        else if (kierunekRuchuGracz == Ruch.Gora && obiekt.Bottom >= graczmapa.Top)
                        {
                            bylaKolizja = element.PowodujeKolizje;
                        }
                        else if (kierunekRuchuGracz == Ruch.Dol && obiekt.Top <= graczmapa.Bottom)
                        {
                            bylaKolizja = element.PowodujeKolizje;
                        }
                        if (bylaKolizja)
                        {
                            int[] koordynaty = obiekt.Name.Split(';').Select(int.Parse).ToArray();
                            timerPrzeplywCzasu.Stop();
                            element.IntegracjaGracz(ekranGlowny.gra.gracz, koordynaty[0], koordynaty[1], ekranGryObiektyTlo, this);
                            timerPrzeplywCzasu.Start();
                            break;
                        }
                    }
                }
            }
            if(index % czasOdnawiania == 0)
            {
            //////Animacje Gifa
                if (kierunekRuchuGracz==Ruch.Prawo)
                {
                    ekranGryObiektyTlo.pBGracz.Image = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + "prawo.gif");
                }
                if (kierunekRuchuGracz == Ruch.Lewo)
                {
                    ekranGryObiektyTlo.pBGracz.Image = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + "lewo.gif");
                }
                if (kierunekRuchuGracz == Ruch.Dol)
                {
                    ekranGryObiektyTlo.pBGracz.Image = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + "dół.gif");
                }
                if (kierunekRuchuGracz == Ruch.Gora)
                {
                    ekranGryObiektyTlo.pBGracz.Image = MenagerZasobow.PobierzBitmape(gra.gracz.ObrazekNaMapie + "góra.gif");
                }
            }
            if (!bylaKolizja)
            {
                ekranGryObiektyTlo.pBGracz.Left += px;
                ekranGryObiektyTlo.panelMapa.Left -= px;
                ekranGryObiektyTlo.pBGracz.Top += py;
                ekranGryObiektyTlo.panelMapa.Top -= py;
            } 
        }
        private void WczytajMape()
        {
            ekranGryObiektyTlo.Visible = false;
            ekranGryObiektyTlo.panelMapa.Width = obszarGry.Rozmiar * obszarGry.Mapa.GetLength(0);
            ekranGryObiektyTlo.panelMapa.Height = obszarGry.Rozmiar * obszarGry.Mapa.GetLength(1);
            //Chodzacy ludek
            ekranGryObiektyTlo.pBGracz.SizeMode = PictureBoxSizeMode.Zoom;
            ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
            ekranGryObiektyTlo.pBGracz.Size = new Size(ekranGryObiektyTlo.pBGracz.Image.Width, ekranGryObiektyTlo.pBGracz.Image.Height);
            ekranGryObiektyTlo.pBGracz.Location= new Point(obszarGry.PozycjaStartowaGracza[0] * obszarGry.Rozmiar, obszarGry.PozycjaStartowaGracza[1] * obszarGry.Rozmiar);

            ekranGryObiektyTlo.pBGracz.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 0; i < obszarGry.Mapa.GetLength(0); i++)
            {
                for (int j = 0; j < obszarGry.Mapa.GetLength(1); j++)
                {
                    if (obszarGry.Mapa[i, j] == null)
                    {
                        continue;
                    }
                    PictureBox element = new PictureBox();
                    element.Name = i + ";" + j;
                    element.BackColor = System.Drawing.Color.Transparent;
                    //element.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    element.BackgroundImage = MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].Tlo);
                    element.Image = MenagerZasobow.PobierzBitmape(obszarGry.Mapa[i, j].ObrazekNaMapie);
                    element.BorderStyle = BorderStyle.FixedSingle;
                    element.Tag = obszarGry.Mapa[i, j];
                    element.Size = new System.Drawing.Size(obszarGry.Rozmiar, obszarGry.Rozmiar);
                    element.Location = new Point(i * obszarGry.Rozmiar, j * obszarGry.Rozmiar);
                    ekranGryObiektyTlo.panelMapa.Controls.Add(element);
                }
            }
            ekranGryObiektyTlo.Visible = true;
     //       int lewa = (Width/2) - (ekranGryObiektyTlo.panelMapa.Width / 2);
    //        int gora = (Height/2) - (ekranGryObiektyTlo.panelMapa.Height / 2);
        //    ekranGryObiektyTlo.panelMapa.Left = lewa;
        //    ekranGryObiektyTlo.panelMapa.Height = gora;
            
        }
        private void EkranGry_Load(object sender, EventArgs e)
        {
            WczytajMape();
          
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
