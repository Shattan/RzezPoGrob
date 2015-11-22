using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    public class SzybkiStrzal:Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Szybki strzał"; }
        }

        public override bool Magiczna
        {
            get { return false; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= atakujacy.Zrecznosc * atakujacy.Obrazenia / (cel.Pancerz * cel.Pancerz);

        }

        public override bool JestDostepna(Postac sprawdzany)
        {
            throw new NotImplementedException();
        }
    }
}
