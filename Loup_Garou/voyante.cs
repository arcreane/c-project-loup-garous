using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Voyante : Personnages
    {
        public Voyante(String Name) : base(Name) { }

        public override List<string> defense { get; set; } = new List<string>(){ "je parle aux objets", "je vois des choses que d’autres ne voient pas", "je me balade seul le soir", "je me prépare pour aller en soirée avec les autres villageois" };

        public override string role { get; set; } = "Voyante";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

    }
}
