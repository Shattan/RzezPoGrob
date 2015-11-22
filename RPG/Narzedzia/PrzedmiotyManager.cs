using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Narzedzia
{
    public static class PrzedmiotyManager
    {
        public static List<Strawa> ListaPozywieniaIMikstur = new List<Strawa>();
        public static List<Ekwipunek> ListaPrzedmiotow = new List<Ekwipunek>();
        static  PrzedmiotyManager()
        {
            //index 0
            ListaPrzedmiotow.Add(new Ekwipunek("Nóż do masła", "Resources/Grafiki ekwipunku/bron1hNóż do masła.png", 1, 1, 0, 0, 1, 0, 0, 0, 0, 0));
            //index 1
            ListaPrzedmiotow.Add(new Ekwipunek("Stara tunika", "Resources/Grafiki ekwipunku/pancerzStara tunika.png", 0, 0, 1, 0, 0, 1, 5, 0, 0, 0));
            //index 2
            ListaPrzedmiotow.Add(new Ekwipunek("Pochodnia", "Resources/Grafiki ekwipunku/tarczaPochodnia.png", 0, 0, 0, 1, 0, 0, 0, 5, 1, 0));
            //index 3
            ListaPrzedmiotow.Add(new Ekwipunek("Długi Miecz", "Resources/Grafiki ekwipunku/bron2hDługiMiecz.PNG", 10, 10, 10, 10, 5, 10, 10, 2, 10, 10));
            //index 4
            ListaPrzedmiotow.Add(new Ekwipunek("Kosa Powiew Śmierci", "Resources/Grafiki ekwipunku/bron2hKosaPowiewŚmierci.PNG", 5, 3, 3, 10, 5, 0, 10, 10, 10, 10));
            //index 5
            ListaPrzedmiotow.Add(new Ekwipunek("Kostur Nowicjusza", "Resources/Grafiki ekwipunku/bron2hKosturNowicjusza.PNG", 10, 10, 10, 0, 4, 0, 10, 10, 10, 10));
            //index 6
            ListaPrzedmiotow.Add(new Ekwipunek("Łuk Z Krain Południa", "Resources/Grafiki ekwipunku/bron2hŁukZKrainPołudnia.PNG", 10, 10, 10, 4, 11, 10, 10, 10, 10, 10));
            //index 7
            ListaPrzedmiotow.Add(new Ekwipunek("Młot Bojowy", "Resources/Grafiki ekwipunku/bron2hMłotBojowy.PNG", 10, 10, 7, 4, 10, 10, 0, 10, 2, 10));
            //index 8
            ListaPrzedmiotow.Add(new Ekwipunek("Topór Bojowy", "Resources/Grafiki ekwipunku/bron2hTopórBojowy.PNG", 10, 8, 0, 10, 6, 10, 0, 16, 10, 10));
            //index 9
            ListaPrzedmiotow.Add(new Ekwipunek("Trójząb", "Resources/Grafiki ekwipunku/bron2hTrójząb.PNG", 0, 10, 10, 0, 10, 6, 10, 7, 10, 7));
            //index 10
            ListaPrzedmiotow.Add(new Ekwipunek("Duża Tarcza", "Resources/Grafiki ekwipunku/tarczaDużaTarcza.PNG", 0, 0, 0, 10, 7, 10, 10, 10, 10, 10));
            //index 11
            ListaPrzedmiotow.Add(new Ekwipunek("Tarcza Króla", "Resources/Grafiki ekwipunku/tarczaTarczaKróla.PNG", 10, 10, 0, 10, 3, 10, 6, 10, 0, 10));
            //index 12
            ListaPrzedmiotow.Add(new Ekwipunek("Sztylet Prosty", "Resources/Grafiki ekwipunku/bron1hSztyletProsty.PNG", 10, 6, 0, 10, 2, 10, 10, 5, 10, 10));
            //index 13
            ListaPrzedmiotow.Add(new Ekwipunek("Sztylet Zabójcy", "Resources/Grafiki ekwipunku/bron1hSztyletZabójcy.PNG", 10, 10, 0, 3, 10, 10, 5, 10, 10, 7));
            //index 14
            ListaPrzedmiotow.Add(new Ekwipunek("Szata Niebieskiego Maga", "Resources/Grafiki ekwipunku/pancerzSzataNiebieskiegoMaga.PNG", 10, 10, 0, 0, 0, 8, 10, 10, 10, 3));
            //index 15
            ListaPrzedmiotow.Add(new Ekwipunek("Pancerz Cienia", "Resources/Grafiki ekwipunku/pancerzPancerzCienia.PNG", 10, 10, 10, 4, 10, 10, 8, 0, 0, 0));

            //index 0
            ListaPozywieniaIMikstur.Add(new Strawa("Świeży chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 10));
            //index 1
            ListaPozywieniaIMikstur.Add(new Strawa("Suchy chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 0));
            //index 2
            ListaPozywieniaIMikstur.Add(new Strawa("Stary chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 0, 10));
            //index 3
            ListaPozywieniaIMikstur.Add(new Strawa("Czerstwy chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 5, 10));
            //index 4
            ListaPozywieniaIMikstur.Add(new Strawa("Chrupiący chleb", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 10, 5));
            //index 5
            ListaPozywieniaIMikstur.Add(new Strawa("Chleb z pleśnią", "Resources/Grafiki pożywienia i mikstur/SuchyChleb.PNG", 5, 5));
        }


    }
}
