using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Umiejetnosci
{
    public class KulaOgnia : Umiejetnosc
    {
        public override string Nazwa
        {
            get { return "Kula ognia"; }
        }

        public override bool Magiczna
        {
            get { return true; }
        }

        protected override void Wykonaj(Postac atakujacy, Postac cel)
        {
            cel.AktualneHp -= atakujacy.Inteligencja *atakujacy.Inteligencja / cel.Pancerz;
        }
        protected override double KosztEnergi
        {
            get
            {
                return 10;
            }
        }
        public override bool JestDostepna(Postac sprawdzany)
        {
            throw new NotImplementedException();
        }
    }
}
