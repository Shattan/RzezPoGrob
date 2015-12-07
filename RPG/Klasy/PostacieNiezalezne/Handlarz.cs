using RPG.Formy;
using RPG.Klasy.Ekwipunek.Zywnosc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.PostacieNiezalezne
{
   public abstract class Handlarz:NPC
    {
       protected abstract List<RPG.Ekwipunek> InicjacjaPosiadanychPrzedmiow();
       private List<RPG.Ekwipunek> _przedmioty = new List<RPG.Ekwipunek>();
       public Handlarz()
       {
           _przedmioty = new List<RPG.Ekwipunek>(InicjacjaPosiadanychPrzedmiow());
       }
   
        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGryObiektyTlo ekranGryObiektyTlo, EkranGry gra)
        {
            EkranHandel ekran = new EkranHandel(gracz, this);
            ekran.ShowDialog();
        }
        public List<RPG.Ekwipunek> PosiadanePrzedmioty
        {
            get
            {
                return _przedmioty;
            }
        }
    }
}
