using RPG.Formy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPG.Klasy.Postacie
{
         class DialogiChlop : DialogiBaza
        {

            List<LiniaDialogowa> dialogi = new List<LiniaDialogowa>();
            List<LiniaDialogowa> dialogiCzasQuesta = new List<LiniaDialogowa>();
            List<LiniaDialogowa> dialogiZakonczenie = new List<LiniaDialogowa>();

            public DialogiChlop(Chlop postac)
                : base(postac)
            {
                dialogi.Add(new LiniaDialogowa()
                {
                    Wypowiadajacy = postac,
                    Tresc = @"Śmiałku! Pomóż ocalić nasz lud!.
Inaczej spadnie na nas niechybna zagłada z rąk okrutnych demonów!
W nagrodę możesz zabrać ze sobą złoto i skarby, które wykradły swoim ofiarom!" });
                dialogi.Add(new LiniaDialogowa() { Wypowiadajacy = Gra.gracz, Tresc = "Jest we mnie honor i męstwo! Nie straszne mi potwory z piekielnych odmętów!\nWyruszam natychmiast, by się z nimi rozprawić!" });
                dialogi.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Dzięki Ci bohaterze! Oby los Ci sprzyjał!" });

                dialogiCzasQuesta.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Dalej nie zabiłeś wszystkich potworów. Błagam pośpiesz się" });


                dialogiZakonczenie.Add(new LiniaDialogowa() { Wypowiadajacy = postac, Tresc = "Dziękuję za pomoc, Twe imie będzie sławne na wieki" });

      
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
            const string nazwaZadania = "Wygnaj zło z krainy";
            int statusZadania = 0;

            private void DodajZadanie()
            {
                Gra.gracz.Zadania.Add(new Zadanie(nazwaZadania, "Chłop", "Zabij wszystkie stworzy", "Sława na wieki", "Zabij wszystkie stworzy w krainie"));
            }
            List<LiniaDialogowa> aktualnaLista = null;
            public override void Konfiguracja()
            {

                bool niemajuzstrowow = true;
                var o = ManagerObszarow.WczytajObszar("mapa").Mapa;
                for (int i = 0; i < o.GetLength(0); i++)
                {
                    for (int j = 0; j < o.GetLength(1); j++)
                    {
                        if (o[i, j] is Przeciwnik)
                        {
                            niemajuzstrowow = false;
                            break;
                        }

                    }
                    if (!niemajuzstrowow)
                    {
                        break;
                    }
                }
                if (niemajuzstrowow && statusZadania != 3)
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
                if (statusZadania == 1)
                {
                    aktualnaLista = dialogiCzasQuesta;
                }
                else if (statusZadania == 2)
                {
                    FormZwyciestwo forma = new FormZwyciestwo();
                    forma.ShowDialog();
        
                }
                id = -1;
            }
        }
    public class Chlop:NPC
    {
       public Chlop()
        {
            dialogi = new DialogiChlop(this);
        }
        private DialogiChlop dialogi;
        public override string Nazwa
        {
            get { return "Chłop"; }
        }

        public override string ObrazekNaMapie
        {
            get { return "resources/Grafiki postaci walczących/wiesniak.png"; }
        }
        public override void IntegracjaGracz(Gracz gracz, int x, int y, EkranGry gra)
        {
            EkranDialog dialog = new EkranDialog(dialogi);
            dialog.ShowDialog();
        }
    }
}
