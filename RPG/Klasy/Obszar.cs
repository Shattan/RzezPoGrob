using RPG.Klasy;
using RPG.Klasy.Obiekty;
using RPG.Klasy.Przeciwnicy;
using RPG.Narzedzia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Obszar
    {
        public string nazwa;
        ElementMapy[,] _mapa;
        public int Rozmiar = 54;
        private int[] _gracz;
        public ElementMapy[,] Mapa { get { return _mapa; } }
        public int[] PozycjaStartowaGracza { get { return _gracz; } }
        int _szerokosc, _wysokosc;
        public Obszar(string _nazwa,ElementMapy[,] mapa,int[]  gracz)
        {
            _szerokosc = mapa.GetLength(0);
            _wysokosc = mapa.GetLength(1);
            _mapa = mapa;
            nazwa = _nazwa;
            _gracz = gracz;
        }
    }
    public static class ManagerObszarow
    {
        private static Dictionary<String, Obszar> obszary = new Dictionary<string, Obszar>();
        private static Obszar Wczytaj(string nazwa)
        {
    string katalog ="Resources/Obszary/" + nazwa+".txt";

                String zawartoscPliku = File.ReadAllText(katalog);

                string[] wiersze = zawartoscPliku.ToLower().Split(new[] { Environment.NewLine },StringSplitOptions.None);
             string[]wymiary= wiersze[0].Split(new[]{" "},StringSplitOptions.RemoveEmptyEntries);
             int szerokosc = int.Parse(wymiary[0]);
             int wysokosc = int.Parse(wymiary[1]);
             int[] gracz=null;
             ElementMapy[,] mapa = new ElementMapy[szerokosc, wysokosc];
            for(int i=1;i<wiersze.Length;i++)//pierwszy wiersz to zawiera wymary
            {
                int poczatek = wiersze[i].IndexOf('(');
                int koniec = wiersze[i].IndexOf(')', poczatek+1);
                int j = 0;
                 while(poczatek>-1 && koniec>-1)
                 {
                     string zawartosc = wiersze[i].Substring(poczatek+1, koniec - poczatek-1).Trim();
                     ElementMapy el = null;
                     if (!string.IsNullOrEmpty(zawartosc))
                     {
                       
                         string[] element = zawartosc.Split(':');
                         if(element[0]=="przeciwnik")
                         {
                             el = StworzPrzeciwnika(element[1]);
                         }
                         else if(element[0]=="obiekt")
                         {
                             el = StworzObiekt(element[1]);
                         }
                         else if (element[0] == "npc")
                         {
                             el = StworzNpc(element[1]);
                         }
                         else if (element[0] == "gracz")
                         {
                             gracz = new[] { j, i };
                         }
                     }
                
                     poczatek = wiersze[i].IndexOf('(',koniec+1);
                     koniec = wiersze[i].IndexOf(')', poczatek + 1);
                     mapa[j,i]=el;
                     j++;
                 };
            }
            return new Obszar(nazwa,mapa,gracz);
        }
        public static Obszar WczytajObszar(string nazwaObszaru)
        {
            if (!obszary.ContainsKey(nazwaObszaru))
            {
                obszary[nazwaObszaru] = Wczytaj(nazwaObszaru);
            }
            return obszary[nazwaObszaru];
        }
        private static Dictionary<string, Type> przeszkody = new Dictionary<string, Type>();
        private static Dictionary<string, Type> postacie = new Dictionary<string, Type>();
        private static Dictionary<string, Type> przeciwnicy = new Dictionary<string, Type>();
        static ManagerObszarow()
        {
            przeszkody = Assembly.GetExecutingAssembly().GetTypes().Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(Przeszkoda))).ToDictionary(x => x.Name.ToLower(), x => x);//Pobieramy wszystkie klasy dziedziczące po klasie Przeszkoda
            postacie = Assembly.GetExecutingAssembly().GetTypes().Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(NPC))).ToDictionary(x => x.Name.ToLower(), x => x);//Pobieramy wszystkie klasy dziedziczące po klasie NPC
            przeciwnicy = Assembly.GetExecutingAssembly().GetTypes().Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(Przeciwnik))).ToDictionary(x => x.Name.ToLower(), x => x);//Pobieramy wszystkie klasy dziedziczące po klasie Przeciwnik
        }
        private static ElementMapy StworzObiekt(string p)
        {
            return (ElementMapy)Activator.CreateInstance(przeszkody[p]);
        }

        private static ElementMapy StworzPrzeciwnika(string p)
        {
            return (ElementMapy)Activator.CreateInstance(przeciwnicy[p]);
        }
        private static ElementMapy StworzNpc(string p)
        {
            return (ElementMapy)Activator.CreateInstance(postacie[p]);
        }
    }
}
