using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{

    partial class GlownyEkran
    {
        #region Zmienne i obiekty globalne
        //zmienne z wartością

        //listy
        List<Postac> postac = new List<Postac>();
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();

        //zmienne sterujące

        #endregion

        #region Funkcje
        void UtworzPostacie()
        {
            postac.Add(new Postac("Lord Krwawy Mati"));                     //index 0
            postac.Add(new Postac("Lord Seba"));                            //index 1
        }

        void UtworzUmiejetnosci()
        {
            umiejetnosc.Add(new Umiejetnosc("Wymachiwanie"));               //index 0
        }

        void UtworzPrzedmiotyEkwipunku()
        {
            ekwipunek.Add(new Ekwipunek("Cywilne ubranie"));                //index 0
        }

        void UtworzPrzeszkody()
        {
            przeszkoda.Add(new Przeszkoda("Drzewo"));                       //index 0
        }
        #endregion

    }
}
