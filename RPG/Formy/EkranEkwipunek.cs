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

        #region Funkcje odświeżające okienka z informacjami i ekwipunek
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

            int oblicz = 0;
            LabelPorownanieStatystyk.Text = "\n";
            LabelPorownanieStatystyk.Text += "\n";
            oblicz = zakladanyPrzedmiot.Sila - zalozonyPrzedmiot.Sila;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Zrecznosc - zalozonyPrzedmiot.Zrecznosc;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Witalnosc - zalozonyPrzedmiot.Witalnosc;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Inteligencja - zalozonyPrzedmiot.Inteligencja;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Obrazenia - zalozonyPrzedmiot.Obrazenia;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Pancerz - zalozonyPrzedmiot.Pancerz;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.HP - zalozonyPrzedmiot.HP;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.Energia - zalozonyPrzedmiot.Energia;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.SzansaNaTrafienie - zalozonyPrzedmiot.SzansaNaTrafienie;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanyPrzedmiot.SzansaNaKrytyczne - zalozonyPrzedmiot.SzansaNaKrytyczne;
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

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


            int oblicz = 0;
            LabelPorownanieStatystyk.Text = "\n";
            LabelPorownanieStatystyk.Text += "\n";
            oblicz = zakladanaBron2h.Sila - (zalozonaBron.Sila + zalozonaTarcza.Sila);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Zrecznosc - (zalozonaBron.Zrecznosc + zalozonaTarcza.Zrecznosc);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Witalnosc - (zalozonaBron.Witalnosc + zalozonaTarcza.Witalnosc);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Inteligencja - (zalozonaBron.Inteligencja + zalozonaTarcza.Inteligencja);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Obrazenia - (zalozonaBron.Obrazenia + zalozonaTarcza.Obrazenia);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Pancerz - (zalozonaBron.Pancerz + zalozonaTarcza.Pancerz);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";
            
            oblicz = zakladanaBron2h.HP - (zalozonaBron.HP + zalozonaTarcza.HP);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.Energia - (zalozonaBron.Energia + zalozonaTarcza.Energia);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.SzansaNaTrafienie - (zalozonaBron.SzansaNaTrafienie + zalozonaTarcza.SzansaNaTrafienie);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

            oblicz = zakladanaBron2h.SzansaNaKrytyczne - (zalozonaBron.SzansaNaKrytyczne + zalozonaTarcza.SzansaNaKrytyczne);
            if (oblicz == 0)
                LabelPorownanieStatystyk.Text += "\n";
            else if (oblicz < 0)
                LabelPorownanieStatystyk.Text += oblicz + "\n";
            else
                LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";
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


            if (zakladanyPrzedmiot.Obrazek.Contains("tarcza") && tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))
            {
                //Wersja dla gracza z dwuręczną bronią próbującego założyć tarczę
                int oblicz = 0;
                LabelPorownanieStatystyk.Text = "\n";
                LabelPorownanieStatystyk.Text += "\n";
                oblicz = zakladanyPrzedmiot.Sila - tymczasowyBohater.ZalozonaBron.Sila;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Zrecznosc - tymczasowyBohater.ZalozonaBron.Zrecznosc;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Witalnosc - tymczasowyBohater.ZalozonaBron.Witalnosc;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Inteligencja - tymczasowyBohater.ZalozonaBron.Inteligencja;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Obrazenia - tymczasowyBohater.ZalozonaBron.Obrazenia;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Pancerz - tymczasowyBohater.ZalozonaBron.Pancerz;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.HP - tymczasowyBohater.ZalozonaBron.HP;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.Energia - tymczasowyBohater.ZalozonaBron.Energia;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.SzansaNaTrafienie - tymczasowyBohater.ZalozonaBron.SzansaNaTrafienie;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";

                oblicz = zakladanyPrzedmiot.SzansaNaKrytyczne - tymczasowyBohater.ZalozonaBron.SzansaNaKrytyczne;
                if (oblicz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (oblicz < 0)
                    LabelPorownanieStatystyk.Text += oblicz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + oblicz + "\n";
            }
            else
            {
                LabelPorownanieStatystyk.Text = "\n";
                LabelPorownanieStatystyk.Text += "\n";

                if (zakladanyPrzedmiot.Sila == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Sila < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Sila + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Sila + "\n";

                if (zakladanyPrzedmiot.Zrecznosc == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Zrecznosc < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Zrecznosc + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Zrecznosc + "\n";

                if (zakladanyPrzedmiot.Witalnosc == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Witalnosc < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Witalnosc + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Witalnosc + "\n";

                if (zakladanyPrzedmiot.Inteligencja == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Inteligencja < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Inteligencja + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Inteligencja + "\n";

                if (zakladanyPrzedmiot.Obrazenia == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Obrazenia < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Obrazenia + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Obrazenia + "\n";

                if (zakladanyPrzedmiot.Pancerz == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Pancerz < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Pancerz + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Pancerz + "\n";

                if (zakladanyPrzedmiot.HP == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.HP < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.HP + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.HP + "\n";

                if (zakladanyPrzedmiot.Energia == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.Energia < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.Energia + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.Energia + "\n";

                if (zakladanyPrzedmiot.SzansaNaTrafienie == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.SzansaNaTrafienie < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.SzansaNaTrafienie + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.SzansaNaTrafienie + "\n";

                if (zakladanyPrzedmiot.SzansaNaKrytyczne == 0)
                    LabelPorownanieStatystyk.Text += "\n";
                else if (zakladanyPrzedmiot.SzansaNaKrytyczne < 0)
                    LabelPorownanieStatystyk.Text += zakladanyPrzedmiot.SzansaNaKrytyczne + "\n";
                else
                    LabelPorownanieStatystyk.Text += "+" + zakladanyPrzedmiot.SzansaNaKrytyczne + "\n";
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




        #region Zdarzenia

        //Aby dostać się do przedmiotu przenoszonego:
        //(e.Data.GetData(typeof(PictureBox)) as PictureBox).Name
        //Aby dostać się do przedmiotu, na którym aktualnie jest Drag and Drop
        //(sender as PictureBox).Name

        void MouseEnterKazdyPrzedmiot(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Left && (sender as PictureBox).ImageLocation!=null)
            {
                int indexPrzedmiotuNadKtorymJestKursor = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)
                {
                    OdswiezInformacjeOPrzedmiocie(ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor]);
                }

                przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor];
                if (przenoszonyPrzedmiot.Obrazek.Contains("bron1h"))
                {
                    if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron1h"))
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot);
                    }
                    else
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("bron2h"))
                {
                    if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot);
                    }
                    else if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron1h"))
                    {
                        if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, tymczasowyBohater.ZalozonaTarcza, przenoszonyPrzedmiot);
                        }
                        else
                        {
                            OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaBron, przenoszonyPrzedmiot);
                        }
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("pancerz"))
                {
                    if (tymczasowyBohater.ZalozonyPancerz.Obrazek.Contains("pancerz"))
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonyPancerz, przenoszonyPrzedmiot);
                    }
                    else
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);
                    }
                }
                else if (przenoszonyPrzedmiot.Obrazek.Contains("tarcza"))
                {
                    if (tymczasowyBohater.ZalozonaTarcza.Obrazek.Contains("tarcza"))
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(tymczasowyBohater.ZalozonaTarcza, przenoszonyPrzedmiot);
                    }
                    else if (tymczasowyBohater.ZalozonaBron.Obrazek.Contains("bron2h"))
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);
                    }
                    else
                    {
                        OdswiezStatystykiZPorownaniemPrzedmiotow(przenoszonyPrzedmiot);
                    }
                }

                PanelOpisPrzedmiotu.Visible = true;
            }
        }
        void MouseLeaveKazdyPrzedmiot(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Left)
            {
                PanelOpisPrzedmiotu.Visible = false;
                OdswiezStatystyki();
            }
        }

        void MouseDownPrzedmiotWPlecaku(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).ImageLocation != null)
            {
                PanelOpisPrzedmiotu.Visible = true;
                int indexPrzedmiotuNadKtorymJestKursor = ekranGry.gra.listaPrzedmiotow.FindIndex(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));
                if (indexPrzedmiotuNadKtorymJestKursor >= 0)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow[indexPrzedmiotuNadKtorymJestKursor];
                    OdswiezInformacjeOPrzedmiocie(przenoszonyPrzedmiot);
                }
                DoDragDrop(sender, DragDropEffects.Move);
                PanelOpisPrzedmiotu.Visible = false;
            }
        }

        private void DragEnterPrzedmiotWPlecaku(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DragDropPrzedmiotWPlecaku(object sender, DragEventArgs e)
        {
            if (MouseButtons != System.Windows.Forms.MouseButtons.Left)
            {
                if ((sender as PictureBox) != null)
                {
                    przenoszonyPrzedmiot = ekranGry.gra.listaPrzedmiotow.Find(x => x.Obrazek.Equals((sender as PictureBox).ImageLocation));

                    (sender as PictureBox).ImageLocation = (e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation;
                    (sender as PictureBox).Image = (e.Data.GetData(typeof(PictureBox)) as PictureBox).Image;

                    if ((sender as PictureBox).ImageLocation != null)
                    {
                        (e.Data.GetData(typeof(PictureBox)) as PictureBox).ImageLocation = przenoszonyPrzedmiot.Obrazek;
                        Program.UstawObrazEkwipunku((e.Data.GetData(typeof(PictureBox)) as PictureBox), przenoszonyPrzedmiot.Obrazek);
                    }
                }
            }
        }




        void MouseDownPictureBoxBron(object sender, MouseEventArgs e)
        {
        }
        private void DragEnterPictureBoxBron(object sender, DragEventArgs e)
        {
        }
        private void DragDropPictureBoxBron(object sender, DragEventArgs e)
        {
        }
        




        void MouseDownPictureBoxTarcza(object sender, MouseEventArgs e)
        {
        }
        private void DragEnterPictureBoxTarcza(object sender, DragEventArgs e)
        {
        }
        private void DragDropPictureBoxTarcza(object sender, DragEventArgs e)
        {
        }



        void MouseDownPictureBoxPancerz(object sender, MouseEventArgs e)
        {
        }
        private void DragEnterPictureBoxPancerz(object sender, DragEventArgs e)
        {
        }
        private void DragDropPictureBoxPancerz(object sender, DragEventArgs e)
        {
        }



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
