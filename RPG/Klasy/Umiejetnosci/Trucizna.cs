using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    public class Trucizna : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Trucizna"; }
        }

        public override bool Magiczna
        {
            get { return true; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.DodajEfekt(new EfektTrucizna(3));
        }

        public override bool JestDostepna(Gracz sprawdzany)
        {

            if (sprawdzany.AktualnaEnerigia < KosztEnergi)
            {
                return false;
            }
            if(sprawdzany.Inteligencja<6)
            {
                return false;
            }
            return true;
        }
        public override double KosztEnergi
        {
            get
            {
                return 10;
            }
        }

    }
   
    public class EfektTrucizna:Efekt
    {


        public EfektTrucizna(int czasTrwania):base(czasTrwania)
        {
         
        }



        public override void Wykonaj(Postac cel)
        {
            cel.AktualneHp -= 1;
        }
    }
}
