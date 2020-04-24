using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Sorcière : Personnages
    {
        private Random random = new Random();
        public Sorcière(String Name) : base(Name) { }


        public override List<string> defense { get; set; } = new List<string>() { "je porte un chapeau pour me rendre beau", "je suis là pour vous jouer de mauvais tours !", "je me balade le soir", "je me prépare pour aller en soirée avec les autres villageois" };

        public override string role { get; set; } = "Sorcière";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        public void joker(List<Personnages> allLife, List<Personnages> isDead)
        {
            /// Partie de Nouhailla 
            Console.WriteLine("Joker Sorciere");
            // on vérifie si c'est bien la sorcière et qu'elle est envie 
            bool isSorciereDead = true;
            for (int l = 0; l < allLife.Count; l++)
            {
                if (allLife.ElementAt(l).role == "Sorcière")
                {
                    // si elle n'est pas morte alors on lance son jocker 
                    isSorciereDead = false;

                    List<Personnages> isDeadWithoutLG = new List<Personnages>(isDead);
                    // on ne veut pas que les loup garoup revive
                    for (int a = 0; a < 3; a++)
                    {
                        for (int i = 0; i < isDeadWithoutLG.Count; i++)
                        {
                            if (isDeadWithoutLG.ElementAt(i).role == "Loup-Garous")
                            {
                                isDeadWithoutLG.RemoveAt(i);
                                break;
                            }
                        }

                    }
                    if (isDeadWithoutLG.Count == 0)
                    {
                        Console.WriteLine("Il n'y a personne a sauvé dommage");
                    }
                    else
                    {
                        int generatedIndexisDead = random.Next(isDeadWithoutLG.Count);
                        string name = isDeadWithoutLG.ElementAt(generatedIndexisDead).name;
                        isDead.ElementAt(generatedIndexisDead).inLife = true;
                        allLife.Add(isDead.ElementAt(generatedIndexisDead));
                        isDead.RemoveAt(generatedIndexisDead);
                        isDeadWithoutLG.RemoveAt(generatedIndexisDead);
                        Console.WriteLine("Cette personne est sauvé " + name);
                    }






                }
            };
            if (isSorciereDead == true)
            {
                Console.WriteLine("Le jocker Sorcière est mort");
            };
        }
        }
}
