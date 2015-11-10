using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gra
    {
        //Wdrożone pola
        public Gracz gracz = new Gracz();
        public List<Zadanie> listaZadan = new List<Zadanie>();
        public List<Ekwipunek> listaPrzedmiotow = new List<Ekwipunek>();
        public List<Strawa> listaPozywieniaIMikstur = new List<Strawa>();
        public List<Umiejetnosc> listaUmiejetnosciFizycznych = new List<Umiejetnosc>();
        public List<Umiejetnosc> listaUmiejetnosciMagicznych = new List<Umiejetnosc>();
        public List<List<Przeciwnik>> listaZestawowPrzeciwnikow = new List<List<Przeciwnik>>();
        public List<Przeciwnik> listaPostaciFabularnych = new List<Przeciwnik>();
        public List<Przeciwnik> listaPostaciZMiasta = new List<Przeciwnik>();
        public List<Przeciwnik> listaPostaciZCmentarza = new List<Przeciwnik>();
        public List<Przeciwnik> listaPostaciZDziczy = new List<Przeciwnik>();

        //Jeszcze nie używane
        public List<Przeszkoda> listaPrzeszkod = new List<Przeszkoda>();
        
        //Konstruktor domyślny
        public Gra()
        {
            //Tworzenie infrastruktury
            UtworzListeZadan();
            UtworzListePrzedmiotow();
            UtworzListePozywieniaIMikstur();
            UtworzListyUmiejetnosci();
            UtworzListePrzeszkod();
            UtworzListyPostaci();
            UtworzZestawyPrzeciwnikow();
            UstawPoczatkowegoGracza();
        }

        //Konstruktor kopiujący
        public Gra(Gra kopiowanaGra)
        {
            this.gracz = kopiowanaGra.gracz;
            this.listaZadan = kopiowanaGra.listaZadan;
            this.listaPrzedmiotow = kopiowanaGra.listaPrzedmiotow;
            this.listaPozywieniaIMikstur = kopiowanaGra.listaPozywieniaIMikstur;
            this.listaUmiejetnosciFizycznych = kopiowanaGra.listaUmiejetnosciFizycznych;
            this.listaUmiejetnosciMagicznych = kopiowanaGra.listaUmiejetnosciMagicznych;
            this.listaPrzeszkod = kopiowanaGra.listaPrzeszkod;
            this.listaPostaciFabularnych = kopiowanaGra.listaPostaciFabularnych;
            this.listaPostaciZMiasta = kopiowanaGra.listaPostaciZMiasta;
            this.listaPostaciZCmentarza = kopiowanaGra.listaPostaciZCmentarza;
            this.listaPostaciZDziczy = kopiowanaGra.listaPostaciZDziczy;
            this.listaZestawowPrzeciwnikow = kopiowanaGra.listaZestawowPrzeciwnikow;
        }

        //Ustawienie statystyk, przedmiotow i zadan gracza na takie jakie ma miec na początku gry
        public void UstawPoczatkowegoGracza()
        {
            gracz = new Gracz(
                "Gracz",                                                                                     //Nazwa
                "Resources/Grafiki postaci na mapie/0/",                                                     //Obraz na mapie
                "Resources/Grafiki postaci mówiących/Mówca1.png",                                            //Obraz w trakcie rozmowy
                0,                                                                                           //Doświadczenie
                3000,                                                                                        //Złoto
                5,                                                                                           //Siła
                5,                                                                                           //Zręczność
                5,                                                                                           //Witalność
                5,                                                                                           //Inteligencja
                5,                                                                                           //Obrażenia
                5,                                                                                           //Pancerz
                10,                                                                                          //Punkty życia
                10,                                                                                          //Energia
                75,                                                                                          //Szansa na trafienie
                5,                                                                                           //Szansa na krytyczne
                listaPrzedmiotow[0],                                                                         //Broń
                listaPrzedmiotow[1],                                                                         //Pancerz
                listaPrzedmiotow[2],                                                                         //Tarcza
                new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] },    //Umiejętności fizyczne
                new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] },    //Umiejętności magiczne
                new List<Ekwipunek> {listaPrzedmiotow[5], listaPrzedmiotow[10] },                            //Przedmioty w plecaku
                new List<Zadanie> {listaZadan[0],listaZadan[1],listaZadan[2] },                              //Zadania
                new List<Strawa> {listaPozywieniaIMikstur[0],listaPozywieniaIMikstur[1] }                    //Jedzenie i mikstury
                );
        }

        //public void DodajZadanie(string nazwa, string zleceniodawca, string cel, string nagroda, string opis)
        //{
        //    listaZadan.Add(new Zadanie(nazwa, zleceniodawca, cel, nagroda, opis));
        //}
        //
        //public Zadanie ZwrocZadanie(int ktore)
        //{
        //    if ((ktore >= 0) && (ktore <= listaZadan.Count))
        //        return listaZadan[ktore];
        //    else return new Zadanie("BrakNazwy", "BrakZleceniodwacy", "BrakCelu", "BrakNagordy", "BrakOpisu");
        //}

        public void UtworzListeZadan()
        {
            //index 0
            listaZadan.Add(new Zadanie
                (
                    "Głodne wilki dwa",
                    "Wieśniaczka Laura",
                    "Zabij wilki nieopodal strumienia",
                    "Niezapomniana noc z Laurą",
                    "No rusz się stary bydlaku, nie będziemy czekać wiecznie, aż wykonasz to zadanie!"
                ));
            //index 1
            listaZadan.Add(new Zadanie
                (
                    "Na ratunek goblinom",
                    "Wódz Gubin",
                    "Przynieś wiadro wody do wioski goblinów",
                    "Gobliny przeżyją kolejny dzień",
                    "Wodę znajdziesz w strumieniu na wschód od wioski goblinów."
                ));
            //index 2
            listaZadan.Add(new Zadanie
                (
                    "Były sobie ogry trzy",
                    "Rycerz Lancit",
                    "Pomóż rycerzowi w pokonaniu Ogrów",
                    "Rycerz będzie zadowolony",
                    "Uważaj na siebie! Ogry to trudni przeciwnicy."
                ));
            //index 3
            listaZadan.Add(new Zadanie
                (
                    "Więcej! Trzeba więcej!",
                    "Starszy wioski Edward",
                    "Dostarcz do wioski 3 goblińskie miecze",
                    "Wioska będzie mogła przetrwać kolejne ataki szczurów",
                    "Gobliny znajdziesz na wschód od wioski."
                ));
        }


        public void UtworzZestawyPrzeciwnikow()
        {
            //index 0
            listaZestawowPrzeciwnikow.Add(listaPostaciFabularnych);
            //index 1
            listaZestawowPrzeciwnikow.Add(listaPostaciZMiasta);
            //index 2
            listaZestawowPrzeciwnikow.Add(listaPostaciZCmentarza);
            //index 3
            listaZestawowPrzeciwnikow.Add(listaPostaciZDziczy);
        }

        public void UtworzListyPostaci()
        {
            //**************************************************************************************************************
            //Postacie fabularne
            //index 0
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Krwawy Mati", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/argul.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 1
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Seba", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/cyklop.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 2
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Ezechiel Kaczor", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/czarna wdowa.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 3
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Dziwny Karol", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/ghoul.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 4
            listaPostaciFabularnych.Add(new Przeciwnik("Klucznik Piotr", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/glucznik.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 5
            listaPostaciFabularnych.Add(new Przeciwnik("Brzydki syn", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/goblin.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //**************************************************************************************************************
            //index 0
            listaPostaciZMiasta.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/goblinzabojca.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 1
            listaPostaciZMiasta.Add(new Przeciwnik("Bandyta łucznik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/golem.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 2
            listaPostaciZMiasta.Add(new Przeciwnik("Rabuś", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/gwojownik.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 3
            listaPostaciZMiasta.Add(new Przeciwnik("Psychopata", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/gzwiadowca.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 4
            listaPostaciZMiasta.Add(new Przeciwnik("Rozwścieczona wieśniaczka", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/hydra.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));


            //**************************************************************************************************************
            //index 0
            listaPostaciZCmentarza.Add(new Przeciwnik("Ghoul", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/scierwojad.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 1
            listaPostaciZCmentarza.Add(new Przeciwnik("Szkielet wojownik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szaman.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 2
            listaPostaciZCmentarza.Add(new Przeciwnik("Bardzo stary szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/poludnica.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 3
            listaPostaciZCmentarza.Add(new Przeciwnik("Lisz", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szczur.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 4
            listaPostaciZCmentarza.Add(new Przeciwnik("Wampir", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szkielet.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 6
            listaPostaciZCmentarza.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/topielec.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));

            //**************************************************************************************************************
            //index 0
            listaPostaciZDziczy.Add(new Przeciwnik("Wilk", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/waz.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 1
            listaPostaciZDziczy.Add(new Przeciwnik("Pajęczyca", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/wilk.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 2
            listaPostaciZDziczy.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/wilkolak.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 3
            listaPostaciZDziczy.Add(new Przeciwnik("Goblin wojownik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/zywiolak ognia.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 4
            listaPostaciZDziczy.Add(new Przeciwnik("Cyklop", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/zywiolak wody.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));
            //index 5
            listaPostaciZDziczy.Add(new Przeciwnik("Żywiołak wody", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szczur.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { listaUmiejetnosciFizycznych[0], listaUmiejetnosciFizycznych[1] }, new List<Umiejetnosc> { listaUmiejetnosciMagicznych[0], listaUmiejetnosciMagicznych[1] }));

        }

        public void UtworzListyUmiejetnosci()
        {
            //index 0
            listaUmiejetnosciFizycznych.Add(new Umiejetnosc("Wymachiwanie"));
            //index 1
            listaUmiejetnosciFizycznych.Add(new Umiejetnosc("Szarża"));
            //index 2
            listaUmiejetnosciFizycznych.Add(new Umiejetnosc("Pacnięcie"));


            //index 0
            listaUmiejetnosciMagicznych.Add(new Umiejetnosc("Kula ognia"));
            //index 1
            listaUmiejetnosciMagicznych.Add(new Umiejetnosc("Kula kwasu"));
            //index 2
            listaUmiejetnosciMagicznych.Add(new Umiejetnosc("Kula pustki"));
        }

        public void UtworzListePrzedmiotow()
        {
            //index 0
            listaPrzedmiotow.Add( new Ekwipunek("Nóż do masła","Resources/Grafiki ekwipunku/bron1hNóż do masła.png",1,1,0,0,1,0,0,0,0,0));
            //index 1
            listaPrzedmiotow.Add( new Ekwipunek("Stara tunika", "Resources/Grafiki ekwipunku/pancerzStara tunika.png", 0, 0, 1, 0, 0, 1, 5, 0, 0, 0));
            //index 2
            listaPrzedmiotow.Add( new Ekwipunek("Pochodnia", "Resources/Grafiki ekwipunku/tarczaPochodnia.png", 0, 0, 0, 1, 0, 0, 0, 5, 1, 0));
            //index 3
            listaPrzedmiotow.Add(new Ekwipunek("Długi Miecz", "Resources/Grafiki ekwipunku/bron2hDługiMiecz.PNG", 10, 10, 10, 10, 5, 10, 10, 2, 10, 10));
            //index 4
            listaPrzedmiotow.Add(new Ekwipunek("Kosa Powiew Śmierci", "Resources/Grafiki ekwipunku/bron2hKosaPowiewŚmierci.PNG", 5, 3, 3, 10, 5, 0, 10, 10, 10, 10));
            //index 5
            listaPrzedmiotow.Add(new Ekwipunek("Kostur Nowicjusza", "Resources/Grafiki ekwipunku/bron2hKosturNowicjusza.PNG", 10, 10, 10, 0, 4, 0, 10, 10, 10, 10));
            //index 6
            listaPrzedmiotow.Add(new Ekwipunek("Łuk Z Krain Południa", "Resources/Grafiki ekwipunku/bron2hŁukZKrainPołudnia.PNG", 10, 10, 10, 4, 11, 10, 10, 10, 10, 10));
            //index 7
            listaPrzedmiotow.Add(new Ekwipunek("Młot Bojowy", "Resources/Grafiki ekwipunku/bron2hMłotBojowy.PNG", 10, 10, 7, 4, 10, 10, 0, 10, 2, 10));
            //index 8
            listaPrzedmiotow.Add(new Ekwipunek("Topór Bojowy", "Resources/Grafiki ekwipunku/bron2hTopórBojowy.PNG", 10, 8, 0, 10, 6, 10, 0, 16, 10, 10));
            //index 9
            listaPrzedmiotow.Add(new Ekwipunek("Trójząb", "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG", 0, 10, 10, 0, 10, 6, 10, 7, 10, 7));
            //index 10
            listaPrzedmiotow.Add(new Ekwipunek("Duża Tarcza", "Resources/Grafiki ekwipunku/tarczaDużaTarcza.PNG", 0, 0, 0, 10, 7, 10, 10, 10, 10, 10));
            //index 11
            listaPrzedmiotow.Add(new Ekwipunek("Tarcza Króla", "Resources/Grafiki ekwipunku/tarczaTarczaKróla.PNG", 10, 10, 0, 10, 3, 10, 6, 10, 0, 10));
            //index 12
            listaPrzedmiotow.Add(new Ekwipunek("Sztylet Prosty", "Resources/Grafiki ekwipunku/bron1hSztyletProsty.PNG", 10, 6, 0, 10, 2, 10, 10, 5, 10, 10));
            //index 13
            listaPrzedmiotow.Add(new Ekwipunek("Sztylet Zabójcy", "Resources/Grafiki ekwipunku/bron1hSztyletZabójcy.PNG", 10, 10, 0, 3, 10, 10, 5, 10, 10, 7));
            //index 14
            listaPrzedmiotow.Add(new Ekwipunek("Szata Niebieskiego Maga", "Resources/Grafiki ekwipunku/pancerzSzataNiebieskiegoMaga.PNG", 10, 10, 0, 0, 0, 8, 10, 10, 10, 3));
            //index 15
            listaPrzedmiotow.Add(new Ekwipunek("Pancerz Cienia", "Resources/Grafiki ekwipunku/pancerzPancerzCienia.PNG", 10, 10, 10, 4, 10, 10, 8, 0, 0, 0));
        }

        public void UtworzListePozywieniaIMikstur()
        {
            //index 0
            listaPozywieniaIMikstur.Add(new Strawa("Świeży chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 10));
            //index 1
            listaPozywieniaIMikstur.Add(new Strawa("Suchy chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 0));
            //index 2
            listaPozywieniaIMikstur.Add(new Strawa("Stary chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 0, 10));
            //index 3
            listaPozywieniaIMikstur.Add(new Strawa("Czerstwy chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 5, 10));
            //index 4
            listaPozywieniaIMikstur.Add(new Strawa("Chrupiący chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 5));
            //index 5
            listaPozywieniaIMikstur.Add(new Strawa("Chleb z pleśnią", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 5, 5));
        }

        public void UtworzListePrzeszkod()
        {
            //index 0
            listaPrzeszkod.Add(new Przeszkoda("Drzewo"));
        }
    }
}
