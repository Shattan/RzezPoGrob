using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using RPG.Narzedzia;


namespace RPG
{
    public partial class EkranEkwipunek : Form
    {

        #region Zmienne
        EkranGry ekranGry;
        Ekwipunek przenoszonyPrzedmiot = new Ekwipunek();
        //Ekwipunek przechowanyPrzedmiot = new Ekwipunek();
        #endregion
        Gracz gracz;
        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;
            gracz = ekranGry.gra.gracz;
            InitializeComponent();

            RozmiescElementy();
            KolorujElementy();
        }

        #region Metody

        #region Metody ustawiające elementy na ekranie
        void RozmiescElementy()
        {
            ShowInTaskbar = false;
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 20 / 100, Height * 80 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 10 / 100, LabelNazwyStatystyk.Height);
            LabelPorownanieStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);

            LabelStatystyki.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 5 / 100, Screen.PrimaryScreen.Bounds.Height * 8 / 100);
            LabelNazwyStatystyk.Location = new Point(LabelStatystyki.Location.X, LabelStatystyki.Location.Y + LabelStatystyki.Height);
            LabelPorownanieStatystyk.Location = new Point(LabelStatystyki.Location.X + LabelNazwyStatystyk.Width, LabelStatystyki.Location.Y + LabelStatystyki.Height);
            LabelWartosciStatystyk.Location = new Point(LabelPorownanieStatystyk.Location.X + LabelPorownanieStatystyk.Width, LabelStatystyki.Location.Y + LabelStatystyki.Height);


            //Rozmieszczanie przycisków
            PictureBoxPotwierdz.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 15 / 100, Screen.PrimaryScreen.Bounds.Height * 15 / 100);
            PictureBoxPotwierdz.Location = new Point(Screen.PrimaryScreen.Bounds.Width * 75 / 100, Screen.PrimaryScreen.Bounds.Height * 80 / 100);

            const int wielkoscPrzyciskow = 25;
            PictureBoxSilaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxSilaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxZrecznoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxWitalnoscPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaMinus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);
            PictureBoxInteligencjaPlus.Size = new Size(wielkoscPrzyciskow, wielkoscPrzyciskow);

            const int odleglosciMiedzyPrzyciskamiX = 5;
            const int odleglosciMiedzyPrzyciskamiY = wielkoscPrzyciskow;
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow*4);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);


            //Rozmieszczanie ekwipunku
            FlowLayoutPanelPlecak.Size = new Size(Width * 22 / 100, Height * 60 / 100);
            PictureBoxBron.Size = new Size(Width * 5 / 100, Height * 8 / 100);
            PictureBoxPancerz.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);
            PictureBoxTarcza.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);

            FlowLayoutPanelPlecak.Location = new Point(Width * 71 / 100, Height * 10 / 100);
            PictureBoxBron.Location = new Point(Width * 45 / 100, Height * 28 / 100);
            PictureBoxPancerz.Location = new Point(Width * 51 / 100, Height * 23 / 100);
            PictureBoxTarcza.Location = new Point(Width * 57 / 100, Height * 23 / 100);
        }
        void KolorujElementy()
        {
            Icon = new Icon("Resources/Grafiki menu/Ikona.ico");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxPotwierdz, "Resources/Grafiki menu/Wyjdź.png");

            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PanelOpisPrzedmiotu, "Resources/Grafiki menu/Tło informacji o przedmiocie.png");
            //Przyciski do rozdawania statystyk
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxSilaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxZrecznoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxWitalnoscPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaMinus, "Resources/Grafiki menu/Przycisk odejmij.png");
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolki(PictureBoxInteligencjaPlus, "Resources/Grafiki menu/Przycisk dodaj.png");
        }
        #endregion

        #region Metody odświeżające okienka z informacjami i ekwipunek
        void OdswiezStatystyki()
        {
            LabelNazwyStatystyk.Text = gracz.Nazwa + "\n";
            LabelNazwyStatystyk.Text += "Doświadczenie:\n";
            LabelNazwyStatystyk.Text += "Poziom:\n";
            LabelNazwyStatystyk.Text += "Punkty do rozdania:\n";
            LabelNazwyStatystyk.Text += "Siła:\n";
            LabelNazwyStatystyk.Text += "Zręczność:\n";
            LabelNazwyStatystyk.Text += "Witalność:\n";
            LabelNazwyStatystyk.Text += "Inteligencja:\n";
            LabelNazwyStatystyk.Text += "Obrażenia:\n";
            LabelNazwyStatystyk.Text += "Pancerz:\n";
            LabelNazwyStatystyk.Text += "Zdrowie:\n";
            LabelNazwyStatystyk.Text += "Energia:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie krytyczne:\n";

            LabelWartosciStatystyk.Text = "\n";
            LabelWartosciStatystyk.Text += gracz.Doswiadczenie + "/" + gracz.DoswiadczenieWymaganeNaKonkretnyPoziom[gracz.Poziom-1] + "\n"; 
            LabelWartosciStatystyk.Text += gracz.Poziom + "\n"; 
            LabelWartosciStatystyk.Text += gracz.PunktyStatystykDoRozdania + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += gracz.Sila + "\n";                 //Siła
            LabelWartosciStatystyk.Text += gracz.Zrecznosc + "\n";            //Zręczność
            LabelWartosciStatystyk.Text += gracz.Witalnosc + "\n";            //Witalność
            LabelWartosciStatystyk.Text += gracz.Inteligencja + "\n";         //Inteligencja
            LabelWartosciStatystyk.Text += gracz.Obrazenia + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += gracz.Pancerz + "\n";              //Pancerz
            LabelWartosciStatystyk.Text += gracz.HP + "\n";                   //Zdrowie
            LabelWartosciStatystyk.Text += gracz.Energia + "\n";              //Energia
            LabelWartosciStatystyk.Text += gracz.SzansaNaTrafienie + "%\n";   //Szansa na trafienie
            LabelWartosciStatystyk.Text += gracz.SzansaNaKrytyczne + "%\n";   //Szansa na trafienie krytyczne

            //Czyszczenie wartości porównań
            LabelPorownanieStatystyk.Text = "";
        }

        void OdswiezLabelZPorownaniemPrzedmiotow()
        {
            LabelNazwyStatystyk.Text = gracz.Nazwa + "\n";
            LabelNazwyStatystyk.Text += "Doświadczenie:\n";
            LabelNazwyStatystyk.Text += "Poziom:\n";
            LabelNazwyStatystyk.Text += "Punkty do rozdania:\n";
            LabelNazwyStatystyk.Text += "Siła:\n";
            LabelNazwyStatystyk.Text += "Zręczność:\n";
            LabelNazwyStatystyk.Text += "Witalność:\n";
            LabelNazwyStatystyk.Text += "Inteligencja:\n";
            LabelNazwyStatystyk.Text += "Obrażenia:\n";
            LabelNazwyStatystyk.Text += "Pancerz:\n";
            LabelNazwyStatystyk.Text += "Zdrowie:\n";
            LabelNazwyStatystyk.Text += "Energia:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie:\n";
            LabelNazwyStatystyk.Text += "Szansa na trafienie krytyczne:\n";

            LabelWartosciStatystyk.Text = "\n";
            LabelWartosciStatystyk.Text += gracz.Doswiadczenie + "/" + gracz.DoswiadczenieWymaganeNaKonkretnyPoziom[gracz.Poziom-1] + "\n"; 
            LabelWartosciStatystyk.Text += gracz.Poziom + "\n";  
            LabelWartosciStatystyk.Text += gracz.PunktyStatystykDoRozdania + "\n";                         //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += gracz.Sila + "\n";                       //Siła
            LabelWartosciStatystyk.Text += gracz.Zrecznosc + "\n";                  //Zręczność
            LabelWartosciStatystyk.Text += gracz.Witalnosc + "\n";                  //Witalność
            LabelWartosciStatystyk.Text += gracz.Inteligencja + "\n";               //Inteligencja
            LabelWartosciStatystyk.Text += gracz.Obrazenia + "\n";                  //Obrażenia
            LabelWartosciStatystyk.Text += gracz.Pancerz + "\n";                    //Pancerz
            LabelWartosciStatystyk.Text += gracz.HP + "\n";                         //Zdrowie
            LabelWartosciStatystyk.Text += gracz.Energia + "\n";                    //Energia
            LabelWartosciStatystyk.Text += gracz.SzansaNaTrafienie + "%\n";         //Szansa na trafienie
            LabelWartosciStatystyk.Text += gracz.SzansaNaKrytyczne + "%\n";         //Szansa na trafienie krytyczne


            #region Przekształcenia używanych przedmiotów na string, żeby nie występowały null dla  .Contains()
            String WyposazonaBron = "";
            String WyposazonyPancerz = "";
            String WyposazonaTarcza = "";

            if (gracz.ZalozonaBron.Obrazek == null)//Gdy bohater nie ma na sobie broni
            {
                WyposazonaBron = "Brak";
            }
            else//Gdy bohater ma na sobie broń
            {
                WyposazonaBron = gracz.ZalozonaBron.Obrazek;
            }

            if (gracz.ZalozonyPancerz.Obrazek == null)//Gdy bohater nie ma na sobie pancerza
            {
                WyposazonyPancerz = "Brak";
            }
            else//Gdy bohater ma na sobie pancerz
            {
                WyposazonyPancerz = gracz.ZalozonyPancerz.Obrazek;
            }

            if (gracz.ZalozonaTarcza.Obrazek == null)//Gdy bohater nie ma na sobie tarczy
            {
                WyposazonaTarcza = "Brak";
            }
            else//Gdy bohater ma na sobie tarczę
            {
                WyposazonaTarcza = gracz.ZalozonaTarcza.Obrazek;
            }
            #endregion

            if (przenoszonyPrzedmiot.Obrazek.Contains("bron1h"))//Jeżeli najechany przedmiot jest bronią jednoręczną
            {
                if (WyposazonaBron.Contains("bron1h")) //jeżeli obecnie założona broń jest jednoręczna
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, ' ', null));//Porównaj dwie bronie jednoręczne (bez tarczy)
                }
                else if (WyposazonaBron.Contains("bron2h"))//jeżeli obecnie założona broń jest dwuręczna
                {//Nie trzeba sprawdzać "if(WyposazonaTarcza.Contains("tarcza")", bo taka sytuacja nie powinna wystąpić przy broni dwuręcznej
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, ' ', null));//Porównaj broń jednoręczną (bez tarczy) i dwuręczną
                }
                else //Jeżeli jeśli gracz nie ma na sobie broni
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, ' ', null, ' ', null));//Wyświetl statystyki najechanej broni jednoręcznej
                }
            }
            else if (przenoszonyPrzedmiot.Obrazek.Contains("bron2h"))//Jeżeli najechany przedmiot jest bronią dwuręczną
            {
                if (WyposazonaBron.Contains("bron2h"))//Jeżeli obecnie założona broń jest dwuręczna
                {//Nie trzeba sprawdzać "if(WyposazonaTarcza.Contains("tarcza")", bo taka sytuacja nie powinna wystąpić przy broni dwuręcznej
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, ' ', null));//Porównaj dwie bronie dwuręczne
                }
                else if (WyposazonaBron.Contains("bron1h"))//Jeżeli obecnie założona broń jest jednoręczna
                {
                    if (WyposazonaTarcza.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                    {
                        WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, '-', gracz.ZalozonaTarcza));//Porównaj założoną broń jednoręczną + założoną tarczę z najechaną bronią dwuręczną
                    }
                    else//Jeżeli gracz nie ma na sobie tarczy
                    {
                        WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, ' ', null));//Porównaj najechaną broń dwuręczną z wyposażoną bronią jednoręczną
                    }
                }
                else //Jeżeli jeśli gracz nie ma na sobie broni
                {
                    if (WyposazonaTarcza.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                    {
                        WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaTarcza, ' ', null));//Wyświetl statystyki najechanej broni - statystyki tarczy
                    }
                    else//Jeżeli gracz nie ma na sobie tarczy
                    {
                        WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, ' ', null, ' ', null));//Wyświetl statystyki najechanej broni dwuręcznej
                    }
                }
            }
            else if (przenoszonyPrzedmiot.Obrazek.Contains("pancerz"))//Jeżeli przenoszony przedmiot jest pancerzem
            {
                if (WyposazonyPancerz.Contains("pancerz"))//Jeżeli najechany przedmiot jest pancerzem
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonyPancerz, ' ', null));//Porównaj pancerz najechany z założonym
                }
                else//Jeżeli gracz nie ma na sobie pancerza
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, ' ', null, ' ', null));//Wyświetl statystyki najechanego pancerza
                }
            }
            else if (przenoszonyPrzedmiot.Obrazek.Contains("tarcza"))//Jeżeli przenoszony przedmiot jest tarczą
            {
                if (WyposazonaTarcza.Contains("tarcza"))//Jeżeli gracz ma założoną tarczę
                {//Nie trzeba sprawdzać if(WyposazonaBron.Contains("bron1h")), bo broń jednoręczna nie konfliktuje z tarczą

                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaTarcza, ' ', null));//Porównaj tarczę najechaną z założoną
                }
                else if (WyposazonaBron.Contains("bron2h"))//Jeżeli gracz ma założoną broń dwuręczną
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, '-', gracz.ZalozonaBron, ' ', null));//Wyświetl statystyki najechanej tarczy - statystyki założonej broni dwuręcznej
                }
                else//Jeżeli gracz nie ma na sobie ani tarczy ani broni dwuręcznej
                {
                    WyswietlWartosciPorownan(PorownaneWartosciDoListy(przenoszonyPrzedmiot, ' ', null, ' ', null));//Wyświetl statystyki najechanej tarczy
                }
            }
        }

        void OdswiezInformacjeONejchanymPrzedmiocie(Ekwipunek przedmiot)
        {
            Program.UstawObrazZDopasowaniemWielkosciObrazuDoKontrolkiJakoImage(PictureBoxPrzenoszony, przedmiot.Obrazek);
            LabelNazwaPrzedmiotu.Text = przedmiot.Nazwa;

            LabelOpisStatystykPrzedmiotu.Text = "Wartość";
            LabelOpisStatystykPrzedmiotu.Text += "\nSiła";
            LabelOpisStatystykPrzedmiotu.Text += "\nZręczność";
            LabelOpisStatystykPrzedmiotu.Text += "\nWitalność";
            LabelOpisStatystykPrzedmiotu.Text += "\nInteligencja";
            LabelOpisStatystykPrzedmiotu.Text += "\nObrazenia";
            LabelOpisStatystykPrzedmiotu.Text += "\nPancerz";
            LabelOpisStatystykPrzedmiotu.Text += "\nPunkty życia";
            LabelOpisStatystykPrzedmiotu.Text += "\nEnergia";
            LabelOpisStatystykPrzedmiotu.Text += "\nSzansa na trafienie";
            LabelOpisStatystykPrzedmiotu.Text += "\nSzansa na krytyczne";

            LabelWartosciStatystykPrzedmiotu.Text = przedmiot.Cena.ToString();
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Sila;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Zrecznosc;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Witalnosc;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Inteligencja;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Obrazenia;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Pancerz;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.HP;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.Energia;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.SzansaNaTrafienie;
            LabelWartosciStatystykPrzedmiotu.Text += "\n" + przedmiot.SzansaNaKrytyczne;
        }

        void OdswiezEkwipunek()
        {
            Program.UstawObrazEkwipunku(PictureBoxBron, gracz.ZalozonaBron.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxPancerz, gracz.ZalozonyPancerz.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxTarcza, gracz.ZalozonaTarcza.Obrazek);

            FlowLayoutPanelPlecak.Controls.Clear();

            int szerokoscIkon = (Width * 5 / 100) - 5;
            int wysokoscIkon = Height * 8 / 100;

            //Dodawanie pól ekwipunku
            int miejscWEkwipunku = gracz.Plecak.Count+10 -(gracz.Plecak.Count+10)%4;//Plecak zawsze dodaje puste pola na końcu, wyrównujące poziom pól(nieograniczona ilość miejsc w plecaku)
            for (int i = 0; i < miejscWEkwipunku; i++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(szerokoscIkon, wysokoscIkon);
                Program.UstawObrazEkwipunku(x, null);
                x.ImageLocation = null;
                x.Name = null;
                FlowLayoutPanelPlecak.Controls.Add(x);
            }

            foreach (Ekwipunek przedmiot in gracz.Plecak)
            {
                Program.UstawObrazEkwipunku((FlowLayoutPanelPlecak.Controls[gracz.Plecak.IndexOf(przedmiot)] as PictureBox), przedmiot.Obrazek);
            }
        }
        #endregion

        #region Metody odpowiadające za mechanikę
        List<int> PorownaneWartosciDoListy(Ekwipunek pierwszyElement, char dzialanie, Ekwipunek drugiElement, char drugieDzialanie, Ekwipunek trzeciElement)
        {
            List<int> listaZWynikami = null;
            if (pierwszyElement != null)
            {
                listaZWynikami = new List<int>();
                if (drugiElement == null || dzialanie == ' ')
                {
                    listaZWynikami.Add(pierwszyElement.Sila);
                    listaZWynikami.Add(pierwszyElement.Zrecznosc);
                    listaZWynikami.Add(pierwszyElement.Witalnosc);
                    listaZWynikami.Add(pierwszyElement.Inteligencja);
                    listaZWynikami.Add((int)pierwszyElement.Obrazenia);
                    listaZWynikami.Add((int)pierwszyElement.Pancerz);
                    listaZWynikami.Add((int)pierwszyElement.HP);
                    listaZWynikami.Add((int)pierwszyElement.Energia);
                    listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie);
                    listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne);
                }
                else if (trzeciElement == null || drugieDzialanie == ' ')
                {
                    switch (dzialanie)
                    {
                        case '+':
                            listaZWynikami.Add(pierwszyElement.Sila + drugiElement.Sila);
                            listaZWynikami.Add(pierwszyElement.Zrecznosc + drugiElement.Zrecznosc);
                            listaZWynikami.Add(pierwszyElement.Witalnosc + drugiElement.Witalnosc);
                            listaZWynikami.Add(pierwszyElement.Inteligencja + drugiElement.Inteligencja);
                            listaZWynikami.Add((int)pierwszyElement.Obrazenia + (int)drugiElement.Obrazenia);
                            listaZWynikami.Add((int)pierwszyElement.Pancerz + (int)drugiElement.Pancerz);
                            listaZWynikami.Add((int)pierwszyElement.HP + (int)drugiElement.HP);
                            listaZWynikami.Add((int)pierwszyElement.Energia + (int)drugiElement.Energia);
                            listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie + (int)drugiElement.SzansaNaTrafienie);
                            listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne + (int)drugiElement.SzansaNaKrytyczne);
                            break;
                        case '-':
                            listaZWynikami.Add(pierwszyElement.Sila - drugiElement.Sila);
                            listaZWynikami.Add(pierwszyElement.Zrecznosc - drugiElement.Zrecznosc);
                            listaZWynikami.Add(pierwszyElement.Witalnosc - drugiElement.Witalnosc);
                            listaZWynikami.Add(pierwszyElement.Inteligencja - drugiElement.Inteligencja);
                            listaZWynikami.Add((int)pierwszyElement.Obrazenia - (int)drugiElement.Obrazenia);
                            listaZWynikami.Add((int)pierwszyElement.Pancerz - (int)drugiElement.Pancerz);
                            listaZWynikami.Add((int)pierwszyElement.HP - (int)drugiElement.HP);
                            listaZWynikami.Add((int)pierwszyElement.Energia - (int)drugiElement.Energia);
                            listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie - (int)drugiElement.SzansaNaTrafienie);
                            listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne - (int)drugiElement.SzansaNaKrytyczne);
                            break;
                    }
                }
                else
                {
                    switch (dzialanie)
                    {
                        case '+':
                            switch (drugieDzialanie)
                            {
                                case '+':
                                    listaZWynikami.Add(pierwszyElement.Sila + drugiElement.Sila + trzeciElement.Sila);
                                    listaZWynikami.Add(pierwszyElement.Zrecznosc + drugiElement.Zrecznosc + trzeciElement.Zrecznosc);
                                    listaZWynikami.Add(pierwszyElement.Witalnosc + drugiElement.Witalnosc + trzeciElement.Witalnosc);
                                    listaZWynikami.Add(pierwszyElement.Inteligencja + drugiElement.Inteligencja + trzeciElement.Inteligencja);
                                    listaZWynikami.Add((int)pierwszyElement.Obrazenia + (int)drugiElement.Obrazenia + (int)trzeciElement.Obrazenia);
                                    listaZWynikami.Add((int)pierwszyElement.Pancerz + (int)drugiElement.Pancerz + (int)trzeciElement.Pancerz);
                                    listaZWynikami.Add((int)pierwszyElement.HP + (int)drugiElement.HP + (int)trzeciElement.HP);
                                    listaZWynikami.Add((int)pierwszyElement.Energia + (int)drugiElement.Energia + (int)trzeciElement.Energia);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie + (int)drugiElement.SzansaNaTrafienie + (int)trzeciElement.SzansaNaTrafienie);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne + (int)drugiElement.SzansaNaKrytyczne + (int)trzeciElement.SzansaNaKrytyczne);
                                    break;
                                case '-':
                                    listaZWynikami.Add(pierwszyElement.Sila + drugiElement.Sila - trzeciElement.Sila);
                                    listaZWynikami.Add(pierwszyElement.Zrecznosc + drugiElement.Zrecznosc - trzeciElement.Zrecznosc);
                                    listaZWynikami.Add(pierwszyElement.Witalnosc + drugiElement.Witalnosc - trzeciElement.Witalnosc);
                                    listaZWynikami.Add(pierwszyElement.Inteligencja + drugiElement.Inteligencja - trzeciElement.Inteligencja);
                                    listaZWynikami.Add((int)pierwszyElement.Obrazenia + (int)drugiElement.Obrazenia - (int)trzeciElement.Obrazenia);
                                    listaZWynikami.Add((int)pierwszyElement.Pancerz + (int)drugiElement.Pancerz - (int)trzeciElement.Pancerz);
                                    listaZWynikami.Add((int)pierwszyElement.HP + (int)drugiElement.HP - (int)trzeciElement.HP);
                                    listaZWynikami.Add((int)pierwszyElement.Energia + (int)drugiElement.Energia - (int)trzeciElement.Energia);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie + (int)drugiElement.SzansaNaTrafienie - (int)trzeciElement.SzansaNaTrafienie);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne + (int)drugiElement.SzansaNaKrytyczne - (int)trzeciElement.SzansaNaKrytyczne);
                                    break;
                            }
                            break;
                        case '-':
                            switch (drugieDzialanie)
                            {
                                case '+':
                                    listaZWynikami.Add(pierwszyElement.Sila - drugiElement.Sila + trzeciElement.Sila);
                                    listaZWynikami.Add(pierwszyElement.Zrecznosc - drugiElement.Zrecznosc + trzeciElement.Zrecznosc);
                                    listaZWynikami.Add(pierwszyElement.Witalnosc - drugiElement.Witalnosc + trzeciElement.Witalnosc);
                                    listaZWynikami.Add(pierwszyElement.Inteligencja - drugiElement.Inteligencja + trzeciElement.Inteligencja);
                                    listaZWynikami.Add((int)pierwszyElement.Obrazenia - (int)drugiElement.Obrazenia + (int)trzeciElement.Obrazenia);
                                    listaZWynikami.Add((int)pierwszyElement.Pancerz - (int)drugiElement.Pancerz + (int)trzeciElement.Pancerz);
                                    listaZWynikami.Add((int)pierwszyElement.HP - (int)drugiElement.HP + (int)trzeciElement.HP);
                                    listaZWynikami.Add((int)pierwszyElement.Energia - (int)drugiElement.Energia + (int)trzeciElement.Energia);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie - (int)drugiElement.SzansaNaTrafienie + (int)trzeciElement.SzansaNaTrafienie);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne - (int)drugiElement.SzansaNaKrytyczne + (int)trzeciElement.SzansaNaKrytyczne);
                                    break;
                                case '-':
                                    listaZWynikami.Add(pierwszyElement.Sila - drugiElement.Sila - trzeciElement.Sila);
                                    listaZWynikami.Add(pierwszyElement.Zrecznosc - drugiElement.Zrecznosc - trzeciElement.Zrecznosc);
                                    listaZWynikami.Add(pierwszyElement.Witalnosc - drugiElement.Witalnosc - trzeciElement.Witalnosc);
                                    listaZWynikami.Add(pierwszyElement.Inteligencja - drugiElement.Inteligencja - trzeciElement.Inteligencja);
                                    listaZWynikami.Add((int)pierwszyElement.Obrazenia - (int)drugiElement.Obrazenia - (int)trzeciElement.Obrazenia);
                                    listaZWynikami.Add((int)pierwszyElement.Pancerz - (int)drugiElement.Pancerz - (int)trzeciElement.Pancerz);
                                    listaZWynikami.Add((int)pierwszyElement.HP - (int)drugiElement.HP - (int)trzeciElement.HP);
                                    listaZWynikami.Add((int)pierwszyElement.Energia - (int)drugiElement.Energia - (int)trzeciElement.Energia);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaTrafienie - (int)drugiElement.SzansaNaTrafienie - (int)trzeciElement.SzansaNaTrafienie);
                                    listaZWynikami.Add((int)pierwszyElement.SzansaNaKrytyczne - (int)drugiElement.SzansaNaKrytyczne - (int)trzeciElement.SzansaNaKrytyczne);
                                    break;
                            }
                            break;
                    }
                }
            }

            return listaZWynikami;
        }

        void WyswietlWartosciPorownan(List<int> wartosci)
        {
            LabelPorownanieStatystyk.Text = "\n";
            LabelPorownanieStatystyk.Text += "\n";
            LabelPorownanieStatystyk.Text += "\n";
            LabelPorownanieStatystyk.Text += "\n";

            if (wartosci != null)
            {
                foreach (int wartosc in wartosci)
                {
                    if (wartosc == 0)
                        LabelPorownanieStatystyk.Text += "\n";
                    else if (wartosc < 0)
                        LabelPorownanieStatystyk.Text += wartosc + "\n";
                    else
                        LabelPorownanieStatystyk.Text += "+" + wartosc + "\n";
                }
            }
            else
            {
                LabelPorownanieStatystyk.Text = "BŁĄD \nWCZYTYWANIA \nDANYCH";
            }
        }

        void PrzeniesPrzedmiotyUpuszczoneNaPlecak(object sender, DragEventArgs e)
        {
            PictureBox przedmiotUpuszczany = (e.Data.GetData(typeof(PictureBox)) as PictureBox);
            PictureBox przedmiotNaKtoryUpuszczamy = (sender as PictureBox);

            #region Przekształcenia używanych przedmiotów na string, żeby nie występowały null dla  .Contains()
            String WyposazonaBron = "";
            String WyposazonyPancerz = "";
            String WyposazonaTarcza = "";
            String NaCoUpuszczamy = "";

            if (gracz.ZalozonaBron.Obrazek == null)//Gdy bohater nie ma na sobie broni
            {
                WyposazonaBron = "Brak";
            }
            else//Gdy bohater ma na sobie broń
            {
                WyposazonaBron = gracz.ZalozonaBron.Obrazek;
            }

            if (gracz.ZalozonyPancerz.Obrazek == null)//Gdy bohater nie ma na sobie pancerza
            {
                WyposazonyPancerz = "Brak";
            }
            else//Gdy bohater ma na sobie pancerz
            {
                WyposazonyPancerz = gracz.ZalozonyPancerz.Obrazek;
            }

            if (gracz.ZalozonaTarcza.Obrazek == null)//Gdy bohater nie ma na sobie tarczy
            {
                WyposazonaTarcza = "Brak";
            }
            else//Gdy bohater ma na sobie tarczę
            {
                WyposazonaTarcza = gracz.ZalozonaTarcza.Obrazek;
            }

            if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Gdy upuszczamy na puste pole
            {
                NaCoUpuszczamy = "Brak";
            }
            else//Gdy gdy upuszczamy na przedmiot
            {
                NaCoUpuszczamy = przedmiotNaKtoryUpuszczamy.ImageLocation;
            }
            #endregion

            if (przedmiotUpuszczany.Name == "PictureBoxBron")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxBron
            {
                if (NaCoUpuszczamy.Contains("bron1h"))//Jeżeli najechany przedmiot jest bronią jednoręczną
                {//Nie potrzeba sprawdzeń, czy przedmiot z PictureBoxBron jest pancerzem, tarczą, czy bronią dwuręczną (dla bron2h obsługa taka sama)
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
                else if (NaCoUpuszczamy.Contains("bron2h"))//Jeżeli najechany przedmiot jest bronią dwuręczną
                {
                    if (przenoszonyPrzedmiot.Obrazek.Contains("bron1h"))//Jeżeli przenoszony przedmiot jest bronią jednoręczną
                    {
                        if (WyposazonaTarcza.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                        {
                            ZdejmijPrzedmiotDoPlecaka(PictureBoxTarcza);
                            ZamienPrzedmiotyMiejscami(przedmiotUpuszczany,przedmiotNaKtoryUpuszczamy);
                        }
                        else//Jeżeli gracz nie ma na sobie tarczy
                        {
                            ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                        }
                    }
                    else if (przenoszonyPrzedmiot.Obrazek.Contains("bron2h"))//Jeżeli przenoszony przedmiot jest bronią dwuręczną
                    {
                        ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                    }
                    else//Jeżeli przenoszony przedmiot nie jest ani bronią jednoręczną, ani bronią dwuręczną
                    {
                        //Taka sytuacja zdaje się nie wymaga żadnej akcji (w miejsce broni nie należy umieszczać pancerzy, ani tarcz, a pustych pól nie chcemy przenosić)
                    }
                }
                else if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Jeżeli najechane pole jest puste
                {
                    ZdejmijPrzedmiotDoPlecaka(PictureBoxBron);
                }
                else//Jeżeli najechane pole jest pancerzem, tarczą, bądź czymś innym
                {
                    //Nie wymagana żadna akcja (w pole broni można wprowadzić tylko broń)
                }
            }
            else if (przedmiotUpuszczany.Name == "PictureBoxPancerz")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxPancerz
            {
                if (NaCoUpuszczamy.Contains("pancerz"))//Jeżeli najechany przedmiot jest pancerzem
                {//Nie potrzeba więcej sprawdzeń, z PictureBoxPancerz można wynieść tylko pancerz
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
                else if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Jeżeli najechane pole jest puste
                {
                    ZdejmijPrzedmiotDoPlecaka(PictureBoxPancerz);
                }
                else//Jeżeli najechany przedmiot najechany nie jest pancerzem
                {
                    //Nie wymagana akcja (nie można ubrać nic innego niż pancerz)
                }
            }
            else if (przedmiotUpuszczany.Name == "PictureBoxTarcza")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxTarcza
            {
                if (NaCoUpuszczamy.Contains("tarcza"))//Jeżeli najechany przedmiot jest tarczą
                {//Nie potrzeba więcej sprawdzeń, z PictureBoxTarcza można wynieść tylko tarczę
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
                else if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Jeżeli najechane pole jest puste
                {
                    ZdejmijPrzedmiotDoPlecaka(PictureBoxTarcza);
                }
                else//Jeżeli najechany przedmiot najechany nie jest tarczą
                {
                    //Nie wymagana akcja (nie można ubrać nic innego niż tarczę)
                }
            }
            else//Jeżeli przenoszony przedmiot pochodzi z plecaka
            {
                if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Jeżeli najechany przedmiot jest pustym polem
                {
                    ZdejmijPrzedmiotDoPlecaka(przedmiotUpuszczany);
                }
                else//Jeżeli najechany przedmiot nie jest pustym polem
                {
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
            }
        }

        void PrzeniesPrzedmiotyUpuszczoneNaBron(object sender, DragEventArgs e)
        {
            PictureBox przedmiotUpuszczany = (e.Data.GetData(typeof(PictureBox)) as PictureBox);
            PictureBox przedmiotNaKtoryUpuszczamy = (sender as PictureBox);

            #region Przekształcenia używanych przedmiotów na string, żeby nie występowały null dla  .Contains()
            String WyposazonaTarcza = "";
            String NaCoUpuszczamy = "";

            if (gracz.ZalozonaTarcza.Obrazek == null)//Gdy bohater nie ma na sobie tarczy
            {
                WyposazonaTarcza = "Brak";
            }
            else//Gdy bohater ma na sobie tarczę
            {
                WyposazonaTarcza = gracz.ZalozonaTarcza.Obrazek;
            }

            if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Gdy upuszczamy na puste pole
            {
                NaCoUpuszczamy = "Brak";
            }
            else//Gdy gdy upuszczamy na przedmiot
            {
                NaCoUpuszczamy = przedmiotNaKtoryUpuszczamy.ImageLocation;
            }
            #endregion

            if (przedmiotUpuszczany.ImageLocation.Contains("bron1h"))//Jeżeli upuszczana jest broń jednoręczna
            {
                ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
            }
            else if (przedmiotUpuszczany.ImageLocation.Contains("bron2h"))//Jeżeli upuszczana jest broń dwuręczna
            {
                if (WyposazonaTarcza.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                {
                    ZdejmijPrzedmiotDoPlecaka(PictureBoxTarcza);
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
                else//Jeżeli gracz nie ma na sobie tarczy
                {
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
            }
        }

        void PrzeniesPrzedmiotyUpuszczoneNaPancerz(object sender, DragEventArgs e)
        {
            PictureBox przedmiotUpuszczany = (e.Data.GetData(typeof(PictureBox)) as PictureBox);
            PictureBox przedmiotNaKtoryUpuszczamy = (sender as PictureBox);

            #region Przekształcenia używanych przedmiotów na string, żeby nie występowały null dla  .Contains()
            String NaCoUpuszczamy = "";

            if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Gdy upuszczamy na puste pole
            {
                NaCoUpuszczamy = "Brak";
            }
            else//Gdy gdy upuszczamy na przedmiot
            {
                NaCoUpuszczamy = przedmiotNaKtoryUpuszczamy.ImageLocation;
            }
            #endregion

            if (przedmiotUpuszczany.ImageLocation.Contains("pancerz"))//Jeżeli upuszczany przedmiot jest pancerzem
            {
                ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
            }
        }

        void PrzeniesPrzedmiotyUpuszczoneNaTarcze(object sender, DragEventArgs e)
        {
            PictureBox przedmiotUpuszczany = (e.Data.GetData(typeof(PictureBox)) as PictureBox);
            PictureBox przedmiotNaKtoryUpuszczamy = (sender as PictureBox);

            #region Przekształcenia używanych przedmiotów na string, żeby nie występowały null dla  .Contains()
            String WyposazonaBron = "";
            String WyposazonaTarcza = "";
            String NaCoUpuszczamy = "";

            if (gracz.ZalozonaBron.Obrazek == null)//Gdy bohater nie ma na sobie broni
            {
                WyposazonaBron = "Brak";
            }
            else//Gdy bohater ma na sobie broń
            {
                WyposazonaBron = gracz.ZalozonaBron.Obrazek;
            }

            if (gracz.ZalozonaTarcza.Obrazek == null)//Gdy bohater nie ma na sobie tarczy
            {
                WyposazonaTarcza = "Brak";
            }
            else//Gdy bohater ma na sobie tarczę
            {
                WyposazonaTarcza = gracz.ZalozonaTarcza.Obrazek;
            }

            if (przedmiotNaKtoryUpuszczamy.ImageLocation == null)//Gdy upuszczamy na puste pole
            {
                NaCoUpuszczamy = "Brak";
            }
            else//Gdy gdy upuszczamy na przedmiot
            {
                NaCoUpuszczamy = przedmiotNaKtoryUpuszczamy.ImageLocation;
            }
            #endregion

            if (przedmiotUpuszczany.ImageLocation.Contains("tarcza"))//Jeżeli upuszczana jest broń jednoręczna
            {
                if(WyposazonaBron.Contains("bron2h"))
                {
                    ZdejmijPrzedmiotDoPlecaka(PictureBoxBron);
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
                else
                {
                    ZamienPrzedmiotyMiejscami(przedmiotUpuszczany, przedmiotNaKtoryUpuszczamy);
                }
            }
        }

        void ZamienPrzedmiotyMiejscami(PictureBox przedmiotUpuszczany, PictureBox przedmiotNaKtoryUpuszczamy)
        {
            //Zamienianie wizualne (na PictureBox'ach)
            if (przedmiotNaKtoryUpuszczamy.ImageLocation != null)//Jeżeli przedmiot upuszczany jest na inny przedmiot
            {
                String przechowalnia = przedmiotNaKtoryUpuszczamy.ImageLocation;
                Program.UstawObrazEkwipunku(przedmiotNaKtoryUpuszczamy, przedmiotUpuszczany.ImageLocation);
                Program.UstawObrazEkwipunku(przedmiotUpuszczany, przechowalnia);
            }
            else//Jeżeli przedmiot upuszczany jest na puste pole
            {
                Program.UstawObrazEkwipunku(przedmiotNaKtoryUpuszczamy, przedmiotUpuszczany.ImageLocation);
                przedmiotUpuszczany.ImageLocation = null;
                przedmiotUpuszczany.Image = null;
            }
            //Przepisanie stanu PictureBox'ów do gracza tymczasowego
            ZapiszEkwipunekZPictureBoxowDoList();
        }

        void ZdejmijPrzedmiotDoPlecaka(PictureBox ktoryPrzedmiot)
        {
            //Usuwanie wizualne (na PictureBox'ach)
            Program.UstawObrazEkwipunku(FlowLayoutPanelPlecak.Controls.OfType<PictureBox>().First(x => x.ImageLocation==null),ktoryPrzedmiot.ImageLocation);//Skopiowanie obrazka  z któryPrzedmiot do pierwszego wolnego pola w plecaku
            ktoryPrzedmiot.Image = null;
            ktoryPrzedmiot.ImageLocation = null;
            //Przepisanie stanu PictureBox'ów do gracza tymczasowego
            ZapiszEkwipunekZPictureBoxowDoList();
        }

        void ZapiszEkwipunekZPictureBoxowDoList()
        {
            if (PictureBoxBron.ImageLocation != null)
            {
                gracz.ZalozonaBron = new Ekwipunek(PrzedmiotyManager.ListaPrzedmiotow.Find(x => x.Obrazek == PictureBoxBron.ImageLocation));
            }
            else
            {
                gracz.ZalozonaBron = new Ekwipunek();
            }
            if (PictureBoxPancerz.ImageLocation != null)
            {
                gracz.ZalozonyPancerz = new Ekwipunek(PrzedmiotyManager.ListaPrzedmiotow.Find(x => x.Obrazek == PictureBoxPancerz.ImageLocation));
            }
            else
            {
                gracz.ZalozonyPancerz = new Ekwipunek();
            }
            if (PictureBoxTarcza.ImageLocation != null)
            {
                gracz.ZalozonaTarcza = new Ekwipunek(PrzedmiotyManager.ListaPrzedmiotow.Find(x => x.Obrazek == PictureBoxTarcza.ImageLocation));
            }
            else
            {
                gracz.ZalozonaTarcza = new Ekwipunek();
            }


            gracz.Plecak.Clear();

            foreach (PictureBox przedmiot in FlowLayoutPanelPlecak.Controls)
            {
                if (przedmiot.ImageLocation != null)//Jeżeli pole nie jest puste (po wejściu w ekwipunek układa przedmioty bez pustych pól)
                {
                    gracz.Plecak.Add(new Ekwipunek(PrzedmiotyManager.ListaPrzedmiotow.Find(x => x.Obrazek == przedmiot.ImageLocation)));
                }
            }
        }

        void WczytajStatystykiOdGracza()
        {
            gracz =ekranGry.gra.gracz;
            OdswiezStatystyki();
            OdswiezEkwipunek();
            DodanieDragAndDropDlaObrazkow();
        }

  

        void DodanieDragAndDropDlaObrazkow()
        {
            //Dodawanie operacji Drop and Drag dla wszystkich PictureBox z FlowLayoutPanelPancerze
            foreach (PictureBox obiekt in FlowLayoutPanelPlecak.Controls.OfType<PictureBox>())
            {
                obiekt.AllowDrop = true;
                
                obiekt.MouseDown += MouseDownPrzedmiotWPlecaku;
                obiekt.DragEnter += new DragEventHandler(DragEnterPrzedmiotWPlecaku);
                obiekt.DragDrop += new DragEventHandler(DragDropPrzedmiotWPlecaku);

                obiekt.MouseEnter += MouseEnterKazdyPrzedmiot;
                obiekt.MouseLeave += MouseLeaveKazdyPrzedmiot;
            }

            //Dodawanie operacji Drop and Drag dla PictureBox Bron/Pancerz/Tarcza
            PictureBoxBron.AllowDrop = true;
            PictureBoxPancerz.AllowDrop = true;
            PictureBoxTarcza.AllowDrop = true;
            
            //Gdy mysz jest naciśnięta na PictureBox, bądź obiekt upuszczony jest poza innym obiektem mogącym go przyjąć
            PictureBoxBron.MouseDown += MouseDownPictureBoxBron;
            PictureBoxPancerz.MouseDown += MouseDownPictureBoxPancerz;
            PictureBoxTarcza.MouseDown += MouseDownPictureBoxTarcza;

            //Gdy w obręb obiektu zostaje wniesiony przenoszony obiekt 
            PictureBoxBron.DragEnter += new DragEventHandler(DragEnterPictureBoxBron);
            PictureBoxPancerz.DragEnter += new DragEventHandler(DragEnterPictureBoxPancerz);
            PictureBoxTarcza.DragEnter += new DragEventHandler(DragEnterPictureBoxTarcza);

            //Gdy w obrębie obiektu zostanie upuszczony przenoszony obiekt
            PictureBoxBron.DragDrop += new DragEventHandler(DragDropPictureBoxBron);
            PictureBoxPancerz.DragDrop += new DragEventHandler(DragDropPictureBoxPancerz);
            PictureBoxTarcza.DragDrop += new DragEventHandler(DragDropPictureBoxTarcza);


            PictureBoxBron.MouseEnter += MouseEnterKazdyPrzedmiot;
            PictureBoxPancerz.MouseEnter += MouseEnterKazdyPrzedmiot;
            PictureBoxTarcza.MouseEnter += MouseEnterKazdyPrzedmiot;


            PictureBoxBron.MouseLeave += MouseLeaveKazdyPrzedmiot;
            PictureBoxPancerz.MouseLeave += MouseLeaveKazdyPrzedmiot;
            PictureBoxTarcza.MouseLeave += MouseLeaveKazdyPrzedmiot;
            
        }
        #endregion

        #endregion




        #region Zdarzenia

        //Aby dostać się do przedmiotu przenoszonego:
        //(e.Data.GetData(typeof(PictureBox)) as PictureBox)
        //Aby dostać się do przedmiotu, na którym aktualnie jest Drag and Drop
        //(sender as PictureBox)

        #region Akcje dla opisów aktualnie najechanego przedmiotu
        void MouseEnterKazdyPrzedmiot(object sender, EventArgs e)//Gdy myszka wejdzie w obręb najechanego przedmiotu
        {
            if (MouseButtons != MouseButtons.Left && (sender as PictureBox).ImageLocation!=null)//Zabezpieczenie przed wyświetlaniem pustych pól i zmienianiem przedmiotów podczas przenoszenia
            {
                przenoszonyPrzedmiot = new Ekwipunek(PrzedmiotyManager.ListaPrzedmiotow.Find(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation))); //Znalezienie przenoszonego przedmiotu w plecaku gracza
                OdswiezInformacjeONejchanymPrzedmiocie(przenoszonyPrzedmiot); //Zaktualizowanie panelu z informacjami o przedmiocie

                OdswiezLabelZPorownaniemPrzedmiotow(); //Porownuje przedmiot najechany z przedmiotami w plecaku i wyświetla wynik w Labelu porównującym

                PanelOpisPrzedmiotu.Visible = true;//Uwidocznij panel z informacjami o najechanym przedmiocie po zaktualizowaniu danych
            }
        }
        void MouseLeaveKazdyPrzedmiot(object sender, EventArgs e)//Gdy myszka opuści obręb najechanego przedmiotu
        {
            if (MouseButtons != MouseButtons.Left)//Jeżeli lewy przycisk myszki zostanie zwolniony
            {
                PanelOpisPrzedmiotu.Visible = false;//Ukryj panel z informacjami o najechanym przedmiocie
                OdswiezStatystyki();//Ukryj dane porównawcze dotyczące najechanej broni
            }
        }
        #endregion




        #region Akcje dla przedmiotów w plecaku

        void MouseDownPrzedmiotWPlecaku(object sender, MouseEventArgs e)//Gdy zostanie kliknięte pole w plecaku
        {
            if ((sender as PictureBox).ImageLocation != null)//Jeżeli pole nie jest puste
            {
                int indexPrzedmiotuNadKtorymJestKursor = gracz.Plecak.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));//Znajdź w plecaku gracza przedmiotu zgodnego z nazwą przenoszonego PictureBox
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)//Jeżeli znaleziono przedmiot (gdyby nie znaleziono index wyniesie -1
                {
                    przenoszonyPrzedmiot = gracz.Plecak[indexPrzedmiotuNadKtorymJestKursor]; //Zapamiętanie przenoszonego przedmiotu jako obiekt typu Ekwipunek
                }
                DoDragDrop(sender, DragDropEffects.Move);//Aktywowanie Drag and Drop dla klikniętego przedmiotu
                PanelOpisPrzedmiotu.Visible = false; //Po wykonaniu Drag and Drop chowa panel informacyjny (przydatne, gdy ktoś wyrzuca przedmioty poza pola)
            }
        }

        private void DragEnterPrzedmiotWPlecaku(object sender, DragEventArgs e)//Gdy zostanie najechane pole w plecaku
        {
            e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotu na najechanym polu
        }

        private void DragDropPrzedmiotWPlecaku(object sender, DragEventArgs e)//Gdy zostanie upuszczony przedmiot na polu w plecaku
        {
            PrzeniesPrzedmiotyUpuszczoneNaPlecak(sender, e);
        }
        #endregion





        #region Akcje dla przedmiotów na miejscu broni
        void MouseDownPictureBoxBron(object sender, MouseEventArgs e)//Gdy kliknięte zostanie pole broni
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pola, gdy puste
            {
                przenoszonyPrzedmiot = gracz.ZalozonaBron;//Ustawienie założonej broni jako przenoszonego przedmiotu
                DoDragDrop(sender, DragDropEffects.Move);//Aktywowanie Drag and Drop dla klikniętego przedmiotu
                PanelOpisPrzedmiotu.Visible = false;//Po wykonaniu Drag and Drop chowa panel informacyjny (przydatne, gdy ktoś wyrzuca przedmioty poza pola)
            }
        }

        private void DragEnterPictureBoxBron(object sender, DragEventArgs e)//Gdy przenoszony obiekt znajdzie się na polu broni
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("bron"))//sprawdzenie, czy przenoszony przedmiot jest bronią
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxBron(object sender, DragEventArgs e)//Gdy przenoszony obiekt zostanie upuszczony na polu broni
        {
            PrzeniesPrzedmiotyUpuszczoneNaBron(sender,e);
        }
        #endregion



        #region Akcje dla przedmiotów na miejscu pancerza
        void MouseDownPictureBoxPancerz(object sender, MouseEventArgs e)//Gdy zostanie kliknięte pole pancerza
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pustych pól
            {
                przenoszonyPrzedmiot = gracz.ZalozonyPancerz;//Ustawienie założonego pancerza jako przenoszonego przedmiotu
                DoDragDrop(sender, DragDropEffects.Move);//Aktywowanie Drag and Drop dla klikniętego przedmiotu
                PanelOpisPrzedmiotu.Visible = false;//Po wykonaniu Drag and Drop chowa panel informacyjny (przydatne, gdy ktoś wyrzuca przedmioty poza pola)
            }
        }

        private void DragEnterPictureBoxPancerz(object sender, DragEventArgs e)//Gdy przenoszony obiekt znajdzie się na polu pancerza
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("pancerz"))//Jeżeli przenoszony przedmiot jest pancerzem
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxPancerz(object sender, DragEventArgs e)//Gdy przenoszony obiekt zostanie upuszczony na polu pancerza
        {
            PrzeniesPrzedmiotyUpuszczoneNaPancerz(sender, e);
        }
        #endregion



        #region Akcje dla przedmiotów na miejscu tarczy
        void MouseDownPictureBoxTarcza(object sender, MouseEventArgs e)//Gdy zostanie kliknięte pole tarczy
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pustych pól
            {
                przenoszonyPrzedmiot = gracz.ZalozonaTarcza;//Ustawienie założonej tarczy jako przenoszonego przedmiotu
                DoDragDrop(sender, DragDropEffects.Move);//Aktywowanie Drag and Drop dla klikniętego przedmiotu
                PanelOpisPrzedmiotu.Visible = false;//Po wykonaniu Drag and Drop chowa panel informacyjny (przydatne, gdy ktoś wyrzuca przedmioty poza pola)
            }
        }

        private void DragEnterPictureBoxTarcza(object sender, DragEventArgs e)//Gdy przenoszony obiekt znajdzie się na polu tarczy
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("tarcza"))//Jeżeli przenoszony przedmiot jest tarczą
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxTarcza(object sender, DragEventArgs e)//Gdy przenoszony obiekt zostanie upuszczony na polu tarczy
        {
            PrzeniesPrzedmiotyUpuszczoneNaTarcze(sender, e);
        }
        #endregion








        private void Zegar_Tick(object sender, EventArgs e)
        {
            if (PanelOpisPrzedmiotu.Visible == true)
            {
                //Ustawianie pozycji okienka z informacjami o przedmiocie
                if (MousePosition.X + 10 + PanelOpisPrzedmiotu.Width < Width)
                {
                    if (MousePosition.Y + PanelOpisPrzedmiotu.Height < Height)
                    {
                        PanelOpisPrzedmiotu.Location = new Point(MousePosition.X + 10, MousePosition.Y);
                    }
                    else
                    {
                        PanelOpisPrzedmiotu.Location = new Point(MousePosition.X + 10, MousePosition.Y - PanelOpisPrzedmiotu.Height);
                    }
                }
                else
                {
                    if (MousePosition.Y + PanelOpisPrzedmiotu.Height < Height)
                    {
                        PanelOpisPrzedmiotu.Location = new Point(MousePosition.X - 10 - PanelOpisPrzedmiotu.Width, MousePosition.Y);
                    }
                    else
                    {
                        PanelOpisPrzedmiotu.Location = new Point(MousePosition.X - 10 - PanelOpisPrzedmiotu.Width, MousePosition.Y - PanelOpisPrzedmiotu.Height);
                    }
                }
                PanelOpisPrzedmiotu.BringToFront();
            }
        }


        #region Przyciski do modyfikowania statystyk
        private void PictureBoxSilaMinus_Click(object sender, EventArgs e)
        {
            if (gracz.SilaPodstawa > ekranGry.gra.gracz.SilaPodstawa)
            {
                gracz.SilaPodstawa--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            if (gracz.PunktyStatystykDoRozdania > 0)
            {
                gracz.SilaPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            if (gracz.ZrecznoscPodstawa > ekranGry.gra.gracz.ZrecznoscPodstawa)
            {
                gracz.ZrecznoscPodstawa--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            if (gracz.PunktyStatystykDoRozdania > 0)
            {
                gracz.ZrecznoscPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            if (gracz.WitalnoscPodstawa > ekranGry.gra.gracz.WitalnoscPodstawa)
            {
                gracz.WitalnoscPodstawa--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            if (gracz.PunktyStatystykDoRozdania > 0)
            {
                gracz.WitalnoscPodstawa++;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            if (gracz.InteligencjaPodstawa > ekranGry.gra.gracz.InteligencjaPodstawa)
            {
                gracz.InteligencjaPodstawa--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            if (gracz.PunktyStatystykDoRozdania > 0)
            {
                gracz.InteligencjaPodstawa++;
                OdswiezStatystyki();
            }
        }
        #endregion

        #region Zamykanie forma
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
     
            DialogResult = DialogResult.OK;
        }

        private void EkranEkwipunek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zegar.Stop();
            this.Dispose();
        }
        #endregion

        private void EkranEkwipunek_Shown(object sender, EventArgs e)
        {
            Zegar.Start();
            WczytajStatystykiOdGracza();
        }

        #endregion

    }
}
