using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class BoucEmissaire : Personnages
    {
        public BoucEmissaire(String name):base(name) { }

     //   public override string name { get; set; } = "";

        public override List<string> defense { get; set; } = new List<string>() { "Je me balade seul le soir", "Je n’aime pas le village", "Je ne veux pas vous répondre", "Je vais tous vous tuer !" };

        public override string role => "Bouc Emissaire";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

    }
}
