using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gra
    {
        public Bohater bohater = new Bohater();
        public List<Zadanie> listaZadan = new List<Zadanie>();
        public List<Ekwipunek> listaEkwipunek = new List<Ekwipunek>();
        public List<Strawa> listaStrawa = new List<Strawa>();

        public List<Umiejetnosc> listaUmiejetnosc = new List<Umiejetnosc>();
        public List<Przeszkoda> listaPrzeszkoda = new List<Przeszkoda>();
        public List<List<NPC>> listaZestawPrzeciwnikow = new List<List<NPC>>();
        public List<NPC> listaPostacFabularna = new List<NPC>();
        public List<NPC> listaPostacZMiasta = new List<NPC>();
        public List<NPC> listaPostacZCmentarza = new List<NPC>();
        public List<NPC> listaPostacZDziczy = new List<NPC>();
        

        public Gra()
        {
            //Tworzenie infrastruktury
            UtworzUmiejetnosci();
            UtworzEkwipunek();
            UtworzStrawy();
            UtworzPostacie();
            UtworzPrzeszkody();
            UtworzZestawyPrzeciwnikow();

            UtworzZadania();
        }

        public void DodajZadanie(string nazwa, string zleceniodawca, string cel, string nagroda, string opis)
        {
            listaZadan.Add(new Zadanie(nazwa, zleceniodawca, cel, nagroda, opis));
        }

        public Zadanie ZwrocZadanie(int ktore)
        {
            if ((ktore >= 0) && (ktore <= listaZadan.Count))
                return listaZadan[ktore];
            else return new Zadanie("BrakNazwy", "BrakZleceniodwacy", "BrakCelu", "BrakNagordy", "BrakOpisu");
        }

        public void UtworzZadania()
        {
            //index 0
            DodajZadanie
                (
                    "Głodne wilki dwa",
                    "Wieśniaczka Laura",
                    "Zabij wilki nieopodal strumienia",
                    "Niezapomniana noc z Laurą",
                    "No rusz się stary bydlaku, nie będziemy czekać wiecznie, aż wykonasz to zadanie!"
                );
            //index 1
            DodajZadanie
                (
                    "Na ratunek goblinom",
                    "Wódz Gubin",
                    "Przynieś wiadro wody do wioski goblinów",
                    "Gobliny przeżyją kolejny dzień",
                    "Wodę znajdziesz w strumieniu na wschód od wioski goblinów."
                );
            //index 2
            DodajZadanie
                (
                    "Były sobie ogry trzy",
                    "Rycerz Lancit",
                    "Pomóż rycerzowi w pokonaniu Ogrów",
                    "Rycerz będzie zadowolony",
                    "Uważaj na siebie! Ogry to trudni przeciwnicy."
                );
            //index 3
            DodajZadanie
                (
                    "Więcej! Trzeba więcej!",
                    "Starszy wioski Edward",
                    "Dostarcz do wioski 3 goblińskie miecze",
                    "Wioska będzie mogła przetrwać kolejne ataki szczurów",
                    "Gobliny znajdziesz na wschód od wioski."
                );
        }
        
        public void UtworzPostacie()
        {
            //**************************************************************************************************************
            //Postacie fabularne
            //index 0
            listaPostacFabularna.Add(new NPC("Lord Krwawy Mati", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 1
            listaPostacFabularna.Add(new NPC("Lord Seba", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //**************************************************************************************************************
            //index 0
            listaPostacZMiasta.Add(new NPC("Szczur", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));

            //**************************************************************************************************************
            //index 0
            listaPostacZCmentarza.Add(new NPC("Ghoul", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));

            //**************************************************************************************************************
            //index 0
            listaPostacZDziczy.Add(new NPC("Wilk", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));

        }

        public void UtworzUmiejetnosci()
        {
            //index 0
            listaUmiejetnosc.Add(new Umiejetnosc("Wymachiwanie"));
        }

        public void UtworzEkwipunek()
        {
            //index 0
            listaEkwipunek.Add(new Ekwipunek("Długi Miecz","Resources/Grafiki ekwipunku/bron2hDługiMiecz.PNG",10,10,10,10,10,10,10,10,10,10));
        }
        public void UtworzStrawy()
        {
            //index 0
            listaStrawa.Add(new Strawa("","",10,10));
        }

        public void UtworzPrzeszkody()
        {
            //index 0
            listaPrzeszkoda.Add(new Przeszkoda("Drzewo"));
        }

        public void UtworzZestawyPrzeciwnikow()
        {
            //index 0
            listaZestawPrzeciwnikow.Add(listaPostacFabularna);
            //index 1
            listaZestawPrzeciwnikow.Add(listaPostacZMiasta);
            //index 2
            listaZestawPrzeciwnikow.Add(listaPostacZCmentarza);
            //index 3
            listaZestawPrzeciwnikow.Add(listaPostacZDziczy);
        }
    

        //public List<Zadanie> ListaZadan
        //{
        //    get { return listaZadan; }
        //    set { listaZadan = value; }
        //}
        //
        //
        //public List<Umiejetnosc> ListaUmiejetnosc
        //{
        //    get { return listaUmiejetnosc; }
        //    set { listaUmiejetnosc = value; }
        //}
        //
        //public List<Ekwipunek> ListaEkwipunek
        //{
        //    get { return listaEkwipunek; }
        //    set { listaEkwipunek = value; }
        //}
        //
        //public List<Przeszkoda> ListaPrzeszkoda
        //{
        //    get { return listaPrzeszkoda; }
        //    set { listaPrzeszkoda = value; }
        //}
        //
        ////public List<Przeszkoda> ListaZestawPrzeciwnikow
        ////{
        ////    get { return listaZestawPrzeciwnikow; }
        ////    set { listaZestawPrzeciwnikow = value; }
        ////}
        //
        //public List<NPC> ListaPostacFabularna
        //{
        //    get { return listaPostacFabularna; }
        //    set { listaPostacFabularna = value; }
        //}
        //
        //public List<NPC> ListaPostacZMiasta
        //{
        //    get { return listaPostacZMiasta; }
        //    set { listaPostacZMiasta = value; }
        //}
        //
        //public List<NPC> ListaPostacZCmentarza
        //{
        //    get { return listaPostacZCmentarza; }
        //    set { listaPostacZCmentarza = value; }
        //}
        //
        //public List<NPC> ListaPostacZDziczy
        //{
        //    get { return listaPostacZDziczy; }
        //    set { listaPostacZDziczy = value; }
        //}
    }
}
