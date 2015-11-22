using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Gra
    {
        //Wdrożone pola
        public Gracz gracz;
      
      
       

        //Jeszcze nie używane
        public List<Przeszkoda> listaPrzeszkod = new List<Przeszkoda>();
        
        //Konstruktor domyślny
        public Gra()
        {
            //Tworzenie infrastruktury
            
            
     
        }




    
      

  
        public void UtworzListePrzeszkod()
        {
            //index 0
            listaPrzeszkod.Add(new Przeszkoda("Drzewo"));
        }
    }
}
