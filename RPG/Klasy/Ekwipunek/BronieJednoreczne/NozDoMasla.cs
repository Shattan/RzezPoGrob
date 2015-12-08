using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.BronieJednoreczne
{
    public class NozDoMasla : RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "N� do mas�a"; }
        }

        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/bron1hN� do mas�a.png"; }
        }

        public override int Sila
        {
            get
            {
                return 1;
            }
        }
        public override int Zrecznosc
        {
            get
            {
                return 1;
            }
        }
        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.BronJednoreczna; }
        }
    }
}
