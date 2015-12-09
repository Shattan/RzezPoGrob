using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class UderzeniePioruna : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Uderzenie Pioruna"; }
        }
        public override bool Magiczna
        {
            get { return true; }
        }
        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= (atakujacy.Inteligencja * atakujacy.Inteligencja)*1.0;
            // pomija pancerz

        }
        public override double KosztEnergi
        {
            get
            {
                return 15;
            }
        }

        public override bool JestDostepna(Gracz sprawdzany)
        {

            if (sprawdzany.AktualnaEnerigia < KosztEnergi)
            {
                return false;
            }
            if (sprawdzany.Inteligencja < 5)
            {
                return false;
            }
            return true;
        }
    }
}
