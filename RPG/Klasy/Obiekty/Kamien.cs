using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Obiekty
{
    public class Kamien:Przeszkoda
    {
        public override string ObrazekNaMapie
        {
            get { return "Resources/Grafiki przeszkód/l2_terrain066.png"; }
        }
    }
}
