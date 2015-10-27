using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Gra
    {
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();
        List<List<Postac>> zestawPrzeciwnikow = new List<List<Postac>>();
        List<Postac> postacFabularna = new List<Postac>();
        List<Postac> postacZMiasta = new List<Postac>();
        List<Postac> postacZCmentarza = new List<Postac>();
        List<Postac> postacZDziczy = new List<Postac>();

        public Gra()
        {
            //Tworzenie infrastruktury
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();
            UtworzZestawyPrzeciwnikow();
        }

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
    }
}
