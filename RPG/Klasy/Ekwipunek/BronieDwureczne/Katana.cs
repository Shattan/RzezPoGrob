using RPG.Klasy.Ekwipunek.BronieDwureczne;
using RPG.Klasy.Ekwipunek.Zywnosc;
using RPG.Klasy.PostacieNiezalezne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG.Klasy.Ekwipunek.BronieDwureczne
{
    class Katana : RPG.Ekwipunek
    {
        public override string Nazwa
        {
            get { return "Katana"; }
        }
        public override double Obrazenia
        {
            get
            {
                return 15;
            }
        }
        public override int Sila
        {
            get
            {
                return 15;
            }
        }
        public override string Obrazek
        {
            get { return "Resources/Grafiki ekwipunku/bron2hKatana.PNG"; }
        }

        public override TypPrzedmiotu TypPrzedmiotu
        {
            get { return Klasy.TypPrzedmiotu.BronDwureczna; }
        }
    }
}