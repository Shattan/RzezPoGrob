using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Strawa
    {
        public string Obrazek { get; set; }
        public string Nazwa { get; set; }
        public int HP { get; set; }
        public int Energia { get; set; }
        
        const double przemnoznikHPIEnergii = 1;

        public int Cena
        {
            get
            {
                return (int)(
                    HP * przemnoznikHPIEnergii
                    + Energia * przemnoznikHPIEnergii
                    );
            }
        }

        public Strawa(string _nazwa, string _obrazek, int _hp, int _energia)
        {
            Nazwa = _nazwa;
            Obrazek = _obrazek;
            HP = _hp;
            Energia = _energia;
        }
    }
}
