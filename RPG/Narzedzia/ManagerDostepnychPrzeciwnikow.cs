using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Narzedzia
{
    public static class ManagerDostepnychPrzeciwnikow
    {
        public static  List<Przeciwnik> listaPostaciFabularnych = new List<Przeciwnik>();
        public static List<Przeciwnik> listaPostaciZMiasta = new List<Przeciwnik>();
        public static List<Przeciwnik> listaPostaciZCmentarza = new List<Przeciwnik>();
        public static List<Przeciwnik> listaPostaciZDziczy = new List<Przeciwnik>();
        public static List<List<Przeciwnik>> listaZestawowPrzeciwnikow = new List<List<Przeciwnik>>();
        static Random losowanie = new Random();
        static ManagerDostepnychPrzeciwnikow()
        {
            UtworzListyPostaci();
            //index 0
            listaZestawowPrzeciwnikow.Add(listaPostaciFabularnych);
            //index 1
            listaZestawowPrzeciwnikow.Add(listaPostaciZMiasta);
            //index 2
            listaZestawowPrzeciwnikow.Add(listaPostaciZCmentarza);
            //index 3
            listaZestawowPrzeciwnikow.Add(listaPostaciZDziczy);

           
        }

        public static void UtworzListyPostaci()
        {
            //**************************************************************************************************************
            //Postacie fabularne
            //index 0
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Krwawy Mati", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/argul.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(),new KulaOgnia(),new Trucizna() }));
            //index 1
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Seba", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/cyklop.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(),  new Trucizna() }));
            //index 2
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Ezechiel Kaczor", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/czarna wdowa.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(), new KulaOgnia(), new Trucizna() }));
            //index 3
            listaPostaciFabularnych.Add(new Przeciwnik("Lord Dziwny Karol", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/ghoul.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(), new KulaOgnia(), new Trucizna() }));
            //index 4
            listaPostaciFabularnych.Add(new Przeciwnik("Klucznik Piotr", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/glucznik.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(), new KulaOgnia(), new Trucizna() }));
            //index 5
            listaPostaciFabularnych.Add(new Przeciwnik("Brzydki syn", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/goblin.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie()}));
            //**************************************************************************************************************
            //index 0
            listaPostaciZMiasta.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/goblinzabojca.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 1
            listaPostaciZMiasta.Add(new Przeciwnik("Bandyta łucznik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/golem.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(),new SzybkiStrzal()}));
            //index 2
            listaPostaciZMiasta.Add(new Przeciwnik("Rabuś", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/gwojownik.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie(),new SzybkiStrzal()}));
            //index 3
            listaPostaciZMiasta.Add(new Przeciwnik("Psychopata", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/gzwiadowca.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(),new SzybkiStrzal(),new KulaOgnia()}));
            //index 4
            listaPostaciZMiasta.Add(new Przeciwnik("Rozwścieczona wieśniaczka", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/hydra.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));


            //**************************************************************************************************************
            //index 0
            listaPostaciZCmentarza.Add(new Przeciwnik("Ghoul", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/scierwojad.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 1
            listaPostaciZCmentarza.Add(new Przeciwnik("Szkielet wojownik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szaman.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 2
            listaPostaciZCmentarza.Add(new Przeciwnik("Bardzo stary szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/poludnica.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 3
            listaPostaciZCmentarza.Add(new Przeciwnik("Lisz", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szczur.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie(),new KulaOgnia(),new Trucizna()}));
            //index 4
            listaPostaciZCmentarza.Add(new Przeciwnik("Wampir", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szkielet.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie(),new KulaOgnia()}));
            //index 6
            listaPostaciZCmentarza.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/topielec.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie()}));

            //**************************************************************************************************************
            //index 0
            listaPostaciZDziczy.Add(new Przeciwnik("Wilk", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/waz.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 1
            listaPostaciZDziczy.Add(new Przeciwnik("Pajęczyca", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/wilk.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie(),new Trucizna()}));
            //index 2
            listaPostaciZDziczy.Add(new Przeciwnik("Szczur", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/wilkolak.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 3
            listaPostaciZDziczy.Add(new Przeciwnik("Goblin wojownik", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/zywiolak ognia.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 4
            listaPostaciZDziczy.Add(new Przeciwnik("Cyklop", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/zywiolak wody.png", 
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10,new List<Umiejetnosc> { new Wymachiwanie()}));
            //index 5
            listaPostaciZDziczy.Add(new Przeciwnik("Żywiołak wody", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci mówiących/Mówca1.png", "Resources/Grafiki postaci walczących/szczur.png",
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, new List<Umiejetnosc> { new KulaOgnia(),new Trucizna()}));

        }
        public static Przeciwnik LosujPrzeciwnika()
        {
            int numerZestawu = losowanie.Next(0, listaZestawowPrzeciwnikow.Count);
           return LosujPrzeciwnika(numerZestawu);
        }
           public static Przeciwnik LosujPrzeciwnika(int numerZestawu)
        {
            int numerPotwora = losowanie.Next(0,listaZestawowPrzeciwnikow[numerZestawu].Count);
            return listaZestawowPrzeciwnikow[numerZestawu][numerPotwora];
        }
    }
}
