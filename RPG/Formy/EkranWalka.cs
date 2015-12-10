using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;

namespace RPG
{
    public partial class EkranWalka : Form
    {
        #region Zmienne
        EkranGry ekranGry;

        Przeciwnik przeciwnik;
        #endregion

        public EkranWalka(EkranGry ekranGry,Przeciwnik przeiwnik)
        {
            this.przeciwnik = przeiwnik;
            this.ekranGry = ekranGry;
            przeciwnik.WyczyscEfekty();
            ekranGry.gra.gracz.WyczyscEfekty();
            InitializeComponent();

            RozmiescElementy();
            KolorujElementy();
            WczytajPrzeciwnikaIGracza();
            OdswiezDane();
        }

        #region Metody
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            //Ustawienia okienka gry
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Ustawienie przycisków
            PictureBoxUcieczka.Size = new Size(Width*30/100,Height*5/100);
            StworzKonfiguracjeTekstu(PictureBoxAtakFizyczny);
            StworzKonfiguracjeTekstu(PictureBoxAtakMagiczny);
            StworzKonfiguracjeTekstu(PictureBoxEkwipunek);
      
            StworzKonfiguracjeTekstu(PictureBoxUcieczka);
            StworzKonfiguracjeTekstu(PictureBoxAtakFizyczny);
            StworzKonfiguracjeTekstu(PictureBoxWyjdzZAtakowFizycznych);
            StworzKonfiguracjeTekstu(pictureBoxWyjdzZAtakowMagicznych);
            StworzKonfiguracjeTekstu(pictureBoxWyjdzZEkwipunku);
            foreach (Control przycisk in FlowLayoutPanelWyboru.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach (Control przycisk in FlowLayoutPanelWyborAtakuFizycznego.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach( Control przycisk in FlowLayoutPanelWyborAtakuMagicznego.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }
            foreach (Control przycisk in FlowLayoutPanelWyborMikstury.Controls)
            {
                przycisk.Size = PictureBoxUcieczka.Size;
            }

            //Ustawienie FlowLayoutPaneli
            FlowLayoutPanelWyboru.Size = new Size(FlowLayoutPanelWyboru.Controls[0].Width+20, FlowLayoutPanelWyboru.Controls.Count * (PictureBoxUcieczka.Height + 6));
            FlowLayoutPanelWyborAtakuFizycznego.Size = FlowLayoutPanelWyboru.Size;
            FlowLayoutPanelWyborAtakuMagicznego.Size = FlowLayoutPanelWyboru.Size;
            FlowLayoutPanelWyborMikstury.Size = FlowLayoutPanelWyboru.Size;

            FlowLayoutPanelWyboru.Location = new Point(0, Height-FlowLayoutPanelWyboru.Height);
            FlowLayoutPanelWyborAtakuFizycznego.Location = FlowLayoutPanelWyboru.Location;
            FlowLayoutPanelWyborAtakuMagicznego.Location = FlowLayoutPanelWyboru.Location;
            FlowLayoutPanelWyborMikstury.Location = FlowLayoutPanelWyboru.Location;


            //Ustawienia dolnego panelu z informacjami
            LabelInformacje.Size = new Size(Width -FlowLayoutPanelWyboru.Width, FlowLayoutPanelWyboru.Height);
            LabelInformacje.Location = new Point(Width-LabelInformacje.Width, Height - LabelInformacje.Height);
            LabelInformacje.Text = "Rozpoczęłą się walka!";

            //Ustawienie paneli z informacjami o graczu i przeciwniku
            PanelDanychGracza.Size = PanelDanychPrzeciwnika.Size = new Size(Width * 30 / 100, Height * 10 / 100);

            PanelDanychPrzeciwnika.Location = new Point(Width - PanelDanychPrzeciwnika.Width, 0);
            PanelDanychGracza.Location = new Point(0, 0);

            PictureBoxPasekHPGracza.Size = PictureBoxPasekHPPrzeciwnika.Size = PictureBoxPasekEnergiiGracza.Size = PictureBoxPasekEnergiiPrzeciwnika.Size = new Size(PanelDanychGracza.Width * 80 / 100, PanelDanychGracza.Height * 10 / 100);

            PictureBoxPasekHPGracza.Location = new Point(PanelDanychGracza.Width * 10 / 100, PanelDanychGracza.Height * 10 / 100);
            PictureBoxPasekEnergiiGracza.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);
            PictureBoxPasekHPPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y);
            PictureBoxPasekEnergiiPrzeciwnika.Location = new Point(PictureBoxPasekHPGracza.Location.X, PictureBoxPasekHPGracza.Location.Y + PictureBoxPasekHPGracza.Height);

            LabelDaneGracza.Size = new Size(PictureBoxPasekEnergiiGracza.Width, PanelDanychGracza.Height - PictureBoxPasekEnergiiGracza.Location.Y - PictureBoxPasekEnergiiGracza.Height);
            LabelDanePrzeciwnika.Size = new Size(PictureBoxPasekEnergiiPrzeciwnika.Width, PanelDanychPrzeciwnika.Height - PictureBoxPasekEnergiiPrzeciwnika.Location.Y - PictureBoxPasekEnergiiPrzeciwnika.Height);
            LabelDaneGracza.Location = new Point(PictureBoxPasekEnergiiGracza.Location.X, PictureBoxPasekEnergiiGracza.Location.Y + PictureBoxPasekEnergiiGracza.Height);
            LabelDanePrzeciwnika.Location = new Point(PictureBoxPasekEnergiiPrzeciwnika.Location.X, PictureBoxPasekEnergiiPrzeciwnika.Location.Y + PictureBoxPasekEnergiiPrzeciwnika.Height);
        }
        private void StworzKonfiguracjeTekstu(Label c)
        {
            c.TextAlign = ContentAlignment.MiddleLeft;
            c.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            c.Font = new System.Drawing.Font("Segoe Script", 20);
            c.ForeColor = Color.Black;
        }
        void KolorujElementy()
        {
            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(LabelInformacje, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Panele sterujące
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyboru, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborAtakuFizycznego, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborAtakuMagicznego, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(FlowLayoutPanelWyborMikstury, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");

            //Przyciski sterujące
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxAtakFizyczny, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxAtakMagiczny, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxEkwipunek, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxUcieczka, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWyjdzZAtakowFizycznych, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBoxWyjdzZAtakowMagicznych, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(pictureBoxWyjdzZEkwipunku, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");


            //Okienka informacyjne
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPGracza, "Resources/Grafiki menu/Pasek HP.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekHPPrzeciwnika, "Resources/Grafiki menu/Pasek HP.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiGracza, "Resources/Grafiki menu/Pasek energii.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPasekEnergiiPrzeciwnika, "Resources/Grafiki menu/Pasek energii.png");
        }
        private void UsunLabele(Control parent)
        {
            for (int i = 0; i < parent.Controls.Count; i++)
            {
                if(parent.Controls[i] is Label && parent.Controls[i].Tag==null)
                {
                    parent.Controls.RemoveAt(i);
                    i--;
                }
            }
        }
        void WczytajPrzeciwnikaIGracza()
        {
            UsunLabele(FlowLayoutPanelWyborAtakuFizycznego);
            UsunLabele(FlowLayoutPanelWyborAtakuMagicznego);
            UsunLabele(FlowLayoutPanelWyborMikstury);
            foreach (Umiejetnosc umiejetnosc in ekranGry.gra.gracz.UmiejetnosciFizyczne)
            {
                FlowLayoutPanelWyborAtakuFizycznego.Controls.Add(StworzPrzyciskUmiejetnosci(umiejetnosc));
            }
            foreach (Umiejetnosc umiejetnosc in ekranGry.gra.gracz.UmiejetnosciMagiczne)
            {
                FlowLayoutPanelWyborAtakuMagicznego.Controls.Add(StworzPrzyciskUmiejetnosci(umiejetnosc));
            }
            foreach (Strawa strawa in ekranGry.gra.gracz.Plecak.Where(x=>x.TypPrzedmiotu==Klasy.TypPrzedmiotu.Zywnosc))
            {
                Label nowaStrawa = new Label();
              
                nowaStrawa.Name = strawa.Nazwa;
                nowaStrawa.Text = strawa.Nazwa;
                StworzKonfiguracjeTekstu(nowaStrawa);
                nowaStrawa.Size = new Size(Width * 30 / 100, Height * 5 / 100);
                Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(nowaStrawa, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
                nowaStrawa.Click += nowaStrawa_Click;
                FlowLayoutPanelWyborMikstury.Controls.Add(nowaStrawa);
            }
        }

   
        private Label StworzPrzyciskUmiejetnosci(Umiejetnosc umiejetnosc)
        {
            Label nowaUmiejetnosc = new Label();
            nowaUmiejetnosc.Text = string.Format("{0}. Użycie {1} enerii",umiejetnosc.Nazwa,umiejetnosc.KosztEnergi);
            StworzKonfiguracjeTekstu(nowaUmiejetnosc);
            nowaUmiejetnosc.Size = new Size(Width * 30 / 100, Height * 5 / 100);
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(nowaUmiejetnosc, "Resources/Grafiki przycisków umiejętności/przyciskNOWY.png");
            nowaUmiejetnosc.Name = umiejetnosc.Nazwa;
            nowaUmiejetnosc.Click += nowaUmiejetnosc_Click;
            return nowaUmiejetnosc;
        }
        void nowaStrawa_Click(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Strawa przedmiot = (Strawa)ekranGry.gra.gracz.Plecak.First(x => x.Nazwa == ctrl.Name);//Pobieramy kliekniętą umiejętność
            przedmiot.Uzyj(ekranGry.gra.gracz);
            ekranGry.gra.gracz.Plecak.Remove(przedmiot);
            ///tu dzieje sięto co wykonujemy
            WykonajAkcjePrzeciwnika();//
        }
        void nowaUmiejetnosc_Click(object sender, EventArgs e)
        {
           
            Control ctrl = (Control)sender;
           Umiejetnosc umiejetnoscwybrana=ekranGry.gra.gracz.Umiejetnosci().First(x => x.Nazwa == ctrl.Name);//Pobieramy kliekniętą umiejętność
           umiejetnoscwybrana.Atak(ekranGry.gra.gracz, przeciwnik, LabelInformacje);
            ///tu dzieje sięto co wykonujemy
            WykonajAkcjePrzeciwnika();//

        }
        private void WykonajAkcjePrzeciwnika()
        {
            przeciwnik.PrzetworzEfektyTrwajace();
            if (przeciwnik.AktualneHp <= 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            Umiejetnosc wybrana = przeciwnik.PobierzUmiejetnosc();
            wybrana.Atak(przeciwnik, ekranGry.gra.gracz, LabelInformacje);
            ekranGry.gra.gracz.PrzetworzEfektyTrwajace();
            if (ekranGry.gra.gracz.AktualneHp <= 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            OdswiezDane();
        }
        void OdswiezDane()
        {

            double procentHPGracza = ekranGry.gra.gracz.AktualneHp / ekranGry.gra.gracz.HP;
            double procentHPPrzeciwnika = przeciwnik.AktualneHp / przeciwnik.HP;
            double procentEnergiiGracza = ekranGry.gra.gracz.AktualnaEnerigia / ekranGry.gra.gracz.Energia;
            double procentEnergiiPrzeciwnika = przeciwnik.AktualnaEnerigia / przeciwnik.Energia;
            LabelDaneGracza.Text = ekranGry.gra.gracz.Nazwa;
            LabelDaneGracza.Text += "\nPoziom:" + ekranGry.gra.gracz.Poziom;
            LabelDaneGracza.Text += "\nPunkty życia: " + ekranGry.gra.gracz.HP * procentHPGracza + "/" + ekranGry.gra.gracz.HP;
            LabelDaneGracza.Text += "\nEnergia: " + ekranGry.gra.gracz.Energia * procentEnergiiGracza + "/" + ekranGry.gra.gracz.Energia;
            LabelDanePrzeciwnika.Text = przeciwnik.Nazwa;
            LabelDanePrzeciwnika.Text += "\nPunkty życia: " + przeciwnik.HP * procentHPPrzeciwnika + "/" + przeciwnik.HP;
            LabelDanePrzeciwnika.Text += "\nEnergia: " + przeciwnik.Energia * procentEnergiiPrzeciwnika + "/" + przeciwnik.Energia;
            UstawPoziomPaska(PictureBoxPasekHPGracza, procentHPGracza);
            UstawPoziomPaska(PictureBoxPasekEnergiiGracza, procentEnergiiGracza);
            UstawPoziomPaska(PictureBoxPasekHPPrzeciwnika, procentHPPrzeciwnika);
            UstawPoziomPaska(PictureBoxPasekEnergiiPrzeciwnika, procentEnergiiPrzeciwnika);
            WczytajPrzeciwnikaIGracza();
        }
        void UstawPoziomPaska(PictureBox pasek, double procentPozostalo)
        {
            pasek.Width = (int)(procentPozostalo * PanelDanychGracza.Width *0.8);
        }
        #endregion

        #region Zdarzenia


        #region Panel początkowy tury
        private void PictureBoxAtakFizyczny_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuFizycznego.Visible = true;
        }

        private void PictureBoxAtakMagiczny_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuMagicznego.Visible = true;
        }

        private void PictureBoxEkwipunek_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborMikstury.Visible = true;
        }

        private void PictureBoxUcieczka_Click(object sender, EventArgs e)
        {
            Random Losuj = new Random();
            int wylosowana = Losuj.Next(0, 100);

            if (wylosowana < 50)
            {
                LabelInformacje.Text = "Próba ucieczki nieudana!";
                WykonajAkcjePrzeciwnika();//lipa przeciwnik atakuje
            }
            else
            {
                AkcjeNaKoniecWalki();
                LabelInformacje.Text = "Udało Ci się uciec!";
                Enabled = false;
                TimerDoZamkniecia.Start();
            }
        }
        /// <summary>
        /// Metoda wykontywania na koniec walki
        /// </summary>
        private void AkcjeNaKoniecWalki()
        {
            przeciwnik.WyczyscEfekty();//czyścimy efekty
            ekranGry.gra.gracz.WyczyscEfekty();//czyścimy efekty
        }
        #endregion

        #region Panel ataków fizycznych
        private void PictureBoxWyjdzZAtakowFizycznych_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuFizycznego.Visible = false;
        }
        #endregion

        #region Panel ataków magicznych
        private void pictureBoxWyjdzZAtakowMagicznych_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborAtakuMagicznego.Visible = false;
        }
        #endregion

        #region Panel ekwipunku
        private void pictureBoxWyjdzZEkwipunku_Click(object sender, EventArgs e)
        {
            FlowLayoutPanelWyborMikstury.Visible = false;
        }
        #endregion

        private void TimerDoZamkniecia_Tick(object sender, EventArgs e)
        {
            LabelInformacje.Text = "HA! Chciałbyś, żeby się form zamknął, co?!? :D";
            TimerDoZamkniecia.Stop();
            DialogResult = DialogResult.OK;
        }

        private void EkranWalka_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
        #endregion
    }
}
