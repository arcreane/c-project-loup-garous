using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Game
    {
        
        bool allDead = false;
        bool allLgDead = false;
        private Random random = new Random();
        Village townInit = new Village();

        List<Personnages> town = new List<Personnages>();
        List<Personnages> allLife = new List<Personnages>();
        List<Personnages> isDead = new List<Personnages>();
        List<Personnages> allLifeDefences = new List<Personnages>();
        bool JokerActive = true;
        BoucEmissaire scapegoat;
        Cupidon cupid;
        Sorcière witch;
        Voleur thief;
        Voyante clairvoyant;
        
        ///CREATION ET AJOUT DE LA LIST DU VILLAGES
        ///ET ATTRIBUTION DES NAMES ALEATOIRES
        public void createGame()
        {
            townInit.initVillage(town);
            cupid = townInit.getCupid();
            witch = townInit.getWitch();
            thief = townInit.getThief();
            clairvoyant = townInit.getClairvoyant();
            scapegoat = townInit.getScapegoat();
        }

        public void votePlayer()
        {
            Console.WriteLine("choississez une personne que vous souhaitez tuer ou votez blanc \"Blanc\"");
                string vote = Console.ReadLine();
                bool badVote = true;
                bool findVote = false;
                while (badVote) {

                    if (vote == "Blanc")
                    {
                        Console.WriteLine("Vous avez decidez de ne votez personne");
                        badVote = false;
                        break;
                    }
                    for (int l = 0; l < allLife.Count; l++)
                    {
                        if (vote == allLife.ElementAt(l).name)
                        {
                            findVote = true;
                            badVote = false;
                            if (allLife.ElementAt(l).inLife == true)
                            {
                                if (allLife.ElementAt(l).role == "Loup-Garous")
                                {
                                    Console.WriteLine("Vous gagnez un nouveau joker");
                                    JokerActive = true;
                                }
                                if (allLife.ElementAt(l).inLove != null)
                                {
                                    string role = allLife.ElementAt(l).inLove.role;
                                    string name = allLife.ElementAt(l).inLove.name;
                                    allLife.ElementAt(l).inLife = false;
                                    allLife.ElementAt(l).inLove = null;
                                    isDead.Add(allLife.ElementAt(l));
                                    Console.WriteLine("Vous avez decidez d'éliminer " + allLife.ElementAt(l).name + " qui était " + allLife.ElementAt(l).role);
                                    Console.WriteLine("Par le chagrin de perdre son ame soeur " + name + " decide de mettre fin à ces jours et qui était " + role);
                                    for(int n = 0; n < allLife.Count; n++)
                                    {
                                        if (allLife.ElementAt(n).name == name)
                                        {
                                        isDead.Add(allLife.ElementAt(n));
                                        allLife.ElementAt(n).inLife = false;
                                        allLife.ElementAt(n).inLove = null;
                                        allLife.RemoveAt(n);
                                        allLife.RemoveAt(l);
                                        break;
                                        }   
                                    }
                                   
                                }
                                else
                                {
                                    allLife.ElementAt(l).inLife = false;
                                    Console.WriteLine("Vous avez decidez d'éliminer " + allLife.ElementAt(l).name + " qui était " + allLife.ElementAt(l).role);
                                    isDead.Add(allLife.ElementAt(l));
                                    allLife.RemoveAt(l);
                                }
                            }
                        }
                    }
                    if (!findVote)
                    {
                        Console.WriteLine("La personne à soit était deja etait tuer soit tu as mal ecris le nom");
                        Console.WriteLine("choissisez le personnage à voter ou appuyer sur Blanc pour ne pas voter ");
                        vote = Console.ReadLine();
                    }
                }
        }

        private void interrogatory()
        {
            List<Personnages> allLifeDefences = new List<Personnages>(allLife);
            bool skip = false;
            for (int i = 0; i < 5; i++)
            {   
                if (skip)
                {
                    break;
                }
                Console.WriteLine("choissisez le personnage à interroger ou appuyer sur V pour passer au vote ");
                string namePerso = Console.ReadLine();
                bool badInterogate = true;
                bool findVilagers = false;
                if (namePerso == "V")
                {
                    break;
                }
                while (badInterogate)
                {
                    if (namePerso == "V")
                    {
                        skip = true;
                        break;
                    }
                    for (int l = 0; l < allLifeDefences.Count; l++)
                    {

                        if (namePerso == allLifeDefences.ElementAt(l).name)
                        {
                            findVilagers = true;
                            badInterogate = false;
                            ///Si il n'y a plus de defences renvois un message par default
                            ///Sinon affiche la deffence et la supprime de la list
                            if (allLifeDefences.ElementAt(l).defense.Count == 0)
                            {
                                Console.WriteLine("Je ne veux plus vous parler");
                                allLifeDefences.RemoveAt(l);
                                break;
                            }
                            else
                            {
                                int generatedIndex = random.Next(allLifeDefences.ElementAt(l).defense.Count);
                                Console.WriteLine(allLifeDefences.ElementAt(l).defense.ElementAt(generatedIndex));
                                allLife.ElementAt(l).defense.RemoveAt(generatedIndex);
                                allLifeDefences.RemoveAt(l);
                                break;
                            }
                        }
                    }
                    ///MESSAGE D ERREUR SI AUCUNE VALIDATION DANS LES VERIFICTION PRECEDENTES
                    if (!findVilagers)
                    {
                        Console.WriteLine("La personne à soit était interroger soit tu as mal ecris le nom");
                        Console.WriteLine("choissisez le personnage à interroger ou appuyer sur V pour passer au vote ");
                        namePerso = Console.ReadLine();
                    }
                }


            }
        }

        private void useJoker() 
        {
            if (JokerActive)
            {
                Console.WriteLine("Vous avez un joker voulez vous l'utiliser");
                Console.WriteLine("Y = yes / N = no");
                string UseJoker = Console.ReadLine();
                bool chooseAswer = false;
                if (UseJoker == "Y")
                {
                    chooseAswer = true;
                    JokerActive = false;
                    int generatedIndex = random.Next(3);
                    switch (generatedIndex)
                    {
                        case 0:

                            witch.joker(allLife, isDead);

                            break;
                        case 1:
                            clairvoyant.joker(allLife);
                            break;

                        case 2:
                            thief.joker(allLife);
                            break;
                    }

                }
                else if (UseJoker == "N")
                {
                    chooseAswer = true;
                    Console.WriteLine("Vous n'utiliserais pas de joker aujourd'hui");
                }
                if (!chooseAswer)
                {
                    Console.WriteLine("Tu as ecrit autre chose tu auras une autre chance demain");
                }

            }
        }

        public void killLG()
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
                    if (allLife.ElementAt(i).inLove != null)
                    {
                        string role = allLife.ElementAt(i).inLove.role;
                        string name = allLife.ElementAt(i).inLove.name;
                        allLife.ElementAt(i).inLife = false;
                        allLife.ElementAt(i).inLove = null;
                        isDead.Add(allLife.ElementAt(i));
                        Console.WriteLine("Vous avez decidez d'éliminer " + allLife.ElementAt(i).name + " qui était " + allLife.ElementAt(i).role);
                        Console.WriteLine("Par le chagrin de perdre son ame soeur " + name + " decide de mettre fin à ces jours et qui était " + role);
                        for (int n = 0; n < allLife.Count; n++)
                        {
                            if (allLife.ElementAt(n).name == name)
                            {
                                isDead.Add(allLife.ElementAt(n));
                                allLife.ElementAt(n).inLife = false;
                                allLife.ElementAt(n).inLove = null;
                                allLife.RemoveAt(n);
                                allLife.RemoveAt(i);
                                break;
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

        /// DIFFERENTE METHOD UTILISE

        public void Play()
        {
           this.allLife = new List<Personnages>(town);
           this.isDead = new List<Personnages>();
           this.allLifeDefences = new List<Personnages>(allLife);
           this.JokerActive = true;

            ///MIS EN COUPLE DE DEUX VILLAGEOIS
            cupid.cupidPlay(allLife);

            useJoker();


            Console.WriteLine("Vous êtes le maire du village");
            Console.WriteLine("Il y a 15 villageois, parmis eux il y a 3 loup-garous, une sorcière, un voleur, une voyante, un cupidon, un bouc émissaire.");
            while (allDead == false)
            {
               
                Console.WriteLine("\nVoici les villageois en vies :");
                List<Personnages> allLifeRandomzie = new List<Personnages>(allLife);
                for(int r = 0; 0 < allLifeRandomzie.Count; r++)
                {
                    int generatedIndex = random.Next(allLifeRandomzie.Count);
                    Console.WriteLine(allLifeRandomzie.ElementAt(generatedIndex).name);
                    allLifeRandomzie.RemoveAt(generatedIndex);

                };
                
                ///ETAPES DE L INTEROGATOIRE
                interrogatory();

                ///ETAPE DU VOTE POUR TUER UNE PERSONNE DU VILLAGE
                ///AJOUT DE JOKER
                ///ELIMINATION DES PERSONNES ET AUSSI DU COUPLE

                votePlayer();

                ///VERIFICATION DES LOUPS GAROUS VIVANTS
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
                ///ELIMINATION DES LOUPS GAROUS
                ///
                ///PREMIERE ETAPES ON ENLEVE LES LOUPS GAROUS DES ALL LIFE
                ///DEUXIEME ETAPES ON PREND UN VILLAGEOIS ALEATOIRES
                ///ET ON CHECK SI EST EN COUPLE
                ///ELIMINATION DU VILLAGEOIS
                killLG();

                ///Deuxieme Verification au cas ou c etait le derniere villageois
                List<Personnages> gameOverCheck = new List<Personnages>(allLife);
                for (int l = 0; l < 3; l++)
                {
                    for (int i = 0; i < gameOverCheck.Count; i++)
                    {
                        if (gameOverCheck.ElementAt(i).role == "Loup-Garous")
                        {
                            gameOverCheck.RemoveAt(i);
                            break;
                        }
                    }
                }


                /// Game Over

                if (gameOverCheck.Count == 0)
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
