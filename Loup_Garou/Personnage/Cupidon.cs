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

        public void cupidonPlay(List<Personnages> allLife)
        {
            Console.WriteLine("Cupidon va choisir deux ames soeurs");
            int generatedIndexOne = random.Next(allLife.Count);
            int generatedIndexTwo = random.Next(allLife.Count);
            bool wrongRandom = true;
            while (wrongRandom)
            {
                if(generatedIndexOne == generatedIndexTwo)
                {
                    generatedIndexTwo = random.Next(allLife.Count);
                }
                else
                {
                    allLife.ElementAt(generatedIndexOne).inLove = allLife.ElementAt(generatedIndexTwo);
                    allLife.ElementAt(generatedIndexTwo).inLove = allLife.ElementAt(generatedIndexOne);
                    for (int l = 0; l < 2; l++)
                    {
                        int generatedIndexDefencesOne = random.Next(allLife.ElementAt(generatedIndexOne).defense.Count);
                        int generatedIndexDefencesTwo = random.Next(allLife.ElementAt(generatedIndexTwo).defense.Count);
                        allLife.ElementAt(generatedIndexOne).defense.RemoveAt(generatedIndexDefencesOne);
                        allLife.ElementAt(generatedIndexTwo).defense.RemoveAt(generatedIndexDefencesTwo);
                    }

                    allLife.ElementAt(generatedIndexOne).defense.Add("Je suis amoureux");
                    allLife.ElementAt(generatedIndexTwo).defense.Add("Je suis amoureux");
                    allLife.ElementAt(generatedIndexOne).defense.Add("Je suis lié à une autre personne");
                    allLife.ElementAt(generatedIndexTwo).defense.Add("Je suis lié à une autre personne");
                    Console.WriteLine(allLife.ElementAt(generatedIndexOne).name);
                    Console.WriteLine(allLife.ElementAt(generatedIndexTwo).name);
                    break;

                }

            }

                    
        }


    }
}
