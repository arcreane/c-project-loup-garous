using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Cupidon : Personnages
    {
        private Random random = new Random();
        public Cupidon(String name, Village village) : base(name, village) { }

        public override List<string> defense { get; set; } = new List<string>() { "je suis un personnage meetic", "j’adore jouer aux fléchettes", "je me prépare pour aller en soirée avec les autres villageois", "Je me balade seul le soir" };

        public override string role { get; set; } = "Cupidon";

        public override bool inLife { get; set; } = true;

        public void cupidPlay()
        {
            Console.WriteLine("Cupidon va choisir deux ames soeurs");

            Personnages v1;
            Personnages v2;
            myVillage.getRandomCharaters(out v1, out v2);

            Personnages.setInLove(v1, v2);
        }
    }
}
