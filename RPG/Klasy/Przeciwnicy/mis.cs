using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Przeciwnicy
{
    public class mis : Przeciwnik
    {
        public override int Sila { get { return 15; } }
        public override int Zrecznosc { get { return 2; } }
        public override int Witalnosc { get { return 20; } }
        public override int Inteligencja { get { return 2; } }
        public override double Obrazenia { get { return 9; } }
        public override double Pancerz { get { return 3; } }
        public override double HP { get { return 10; } }
        public override double Energia { get { return 30; } }
        public override double SzansaNaTrafienie { get { return 10; } }
        public override double SzansaNaKrytyczne { get { return 5; } }

        public override string Nazwa
        {
            get { return "mis"; }
        }

        public override string ObrazekWalki
        {
            get { return "Resources/Grafiki postaci walczących/mis.png"; }
        }

        public override string ObrazekNaMapie
        {
            get { return "Resources/Grafiki postaci walczących/mis.png"; }
        }

        public override List<Umiejetnosc> Umiejetnosci()
        {
            return new List<Umiejetnosc> { new Wymachiwanie() };
        }
    }
}

