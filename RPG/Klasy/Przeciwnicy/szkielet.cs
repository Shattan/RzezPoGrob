﻿using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Przeciwnicy
{
    public class szkielet : Przeciwnik
    {
        public override int Sila { get { return 2; } }
        public override int Zrecznosc { get { return 1; } }
        public override int Witalnosc { get { return 1; } }
        public override int Inteligencja { get { return 1; } }
        public override double Obrazenia { get { return 2; } }
        public override double Pancerz { get { return 1; } }
        public override double HP { get { return 1; } }
        public override double Energia { get { return 1; } }
        public override double SzansaNaTrafienie { get { return 10; } }
        public override double SzansaNaKrytyczne { get { return 5; } }

        public override string Nazwa
        {
            get { return "Szkielet"; }
        }

        public override string ObrazekWalki
        {
            get { return "Resources/Grafiki postaci walczących/szkielet.png"; }
        }

        public override string ObrazekNaMapie
        {
            get { return "Resources/Grafiki postaci walczących/szkielet.png"; }
        }

        public override List<Umiejetnosc> Umiejetnosci()
        {
            return new List<Umiejetnosc> { new Wymachiwanie() };
        }
    }
}
