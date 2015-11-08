using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Postac
    {
        public string Nazwa { get; set; }
        public int Zloto { get; set; }

        public string ObrazekNaMapie { get; set; }
        public string ObrazekMowienia { get; set; }
        public string ObrazekWalki { get; set; }
        public int iloscPunktowDoRozdaniaCoPoziom { get { return 4; } }

        //statystyki bez przedmiotow    
        public int SilaPodstawa { get; set; }
        public int ZrecznoscPodstawa { get; set; }
        public int WitalnoscPodstawa { get; set; }
        public int InteligencjaPodstawa { get; set; }
        public int ObrazeniaPodstawa { get; set; }
        public int PancerzPodstawa { get; set; }
        public int HPPodstawa { get; set; }
        public int EnergiaPodstawa { get; set; }
        public int SzansaNaTrafieniePodstawa { get; set; }
        public int SzansaNaKrytycznePodstawa { get; set; }

        public int SumaStatystykPodstawowych { get { return SilaPodstawa + ZrecznoscPodstawa + WitalnoscPodstawa + InteligencjaPodstawa; } }

        public List<Umiejetnosc> UmiejetnosciFizyczne { get; set; }
        public List<Umiejetnosc> UmiejetnosciMagiczne { get; set; }

    }
}
