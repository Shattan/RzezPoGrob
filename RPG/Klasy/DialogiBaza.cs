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
        Gracz _gracz;

        public Gracz Gracz
        {
            get { return _gracz; }
          
        }
        public DialogiBaza(NPC postac,Gracz gracz)
        {
            _npc = postac;
            _gracz = gracz;
        }
        public  LiniaDialogowa NAstepnaLinia(int? wybranaopcjala);
    }
    public class LiniaDialogowa 
    {
        
    }
}
