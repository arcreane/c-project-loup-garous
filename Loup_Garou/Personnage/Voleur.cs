using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Voleur : Personnages
    {
        private Random random = new Random();
        public Voleur(String Name) : base(Name) { }

        public override List<string> defense { get; set; } = new List<string>() { "je me balade le soir", "je me déplace en silence", "je vais voler votre bourses", "je me prépare pour aller en soirée avec les autres villageois" };

        public override string role { get; set; } = "Voleur";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        public void joker(List<Personnages> allLife)
        {
            /// Partie de Clement
            Console.WriteLine("Joker Voleur");
            bool isVoleurDead = true;
            for (int l = 0; l < allLife.Count; l++)
            {
                /// check si le voleur est en vie ou si il est mort
                if (allLife.ElementAt(l).role == "Voleur")
                {
                    List<Personnages> WithoutVoleur = new List<Personnages>(allLife);
                    for (int V = 0; V < WithoutVoleur.Count; V++)
                    {
                        if (WithoutVoleur.ElementAt(V).role == "Voleur")
                        {
                            WithoutVoleur.RemoveAt(V);
                            break;
                        }
                    }
                    isVoleurDead = false;
                    int indexAllLifeOne = random.Next(WithoutVoleur.Count);
                    int indexAllLifeTwo = random.Next(WithoutVoleur.Count);
                    string villageoisOne = WithoutVoleur.ElementAt(indexAllLifeOne).role;
                    string villageoisTwo = WithoutVoleur.ElementAt(indexAllLifeTwo).role;
                    List<string> defenseVillageoisOne = WithoutVoleur.ElementAt(indexAllLifeOne).defense;
                    List<string> defenseVillageoisTwo = WithoutVoleur.ElementAt(indexAllLifeTwo).defense;
                    string newRoleOne = villageoisTwo;
                    List<string> newDefenseOne = defenseVillageoisTwo;
                    string newRoleTwo = villageoisOne;
                    List<string> newDefenseTwo = defenseVillageoisOne;
                    allLife.ElementAt(indexAllLifeOne).role = newRoleOne;
                    allLife.ElementAt(indexAllLifeOne).defense = newDefenseOne;
                    allLife.ElementAt(indexAllLifeTwo).role = newRoleTwo;
                    allLife.ElementAt(indexAllLifeTwo).defense = newDefenseTwo;
                    Console.WriteLine("Deux villageois ont changés de role");

                }
            }
            if (isVoleurDead == true)
            {
                Console.WriteLine("votre joker est morte");
            }
        }

    }
}
