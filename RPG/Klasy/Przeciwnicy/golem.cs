using RPG.Klasy.Umiejetnosci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Przeciwnicy
{
    public class golem : Przeciwnik
    {
        public override int Sila { get { return 15; } }
        public override int Zrecznosc { get { return 3; } }
        public override int Witalnosc { get { return 15; } }
        public override int Inteligencja { get { return 1; } }
        public override double Obrazenia { get { return 4; } }
        public override double Pancerz { get { return 5; } }
        public override double HP { get { return 20; } }
        public override double Energia { get { return 30; } }
        public override double SzansaNaTrafienie { get { return 10; } }
        public override double SzansaNaKrytyczne { get { return 5; } }

        public override string Nazwa
        {
            get { return "golem"; }
        }

        public override string ObrazekWalki
        {
            get { return "Resources/Grafiki postaci walczących/golem.png"; }
        }

        public override string ObrazekNaMapie
        {
            get { return "Resources/Grafiki postaci walczących/golem.png"; }
        }

        public override List<Umiejetnosc> Umiejetnosci()
        {
            return new List<Umiejetnosc> { new Wymachiwanie() };
        }
    }
}


