﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Obiekty
{
    public class domek : Przeszkoda
    {
        public override string ObrazekNaMapie
        {
            get { return "Resources/Mapy/domek.png"; }
        }
    }
}


