﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Obiekty
{
    class brickstone : Przeszkoda
    {
        public override string ObrazekNaMapie
        {
            get { return "Resources/Mapy/brickstone.png"; }
        }
    }
}