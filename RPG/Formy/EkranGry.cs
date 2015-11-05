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
        //Zeby miec dostep do: ekranGlowny.EkranGryTloMapa,
        private EkranGlowny ekranGlowny;    

        //Dostep do Teł Ekranow
        public EkranEkranDziennikZadanTlo ekranEkranDziennikZadanTlo;
        public EkranEkwipunekTlo ekranEkwipunekTlo;
        public EkranWalkaTlo ekranWalkaTlo;

        //Dostep do Form zwiazanych z gra
        public EkranDziennikZadan ekranDziennikZadan;
        public EkranEkwipunek ekranEkwipunek;
        public EkranWalka ekranWalka;
        public EkranOpcje ekranOpcje;

        //Nasz rdzen gry, dostepny dla wszystkich form zwiazanych z gra
        public Gra gra = new Gra();
        
        //Zmienne dla przyciskow
        PictureBox[] praweMenu;

        //Poruszanie sie bohaterem
        int index = 0;
        bool prawo=false, lewo=false, gora=false, dol=false;
        bool blokadaPrawo = false, blokadaLewo = false, blokadaGora = false, blokadaDol = false;
        bool zablokujPostac = false;
        string ostatniZablokwanyObiekt = "";

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
            //Stworzenie dostepu do pozostalych Form i ich teł
            this.ekranGlowny = ekranGlowny;
            this.ekranOpcje = ekranOpcje;

            this.ekranDziennikZadan = new EkranDziennikZadan(this);
            this.ekranEkwipunek = new EkranEkwipunek(this);
            this.ekranWalka = new EkranWalka(this);

            this.ekranEkranDziennikZadanTlo = new EkranEkranDziennikZadanTlo(ekranDziennikZadan);
            this.ekranEkwipunekTlo = new EkranEkwipunekTlo(ekranEkwipunek);
            this.ekranWalkaTlo = new EkranWalkaTlo(ekranWalka);


            InitializeComponent();
            RozmiescElementy();
            KolorujElementy();

            //Dzwiek zakomentowany na czas debugowania
            //ekranOpcje.OdtworzDzwiek(odtwarzacz, sciezka);

            //Pamietaj! 
            //Zatrzymaj czas przy wchodzeniu do innej formy lub uzywaj ShowDialog()!
            timerPrzeplywCzasu.Start();
        }

        #region Metody
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Wczytanie Right Menu Panel
            List<Image> ListaObrazkow = new List<Image>();
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Adark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Bdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/Cdark.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/D.png"));
            ListaObrazkow.Add(new Bitmap("Resources/Grafiki menu/E.png"));

            const int wielkoscPrzyciskow = 80;
            const int odlegloscMiedzyPrzyciskami = 20;
            int iloscPrzyciskow = ListaObrazkow.Count();

            panelPraweMenu.Location = new Point(Screen.PrimaryScreen.Bounds.Width - wielkoscPrzyciskow, Screen.PrimaryScreen.Bounds.Y);
            panelPraweMenu.Size = new Size(wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami, wielkoscPrzyciskow * iloscPrzyciskow+40);
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(panelPraweMenu, "Resources/Grafiki menu/Panel pod przyciski.png");

            praweMenu = new PictureBox[iloscPrzyciskow];
            for (int index = 0; index < praweMenu.Length; index++)
            {
                praweMenu[index] = new PictureBox();
                panelPraweMenu.Controls.Add(praweMenu[index]);
                praweMenu[index].Location = new Point(0, index * wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami);
                praweMenu[index].Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
                praweMenu[index].BackgroundImage = new Bitmap(ListaObrazkow[index], wielkoscPrzyciskow, wielkoscPrzyciskow);
                //praweMenu[index].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenu_MouseEnter);
                //praweMenu[index].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenu_MouseLeave);
            }

            praweMenu[0].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            praweMenu[0].MouseEnter += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseEnter);
            praweMenu[0].MouseLeave += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseLeave);
            praweMenu[1].Click += new System.EventHandler(this.PictureBoxPraweMenuEkranDziennikZadan_MouseClick);
            //praweMenu[2].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[3].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);
            //praweMenu[4].Click += new System.EventHandler(this.PictureBoxPraweMenuEkwipunek_MouseClick);


          
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
        }

        public void WczytajNowaGre()
        {
            //Metoda Wywolywana w ekranNowaGra
            label1.Text = gra.gracz.Nazwa;
            ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
        }

        private void Walka(DialogResult dR, PictureBox pB)
        {
            if (dR == DialogResult.OK)
            {
                ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.Remove(pB);
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
                timerPrzeplywCzasu.Start();
                lewo = prawo = dol = gora = false;
            }
            else if (dR == DialogResult.Abort)
            {

                //Co robimy jak gracz przegral?
                ekranGlowny.ekranGryTloObiekty.pBGracz.Visible = false;
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
        #endregion

        #region Zdarzenia
        private void timerPrzeplywCzasu_Tick(object sender, EventArgs e)
        {
            index++;
            const int czasOdnawiania = 5; //Gifa

            //Sprawdz czy ktorys z obiektow jest w innym
            foreach (PictureBox obiekt in ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            {
                if (obiekt.Name != ekranGlowny.ekranGryTloObiekty.pBGracz.Name)
                {
                    if (ekranGlowny.ekranGryTloObiekty.pBGracz.Bounds.IntersectsWith(obiekt.Bounds))
                    {
                        if (obiekt.Name.StartsWith("Blok"))
                        {
                            if (zablokujPostac == true)
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
                                ostatniZablokwanyObiekt = obiekt.Name;
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
                    }
                    else
                    {
                        if (obiekt.Name == ostatniZablokwanyObiekt)
                        {
                            zablokujPostac = false;
                        }
                    }
                }
            }

            //Animacje Gifa
            if (prawo == true && index % czasOdnawiania == 0)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "prawo.gif");
            }
            if (lewo == true && index % czasOdnawiania == 0)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "lewo.gif");
            }
            if (dol == true && index % czasOdnawiania == 0)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.gif");
            }
            if (gora == true && index % czasOdnawiania == 0)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "góra.gif");
            }

            //Ruch Bohatera i planszy
            if (prawo == true)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Left += 5;
                ekranGlowny.ekranGryTloObiekty.panelMapa.Left -= 5;
                ekranGlowny.ekranGryTloMapa.RuchPowierzchniMapy((int)Ruch.Prawo, 5);
            }

            if (lewo == true)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Left -= 5;
                ekranGlowny.ekranGryTloObiekty.panelMapa.Left += 5;
                ekranGlowny.ekranGryTloMapa.RuchPowierzchniMapy((int)Ruch.Lewo, 5);
            }

            if (gora == true)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Top -= 5;
                ekranGlowny.ekranGryTloObiekty.panelMapa.Top += 5;
                ekranGlowny.ekranGryTloMapa.RuchPowierzchniMapy((int)Ruch.Gora, 5);
            }

            if (dol == true)
            {
                ekranGlowny.ekranGryTloObiekty.pBGracz.Top += 5;
                ekranGlowny.ekranGryTloObiekty.panelMapa.Top -= 5;
                ekranGlowny.ekranGryTloMapa.RuchPowierzchniMapy((int)Ruch.Dol, 5);
            }
        }

        private void EkranGry_Load(object sender, EventArgs e)
        {
            //Chodzacy ludek
            ekranGlowny.ekranGryTloObiekty.pBGracz.SizeMode = PictureBoxSizeMode.Zoom;
            ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
            ekranGlowny.ekranGryTloObiekty.pBGracz.Size = new Size(ekranGlowny.ekranGryTloObiekty.pBGracz.Image.Width, ekranGlowny.ekranGryTloObiekty.pBGracz.Image.Height);

            const int wielkoscPrzyciskow = 90;
            const int odlegloscMiedzyPrzyciskami = 20;
            int iloscPrzyciskow = 5;

            ekranGlowny.ekranGryTloUI.UstawPanelPrawy(new Point(Screen.PrimaryScreen.Bounds.Width - wielkoscPrzyciskow, Screen.PrimaryScreen.Bounds.Y), new Size(wielkoscPrzyciskow + odlegloscMiedzyPrzyciskami, wielkoscPrzyciskow * iloscPrzyciskow), "Resources/Grafiki menu/Panel pod przyciski.png");

            //Automatyczne Tworzenie obrzeża Krainy
            List<PictureBox> ObzezaKariny = new List<PictureBox>();
            int SzerokoscBokuPrzeszkody = 54;
            int WysokoscBokuPrzeszkody = 54;
            for (int i = 0; i < ekranGlowny.ekranGryTloObiekty.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodaDol" + i;

                przeszkoda.Location = new Point((i - 1) * SzerokoscBokuPrzeszkody, ekranGlowny.ekranGryTloObiekty.panelMapa.Height - WysokoscBokuPrzeszkody);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.Add(przeszkoda);
            }
            for (int i = 0; i < ekranGlowny.ekranGryTloObiekty.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodGora" + i;

                przeszkoda.Location = new Point((i - 1) * SzerokoscBokuPrzeszkody, 0);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.Add(przeszkoda);
            }
            for (int i = 0; i < ekranGlowny.ekranGryTloObiekty.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodaLewa" + i;

                przeszkoda.Location = new Point(0, i * WysokoscBokuPrzeszkody);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.Add(przeszkoda);

            }
            for (int i = 0; i < ekranGlowny.ekranGryTloObiekty.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodaPrawa" + i;

                przeszkoda.Location = new Point(ekranGlowny.ekranGryTloObiekty.panelMapa.Width - SzerokoscBokuPrzeszkody, i * WysokoscBokuPrzeszkody);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGlowny.ekranGryTloObiekty.panelMapa.Controls.Add(przeszkoda);

            }

            //tymczasowe elementy mapy, na czas debugowania
            ekranGlowny.ekranGryTloObiekty.Blok1.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l3_wall_deco79.png");
            ekranGlowny.ekranGryTloObiekty.Blok2.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l1_bridgestonensin.png");
            ekranGlowny.ekranGryTloObiekty.AkcjaWielkiMag.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/31/dół.png");
            ekranGlowny.ekranGryTloObiekty.AkcjaStrazniczkaLasu.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/23/dół.png");
            ekranGlowny.ekranGryTloObiekty.AkcjaStrazniczkaGor.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/29/dół.png");

            //KOD PRZYKŁADOWY:
            //Dla każdego elementy zaczynającego się od nazwy "BlokKraniec" dodaj grafike "l2_terrain066.png".
            //foreach (PictureBox obiekt in panelMapa.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            //{
            //    if (obiekt.Name.StartsWith("BlokKraniec"))
            //    {
            //        obiekt.Image = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
            //    }
            //}

            //Do usniecia? 
            //using (Graphics grafikaGracza = Graphics.FromImage(PictureBoxMgla.Image))
            //{
            //    //grafikaGracza.DrawImage(new Bitmap(gra.bohater.Obrazek + "lewo.gif"), PictureBoxMgla.Width / 2, PictureBoxMgla.Height / 2);
            //}
        }

        private void PictureBoxPraweMenuEkwipunek_MouseClick(object sender, EventArgs e)
        {
            ekranEkwipunekTlo.ShowDialog();
        }
        private void PictureBoxPraweMenuEkwipunek_MouseEnter(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Alight.png");
        }
        private void PictureBoxPraweMenuEkwipunek_MouseLeave(object sender, EventArgs e)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(praweMenu[0], "Resources/Grafiki menu/Adark.png");
        }
        private void PictureBoxPraweMenuEkranDziennikZadan_MouseClick(object sender, EventArgs e)
        {
            ekranEkranDziennikZadanTlo.ShowDialog();
        }
        
        private void PictureBox_Click(object sender, EventArgs e)
        {
            //Później trzeba to usunąć, bo w przypadku zamykania chcemy pokazac Menu
            Close();
        }

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
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "prawo.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = false;
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "lewo.png");
            }
            if (e.KeyCode == Keys.Up)
            {
                gora = false;
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "góra.png");
            }
            if (e.KeyCode == Keys.Down)
            {
                dol = false;
                ekranGlowny.ekranGryTloObiekty.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
            }
        }
        #endregion


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
        #endregion
    }
}
