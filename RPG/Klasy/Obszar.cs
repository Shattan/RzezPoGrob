using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Obszar
    {
        public string nazwa;
        int zestawPotworow = 0;

        public Obszar(String _nazwa, int _zestawPotworow)
        {
            nazwa = _nazwa;
            zestawPotworow = _zestawPotworow;
        }
    }
}
