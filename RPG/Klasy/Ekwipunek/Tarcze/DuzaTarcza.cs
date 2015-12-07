using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.Tarcze
{
   public class DuzaTarcza:RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "Duża tarcza"; }
        }

        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/tarczaDużaTarcza.PNG"; }
        }

        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.Tarcza; }
        }
        public override double Pancerz
        {
            get
            {
                return 5;
            }
        }
        public override int Sila
        {
            get
            {
                return 3;
            }
        }
    }
}
