using RPG.Formy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy.Postacie
{
    class PasterkaKrysia : NPC
    {
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
    class DialogiPasterkiKrysi:DialogiBaza
    {
        public DialogiPasterkiKrysi(PasterkaKrysia postac):base(postac)
        { 
        }
        public override LiniaDialogowa NastepnaLinia(Gracz gracz,int? wybranaopcjala)
        {
            throw new NotImplementedException();
        }
    }
}
