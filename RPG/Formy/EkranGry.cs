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
#endregion

namespace RPG
{
    public partial class EkranGry : Form
    {
        #region Zmienne
        EkranGlowny ekranGlowny;
        EkranGryMapaTlo ekranGryMapaTlo;
        EkranGryObiektyTlo ekranGryObiektyTlo;
        EkranGryUITlo ekranGryUITlo;

        public string wylosowanyTeren="";
        //Tworzenie zmiennej losującej przeciwnika i planszę
        Random losowanie = new Random();



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

        public EkranGry(EkranGlowny ekranGlowny, EkranGryMapaTlo ekranGryMapaTlo, EkranGryObiektyTlo ekranGryObiektyTlo, EkranGryUITlo ekranGryUITlo)
        {
            this.ekranGlowny = ekranGlowny;
            this.ekranGryMapaTlo = ekranGryMapaTlo;
            this.ekranGryObiektyTlo = ekranGryObiektyTlo;
            this.ekranGryUITlo = ekranGryUITlo;
            this.gra = ekranGlowny.gra;

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

            LabelInformacje.Size = new Size(Width, Height / 8);
            LabelInformacje.Location = new Point(0, Height - LabelInformacje.Size.Height);
            LabelInformacje.Text = "Witaj w grze!";

            PictureBoxLewyMowiacy.Size = new Size(Width*20/100,Height*40/100);
            PictureBoxPrawyMowiacy.Size = PictureBoxLewyMowiacy.Size;
            PictureBoxLewyMowiacy.Location = new Point(0, LabelInformacje.Location.Y - PictureBoxLewyMowiacy.Height);
            PictureBoxPrawyMowiacy.Location = new Point(Width - PictureBoxPrawyMowiacy.Width, LabelInformacje.Location.Y - PictureBoxPrawyMowiacy.Height);

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


            //Rozmiar i lokacja menu wyboru i jego przycisków
            FlowLayoutPanelMenuWyboru.Size = new Size(Width*10/100,(PictureBoxKontynuuj.Height+5)*FlowLayoutPanelMenuWyboru.Controls.Count);
            FlowLayoutPanelMenuWyboru.Location = new Point((Width / 2) - (FlowLayoutPanelMenuWyboru.Width / 2), (Height / 2) - (FlowLayoutPanelMenuWyboru.Height / 2));

            foreach (PictureBox przycisk in FlowLayoutPanelMenuWyboru.Controls)
            {
                przycisk.Size = new Size(FlowLayoutPanelMenuWyboru.Width, przycisk.Height);
            }
        }

        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelMenuWyboru, "Resources/Grafiki menu/Menu wyboru tło.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxKontynuuj, "Resources/Grafiki menu/Menu wyboru kontynuuj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZapisz, "Resources/Grafiki menu/Menu wyboru zapisz grę.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWczytaj, "Resources/Grafiki menu/Menu wyboru wczytaj grę.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdzDoMenu, "Resources/Grafiki menu/Menu wyboru wyjdź do menu.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdzZGry, "Resources/Grafiki menu/Menu wyboru wyjdź z gry.png");
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
        void UniewidocznijGre()
        {
            Hide();
            ekranGryUITlo.Hide();
            ekranGryObiektyTlo.Hide();
            ekranGryMapaTlo.Hide();
        }
        void UwidocznijGre()
        {
            ekranGryMapaTlo.Show();
            ekranGryObiektyTlo.Show();
            ekranGryUITlo.Show();
            Show();
        }

    
        void LosujTloWalki()
        {
            string plansza = losowanie.Next(0, 10).ToString();
            wylosowanyTeren = "Resources/Grafiki tła walki/" + plansza + ".png";
        }

        private void WykryjKolizje()
        {
            //Sprawdz czy ktorys z obiektow jest w innym
            foreach (PictureBox obiekt in ekranGryObiektyTlo.panelMapa.Controls.OfType<PictureBox>().Cast<Control>().ToList())
            {
                if (obiekt.Name != ekranGryObiektyTlo.pBGracz.Name)
                {
                    if (ekranGryObiektyTlo.pBGracz.Bounds.IntersectsWith(obiekt.Bounds))
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
                            PokazWalke(obiekt);
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

        private void PokazWalke(PictureBox pB)
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            LosujTloWalki();
            EkranWalkaTlo ekranWalkaTlo = new EkranWalkaTlo(this);
            ekranWalkaTlo.ShowDialog();

            if (ekranWalkaTlo.DialogResult == DialogResult.OK)//Jeżeli gracz wygrał
            {
                UwidocznijGre();
                ekranGryObiektyTlo.panelMapa.Controls.Remove(pB);
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
                timerPrzeplywCzasu.Start();
                lewo = prawo = dol = gora = false;
            }
            else if (ekranWalkaTlo.DialogResult == DialogResult.Abort)//Jeżeli gracz przegrał
            {
                OdtwrzaczManager.Odtworz(4,"Resources/Dźwięki/smierc.wav",false);
                UwidocznijGre();
                //Co robimy jak gracz przegral?
                ekranGryObiektyTlo.pBGracz.Visible = false;
                //Co robimy jak gracz przegral? 
                //Wylaczamy sterowanie gracza, 
                //na dole pojawia się napis "Porażka", 
                //włącza się muzyczka "Resources/Dźwięki/smierc.wav"
                //Zmieniamy tło gracza na plamę krwi 
            }
            else if (ekranWalkaTlo.DialogResult == DialogResult.Ignore)//Jeżeli gracz uciekł
            {
                UwidocznijGre();
            }
            else
            {
                //Ktos zamknal na sile forme, zamykamy wiec gre, chociaz powinniosmy po prostu ukarac gracza
                //Może 3-dniowy ban dla gracza za alt+F4? :D
                DialogResult = ekranWalkaTlo.DialogResult;
            }
        }

        private void PokazKupca()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            UwidocznijGre();
        }

        private void PokazRozmowe()
        {
            UniewidocznijGre();
            timerPrzeplywCzasu.Stop();
            UwidocznijGre();
        }
        #endregion

        #region Zdarzenia
        private void timerPrzeplywCzasu_Tick(object sender, EventArgs e)
        {
            index++;
            const int czasOdnawiania = 4; //Gifa

            WykryjKolizje();

            //Animacje Gifa
            if (prawo == true && index % czasOdnawiania == 0)
            {
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "prawo.gif");
            }
            if (lewo == true && index % czasOdnawiania == 0)
            {
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "lewo.gif");
            }
            if (dol == true && index % czasOdnawiania == 0)
            {
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.gif");
            }
            if (gora == true && index % czasOdnawiania == 0)
            {
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "góra.gif");
            }

            //Ruch Bohatera i planszy
            if (prawo == true)
            {
                ekranGryObiektyTlo.pBGracz.Left += 5;
                ekranGryObiektyTlo.panelMapa.Left -= 5;
                ekranGryMapaTlo.RuchPowierzchniMapy((int)Ruch.Prawo, 5);
            }

            if (lewo == true)
            {
                ekranGryObiektyTlo.pBGracz.Left -= 5;
                ekranGryObiektyTlo.panelMapa.Left += 5;
                ekranGryMapaTlo.RuchPowierzchniMapy((int)Ruch.Lewo, 5);
            }

            if (gora == true)
            {
                ekranGryObiektyTlo.pBGracz.Top -= 5;
                ekranGryObiektyTlo.panelMapa.Top += 5;
                ekranGryMapaTlo.RuchPowierzchniMapy((int)Ruch.Gora, 5);
            }

            if (dol == true)
            {
                ekranGryObiektyTlo.pBGracz.Top += 5;
                ekranGryObiektyTlo.panelMapa.Top -= 5;
                ekranGryMapaTlo.RuchPowierzchniMapy((int)Ruch.Dol, 5);
            }
        }

        private void EkranGry_Load(object sender, EventArgs e)
        {
            //Chodzacy ludek
            ekranGryObiektyTlo.pBGracz.SizeMode = PictureBoxSizeMode.Zoom;
            ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
            ekranGryObiektyTlo.pBGracz.Size = new Size(ekranGryObiektyTlo.pBGracz.Image.Width, ekranGryObiektyTlo.pBGracz.Image.Height);

            //Automatyczne Tworzenie obrzeża Krainy
            List<PictureBox> ObzezaKariny = new List<PictureBox>();
            int SzerokoscBokuPrzeszkody = 54;
            int WysokoscBokuPrzeszkody = 54;
            for (int i = 0; i < ekranGryObiektyTlo.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodaDol" + i;

                przeszkoda.Location = new Point((i - 1) * SzerokoscBokuPrzeszkody, ekranGryObiektyTlo.panelMapa.Height - WysokoscBokuPrzeszkody);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGryObiektyTlo.panelMapa.Controls.Add(przeszkoda);
            }
            for (int i = 0; i < ekranGryObiektyTlo.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
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
                ekranGryObiektyTlo.panelMapa.Controls.Add(przeszkoda);
            }
            for (int i = 0; i < ekranGryObiektyTlo.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
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
                ekranGryObiektyTlo.panelMapa.Controls.Add(przeszkoda);

            }
            for (int i = 0; i < ekranGryObiektyTlo.panelMapa.Width / SzerokoscBokuPrzeszkody; i++)
            {
                PictureBox przeszkoda = new PictureBox();
                przeszkoda.Name = "BlokPrzeszkodaPrawa" + i;

                przeszkoda.Location = new Point(ekranGryObiektyTlo.panelMapa.Width - SzerokoscBokuPrzeszkody, i * WysokoscBokuPrzeszkody);
                przeszkoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                przeszkoda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                przeszkoda.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l2_terrain066.png");
                przeszkoda.Size = new System.Drawing.Size(SzerokoscBokuPrzeszkody, WysokoscBokuPrzeszkody);
                //ObzezaKariny.Add(przeszkoda);
                //panelMapa.Controls.Add(ObzezaKariny[i]);
                ekranGryObiektyTlo.panelMapa.Controls.Add(przeszkoda);

            }

            //tymczasowe elementy mapy, na czas debugowania
            ekranGryObiektyTlo.Blok1.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l3_wall_deco79.png");
            ekranGryObiektyTlo.Blok2.BackgroundImage = new Bitmap("Resources/Grafiki przeszkód/l1_bridgestonensin.png");
            ekranGryObiektyTlo.AkcjaWielkiMag.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/31/dół.png");
            ekranGryObiektyTlo.AkcjaStrazniczkaLasu.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/23/dół.png");
            ekranGryObiektyTlo.AkcjaStrazniczkaGor.BackgroundImage = new Bitmap("Resources/Grafiki postaci na mapie/29/dół.png");

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
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "prawo.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                lewo = false;
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "lewo.png");
            }
            if (e.KeyCode == Keys.Up)
            {
                gora = false;
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "góra.png");
            }
            if (e.KeyCode == Keys.Down)
            {
                dol = false;
                ekranGryObiektyTlo.pBGracz.Image = new Bitmap(gra.gracz.ObrazekNaMapie + "dół.png");
            }
        }
        #endregion


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
