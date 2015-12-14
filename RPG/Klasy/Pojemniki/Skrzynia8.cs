using RPG.Klasy.Ekwipunek.BronieJednoreczne;
using RPG.Klasy.Ekwipunek.Zywnosc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Pojemniki
{
    public class Skrzynia8 : PojemnikBaza
    {
        protected override List<RPG.Ekwipunek> Przedmioty
        {
            get { return new List<RPG.Ekwipunek>() {new SwiezyChleb() }; }
        }
        protected override int Zloto
        {
            get
            {
                return 10;
            }
        }
    }
}
