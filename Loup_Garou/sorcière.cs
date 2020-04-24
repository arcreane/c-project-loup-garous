using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Sorcière : Personnages
    {
        public Sorcière(String Name) : base(Name) { }


        public override List<string> defense { get; set; } = new List<string>() { "je porte un chapeau pour me rendre beau", "je suis là pour vous jouer de mauvais tours !", "je me balade le soir", "je me prépare pour aller en soirée avec les autres villageois" };

        public override string role { get; set; } = "Sorcière";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        }
}
