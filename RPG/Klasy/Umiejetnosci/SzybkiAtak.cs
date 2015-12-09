using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class SzybkiAtak
    {
        public override string Nazwa
        {
            get { return "Szybki Atak"; }
        }

        public override bool Magiczna
        {
            get { return false; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= atakujacy.Sila * (atakujacy.Obrazenia / cel.Pancerz) * 1.2;

        }

        public override bool JestDostepna(Gracz sprawdzany)
        {
            if (sprawdzany.SilaZPrzedmiotami < 10)
            {
                return false;
            }
            return true;
        }
    }
}
