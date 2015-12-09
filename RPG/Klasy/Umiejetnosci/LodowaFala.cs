using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class LodowaFala : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Lodowa Fala"; }
        }
        public override bool Magiczna
        {
            get { return true; }
        }
        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= (atakujacy.Inteligencja * atakujacy.Inteligencja / cel.Pancerz) + 50;
            // + spowolnienie jeśli sie doda

        }
        public override double KosztEnergi
        {
            get
            {
                return 35;
            }
        }

        public override bool JestDostepna(Gracz sprawdzany)
        {

            if (sprawdzany.AktualnaEnerigia < KosztEnergi)
            {
                return false;
            }
            if (sprawdzany.Inteligencja < 15)
            {
                return false;
            }
            return true;
        }
    }
}
