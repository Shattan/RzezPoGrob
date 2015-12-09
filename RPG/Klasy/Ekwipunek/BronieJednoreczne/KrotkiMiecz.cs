using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Ekwipunek.BronieJednoreczne
{
    public class KrotkiMiecz : RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "Krótki miecz"; }
        }

        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/bron1hMieczProsty.png"; }
        }
        public override double Obrazenia
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
        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.BronJednoreczna; }
        }
    }
}
