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
        public Cupidon(String name) : base(name) { }

        public override List<string> defense { get; set; } = new List<string>() { "je suis un personnage meetic", "j’adore jouer aux fléchettes", "je me prépare pour aller en soirée avec les autres villageois", "Je me balade seul le soir" };

        public override string role { get; set; } = "Cupidon";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        public void cupidonPlay(List<Personnages> allLife)
        {
            Console.WriteLine("Cupidon va choisir deux ames soeurs");
            for (int i = 0; i < 2; i++)
            {
                bool isLove = true;
                while (isLove)
                {
                    isLove = false;
                    int generatedIndex = random.Next(allLife.Count);

                    if (allLife.ElementAt(generatedIndex).inLove == true)
                    {
                        isLove = true;
                        continue;
                    }

                    allLife.ElementAt(generatedIndex).inLove = true;

                    for (int l = 0; l < 2; l++)
                    {
                        int generatedIndexDefences = random.Next(allLife.ElementAt(generatedIndex).defense.Count);
                        allLife.ElementAt(generatedIndex).defense.RemoveAt(generatedIndexDefences);
                    }

                    allLife.ElementAt(generatedIndex).defense.Add("Je suis amoureux");
                    allLife.ElementAt(generatedIndex).defense.Add("Je suis lié à une autre personne");
                }


            }
        }


    }
}
