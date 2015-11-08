using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Umiejetnosc
    {
        public string nazwa;

        public Umiejetnosc(string _nazwa)
        {
            nazwa = _nazwa;
        }

        public Umiejetnosc(Umiejetnosc umiejetnosc)
        {
            this.nazwa = umiejetnosc.nazwa;
        }
    }
}
