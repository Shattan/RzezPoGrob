using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy
{
  public abstract class  NPC : Postac
    {


        public override int Sila
        {
            get { return 1; }
        }

        public override int Zrecznosc
        {
            get { return 1; }
        }

        public override int Witalnosc
        {
            get { return 1; }
        }

        public override int Inteligencja
        {
            get { return 1; }
        }

        public override double Obrazenia
        {
            get { return 1; }
        }

        public override double Pancerz
        {
            get { return 1; }
        }

        public override double HP
        {
            get { return 1; }
        }

        public override double Energia
        {
            get { return 1; }
        }

        public override double SzansaNaTrafienie
        {
            get { return 1; }
        }

        public override double SzansaNaKrytyczne
        {
            get { return 1; }
        }

        public override List<Umiejetnosc> Umiejetnosci()
        {
            return new List<Umiejetnosc>();
        }

        public override void IntegracjaGracz(Gracz gracz, int x, int y,  EkranGry gra)
        {
            
        }

    }
}
