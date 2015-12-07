using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy
{
    public abstract class ElementMapy
    {

        public abstract string ObrazekNaMapie { get; }
        public abstract void IntegracjaGracz(Gracz gracz, int x, int y, EkranGryObiektyTlo ekranGryObiektyTlo, EkranGry gra);

        
    }
}
