using RPG.Formy;
using RPG.Klasy.Przeciwnicy.Zadania;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Postacie
{
    class PasterkaKrysia : NPC
    {
        class DialogiPasterkiKrysi : DialogiBaza
        {

            List<LiniaDialogowa> dialogi = new List<LiniaDialogowa>();
            List<LiniaDialogowa> dialogiCzasQuesta = new List<LiniaDialogowa>();
            List<LiniaDialogowa> dialogiZakonczenie = new List<LiniaDialogowa>();
            List<LiniaDialogowa> dialogiPozniej = new List<LiniaDialogowa>();
            public DialogiPasterkiKrysi(PasterkaKrysia postac)
                : base(postac)
            {
                dialogi.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Witaj" });
                dialogi.Add(new LiniaDialogowa() { Wypowiadajacy = Gra.gracz, Tresc = "Witaj Krysiu" });
                dialogi.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Uratuj moją owieczkę, zabij złe wilki" });

                dialogiCzasQuesta.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Dalej nie zabiłeś wilków" });


                dialogiZakonczenie.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Dziękuję za pomoc, proszę oto 50 sztuk złota" });

                dialogiPozniej.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Witaj mój przyjacielu" });
            }
            int id = -1;
            public override LiniaDialogowa NastepnaAkcja()
            {
            
                id++;
                if (id < aktualnaLista.Count)
                {
                    return aktualnaLista[id];
                }
              
                return null;

            }
            const string nazwaZadania = "Zabij złe wilki";
            int statusZadania = 0;

            private void DodajZadanie()
            {
                Gra.gracz.Zadania.Add(new Zadanie(nazwaZadania, "Pasterka Krysia", "Zabij złe wilki", "Złoto", "Zabij złe wilki napadające na moje owce"));
            }
            List<LiniaDialogowa> aktualnaLista = null;
            public override void Konfiguracja()
            {

                bool niemajuzwilkow = true;
                var o = ManagerObszarow.WczytajObszar("mapa").Mapa;
                for (int i = 0; i < o.GetLength(0); i++)
                {
                    for (int j = 0; j < o.GetLength(1); j++)
                    {
                        if (o[i,j] is WilkKrysia)
                        {
                            niemajuzwilkow = false;
                            break;
                        }

                    }
                    if (!niemajuzwilkow)
                    {
                        break;
                    }
                }
                if (niemajuzwilkow && statusZadania!=3)
                {
                    statusZadania = 2;
                }

       
                if (statusZadania == 0)
                {//rozpoczynamy zadanie
                    if (Gra.gracz.Zadania.Any(x => x.Nazwa == nazwaZadania))
                    {
                        statusZadania = 1;
                    }
                    else
                    {
                        DodajZadanie();
                    }
                    aktualnaLista = dialogi;
                        
                }
                if(statusZadania==1)
                {
                    aktualnaLista = dialogiCzasQuesta;
                }
                else if (statusZadania == 2)
                {
                    aktualnaLista = dialogiZakonczenie;
                    Gra.gracz.Zloto += 50;
                    statusZadania = 3;
                    Gra.gracz.Zadania.RemoveAll(x => x.Nazwa == nazwaZadania);
                }
                else if(statusZadania==3)
                {
                    aktualnaLista = dialogiPozniej;
                }
            
                id = -1;
            }
        }
        private DialogiPasterkiKrysi dialogi;
        public PasterkaKrysia()
        {
            dialogi = new DialogiPasterkiKrysi(this);
        }
        public override string Nazwa
        {
            get { return "Pasterka Krysia"; }
        }

        public override string ObrazekNaMapie
        {
            get {return "Resources\\Grafiki postaci na mapie\\8\\dół.png";}
        }
        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGry gra)
        {
            EkranDialog dialog = new EkranDialog(dialogi);
            dialog.ShowDialog();
        }
    }
  
}
