using RPG.Klasy.Ekwipunek.BronieJednoreczne;
using RPG.Klasy.Ekwipunek.Zywnosc;
using RPG.Klasy.PostacieNiezalezne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Postacie.Sprzedawcy
{
    public class SprzdawcaZenon:Handlarz
    {
        protected override List<RPG.Ekwipunek> InicjacjaPosiadanychPrzedmiow()
        {
            List<RPG.Ekwipunek> wynik = new List<RPG.Ekwipunek>();

            wynik.Add(new SwiezyChleb());
            wynik.Add(new SwiezyChleb());
            wynik.Add(new SwiezyChleb());
            wynik.Add(new SwiezyChleb());
            wynik.Add(new KrotkiMiecz());
            return wynik;

        }
        public override string Nazwa
        {
            get { return "Sprzedawca Zenon"; }
        }

        public override string ObrazekNaMapie
        {
            get { return "Resources\\Grafiki postaci na mapie\\24\\dół.gif"; }
        }
    }
}
