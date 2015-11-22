using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPG.Narzedzia
{
    public class Odtwarzacz
    {
        MediaPlayer player;
        public Odtwarzacz()
        {
            player = new MediaPlayer();

        }
        public bool JestWolny
        {
            get
            {
                if (!player.HasAudio)//nie ma muzyki czyli napewno jest wolny
                {
                    return true;
                }
                return (player.NaturalDuration == player.Position);
            }
        }
      
        /// <summary>
        /// Odtwarza określony dźwięk, wyrzuca wyjątek jeśli próbujemy odtworzyć dźwięk kiedy inny jest odtwarzany
        /// </summary>
        /// <param name="sciezka"></param>
        public void Odtworz(string sciezka,bool zapetlony)
        {
            if(!JestWolny)
            {
                player.Stop();
                player.MediaEnded -=player_MediaEnded;
            }
                player.Open(new Uri(sciezka, UriKind.Relative));
                player.Play();
            if(zapetlony)
            {
                player.MediaEnded+=player_MediaEnded;
            }
         
        }

        void player_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer odtarzacz = (MediaPlayer)sender;
            player.Play();
        }
        /// <summary>
        /// Zatrzymuje odtwarzany dźwięk
        /// </summary>
        public void Zatrzymaj()
        {
            if(!JestWolny)
            {
                player.Stop();
            }
        }
        /// <summary>
        /// Aktualnie odtwarzany dźwięk
        /// </summary>
        public string OdtwarzanyPlik
        {
            get
            {
                return player.Source.AbsolutePath;
            }
        }

        public double Glosnosc
        {
            get
            {
                return player.Volume*10;
            }
            set
            {
                player.Volume = value/10;
            }
        }
    }
    /// <summary>
    /// Klasa narządziowa do odtwarzania muzyki
    /// </summary>
    public static class OdtwrzaczManager
    {
        private static List<Odtwarzacz> odtwarzacze;
        static OdtwrzaczManager()
        {
            odtwarzacze = new List<Odtwarzacz>();
            for(int i=0;i<10;i++)
            {
                Odtwarzacz tmp = new Odtwarzacz();
                odtwarzacze.Add(tmp);
            }
            UstawDomyslneGlosnosci();
        }
        public static void UstawDomyslneGlosnosci()
        {
            for (int i = 0; i < odtwarzacze.Count; i++)
            {
               
                if (i < 2)
                {
                    odtwarzacze[i].Glosnosc = Ustawienia.GlosnoscMuzyki;
                }
                else
                {
                    odtwarzacze[i].Glosnosc = Ustawienia.GlosnoscDzwiekow;
                }
            }
        }
        public static int LiczbaOdtwarzaczy
        {
            get
            {
                return odtwarzacze.Count;
            }
        }
        public static void Odtworz(int odtwarzacz,string sciezka,bool zapetlony)
        {
            Odtwarzacz wolny = odtwarzacze[odtwarzacz];//pobieramy pierwszy wolny odtwarzacz
            if(wolny!=null)
            {
                wolny.Odtworz(sciezka, zapetlony);
             
            }
        }
        public static void Zatrzymaj(int odtwarzacz)
        {
            odtwarzacze[odtwarzacz].Zatrzymaj();
          
        }
        /// <summary>
        /// Zatrzymuje wszystkie odtwarzacze
        /// </summary>
        public static void ZatrzymajWszystkie()
        {
            for (int i = 0; i < odtwarzacze.Count; i++)
            {
                odtwarzacze[i].Zatrzymaj();
            }
        }
        public static void UstawGlosnosc(int odtwarzacz,double wartosc)
        {
            
            odtwarzacze[odtwarzacz].Glosnosc = wartosc;
        }
    }
}
