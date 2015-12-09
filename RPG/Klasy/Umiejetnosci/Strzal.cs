using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class Strzal : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Strzał"; }
        }

        public override bool Magiczna
        {
            get { return false; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= (atakujacy.Zrecznosc * atakujacy.Obrazenia / (cel.Pancerz * cel.Pancerz))*0.9;

        }

        public override bool JestDostepna(Gracz sprawdzany)
        {
            if (sprawdzany.AktualnaEnerigia < KosztEnergi)
            {
                return false;
            }
            if (sprawdzany.Zrecznosc < 4)
            {
                return false;
            }
            if (sprawdzany.ZalozonaBron == null)
            {
                return false;
            }
            if (sprawdzany.ZalozonaBron.TypPrzedmiotu != TypPrzedmiotu.BronMiotana)
            {
                return false;
            }
            return true;
        }
        public override double KosztEnergi
        {
            get
            {
                return 6;
            }
        }
    }
}
