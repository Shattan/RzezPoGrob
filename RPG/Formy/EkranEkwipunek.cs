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


namespace RPG
{
    public partial class EkranEkwipunek : Form
    {
        #region Zmienne
        EkranGry ekranGry;
        Gracz tymczasowyBohater = new Gracz();
        Ekwipunek przenoszonyPrzedmiot = new Ekwipunek();
        //Ekwipunek przechowanyPrzedmiot = new Ekwipunek();
        #endregion

        public EkranEkwipunek(EkranGry ekranGry)
        {
            this.ekranGry = ekranGry;

            InitializeComponent();

            RozmiescElementy();
            KolorujElementy();
        }

        #region Metody

        #region Metody ustawiające elementy na ekranie
        void RozmiescElementy()
        {
            Program.DopasujRozmiarFormyDoEkranu(this);

            //Rozmieszczanie statystyk
            LabelNazwyStatystyk.Size = new Size(Width * 20 / 100, Height * 80 / 100);
            LabelWartosciStatystyk.Size = new Size(Width * 4 / 100, LabelNazwyStatystyk.Height);
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
            PictureBoxSilaMinus.Location = new Point(LabelWartosciStatystyk.Location.X + LabelWartosciStatystyk.Width + LabelPorownanieStatystyk.Width, LabelWartosciStatystyk.Location.Y + wielkoscPrzyciskow*2);
            PictureBoxSilaPlus.Location = new Point(PictureBoxSilaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxSilaMinus.Location.Y);
            PictureBoxZrecznoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxSilaMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxZrecznoscPlus.Location = new Point(PictureBoxZrecznoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxZrecznoscMinus.Location.Y);
            PictureBoxWitalnoscMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxZrecznoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxWitalnoscPlus.Location = new Point(PictureBoxWitalnoscMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxWitalnoscMinus.Location.Y);
            PictureBoxInteligencjaMinus.Location = new Point(PictureBoxSilaMinus.Location.X, PictureBoxWitalnoscMinus.Location.Y + odleglosciMiedzyPrzyciskamiY);
            PictureBoxInteligencjaPlus.Location = new Point(PictureBoxInteligencjaMinus.Location.X + wielkoscPrzyciskow + odleglosciMiedzyPrzyciskamiX, PictureBoxInteligencjaMinus.Location.Y);


            //Rozmieszczanie ekwipunku
            FlowLayoutPanelPancerze.Size = new Size(Width * 22 / 100, Height * 60 / 100);
            PictureBoxBron.Size = new Size(Width * 5 / 100, Height * 8 / 100);
            PictureBoxPancerz.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);
            PictureBoxTarcza.Size = new Size(PictureBoxBron.Width, PictureBoxBron.Height);

            FlowLayoutPanelPancerze.Location = new Point(Width * 71 / 100, Height * 10 / 100);
            PictureBoxBron.Location = new Point(Width * 45 / 100, Height * 28 / 100);
            PictureBoxPancerz.Location = new Point(Width * 51 / 100, Height * 23 / 100);
            PictureBoxTarcza.Location = new Point(Width * 57 / 100, Height * 23 / 100);
        }
        void KolorujElementy()
        {
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
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";   
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
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";               //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.SilaSuma + "\n";                 //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.ZrecznoscSuma + "\n";            //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.WitalnoscSuma + "\n";            //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.InteligencjaSuma + "\n";         //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.ObrazeniaSuma + "\n";            //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.PancerzSuma + "\n";              //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HPSuma + "\n";                   //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.EnergiaSuma + "\n";              //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienieSuma + "%\n";   //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczneSuma + "%\n";   //Szansa na trafienie krytyczne

            //Czyszczenie wartości porównań
            LabelPorownanieStatystyk.Text = "";
        }


        //Przeciążenie dla gracza bez przedmiotu
        void OdswiezStatystykiZPorownaniemPrzedmiotow(Ekwipunek zakladanyPrzedmiot)
        {
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";
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
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";                         //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.SilaSuma + "\n";                       //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.ZrecznoscSuma + "\n";                  //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.WitalnoscSuma + "\n";                  //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.InteligencjaSuma + "\n";               //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.ObrazeniaSuma + "\n";                  //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.PancerzSuma + "\n";                    //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HPSuma + "\n";                         //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.EnergiaSuma + "\n";                    //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienieSuma + "%\n";         //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczneSuma + "%\n";         //Szansa na trafienie krytyczne


            if (zakladanyPrzedmiot.Obrazek.Contains("bron2h") && tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))
            {
                //Wersja dla gracza z bez broni, ale z tarczą, próbującego założyć broń dwuręczną
                LabelPorownanieStatystyk.Text = "\n";
                LabelPorownanieStatystyk.Text += "\n";

                List<int> wartosci = PorownajDoListy(zakladanyPrzedmiot, '-', tymczasowyBohater.ZalozonaTarcza, ' ', null);
                foreach (int wartosc in wartosci)
                {
                    DodajLinijkeTekstuDoPorownan(wartosc);
                }
            }
            else if (zakladanyPrzedmiot.Obrazek.Contains("tarcza") && tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))
            {
                //Wersja dla gracza z dwuręczną bronią próbującego założyć tarczę
                LabelPorownanieStatystyk.Text = "\n";
                LabelPorownanieStatystyk.Text += "\n";

                List<int> wartosci = PorownajDoListy(zakladanyPrzedmiot, '-', tymczasowyBohater.ZalozonaBron, ' ', null);
                foreach (int wartosc in wartosci)
                {
                    DodajLinijkeTekstuDoPorownan(wartosc);
                }
            }
            else
            {
                //Wersja dla gracza, który zakłada broń jednoręczną na puste pole broni, lub dwuręczną na puste pola broni i tarczy
                LabelPorownanieStatystyk.Text = "\n";
                LabelPorownanieStatystyk.Text += "\n";

                List<int> wartosci = PorownajDoListy(zakladanyPrzedmiot, ' ', null, ' ', null);
                foreach (int wartosc in wartosci)
                {
                    DodajLinijkeTekstuDoPorownan(wartosc);
                }
            }
        }
        //Przeciążenie dla dwóch przedmiotów
        void OdswiezStatystykiZPorownaniemPrzedmiotow(Ekwipunek zalozonyPrzedmiot, Ekwipunek zakladanyPrzedmiot)
        {
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";
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
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";                         //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.SilaSuma + "\n";                       //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.ZrecznoscSuma + "\n";                  //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.WitalnoscSuma + "\n";                  //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.InteligencjaSuma + "\n";               //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.ObrazeniaSuma + "\n";                  //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.PancerzSuma + "\n";                    //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HPSuma + "\n";                         //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.EnergiaSuma + "\n";                    //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienieSuma + "%\n";         //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczneSuma + "%\n";         //Szansa na trafienie krytyczne

            LabelPorownanieStatystyk.Text = "\n";
            LabelPorownanieStatystyk.Text += "\n";

            List<int> wartosci = PorownajDoListy(zakladanyPrzedmiot, '-', zalozonyPrzedmiot, ' ', null);
            foreach (int wartosc in wartosci)
            {
                DodajLinijkeTekstuDoPorownan(wartosc);
            }
        }

        //Przeciążenie dla broni 2 ręcznej i broni z tarczą
        void OdswiezStatystykiZPorownaniemPrzedmiotow(Ekwipunek zalozonaBron,Ekwipunek zalozonaTarcza, Ekwipunek zakladanaBron2h)
        {
            LabelNazwyStatystyk.Text = tymczasowyBohater.Nazwa + "\n";
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
            LabelWartosciStatystyk.Text += tymczasowyBohater.Punkty + "\n";                         //Pozostałe punkty do rozdania
            LabelWartosciStatystyk.Text += tymczasowyBohater.SilaSuma + "\n";                       //Siła
            LabelWartosciStatystyk.Text += tymczasowyBohater.ZrecznoscSuma + "\n";                  //Zręczność
            LabelWartosciStatystyk.Text += tymczasowyBohater.WitalnoscSuma + "\n";                  //Witalność
            LabelWartosciStatystyk.Text += tymczasowyBohater.InteligencjaSuma + "\n";               //Inteligencja
            LabelWartosciStatystyk.Text += tymczasowyBohater.ObrazeniaSuma + "\n";                  //Obrażenia
            LabelWartosciStatystyk.Text += tymczasowyBohater.PancerzSuma + "\n";                    //Pancerz
            LabelWartosciStatystyk.Text += tymczasowyBohater.HPSuma + "\n";                         //Zdrowie
            LabelWartosciStatystyk.Text += tymczasowyBohater.EnergiaSuma + "\n";                    //Energia
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaTrafienieSuma + "%\n";         //Szansa na trafienie
            LabelWartosciStatystyk.Text += tymczasowyBohater.SzansaNaKrytyczneSuma + "%\n";         //Szansa na trafienie krytyczne

            LabelPorownanieStatystyk.Text = "\n";
            LabelPorownanieStatystyk.Text += "\n";

            List<int> wartosci = PorownajDoListy(zakladanaBron2h, '-', zalozonaBron, '+', zalozonaTarcza);
            foreach (int wartosc in wartosci)
            {
                DodajLinijkeTekstuDoPorownan(wartosc);
            }
        }


        void OdswiezInformacjeOPrzedmiocie(Ekwipunek przedmiot)
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
            Program.UstawObrazEkwipunku(PictureBoxBron, tymczasowyBohater.ZalozonaBron.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxPancerz, tymczasowyBohater.ZalozonyPancerz.Obrazek);
            Program.UstawObrazEkwipunku(PictureBoxTarcza, tymczasowyBohater.ZalozonaTarcza.Obrazek);

            FlowLayoutPanelPancerze.Controls.Clear();

            int szerokoscIkon = (Width * 5 / 100) - 5;
            int wysokoscIkon = Height * 8 / 100;

            //Dodawanie pól ekwipunku
            const int miejscWEkwipunku = 59;
            for (int i = 0; i <= miejscWEkwipunku; i++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(szerokoscIkon, wysokoscIkon);
                Program.UstawObrazEkwipunku(x, null);
                x.ImageLocation = null;
                x.Name = null;
                FlowLayoutPanelPancerze.Controls.Add(x);
            }

            foreach (Ekwipunek przedmiot in tymczasowyBohater.plecakGracza)
            {
                //tymczasowe zabezpieczenie na wypadek wiekszej ilosci przedmiotow niz miejsc w plecaku
                if (tymczasowyBohater.plecakGracza.IndexOf(przedmiot) < FlowLayoutPanelPancerze.Controls.Count)
                {
                    Program.UstawObrazEkwipunku((FlowLayoutPanelPancerze.Controls[tymczasowyBohater.plecakGracza.IndexOf(przedmiot)] as PictureBox), przedmiot.Obrazek);
                }
            }
        }
        #endregion

        #region Metody odpowiadające za mechanikę
        List<int> PorownajDoListy(Ekwipunek pierwszyElement, char dzialanie, Ekwipunek drugiElement, char drugieDzialanie, Ekwipunek trzeciElement)
        {
            List<int> listaZWynikami = new List<int>();
            if (drugiElement == null || dzialanie == ' ')
            {
                listaZWynikami.Add(pierwszyElement.Sila              );
                listaZWynikami.Add(pierwszyElement.Zrecznosc         );
                listaZWynikami.Add(pierwszyElement.Witalnosc         );
                listaZWynikami.Add(pierwszyElement.Inteligencja      );
                listaZWynikami.Add(pierwszyElement.Obrazenia         );
                listaZWynikami.Add(pierwszyElement.Pancerz           );
                listaZWynikami.Add(pierwszyElement.HP                );
                listaZWynikami.Add(pierwszyElement.Energia           );
                listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie );
                listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne );
            }
            else if (trzeciElement == null || drugieDzialanie == ' ')
            {
                switch (dzialanie)
                {
                    case '+':
                        listaZWynikami.Add(pierwszyElement.Sila                 + drugiElement.Sila);
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            + drugiElement.Zrecznosc);
                        listaZWynikami.Add(pierwszyElement.Witalnosc            + drugiElement.Witalnosc);
                        listaZWynikami.Add(pierwszyElement.Inteligencja         + drugiElement.Inteligencja);
                        listaZWynikami.Add(pierwszyElement.Obrazenia            + drugiElement.Obrazenia);
                        listaZWynikami.Add(pierwszyElement.Pancerz              + drugiElement.Pancerz);
                        listaZWynikami.Add(pierwszyElement.HP                   + drugiElement.HP);
                        listaZWynikami.Add(pierwszyElement.Energia              + drugiElement.Energia);
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    + drugiElement.SzansaNaTrafienie);
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    + drugiElement.SzansaNaKrytyczne);
                        break;
                    case '-':
                        listaZWynikami.Add(pierwszyElement.Sila                 - drugiElement.Sila);
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            - drugiElement.Zrecznosc);
                        listaZWynikami.Add(pierwszyElement.Witalnosc            - drugiElement.Witalnosc);
                        listaZWynikami.Add(pierwszyElement.Inteligencja         - drugiElement.Inteligencja);
                        listaZWynikami.Add(pierwszyElement.Obrazenia            - drugiElement.Obrazenia);
                        listaZWynikami.Add(pierwszyElement.Pancerz              - drugiElement.Pancerz);
                        listaZWynikami.Add(pierwszyElement.HP                   - drugiElement.HP);
                        listaZWynikami.Add(pierwszyElement.Energia              - drugiElement.Energia);
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    - drugiElement.SzansaNaTrafienie);
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    - drugiElement.SzansaNaKrytyczne);
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
                        listaZWynikami.Add(pierwszyElement.Sila                 + drugiElement.Sila              + trzeciElement.Sila                );
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            + drugiElement.Zrecznosc         + trzeciElement.Zrecznosc           );
                        listaZWynikami.Add(pierwszyElement.Witalnosc            + drugiElement.Witalnosc         + trzeciElement.Witalnosc           );
                        listaZWynikami.Add(pierwszyElement.Inteligencja         + drugiElement.Inteligencja      + trzeciElement.Inteligencja        );
                        listaZWynikami.Add(pierwszyElement.Obrazenia            + drugiElement.Obrazenia         + trzeciElement.Obrazenia           );
                        listaZWynikami.Add(pierwszyElement.Pancerz              + drugiElement.Pancerz           + trzeciElement.Pancerz             );
                        listaZWynikami.Add(pierwszyElement.HP                   + drugiElement.HP                + trzeciElement.HP                  );
                        listaZWynikami.Add(pierwszyElement.Energia              + drugiElement.Energia           + trzeciElement.Energia             );
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    + drugiElement.SzansaNaTrafienie + trzeciElement.SzansaNaTrafienie   );
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    + drugiElement.SzansaNaKrytyczne + trzeciElement.SzansaNaKrytyczne   );
                                break;
                            case '-':
                        listaZWynikami.Add(pierwszyElement.Sila                 + drugiElement.Sila              - trzeciElement.Sila                );
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            + drugiElement.Zrecznosc         - trzeciElement.Zrecznosc           );
                        listaZWynikami.Add(pierwszyElement.Witalnosc            + drugiElement.Witalnosc         - trzeciElement.Witalnosc           );
                        listaZWynikami.Add(pierwszyElement.Inteligencja         + drugiElement.Inteligencja      - trzeciElement.Inteligencja        );
                        listaZWynikami.Add(pierwszyElement.Obrazenia            + drugiElement.Obrazenia         - trzeciElement.Obrazenia           );
                        listaZWynikami.Add(pierwszyElement.Pancerz              + drugiElement.Pancerz           - trzeciElement.Pancerz             );
                        listaZWynikami.Add(pierwszyElement.HP                   + drugiElement.HP                - trzeciElement.HP                  );
                        listaZWynikami.Add(pierwszyElement.Energia              + drugiElement.Energia           - trzeciElement.Energia             );
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    + drugiElement.SzansaNaTrafienie - trzeciElement.SzansaNaTrafienie   );
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    + drugiElement.SzansaNaKrytyczne - trzeciElement.SzansaNaKrytyczne   );
                                break;
                        }
                        break;
                    case '-':
                        switch (drugieDzialanie)
                        {
                            case '+':
                        listaZWynikami.Add(pierwszyElement.Sila                 - drugiElement.Sila              + trzeciElement.Sila                );
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            - drugiElement.Zrecznosc         + trzeciElement.Zrecznosc           );
                        listaZWynikami.Add(pierwszyElement.Witalnosc            - drugiElement.Witalnosc         + trzeciElement.Witalnosc           );
                        listaZWynikami.Add(pierwszyElement.Inteligencja         - drugiElement.Inteligencja      + trzeciElement.Inteligencja        );
                        listaZWynikami.Add(pierwszyElement.Obrazenia            - drugiElement.Obrazenia         + trzeciElement.Obrazenia           );
                        listaZWynikami.Add(pierwszyElement.Pancerz              - drugiElement.Pancerz           + trzeciElement.Pancerz             );
                        listaZWynikami.Add(pierwszyElement.HP                   - drugiElement.HP                + trzeciElement.HP                  );
                        listaZWynikami.Add(pierwszyElement.Energia              - drugiElement.Energia           + trzeciElement.Energia             );
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    - drugiElement.SzansaNaTrafienie + trzeciElement.SzansaNaTrafienie   );
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    - drugiElement.SzansaNaKrytyczne + trzeciElement.SzansaNaKrytyczne   );
                                break;
                            case '-':
                        listaZWynikami.Add(pierwszyElement.Sila                 - drugiElement.Sila              - trzeciElement.Sila                );
                        listaZWynikami.Add(pierwszyElement.Zrecznosc            - drugiElement.Zrecznosc         - trzeciElement.Zrecznosc           );
                        listaZWynikami.Add(pierwszyElement.Witalnosc            - drugiElement.Witalnosc         - trzeciElement.Witalnosc           );
                        listaZWynikami.Add(pierwszyElement.Inteligencja         - drugiElement.Inteligencja      - trzeciElement.Inteligencja        );
                        listaZWynikami.Add(pierwszyElement.Obrazenia            - drugiElement.Obrazenia         - trzeciElement.Obrazenia           );
                        listaZWynikami.Add(pierwszyElement.Pancerz              - drugiElement.Pancerz           - trzeciElement.Pancerz             );
                        listaZWynikami.Add(pierwszyElement.HP                   - drugiElement.HP                - trzeciElement.HP                  );
                        listaZWynikami.Add(pierwszyElement.Energia              - drugiElement.Energia           - trzeciElement.Energia             );
                        listaZWynikami.Add(pierwszyElement.SzansaNaTrafienie    - drugiElement.SzansaNaTrafienie - trzeciElement.SzansaNaTrafienie   );
                        listaZWynikami.Add(pierwszyElement.SzansaNaKrytyczne    - drugiElement.SzansaNaKrytyczne - trzeciElement.SzansaNaKrytyczne   );
                                break;
                        }
                        break;
                }
            }
            return listaZWynikami;
        }

        void DodajLinijkeTekstuDoPorownan(int WartoscDoDodania)
        {
            if (WartoscDoDodania == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (WartoscDoDodania < 0)
                LabelPorownanieStatystyk.Text += WartoscDoDodania + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + WartoscDoDodania + "\n";
        }

        void ZamienPrzedmiotyMiejscami(PictureBox pierwszyPrzedmiot, PictureBox drugiPrzedmiot)
        {
        }

        void WczytajStatystykiOdGracza()
        {
            tymczasowyBohater = new Gracz(ekranGry.gra.gracz);
            OdswiezStatystyki();
            OdswiezEkwipunek();
            DodanieDragAndDropDlaObrazkow();
        }

        void ZapiszStatystykiDoGracza()
        {
            ekranGry.gra.gracz = new Gracz(tymczasowyBohater);
        }

        void DodanieDragAndDropDlaObrazkow()
        {
            //Dodawanie operacji Drop and Drag dla wszystkich PictureBox z FlowLayoutPanelPancerze
            foreach (PictureBox obiekt in FlowLayoutPanelPancerze.Controls.OfType<PictureBox>())
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
                przenoszonyPrzedmiot = new Ekwipunek(tymczasowyBohater.plecakGracza.Find(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation))); //Znalezienie przenoszonego przedmiotu w plecaku gracza
                OdswiezInformacjeOPrzedmiocie(przenoszonyPrzedmiot); //Zaktualizowanie panelu z informacjami o przedmiocie

                if (przenoszonyPrzedmiot.Obrazek.Contains("bron1h"))//Jeżeli najechany przedmiot jest bronią jednoręczną
                {
                    if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron1h")) //jeżeli obecnie założona broń jest jednoręczna
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot); //Porównaj dwie bronie jednoręczne (bez tarczy)
                    }
                    else if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))//jeżeli obecnie założona broń jest dwuręczna
                    {//Nie trzeba sprawdzać "if(tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza")", bo taka sytuacja nie powinna wystąpić przy broni dwuręcznej
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot); //Porównaj broń jednoręczną (bez tarczy) i dwuręczną
                    }
                    else //Jeżeli jeśli gracz nie ma na sobie broni
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot); //Wyświetl statystyki najechanej broni jednoręcznej
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("bron2h"))//Jeżeli najechany przedmiot jest bronią dwuręczną
                {
                    if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))//Jeżeli obecnie założona broń jest dwuręczna
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot);//Porównaj dwie bronie dwuręczne
                    }
                    else if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron1h"))//Jeżeli obecnie założona broń jest jednoręczna
                    {
                        if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, tymczasowyBohater.ZalozonaTarcza, przenoszonyPrzedmiot);//Porównaj założoną broń jednoręczną + założoną tarczę z najechaną bronią dwuręczną
                        }
                        else//Jeżeli gracz nie ma na sobie tarczy
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot);//Porównaj najechaną broń dwuręczną z wyposażoną bronią jednoręczną
                        }
                    }
                    else //Jeżeli jeśli gracz nie ma na sobie broni
                    {
                        if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);//Wyświetl statystyki najechanej broni - statystyki tarczy
                        }
                        else//Jeżeli gracz nie ma na sobie tarczy
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot); //Wyświetl statystyki najechanej broni dwuręcznej
                        }
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("pancerz"))//Jeżeli przenoszony przedmiot jest pancerzem
                {
                    if (tymczasowyBohater.ZalozonyPancerz.Obrazek.Contains("pancerz"))//Jeżeli najechany przedmiot jest pancerzem
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonyPancerz, przenoszonyPrzedmiot);//Porównaj pancerz najechany z założonym
                    }
                    else//Jeżeli gracz nie ma na sobie pancerza
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);//Wyświetl statystyki najechanego pancerza
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("tarcza"))//Jeżeli przenoszony przedmiot jest tarczą
                {
                    if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))//Jeżeli gracz ma założoną tarczę
                    {//Nie trzeba sprawdzać if(tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron1h")), bo broń jednoręczna nie konfliktuje z tarczą
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaTarcza, przenoszonyPrzedmiot);//Porównaj tarczę najechaną z założoną
                    }
                    else if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))//Jeżeli gracz ma założoną broń dwuręczną
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);//Wyświetl statystyki najechanej tarczy - statystyki założonej broni dwuręcznej
                    }
                    else//Jeżeli gracz nie ma na sobie ani tarczy ani broni dwuręcznej
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);//Wyświetl statystyki najechanej tarczy
                    }
                }

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
                int indexPrzedmiotuNadKtorymJestKursor = tymczasowyBohater.plecakGracza.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));//Znajdź w plecaku gracza przedmiotu zgodnego z nazwą przenoszonego PictureBox
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)//Jeżeli znaleziono przedmiot (gdyby nie znaleziono index wyniesie -1
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor]; //Zapamiętanie przenoszonego przedmiotu jako obiekt typu Ekwipunek
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
            int indexPrzedmiotuNadKtorymJestKursor = tymczasowyBohater.plecakGracza.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
            int indexPrzedmiotuKtoryPrzenosimy = tymczasowyBohater.plecakGracza.FindIndex(x => x.Obrazek.Equals(przenoszonyPrzedmiot.Obrazek));
            if ((e.Data.GetData(typeof(PictureBox)) as PictureBox).Name == "PictureBoxBron")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxBron
            {
                if ((sender as PictureBox).ImageLocation.Contains("bron1h"))//Jeżeli najechany przedmiot jest bronią jednoręczną
                {//Nie potrzeba sprawdzeń, czy przedmiot z PictureBoxBron jest pancerzem, tarczą, czy bronią dwuręczną (dla bron2h obsługa taka sama)
                    //[TODO]Zamień miejscami założoną broń z bronią najechaną
                }
                else if ((sender as PictureBox).ImageLocation.Contains("bron2h"))//Jeżeli najechany przedmiot jest bronią dwuręczną
                {
                    if (przenoszonyPrzedmiot.Obrazek.Contains("bron1h"))//Jeżeli przenoszony przedmiot jest bronią jednoręczną
                    {
                        if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))//Jeżeli gracz ma na sobie tarczę
                        {
                            //[TODO]Znajdź wolne miejsce w plecaku gracza, umieść tam tarczę, wyczyść pole tarczy
                            //[TODO]Zamień miejscami najechany przedmiot z przedmiotem założonym
                        }
                        else//Jeżeli gracz nie ma na sobie tarczy
                        {
                            //[TODO]Zamień miejscami najechany przedmiot z przedmiotem założonym
                        }
                    }
                    else if (przenoszonyPrzedmiot.Obrazek.Contains("bron2h"))//Jeżeli przenoszony przedmiot jest bronią dwuręczną
                    {
                        //[TODO]Zamień miejscami najechany przedmiot z przedmiotem założonym
                    }
                    else//Jeżeli przenoszony przedmiot nie jest ani bronią jednoręczną, ani bronią dwuręczną
                    {
                        //Taka sytuacja zdaje się nie wymaga żadnej akcji (w miejsce broni nie należy umieszczać pancerzy, ani tarcz, a pustych pól nie chcemy przenosić)
                    }
                }
                else if ((sender as PictureBox).ImageLocation == null)//Jeżeli najechane pole jest puste
                {
                    //[TODO]Skopiuj używaną broń na puste pole, i wyczyść pole broni
                }
                else//Jeżeli najechane pole jest pancerzem, tarczą, bądź czymś innym
                {
                    //Nie wymagana żadna akcja (w pole broni można wprowadzić tylko broń)
                }
            }
            else if ((e.Data.GetData(typeof(PictureBox)) as PictureBox).Name == "PictureBoxPancerz")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxPancerz
            {
                if ((sender as PictureBox).ImageLocation.Contains("pancerz"))//Jeżeli najechany przedmiot jest pancerzem
                {//Nie potrzeba więcej sprawdzeń, z PictureBoxPancerz można wynieść tylko pancerz
                    //[TODO]Zamień miejscami pancerz z plecaka z pancerzem założonym
                }
                else//Jeżeli najechany przedmiot najechany nie jest pancerzem
                {
                    //Nie wymagana akcja (nie można ubrać nic innego niż pancerz)
                }
            }
            else if ((e.Data.GetData(typeof(PictureBox)) as PictureBox).Name == "PictureBoxTarcza")//Jeżeli przenoszony przedmiot pochodzi z PictureBoxTarcza
            {
                if ((sender as PictureBox).ImageLocation.Contains("tarcza"))//Jeżeli najechany przedmiot jest tarczą
                {//Nie potrzeba więcej sprawdzeń, z PictureBoxTarcza można wynieść tylko tarczę
                    //[TODO]Zamień miejscami tarczę z plecaka z tarczą założoną
                }
                else//Jeżeli najechany przedmiot najechany nie jest tarczą
                {
                    //Nie wymagana akcja (nie można ubrać nic innego niż tarczę)
                }
            }
            else//Jeżeli przenoszony przedmiot pochodzi z plecaka
            {
                if ((sender as PictureBox).ImageLocation == null)//Jeżeli najechany przedmiot jest pustym polem
                {
                    //[TODO]Skopiuj przenoszony przedmiot w najechane pole, a pole przedmiotu wyczyść
                    Program.UstawObrazEkwipunku((sender as PictureBox), przenoszonyPrzedmiot.Obrazek);
                    (e.Data.GetData(typeof(PictureBox)) as PictureBox).Image = null;
                }
                else//Jeżeli najechany przedmiot nie jest pustym polem
                {
                    //[TODO]Zamień miejscami najechany przedmiot z przedmiotem przenoszonym
                }
            }

        }
        #endregion





        #region Akcje dla przedmiotów na miejscu broni
        void MouseDownPictureBoxBron(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pustych pól
            {
                int indexPrzedmiotuNadKtorymJestKursor = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor];
                }
                DoDragDrop(sender, DragDropEffects.Move);
                PanelOpisPrzedmiotu.Visible = false;
            }
        }

        private void DragEnterPictureBoxBron(object sender, DragEventArgs e)
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("bron"))//sprawdzenie, czy przenoszony przedmiot jest bronią
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxBron(object sender, DragEventArgs e)
        {
            if ((e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation.Contains("bron1h"))
            {
            }
            else if ((e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation.Contains("bron2h"))
            {
                if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))
                {
                }
                else
                {
                }
            }
        }
        #endregion



        #region Akcje dla przedmiotów na miejscu pancerza
        void MouseDownPictureBoxPancerz(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pustych pól
            {
                int indexPrzedmiotuNadKtorymJestKursor = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor];
                }
                DoDragDrop(sender, DragDropEffects.Move);
                PanelOpisPrzedmiotu.Visible = false;
            }
        }

        private void DragEnterPictureBoxPancerz(object sender, DragEventArgs e)
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("pancerz"))//sprawdzenie, czy przenoszony przedmiot jest pancerzem
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxPancerz(object sender, DragEventArgs e)
        {
        }
        #endregion



        #region Akcje dla przedmiotów na miejscu tarczy
        void MouseDownPictureBoxTarcza(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).ImageLocation != null)//Aby nie można przenosić pustych pól
            {
                int indexPrzedmiotuNadKtorymJestKursor = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor];
                }
                DoDragDrop(sender, DragDropEffects.Move);
                PanelOpisPrzedmiotu.Visible = false;
            }
        }

        private void DragEnterPictureBoxTarcza(object sender, DragEventArgs e)
        {
            if (przenoszonyPrzedmiot.Obrazek.Contains("tarcza"))//sprawdzenie, czy przenoszony przedmiot jest tarczą
            {
                e.Effect = DragDropEffects.Move;//Umożliwienie upuszczenia przedmiotów na najechanym polu
            }
        }

        private void DragDropPictureBoxTarcza(object sender, DragEventArgs e)
        {
        }
        #endregion









        private void Zegar_Tick(object sender, EventArgs e)
        {
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


        #region Przyciski do modyfikowania statystyk
        private void PictureBoxSilaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.SilaPodstawa > ekranGry.gra.gracz.SilaPodstawa)
            {
                tymczasowyBohater.SilaPodstawa--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxSilaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.SilaPodstawa++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxZrecznoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.ZrecznoscPodstawa > ekranGry.gra.gracz.ZrecznoscPodstawa)
            {
                tymczasowyBohater.ZrecznoscPodstawa--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxZrecznoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.ZrecznoscPodstawa++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxWitalnoscMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.WitalnoscPodstawa > ekranGry.gra.gracz.WitalnoscPodstawa)
            {
                tymczasowyBohater.WitalnoscPodstawa--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxWitalnoscPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.WitalnoscPodstawa++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }

        private void PictureBoxInteligencjaMinus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.InteligencjaPodstawa > ekranGry.gra.gracz.InteligencjaPodstawa)
            {
                tymczasowyBohater.InteligencjaPodstawa--;
                tymczasowyBohater.Punkty++;
            }
            OdswiezStatystyki();
        }

        private void PictureBoxInteligencjaPlus_Click(object sender, EventArgs e)
        {
            if (tymczasowyBohater.Punkty > 0)
            {
                tymczasowyBohater.InteligencjaPodstawa++;
                tymczasowyBohater.Punkty--;
                OdswiezStatystyki();
            }
        }
        #endregion

        #region Zamykanie forma
        private void PictureBoxPotwierdz_Click(object sender, EventArgs e)
        {
            ZapiszStatystykiDoGracza();
            Close();
        }

        private void EkranEkwipunek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zegar.Stop();
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
