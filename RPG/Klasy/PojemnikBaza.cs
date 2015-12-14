using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy
{
    public abstract class PojemnikBaza : Przeszkoda
    {
       bool otwarty = false;
        public override string ObrazekNaMapie
        {
            get { return "Resources/Mapy/Skrzynka.png"; }
        }
        protected virtual int Zloto { get { return 0; } }
        protected abstract List<RPG.Ekwipunek> Przedmioty { get; }
        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGry gra)
        {
            if (otwarty)
            {
                return;
            }

            gracz.Zloto += Zloto;
            gracz.Plecak.AddRange(Przedmioty);

            gra.Komunikat = "W skrzyni znalazłeś ";
            if(Zloto>0)
            {
                gra.Komunikat += string.Format("{0} złota ", Zloto);
            }
            if(Przedmioty.Any())
            {
                 var nazwy=Przedmioty.Select(z=>z.Nazwa).ToList();
                 gra.Komunikat += nazwy.Aggregate((current, next) => current + ", " + next); 
            }
            gra.CzasWyswietlanieKomunikatu = 2000;
            otwarty = true;
        }

    }
}
