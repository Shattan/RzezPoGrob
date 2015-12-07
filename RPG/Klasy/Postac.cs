using RPG.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Postac:ElementMapy
    {

        public void UstawHp()
        {
            AktualneHp = HP;
            AktualnaEnerigia = Energia;
        }
        public abstract List<Umiejetnosc> Umiejetnosci();
        public abstract string Nazwa { get; }

        public List<Umiejetnosc> UmiejetnosciFizyczne { get { return Umiejetnosci().Where(x=>!x.Magiczna).ToList(); } }
        public List<Umiejetnosc> UmiejetnosciMagiczne { get { return Umiejetnosci().Where(x => x.Magiczna).ToList(); } }

        /// <summary>
        /// Całkowita siła
        /// </summary>

        public abstract int Sila { get ;} 
        public abstract int Zrecznosc { get ;} 
        public abstract int Witalnosc { get ;} 
        public abstract int Inteligencja { get ;} 
        public abstract double Obrazenia { get ;} 
        public abstract double Pancerz { get ;} 
        public abstract double HP{ get ;} 
        public abstract double Energia{ get ;} 
        public abstract double SzansaNaTrafienie{ get ;} 
        public abstract double SzansaNaKrytyczne { get ;}

        public double AktualneHp { get; set; }
        public double AktualnaEnerigia { get; set; }
        /// <summary>
        /// Aktywne efekty nałożone na postać
        /// </summary>
        private List<Efekt> _efekty = new List<Efekt>();
        public void DodajEfekt(Efekt efekt)
        {
            _efekty.Add(efekt);
        }
        public void WyczyscEfekty()
        {
            _efekty.Clear();
        }
        public List<Efekt> PobierzEfekty()
        {
            return _efekty;
        }
        public void PrzetworzEfektyTrwajace()
        {
            for (int i = 0; i < _efekty.Count; i++)
            {
                _efekty[i].Wykonaj(this);
                _efekty[i].PozostaloTur--;
                if (_efekty[i].PozostaloTur <= 0)
                {
                    _efekty.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
