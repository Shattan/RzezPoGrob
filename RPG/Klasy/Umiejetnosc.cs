using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public abstract class Efekt
    {

        public Efekt(int czasTrwania)
        {
            PozostaloTur = czasTrwania;
        }
        public int PozostaloTur { get; set; }


        public abstract void Wykonaj(Postac cel);
    }
    public abstract class Umiejetnosc
    {
        public abstract String Nazwa { get;}
        public virtual String ObrazekPrzycisku { get { return "Resources/Grafiki przycisków umiejętności/Przykładowy przycisk.png"; } }
        public virtual String ObrazekWWalce { get { return "Resources/Grafiki umiejętności/Eksplozja.png"; } }
        /// <summary>
        /// Czy to umiejetnosc magiczna
        /// </summary>
        public abstract bool Magiczna{get;}
        protected abstract void Wykonaj(Postac atakujacy, Postac cel);
        public abstract bool JestDostepna(Postac sprawdzany);
        /// <summary>
        /// Ile kosztuje użycie umiejętności
        /// </summary>
        protected virtual double KosztEnergi { get { return 0; } }
        protected virtual void ZaplacZaUzycie(Postac atakujacy)
        {
            atakujacy.AktualnaEnerigia -= KosztEnergi;
        }
        public void Atak(Postac atakujacy, Postac cel, TextBox komunikaty)
        {
            if(CzyTrafiono(atakujacy,cel))
            {
                Wykonaj(atakujacy,cel);
                komunikaty.Text += "Trafienie\r\n";
            }
            else
            {
                komunikaty.Text += "Pudło\r\n";
            }
            ZaplacZaUzycie(atakujacy);

        }
        protected virtual bool CzyTrafiono(Postac atakujacy, Postac cel)
        {
            Random r = new Random();
            int szansa = r.Next(0, 100);
            if (szansa >= atakujacy.SzansaNaTrafienie)
            {
                return true;
            }
            return false;
        }
    }
}
