using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.BronieDwureczne
{
   public class DlugiMiecz:RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "Długi miecz"; }
        }
        public override double Obrazenia
        {
            get
            {
                return 10;
            }
        }
        public override int Sila
        {
            get
            {
                return 10;
            }
        }
        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/bron2hDługiMiecz.PNG"; }
        }

        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.BronDwureczna; }
        }
    }
}
