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
    public partial class Gra : Form
    {
        #region Zmienne i obiekty globalne
        //zmienne z wartością

        //listy
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();
        List<List<Postac>> zestawPrzeciwnikow = new List<List<Postac>>();
        List<Postac> postacFabularna = new List<Postac>();
        List<Postac> postacZMiasta = new List<Postac>();
        List<Postac> postacZCmentarza = new List<Postac>();
        List<Postac> postacZDziczy = new List<Postac>();

        //zmienne sterujące
        GlownyEkran glownyEkran;
        DziennikZadan dziennikZadan;

        #endregion

        public Gra(GlownyEkran Eg, Boolean czyWczytujemy)   //false nowa gra, true - wczytuejmy
        {
            glownyEkran = Eg;
            //glownyEkran.opcje.OdtworzDzwiek(blablabla);
            InitializeComponent();

            UtworzDaneGry();

            if (!czyWczytujemy)
            {
                NowaGra nowaGra = new NowaGra(this);  //Uruchamiamy kreatore nowej gry
                nowaGra.ShowDialog();
            }
            else
            {
                //Deserializacja z XML          //Wczytujemy stan gry
            }

            UstawElementyNaEkranie();
        }

        void UstawElementyNaEkranie()
        {
            //Ustawienia okienka gry
            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Ustawienie ikony w trybie okienkowym
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
        }

        void UtworzDaneGry()
        {

            //Tworzenie infrastruktury
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();
            UtworzZestawyPrzeciwnikow();
            
            //Tworzenie Form
            dziennikZadan = new DziennikZadan();
        }

        #region Funkcje
        void UtworzPostacie()
        {
            //**************************************************************************************************************
            //index 0
            postacFabularna.Add(new Postac("Lord Krwawy Mati"));
            //index 1
            postacFabularna.Add(new Postac("Lord Seba"));

            //**************************************************************************************************************
            //index 0
            postacZMiasta.Add(new Postac("Szczur"));

            //**************************************************************************************************************
            //index 0
            postacZCmentarza.Add(new Postac("Ghoul"));

            //**************************************************************************************************************
            //index 0
            postacZDziczy.Add(new Postac("Wilk"));

        }

        void UtworzUmiejetnosci()
        {
            //index 0
            umiejetnosc.Add(new Umiejetnosc("Wymachiwanie"));
        }

        void UtworzPrzedmiotyEkwipunku()
        {
            //index 0
            ekwipunek.Add(new Ekwipunek("Cywilne ubranie"));
        }

        void UtworzPrzeszkody()
        {
            //index 0
            przeszkoda.Add(new Przeszkoda("Drzewo"));
        }
        void UtworzZestawyPrzeciwnikow()
        {
            //index 0
            zestawPrzeciwnikow.Add(postacFabularna);
            //index 1
            zestawPrzeciwnikow.Add(postacZMiasta);
            //index 2
            zestawPrzeciwnikow.Add(postacZCmentarza);
            //index 3
            zestawPrzeciwnikow.Add(postacZDziczy);
        }
        #endregion

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (dziennikZadan.Visible == false)
            {
                dziennikZadan.Visible = true;
                dziennikZadan.BringToFront();
            }
            else
            {
                dziennikZadan.Visible = false;
            }
        }

        #region sprawiamy, ze okno jest niewidoczne w alt+tab

        //Obsluga wychodzenia - zakaz alt+f4
        private void Opcje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        //Nie pojawia sie w alt+tab
        private void Opcje_Load(object sender, EventArgs e)
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
