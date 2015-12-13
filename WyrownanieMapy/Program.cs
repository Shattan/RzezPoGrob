using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyrownanieMapy
{
    class Program
    {
        static void Main(string[] args)
        {
            string sciezka = "../../../Rpg/Resources/obszary/mapa.txt";

            string wynik = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sciezka);
            string zawartosc = File.ReadAllText(wynik);
            string[] wiersze = zawartosc.ToLower().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int maksprzerwa = 0;
            for (int i = 1; i < wiersze.Length; i++)//pierwszy wiersz to zawiera wymary
            {
                int poczatek = wiersze[i].IndexOf('(');
                int koniec = wiersze[i].IndexOf(')', poczatek + 1);

                while (poczatek > -1 && koniec > -1)
                {
                    maksprzerwa = koniec - poczatek - 1;
                    poczatek = wiersze[i].IndexOf('(', koniec + 1);
                    koniec = wiersze[i].IndexOf(')', poczatek + 1);
                };
            }

            //int pos = zawartosc.IndexOf('(');
            //while (pos >= 0)
            //{
            //    int koniec = zawartosc.IndexOf(')', pos + 1);
            //    if (koniec < 0)
            //    {
            //        break;
            //    }
            //    string wpis = zawartosc.Substring(pos+1, koniec - pos - 1);
            //    pos = zawartosc.IndexOf('(', koniec + 1);
            //    int ostatniaspacja = wpis.las(x => !Char.IsWhiteSpace(x));
            //};


        }
    }
}
