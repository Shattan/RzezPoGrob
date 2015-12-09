using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Narzedzia
{
   public static class ManagerZadan
    {
       public static List<Zadanie> ListaZadan = new List<Zadanie>();
       static ManagerZadan()
       {
           UtworzListeZadan();

       }

       public static void UtworzListeZadan()
       {
           //index 0
           ListaZadan.Add(new Zadanie
               (
                   "Głodne wilki dwa",
                   "Wieśniaczka Laura",
                   "Zabij wilki nieopodal strumienia",
                   "Niezapomniana noc z Laurą",
                   "No rusz się stary bydlaku, nie będziemy czekać wiecznie, aż wykonasz to zadanie!"
               ));
           //index 1
           ListaZadan.Add(new Zadanie
               (
                   "Na ratunek goblinom",
                   "Wódz Gubin",
                   "Przynieś wiadro wody do wioski goblinów",
                   "Gobliny przeżyją kolejny dzień",
                   "Wodę znajdziesz w strumieniu na wschód od wioski goblinów."
               ));
           //index 2
           ListaZadan.Add(new Zadanie
               (
                   "Były sobie ogry trzy",
                   "Rycerz Lancit",
                   "Pomóż rycerzowi w pokonaniu Ogrów",
                   "Rycerz będzie zadowolony",
                   "Uważaj na siebie! Ogry to trudni przeciwnicy."
               ));
           //index 3
           ListaZadan.Add(new Zadanie
               (
                   "Więcej! Trzeba więcej!",
                   "Starszy wioski Edward",
                   "Dostarcz do wioski 3 goblińskie miecze",
                   "Wioska będzie mogła przetrwać kolejne ataki szczurów",
                   "Gobliny znajdziesz na wschód od wioski."
               ));
       }
    }
}
