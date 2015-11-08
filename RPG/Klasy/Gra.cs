using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gra
    {
        public Gracz gracz = new Gracz();

        public List<Zadanie> listaZadan = new List<Zadanie>();
        public List<Ekwipunek> listaPrzedmiotow = new List<Ekwipunek>();
        public List<Strawa> listaPozywieniaIMikstur = new List<Strawa>();
        public List<Umiejetnosc> listaUmiejetnosciFizycznych = new List<Umiejetnosc>();
        public List<Umiejetnosc> listaUmiejetnosciMagicznych = new List<Umiejetnosc>();

        public List<Przeszkoda> listaPrzeszkod = new List<Przeszkoda>();
        public List<NPC> listaPostaciFabularnych = new List<NPC>();
        public List<NPC> listaPostaciZMiasta = new List<NPC>();
        public List<NPC> listaPostaciZCmentarza = new List<NPC>();
        public List<NPC> listaPostaciZDziczy = new List<NPC>();
        public List<List<NPC>> listaZestawowPrzeciwnikow = new List<List<NPC>>();
        

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

        //Ustawienie statystyk, przedmiotow i zadan gracza na takie jakie ma miec na początku gry
        public void UstawPoczatkowegoGracza()
        {
            gracz.SilaPodstawa=5;
            gracz.ZrecznoscPodstawa=5;
            gracz.WitalnoscPodstawa=5;
            gracz.InteligencjaPodstawa=5;
            gracz.ObrazeniaPodstawa=5;
            gracz.PancerzPodstawa=5;
            gracz.HPPodstawa=5;
            gracz.EnergiaPodstawa=5;
            gracz.SzansaNaTrafieniePodstawa=75;
            gracz.SzansaNaKrytycznePodstawa=5;

            gracz.ZalozonaBron = listaPrzedmiotow[0];
            gracz.ZalozonyPancerz = listaPrzedmiotow[1];
            gracz.ZalozonaTarcza = listaPrzedmiotow[2];

            gracz.Plecak.Add(listaPrzedmiotow[0]);
            gracz.Plecak.Add(listaPrzedmiotow[1]);
            gracz.Plecak.Add(listaPrzedmiotow[2]);
            gracz.Plecak.Add(listaPrzedmiotow[4]);
            gracz.Plecak.Add(listaPrzedmiotow[5]);
            gracz.Plecak.Add(listaPrzedmiotow[6]);
            gracz.Plecak.Add(listaPrzedmiotow[1]);
            gracz.Plecak.Add(listaPrzedmiotow[2]);
            gracz.Plecak.Add(listaPrzedmiotow[3]);
            gracz.Plecak.Add(listaPrzedmiotow[4]);
            gracz.Plecak.Add(listaPrzedmiotow[5]);
            gracz.Plecak.Add(listaPrzedmiotow[6]);
            gracz.Plecak.Add(listaPrzedmiotow[7]);
            gracz.Plecak.Add(listaPrzedmiotow[8]);
            gracz.Plecak.Add(listaPrzedmiotow[9]);
            gracz.Plecak.Add(listaPrzedmiotow[10]);
            gracz.Plecak.Add(listaPrzedmiotow[11]);
            gracz.Plecak.Add(listaPrzedmiotow[12]);
            gracz.Plecak.Add(listaPrzedmiotow[13]);
            gracz.Plecak.Add(listaPrzedmiotow[14]);
            gracz.Plecak.Add(listaPrzedmiotow[15]);
            gracz.Plecak.Add(listaPrzedmiotow[0]);
            gracz.Plecak.Add(listaPrzedmiotow[1]);
            gracz.Plecak.Add(listaPrzedmiotow[2]);
            gracz.Plecak.Add(listaPrzedmiotow[4]);
            gracz.Plecak.Add(listaPrzedmiotow[5]);
            gracz.Plecak.Add(listaPrzedmiotow[6]);
            gracz.Plecak.Add(listaPrzedmiotow[1]);
            gracz.Plecak.Add(listaPrzedmiotow[2]);
            gracz.Plecak.Add(listaPrzedmiotow[9]);
            gracz.Plecak.Add(listaPrzedmiotow[10]);
            gracz.Plecak.Add(listaPrzedmiotow[11]);
            gracz.Plecak.Add(listaPrzedmiotow[6]);
            gracz.Plecak.Add(listaPrzedmiotow[7]);
            gracz.Plecak.Add(listaPrzedmiotow[12]);
            gracz.Plecak.Add(listaPrzedmiotow[3]);
            gracz.Plecak.Add(listaPrzedmiotow[4]);
            gracz.Plecak.Add(listaPrzedmiotow[5]);
            gracz.Plecak.Add(listaPrzedmiotow[8]);
            gracz.Plecak.Add(listaPrzedmiotow[13]);
            gracz.Plecak.Add(listaPrzedmiotow[14]);
            gracz.Plecak.Add(listaPrzedmiotow[15]);

            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[0]);
            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[1]);
            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[2]);
            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[3]);
            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[4]);
            gracz.MiksturyIPozywienie.Add(listaPozywieniaIMikstur[5]);

            gracz.Zadania.Add(listaZadan[0]);
            gracz.Zadania.Add(listaZadan[1]);
            gracz.Zadania.Add(listaZadan[2]);
            gracz.Zadania.Add(listaZadan[3]);
            gracz.Zadania.Add(listaZadan[2]);
            gracz.Zadania.Add(listaZadan[1]);
            gracz.Zadania.Add(listaZadan[0]);
            gracz.Zadania.Add(listaZadan[2]);
            gracz.Zadania.Add(listaZadan[2]);
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
            listaPostaciFabularnych.Add(new NPC("Lord Krwawy Mati", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 1
            listaPostaciFabularnych.Add(new NPC("Lord Seba", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 2
            listaPostaciFabularnych.Add(new NPC("Lord Ezechiel Kaczor", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 3
            listaPostaciFabularnych.Add(new NPC("Lord Dziwny Karol", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 4
            listaPostaciFabularnych.Add(new NPC("Klucznik Piotr", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 5
            listaPostaciFabularnych.Add(new NPC("Brzydki syn", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //**************************************************************************************************************
            //index 0
            listaPostaciZMiasta.Add(new NPC("Szczur", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 1
            listaPostaciZMiasta.Add(new NPC("Bandyta łucznik", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 2
            listaPostaciZMiasta.Add(new NPC("Rabuś", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 3
            listaPostaciZMiasta.Add(new NPC("Psychopata", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 4
            listaPostaciZMiasta.Add(new NPC("Rozwścieczona wieśniaczka", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));


            //**************************************************************************************************************
            //index 0
            listaPostaciZCmentarza.Add(new NPC("Ghoul", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 1
            listaPostaciZCmentarza.Add(new NPC("Szkielet wojownik", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 2
            listaPostaciZCmentarza.Add(new NPC("Bardzo stary szczur", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 3
            listaPostaciZCmentarza.Add(new NPC("Lisz", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 4
            listaPostaciZCmentarza.Add(new NPC("Wampir", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 6
            listaPostaciZCmentarza.Add(new NPC("Szczur", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));

            //**************************************************************************************************************
            //index 0
            listaPostaciZDziczy.Add(new NPC("Wilk", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 1
            listaPostaciZDziczy.Add(new NPC("Pajęczyca", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 2
            listaPostaciZDziczy.Add(new NPC("Szczur", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 3
            listaPostaciZDziczy.Add(new NPC("Goblin wojownik", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 4
            listaPostaciZDziczy.Add(new NPC("Cyklop", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));
            //index 5
            listaPostaciZDziczy.Add(new NPC("Żywiołak wody", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", "Resources/Grafiki postaci mówiących/Mowca1.png", 10, 10, 10, 10, 10, 10, 10, 10, 10, 10));

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
