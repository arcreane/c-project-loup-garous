using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Villageois : Personnages
    {

        public Villageois(string v) : base(v){
            
        }


        public override List<string> defense { get; set; } = new List<string>() { "je me prépare pour aller en soirée avec les autres villageois", "Viens faire la fête avec nous !", "Tu me payes quand le Mcdo ?", "Wesh la famille ca dit quoi ?" };

        public override string role => "Villageois";

        public override bool inLife { get; set; } = true;

        public override bool inLove { get; set; } = false;

    }
}
