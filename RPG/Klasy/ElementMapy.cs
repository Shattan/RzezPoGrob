using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy
{
    public abstract class ElementMapy
    {
        public virtual bool PowodujeKolizje { get { return true; } }
        public abstract string ObrazekNaMapie { get; }
        public abstract void IntegracjaGracz(Gracz gracz, int x, int y, EkranGryObiektyTlo ekranGryObiektyTlo, EkranGry gra);
        public string Tlo { get; set; }
        
    }
    public class ElementMapyPusty : ElementMapy
    {
        public override bool PowodujeKolizje { get { return false; } }
        public override string ObrazekNaMapie
        {
            get { return null; }
        }

        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGryObiektyTlo ekranGryObiektyTlo, EkranGry gra)
        {
            
        }
    }
}
