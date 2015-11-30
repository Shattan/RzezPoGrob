using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    class PrecyzyjnyAtak
    {
        public override string Nazwa
        {
            get { return "Precyzyjny Atak"; }
        }

        public override bool Magiczna
        {
            get { return false; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= atakujacy.Sila * (atakujacy.Obrazenia / cel.Pancerz) * 1.5;

        }

        public override bool JestDostepna(Gracz sprawdzany)
        {
            if (sprawdzany.SilaZPrzedmiotami < 15)
            {
                return false;
            }
            return true;
        }
    }
}
