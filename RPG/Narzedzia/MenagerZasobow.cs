using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Narzedzia
{
    public class MenagerZasobow
    {
        static Dictionary<string, Bitmap> _zasoby = new Dictionary<string, Bitmap>();


        public static Bitmap PobierzBitmape(string sciezka)
        {
            if(!_zasoby.ContainsKey(sciezka))
            {
                _zasoby.Add(sciezka, new Bitmap(sciezka));
            }
            return _zasoby[sciezka];
        }
    }
}
