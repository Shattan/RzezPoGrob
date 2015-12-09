using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Obiekty
{
    public class ScianaPozioma:Przeszkoda
    {
        public override string ObrazekNaMapie
        {
            get { return "Resources/Grafiki przeszkód/L2_WallBrickN.png"; }
        }
    }
}
