using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gra
    {
        List<Zadanie> zadanie = new List<Zadanie>();
        List<Umiejetnosc> umiejetnosc = new List<Umiejetnosc>();
        List<Ekwipunek> ekwipunek = new List<Ekwipunek>();
        List<Przeszkoda> przeszkoda = new List<Przeszkoda>();
        List<List<Postac>> zestawPrzeciwnikow = new List<List<Postac>>();
        List<Postac> postacFabularna = new List<Postac>();
        List<Postac> postacZMiasta = new List<Postac>();
        List<Postac> postacZCmentarza = new List<Postac>();
        List<Postac> postacZDziczy = new List<Postac>();
        public Bohater bohater = new Bohater("Nazwa");
        

        public Gra()
        {
            //Tworzenie infrastruktury
            UtworzUmiejetnosci();
            UtworzPrzedmiotyEkwipunku();
            UtworzPostacie();
            UtworzPrzeszkody();
            UtworzZestawyPrzeciwnikow();
            UtworzZadania();
        }
        public void UtworzZadania()
        {
            //index 0
            zadanie.Add(new Zadanie
                (
                    "Głodne wilki dwa",
                    "Wieśniaczka Laura",
                    "Zabij wilki nieopodal strumienia",
                    "Niezapomniana noc z Laurą",
                    "No rusz się stary bydlaku, nie będziemy czekać wiecznie, aż wykonasz to zadanie!"
                ));
            //index 1
            zadanie.Add(new Zadanie
                (
                    "Na ratunek goblinom",
                    "Wódz Gubin",
                    "Przynieś wiadro wody do wioski goblinów",
                    "Gobliny przeżyją kolejny dzień",
                    "Wodę znajdziesz w strumieniu na wschód od wioski goblinów."
                ));
            //index 2
            zadanie.Add(new Zadanie
                (
                    "Były sobie ogry trzy",
                    "Rycerz Lancit",
                    "Pomóż rycerzowi w pokonaniu Ogrów",
                    "Rycerz będzie zadowolony",
                    "Uważaj na siebie! Ogry to trudni przeciwnicy."
                ));
            //index 3
            zadanie.Add(new Zadanie
                (
                    "Więcej! Trzeba więcej!",
                    "Starszy wioski Edward",
                    "Dostarcz do wioski 3 goblińskie miecze",
                    "Wioska będzie mogła przetrwać kolejne ataki szczurów",
                    "Gobliny znajdziesz na wschód od wioski."
                ));
        }
        public void UtworzPostacie()
        {
            //**************************************************************************************************************
            //Postacie fabularne
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

        public void UtworzUmiejetnosci()
        {
            //index 0
            umiejetnosc.Add(new Umiejetnosc("Wymachiwanie"));
        }

        public void UtworzPrzedmiotyEkwipunku()
        {
            //index 0
            ekwipunek.Add(new Ekwipunek("Cywilne ubranie"));
        }

        public void UtworzPrzeszkody()
        {
            //index 0
            przeszkoda.Add(new Przeszkoda("Drzewo"));
        }

        public void UtworzZestawyPrzeciwnikow()
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
