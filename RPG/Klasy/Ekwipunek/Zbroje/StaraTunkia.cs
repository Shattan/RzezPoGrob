using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.Zbroje
{
   public class StaraTunika:RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "Stara tunika"; }
        }

        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/pancerzStara tunika.png"; }
        }

        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.Zbroja; }
        }
        public override double Pancerz
        {
            get
            {
                return 1;
            }
        }
    }
}
