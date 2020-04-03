using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Game
    {
        bool allDead = false;
        bool allLgDead = false;
        private Random random = new Random();
        List<string> name = new List<string>() { "Macron", "Trump", "Kim Jong-un", "Aya Nakamura", "Ninho", "Bad Bunny", "Booba", "Kaaris", "Dominique", "Ariana", "Angèle", "Obama", "Steve Job", "Elon Musk", "Marge Simpson" };

        List<Personnages> village = new List<Personnages>();
        Villageois[] villageois;
        LoupGarou[] loupGarou;
        BoucEmissaire boucEmissaire;
        Cupidon cupidon;
        Sorcière sorcière;
        Voleur voleur;
        Voyante voyante;
        private String getName()
        {
            int generatedIndex = random.Next(name.Count);
            String personnageName = name.ElementAt(generatedIndex);
            name.RemoveAt(generatedIndex);
            return personnageName;
        }
        public static Game Instance
        {
            get
            {
                return new Game();
            }
        }
        public void createGame() 
        {
            boucEmissaire = new BoucEmissaire(getName());
            cupidon = new Cupidon(getName());
            sorcière = new Sorcière(getName());
            voleur = new Voleur(getName());
            voyante = new Voyante(getName());
            village.Add(boucEmissaire);
            village.Add(cupidon);
            village.Add(sorcière);
            village.Add(voleur);
            village.Add(voyante);
            Villageois[] villageois = new Villageois[7];
            for (int i = 0; i < 7; i++)
            {
                villageois[i] = new Villageois(getName());
                village.Add(villageois[i]);
            }
            LoupGarou[] loupGarou = new LoupGarou[3];
            for (int i = 0; i < 3; i++)
            {   
                loupGarou[i] = new LoupGarou(getName());
                village.Add(loupGarou[i]);
                Console.WriteLine(loupGarou[i].name);
            }

        }

        public void Play()
        {
            List<Personnages> allLife = new List<Personnages>(village);


            Console.WriteLine("Cupidon va choisir deux ames soeurs");
            for(int i = 0; i < 2; i++) 
            {
                int generatedIndex = random.Next(allLife.Count);
                allLife.ElementAt(generatedIndex).inLove = true;
                ///Ajouter deux defence disant qu ils sont amoureux et retirer deux
            }
            Console.WriteLine("Vous êtes le maire du village");
            Console.WriteLine("Il y a 15 villageois, parmis eux il y a 3 loup-garous, une sorcière, un voleur, une voyante, un cupidon, un bouc émissaire.");
            while (allDead == false) 
            {
                Console.WriteLine("\nVoici les villageois en vies :");
                allLife.ForEach((villageois) =>
                {
                    Console.WriteLine(villageois.name);
                });
                for ( int i = 0; i < 5; i++)
                {
                    Console.WriteLine("choissisez le personnage à interroger ou appuyer sur V pour passer au vote ");
                    string namePerso = Console.ReadLine();
                    if (namePerso == "V")
                    {
                        break;
                    }
                    for(int l = 0; l < allLife.Count; l++) 
                    {
                        if(namePerso == allLife.ElementAt(l).name) 
                        {
                            int generatedIndex = random.Next(allLife.ElementAt(l).defense.Count);
                            Console.WriteLine(allLife.ElementAt(l).defense.ElementAt(generatedIndex));
                            allLife.ElementAt(l).defense.RemoveAt(generatedIndex);
                            ///Mettre une securité pour dire qu il n a plus de defense
                        }
                        ///il peut tjr choisir deux fois la meme personne a interroger
                    }
                     
                }
                /// Faire une boucle infini si il fait le con
                Console.WriteLine("choississez une personne que vous souhaitez tuer");
                string vote = Console.ReadLine();
                for (int l = 0; l < allLife.Count; l++)
                {
                    if (vote == allLife.ElementAt(l).name)
                    {
                        if(allLife.ElementAt(l).inLife == true) 
                        {
                            if(allLife.ElementAt(l).inLove == true) 
                            {
                                string role = allLife.ElementAt(l).role;
                                string name = allLife.ElementAt(l).name;
                                allLife.ElementAt(l).inLife = false;
                                allLife.ElementAt(l).inLove = false;
                                allLife.RemoveAt(l);
                                for (int n = 0; n < allLife.Count; n++)
                                {
                                    if(allLife.ElementAt(n).inLove == true)
                                    {
                                        allLife.ElementAt(n).inLife = false;
                                        allLife.ElementAt(n).inLove = false;
                                        Console.WriteLine("Vous avez decidez d'éliminer " + name + " qui était " + role );
                                        Console.WriteLine("Par le chagrin de perdre son ame soeur " + allLife.ElementAt(n).name + " decide de mettre fin à ces jours et qui était " + allLife.ElementAt(n).role);
                                        allLife.RemoveAt(n);
                                    }
                                }
                            }
                            else
                            {
                                allLife.ElementAt(l).inLife = false;
                                Console.WriteLine("Vous avez decidez d'éliminer " + allLife.ElementAt(l).name + " qui était " + allLife.ElementAt(l).role);
                                allLife.RemoveAt(l);
                            }
                        }
                    }
                }
                ///Verification que tout les loups garous sont en vie
                allLgDead = true;
                allLife.ForEach((villageois) =>
                {
                    if(villageois.role == "Loup-Garous") 
                    {
                        allLgDead = false;
                    }
                });
                if (allLgDead == true)
                {
                    break;
                }
                Console.WriteLine("Le village s'endore \n\n\n");
                /// l'elimination du loup garou
                List<Personnages> allLifeWithoutLG = new List<Personnages>(allLife);
                /// language stupide
                for(int l = 0; l < 3; l++)
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
                for(int i = 0; i < allLife.Count; i++)
                {
                    if(allLife.ElementAt(i).name == allLifeWithoutLG.ElementAt(generatedIndexLG).name) 
                    {
                        if(allLife.ElementAt(i).inLove == true)
                        {
                            string role = allLife.ElementAt(i).role;
                            string name = allLife.ElementAt(i).name;
                            allLife.ElementAt(i).inLife = false;
                            allLife.ElementAt(i).inLove = false;
                            allLife.RemoveAt(i);
                            for (int n = 0; n < allLife.Count; n++)
                            {
                                if (allLife.ElementAt(n).inLove == true)
                                {
                                    allLife.ElementAt(n).inLife = false;
                                    allLife.ElementAt(n).inLove = false;
                                    Console.WriteLine("Le Village se reveille sans " + name + " qui était " + role);
                                    Console.WriteLine("Par le chagrin de perdre son ame soeur " + allLife.ElementAt(n).name + " decide de mettre fin à ces jours et qui était " + allLife.ElementAt(n).role);
                                    allLife.RemoveAt(n);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Le Village se reveille sans " + allLife.ElementAt(i).name + " qui était " + allLife.ElementAt(i).role);
                            allLife.RemoveAt(i);
                        }
                        
                    }
                }
                

                /// Game Over

                if(allLifeWithoutLG.Count == 0)
                {
                    allDead = true;
                }
            }
            if (allDead == true) 
            {
                Console.WriteLine("vous avez perdu");
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("vous avez gagné");
                Console.ReadLine();
            }




        }
    }
}
