using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Klasy
{
    public abstract class DialogiBaza
    {
        NPC _npc;

        public NPC Npc
        {
            get { return _npc; }
        }
        public DialogiBaza(NPC postac)
        {
            _npc = postac;
        }
        public abstract  LiniaDialogowa NastepnaLinia(Postac ktoWymowilOstatniaKwestie,int? wybranaopcjala);
    }
    public class LiniaDialogowa 
    {
        public Postac Wypowiadajacy { get; set; }
        public string Tresc { get; set; }
    }
}
