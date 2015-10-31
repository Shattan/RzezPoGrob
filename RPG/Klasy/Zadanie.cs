using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Zadanie
    {
        public string nazwa;
        public string zleceniodawca;
        public string cel;
        public string nagroda;
        public string opis;

        public Zadanie(string _nazwa, string _zleceniodawca, string _cel, string _nagroda, string _opis)
        {
            nazwa = _nazwa;
            zleceniodawca = _zleceniodawca;
            cel = _cel;
            nagroda = _nagroda;
            opis = _opis;
        }
    }
}
