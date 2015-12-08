using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.Zywnosc
{
    public class SwiezyChleb : RPG.Strawa
    {
        public override string Nazwa
        {
            get { return "Świeży chleb"; }
        }

        public override string Obrazek
        {
            get { return "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG"; }
        }
        public override double HP
        {
            get
            {
                return 20;
            }
        }
        
    }
}
