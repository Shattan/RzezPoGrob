using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class BrylaLodu : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Bryła Lodu"; }
        }
        public override bool Magiczna
        {
            get { return true; }
        }
        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= (atakujacy.Inteligencja * atakujacy.Inteligencja / cel.Pancerz) + 25;
            // + spowolnienie jeśli sie doda

        }
        public override double KosztEnergi
        {
            get
            {
                return 20;
            }
        }

        public override bool JestDostepna(Gracz sprawdzany)
        {

            if (sprawdzany.AktualnaEnerigia < KosztEnergi)
            {
                return false;
            }
            if (sprawdzany.Inteligencja < 10)
            {
                return false;
            }
            return true;
        }
    }
}
