using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Zadanie
    {
        public string Nazwa { get; set; }
        public string Zleceniodawca { get; set; }
        public string Cel { get; set; }
        public string Nagroda { get; set; }
        public string Opis { get; set; } 

        public Zadanie(string nazwa, string zleceniodawca, string cel, string nagroda, string opis)
        {
            Nazwa = nazwa;
            Zleceniodawca = zleceniodawca;
            Cel = cel;
            Nagroda = nagroda;
            Opis = opis;
        }

        public Zadanie(Zadanie kopiowaneZadanie)
        {
            this.Nazwa = kopiowaneZadanie.Nazwa;
            this.Zleceniodawca = kopiowaneZadanie.Zleceniodawca;
            this.Cel = kopiowaneZadanie.Cel;
            this.Nagroda = kopiowaneZadanie.Nagroda;
            this.Opis = kopiowaneZadanie.Opis;
        }
    }
}
