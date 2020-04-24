using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class LoupGarou : Personnages
    {
        private Random random = new Random();
        public LoupGarou(String name) : base(name){ }

        public override List<string> defense { get; set; } = new List<string>() { "je me prépare pour aller en soirée avec les autres villageois", "Je me balade seul le soir", "Je vais tous vous tuer !", "Je ne veux pas vous répondre" };

        public override string role { get; set; } = "Loup-Garous";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        public void killLG(List<Personnages> allLife, List<Personnages> isDead)
        {
            List<Personnages> allLifeWithoutLG = new List<Personnages>(allLife);
            for (int l = 0; l < 3; l++)
            {
                for (int i = 0; i < allLifeWithoutLG.Count; i++)
                {
                    if (allLifeWithoutLG.ElementAt(i).role == "Loup-Garous")
                    {
                        allLifeWithoutLG.RemoveAt(i);
                        break;
                    }
                }
            }

            int generatedIndexLG = random.Next(allLifeWithoutLG.Count);
            for (int i = 0; i < allLife.Count; i++)
            {
                if (allLifeWithoutLG.Count == 0)
                {
                    break;
                }
                if (allLife.ElementAt(i).name == allLifeWithoutLG.ElementAt(generatedIndexLG).name)
                {
                    if (allLife.ElementAt(i).inLove == true)
                    {
                        string role = allLife.ElementAt(i).role;
                        string name = allLife.ElementAt(i).name;
                        allLife.ElementAt(i).inLife = false;
                        allLife.ElementAt(i).inLove = false;
                        isDead.Add(allLife.ElementAt(i));
                        allLife.RemoveAt(i);
                        for (int n = 0; n < allLife.Count; n++)
                        {
                            if (allLife.ElementAt(n).inLove == true)
                            {
                                allLife.ElementAt(n).inLife = false;
                                allLife.ElementAt(n).inLove = false;
                                Console.WriteLine("Le Village se reveille sans " + name + " qui était " + role);
                                Console.WriteLine("Par le chagrin de perdre son ame soeur " + allLife.ElementAt(n).name + " decide de mettre fin à ces jours et qui était " + allLife.ElementAt(n).role);
                                isDead.Add(allLife.ElementAt(n));
                                allLife.RemoveAt(n);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le Village se reveille sans " + allLife.ElementAt(i).name + " qui était " + allLife.ElementAt(i).role);
                        isDead.Add(allLife.ElementAt(i));
                        allLife.RemoveAt(i);
                    }

                }
            }
        }
    }
}
