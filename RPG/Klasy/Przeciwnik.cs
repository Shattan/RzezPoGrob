using RPG.Klasy;
using RPG.Klasy.Umiejetnosci;
using RPG.Narzedzia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public abstract class Przeciwnik :Postac
    {
        protected Przeciwnik()
        {
            AktualneHp = HP;
            AktualnaEnerigia = Energia;
        }

        public abstract string ObrazekWalki { get;  }
        //statystyki po obliczeniu bonusów 

        public int ZlotoZaZabicie { get
        {
            Random Losowanie = new Random();
            return Losowanie.Next(50, 150) / 100 * SumaStatystyk;
        }}
        public int DoswiadczenieZaZabicie { get { return SumaStatystyk; } }

        public int SumaStatystyk { get { return Sila + Zrecznosc + Witalnosc + Inteligencja; } }
        //Konstruktor domyślny
     

        internal Umiejetnosc PobierzUmiejetnosc()
        {

            Random r = new Random();
            List<Umiejetnosc> wszystkie=Umiejetnosci();
            Umiejetnosc u = wszystkie[r.Next(0, wszystkie.Count - 1)];
            if(u.KosztEnergi>Energia)//jak nie stać to używamy wymachiwania
            {
                return new Wymachiwanie();
            }
            return u;
        }
        string LosujTloWalki()
        {
            Random losowanie = new Random();
            string plansza = losowanie.Next(0, 10).ToString();
           return "Resources/Grafiki tła walki/" + plansza + ".png";
        }
        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGry gra)
        {
            gra.UniewidocznijGre();
         
            EkranWalkaTlo ekranWalkaTlo = new EkranWalkaTlo(gra,LosujTloWalki(),this);
            ekranWalkaTlo.ShowDialog();
           
            if (ekranWalkaTlo.DialogResult == DialogResult.OK)//Jeżeli gracz wygrał
            {
             PoWygranejGracza(gracz,x,y,gra);
               
              
              
            }
            else if (ekranWalkaTlo.DialogResult == DialogResult.Abort)//Jeżeli gracz przegrał
            {
                gra.UwidocznijGre();
                OdtwrzaczManager.Odtworz(4, "Resources/Dźwięki/smierc.wav", false);
                gra.DialogResult = ekranWalkaTlo.DialogResult;
                //Co robimy jak gracz przegral?
           
                //Co robimy jak gracz przegral? 
                //Wylaczamy sterowanie gracza, 
                //na dole pojawia się napis "Porażka", 
                //włącza się muzyczka "Resources/Dźwięki/smierc.wav"
                //Zmieniamy tło gracza na plamę krwi 
            }
            else if (ekranWalkaTlo.DialogResult == DialogResult.Ignore)//Jeżeli gracz uciekł
            {
                gra.UwidocznijGre();
            }
            else
            {
                //Ktos zamknal na sile forme, zamykamy wiec gre, chociaz powinniosmy po prostu ukarac gracza
                //Może 3-dniowy ban dla gracza za alt+F4? :D
                gra.DialogResult = ekranWalkaTlo.DialogResult;
            }
        }
        protected virtual void PoWygranejGracza(Gracz gracz, int x, int y, EkranGry gra)
        {
            gracz.Zloto += this.ZlotoZaZabicie;
            gracz.Doswiadczenie += DoswiadczenieZaZabicie;
            gra.obszarGry.Mapa[x, y] = new ElementMapyPusty() { Tlo = gra.obszarGry.Mapa[x, y].Tlo };
            gra.UwidocznijGre();
        }
    }
}
