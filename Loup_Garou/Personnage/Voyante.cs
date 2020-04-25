using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Voyante : Personnages
    {
        private Random random = new Random();
        public Voyante(String Name) : base(Name) { }

        public override List<string> defense { get; set; } = new List<string>(){ "je parle aux objets", "je vois des choses que d’autres ne voient pas", "je me balade seul le soir", "je me prépare pour aller en soirée avec les autres villageois" };

        public override string role { get; set; } = "Voyante";

        public override bool inLife { get; set; } = true;

        public void joker(List<Personnages> allLife)
        {
            /// Partie de Amanda
            Console.WriteLine("Joker Voyante");
            bool VoyanteIsDead = true;

            for (int l = 0; l < allLife.Count; l++)
            {
                if (allLife.ElementAt(l).role == "Voyante")
                {
                    VoyanteIsDead = false;

                    List<Personnages> WithoutVoyante = new List<Personnages>(allLife);
                    for (int V = 0; V < WithoutVoyante.Count; V++)
                    {
                        if (WithoutVoyante.ElementAt(V).role == "Voyante")
                        {
                            WithoutVoyante.RemoveAt(V);
                            break;
                        }

                    }
                    int seeRole = random.Next(allLife.Count);
                    Console.WriteLine("Je sais que " + allLife.ElementAt(seeRole).name + " est " + allLife.ElementAt(seeRole).role);

                }
            }
            //si la voyante est morte
            if (VoyanteIsDead == true)
            {
                Console.WriteLine("Votre joker est mort");
            }

        }

    }
}
