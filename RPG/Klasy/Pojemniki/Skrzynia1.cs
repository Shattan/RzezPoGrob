using RPG.Klasy.Ekwipunek.BronieJednoreczne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Pojemniki
{
    public class Skrzynia1 : PojemnikBaza
    {
        protected override List<RPG.Ekwipunek> Przedmioty
        {
            get { return new List<RPG.Ekwipunek> {new KrotkiMiecz() }; }
        }
        protected override int Zloto
        {
            get
            {
                return 200;
            }
        }
    }
}
