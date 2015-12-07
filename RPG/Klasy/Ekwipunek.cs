using RPG.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Ekwipunek
    {
        public abstract string Nazwa { get;  }
        public abstract string Obrazek { get;  }
        public virtual int Sila
        {
            get { return 0; }
        }

        public virtual int Zrecznosc
        {
            get { return 0; }
        }

        public virtual int Witalnosc
        {
            get { return 0; }
        }

        public virtual int Inteligencja
        {
            get { return 0; }
        }

        public virtual double Obrazenia
        {
            get { return 0; }
        }

        public virtual double Pancerz
        {
            get { return 0; }
        }

        public virtual double HP
        {
            get { return 0; }
        }

        public virtual double Energia
        {
            get { return 0; }
        }

        public virtual double SzansaNaTrafienie
        {
            get { return 0; }
        }

        public virtual double SzansaNaKrytyczne
        {
            get { return 0; }
        }

        public abstract TypPrzedmiotu TypPrzedmiotu
        {
            get;
        }

        public virtual int Cena
        {
            get { return 10; }
        }
    }
}
