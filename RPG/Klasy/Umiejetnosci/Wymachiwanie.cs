using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    public class Wymachiwanie:Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Wymachiwanie"; }
        }

        public override bool Magiczna
        {
            get { return false; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= atakujacy.Sila * (atakujacy.Obrazenia / cel.Pancerz);
         
        }

        public override bool JestDostepna(Gracz sprawdzany)
        {
            return true;
        }


     
    }
}
