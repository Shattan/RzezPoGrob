using RPG.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Strawa:Ekwipunek
    {
       
        public void Uzyj(Postac cel)
        {
            cel.AktualneHp += HP;
            if (cel.AktualneHp > cel.HP)
            {
                cel.AktualneHp = cel.HP;

            }
            cel.AktualnaEnerigia += Energia;
            if (cel.AktualnaEnerigia > cel.Energia)
            {
                cel.AktualnaEnerigia = cel.Energia;
            }
        }
        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.Zywnosc; }
        }
    }
}
