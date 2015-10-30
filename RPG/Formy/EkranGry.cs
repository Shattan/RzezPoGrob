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

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        private EkranGlowny ekranGlowny;

        //EkranGryTlo ekranGryTlo;
        public EkranEkranDziennikZadanTlo ekranEkranDziennikZadanTlo;
        public EkranEkwipunekTlo ekranEkwipunekTlo;
        public EkranWalkaTlo ekranWalkaTlo;

        public EkranDziennikZadan ekranDziennikZadan;
        public EkranEkwipunek ekranEkwipunek;
        public EkranWalka ekranWalka;
        public EkranOpcje ekranOpcje;

        Gra gra;
        Mapa mapa;

        //Poruszanie sie bohaterem
        int index = 0;
        bool prawo=false, lewo=false, gora=false, dol=false;
        bool blokadaPrawo = false, blokadaLewo = false, blokadaGora = false, blokadaDol = false;
        bool zablokujPostac = false;

        public enum Ruch
        {
            Lewo = 0,
            Prawo = 1,
            Gora = 2,
            Dol = 3,
        }
        #endregion

        public EkranGry(EkranGlowny ekranGlowny, EkranOpcje ekranOpcje) 
        {
            this.ekranGlowny = ekranGlowny;

            this.ekranOpcje = ekranOpcje;

            //ekranOpcje.OdtworzDzwiek(odtwarzacz, sciezka);

            gra = new Gra();
            mapa = new Mapa();
            ekranDziennikZadan = new EkranDziennikZadan(this);
            ekranEkwipunek = new EkranEkwipunek(this);
            ekranWalka = new EkranWalka(this);

            ekranEkranDziennikZadanTlo = new EkranEkranDziennikZadanTlo(ekranDziennikZadan);
            ekranEkwipunekTlo = new EkranEkwipunekTlo(ekranEkwipunek);
            ekranWalkaTlo = new EkranWalkaTlo(ekranWalka);
            
            InitializeComponent();
            UstawElementyNaEkranie();
            timerPrzeplywCzasu.Start();
            
        }

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            Blok1.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l3_wall_deco79.png");
            Blok2.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l1_bridgestonensin.png");
            AkcjaWielkiMag.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/31/dół.png");
            AkcjaStrazniczkaLasu.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/23/dół.png");
            AkcjaStrazniczkaGor.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/29/dół.png");

            //Chodzacy ludek
            pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/dół.png");
            pBGracz.Size = new Size(pBGracz.Image.Width, pBGracz.Image.Height);

            //Wczytanie Right Menu Panel
            const int wielkoscPrzyciskow = 100;
            panelPraweMenu.Location = new Point(Screen.PrimaryScreen.Bounds.Width - wielkoscPrzyciskow, Screen.PrimaryScreen.Bounds.Y + 30);
            panelPraweMenu.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow*5);

            List<Image> ListaObrazkow = new List<Image>();
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Adark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Bdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Cdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/D.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/E.png"));


            PictureBox[] praweMenu = new PictureBox[5];
            for (int index = 0; index < praweMenu.Length; index++)
            {
                praweMenu[index] = new PictureBox();
                panelPraweMenu.Controls.Add(praweMenu[index]);
                praweMenu[index].Location = new Point(0, index * wielkoscPrzyciskow + 20);
                praweMenu[index].Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
                praweMenu[index].Image = new Bitmap(ListaObrazkow[index], wielkoscPrzyciskow, wielkoscPrzyciskow);
                //praweMenu[index].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenu_MouseEnter);
                //praweMenu[index].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenu_MouseLeave);
            }

            praweMenu[0].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[0].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseEnter);
            praweMenu[1].Click += new System.EventHandler(this.PictureBoxPraweMenuEkranDziennikZadan_MouseClick);
            //praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[3].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[4].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);



            //using (Graphics grafikaGracza = Graphics.FromImage(PictureBoxMgla.Image))
            //{
            //    //grafikaGracza.DrawImage(new Bitmap("Resources/Grafiki postaci na mapie/2/lewo.gif"), PictureBoxMgla.Width / 2, PictureBoxMgla.Height / 2);
            //}
        }

        public void ZapiszNazwe(string nazwa)
        {
            label1.Text = nazwa;
        }

        //Tutaj dzieki zdarzeniom bedziemy tylko wywolywac metody z klasy Gra
        //Dzieki temu mamy oddzielona gre od warstwy srodowiska

        #region Obsluga zdarzeń
        private void PictureBoxPraweMenuEkwipunek_MouseClick(object sender, EventArgs e)
        {
            ekranEkwipunekTlo.ShowDialog();
        }
        private void PictureBoxPraweMenuEkwipunek_MouseEnter(object sender, EventArgs e)
        {
            //prawemenu[0].Image = new Bitmap("Resources/Grafiki menu/Alight.png");
        }

        private void PictureBoxPraweMenuEkranDziennikZadan_MouseClick(object sender, EventArgs e)
        {
            ekranEkranDziennikZadanTlo.ShowDialog();
        }
        
        private void PictureBox_Click(object sender, EventArgs e)
        {
            ekranEkranDziennikZadanTlo.ShowDialog();
        }
        #endregion

        #region Poruszanie sie bohatera
        private void przechwytywanieKlawiszy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                prawo = true;                
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = true;            
            }
            if (e.KeyCode == Keys.Up)
            {
                gora = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                dol = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); //Zamienic na Pokaz Menu         
            }

        }

        private void przechwytywanieKlawiszy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                prawo = false;
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/prawo.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = false;
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/lewo.png");
            }
            if (e.KeyCode == Keys.Up)
            {
                gora = false;
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/góra.png");
            }
            if (e.KeyCode == Keys.Down)
            {
                dol = false;
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/dół.png");
            }
        }
        #endregion

        private void timerPrzeplywCzasu_Tick(object sender, EventArgs e)
        {
            index++;
            const int czasOdnawiania = 5; //Gifa
            
            //Sprawdz czy ktorys z obiektow jest w innym
            foreach (PictureBox obiekt in panelMapa.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            {
                if (obiekt.Name != pBGracz.Name)
                {
                    if (pBGracz.Bounds.IntersectsWith(obiekt.Bounds))
                    {
                        if (obiekt.Name.StartsWith("Blok"))
                        {
                            if (zablokujPostac)
                            {
                                if (blokadaPrawo == true) prawo = false;
                                if (blokadaLewo == true) lewo = false;
                                if (blokadaGora == true) gora = false;
                                if (blokadaDol == true) dol = false;
                            }
                            else
                            {
                                blokadaPrawo = prawo == true ? true : false;
                                blokadaLewo = lewo == true ? true : false;
                                blokadaGora = gora == true ? true : false;
                                blokadaDol = dol == true ? true : false;

                                if (blokadaPrawo == true) prawo = false;
                                if (blokadaLewo == true) lewo = false;
                                if (blokadaGora == true) gora = false;
                                if (blokadaDol == true) dol = false;

                                zablokujPostac = true;
                            }
                        }
                        else if (obiekt.Name.StartsWith("Akcja"))
                        {
                            timerPrzeplywCzasu.Stop();
                            Walka(ekranWalkaTlo.ShowDialog(), obiekt);
                        }
                        else if (obiekt.Name.StartsWith("NPC"))
                        {

                        } 
                        else
                        {
                            zablokujPostac = false;
                        }
                    }
                }
            }

            //Animacje Gifa
            if (prawo == true && index % czasOdnawiania == 0)
            {
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/prawo.gif");
            }
            if (lewo == true && index % czasOdnawiania == 0)
            {
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/lewo.gif");
            }
            if (dol == true && index % czasOdnawiania == 0)
            {
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/dół.gif");
            }
            if (gora == true && index % czasOdnawiania == 0)
            {
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/góra.gif");
            }

            //Ruch Bohatera i planszy
            if (prawo == true)
            {
                pBGracz.Left += 5;
                panelMapa.Left -= 5;
                ekranGlowny.ekranGryTlo.RuchPowierzchniMapy((int)Ruch.Prawo, 5); 
            }

            if (lewo == true)
            {
                pBGracz.Left -= 5;
                panelMapa.Left += 5;
                ekranGlowny.ekranGryTlo.RuchPowierzchniMapy((int)Ruch.Lewo, 5);
            }

            if (gora == true)
            {
                pBGracz.Top -= 5;
                panelMapa.Top += 5;
                ekranGlowny.ekranGryTlo.RuchPowierzchniMapy((int)Ruch.Gora, 5);
            }

            if (dol == true)
            {
                pBGracz.Top += 5;
                panelMapa.Top -= 5;
                ekranGlowny.ekranGryTlo.RuchPowierzchniMapy((int)Ruch.Dol, 5);
            }
        }

        private void Walka(DialogResult dR, PictureBox pB)
        {
            if (dR == DialogResult.OK)
            {
                panelMapa.Controls.Remove(pB);
                pBGracz.Image = new Bitmap("Resources/Grafiki postaci na mapie/2/dół.png");
                timerPrzeplywCzasu.Start();
                lewo = prawo = dol = gora = false;
            }
            else if (dR == DialogResult.Abort)
            {

                //Co robimy jak gracz przegral?
                pBGracz.Visible = false; 
                //Co robimy jak gracz przegral? 
                //Wylaczamy sterowanie gracza, 
                //na dole pojawia się napis "Porażka", 
                //włącza się muzyczka "Resources/Dźwięki/smierc.wav"
                //Zmieniamy tło gracza na plamę krwi 
            }
            else
            {
                //Ktos zamknal na sile forme, zamykamy wiec gre, chociaz powinniosmy po prostu ukarac gracza
                this.Close();
            }
        }

        #region sprawiamy, ze okno jest niewidoczne w alt+tab
        //Obsluga wychodzenia - zakaz alt+f4
        private void EkranOpcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            Application.Exit();
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
    }
}
