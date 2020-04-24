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
        List<string> name = new List<string>() { "Macron", "Trump", "Kim Jong-un", "Aya Nakamura", "Ninho", "Bad Bunny", "Booba", "Kaaris", "Dominique", "Ariana", "Angèle", "Obama", "Steve Job", "Elon Musk", "Marge Simpson" };

        List<Personnages> village = new List<Personnages>();
        List<Personnages> allLife = new List<Personnages>();
        List<Personnages> isDead = new List<Personnages>();
        List<Personnages> allLifeDefences = new List<Personnages>();
        bool JokerActive = true;
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
        ///CREATION ET AJOUT DE LA LIST DU VILLAGES
        ///ET ATTRIBUTION DES NAMES ALEATOIRES
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
            }
        }

        private void cupidonPlay()
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
                                if (allLife.ElementAt(l).inLove == true)
                                {
                                    string role = allLife.ElementAt(l).role;
                                    string name = allLife.ElementAt(l).name;
                                    allLife.ElementAt(l).inLife = false;
                                    allLife.ElementAt(l).inLove = false;
                                    isDead.Add(allLife.ElementAt(l));
                                    allLife.RemoveAt(l);
                                    for (int n = 0; n < allLife.Count; n++)
                                    {
                                        if (allLife.ElementAt(n).inLove == true)
                                        {
                                            allLife.ElementAt(n).inLife = false;
                                            allLife.ElementAt(n).inLove = false;
                                            Console.WriteLine("Vous avez decidez d'éliminer " + name + " qui était " + role);
                                            Console.WriteLine("Par le chagrin de perdre son ame soeur " + allLife.ElementAt(n).name + " decide de mettre fin à ces jours et qui était " + allLife.ElementAt(n).role);
                                            isDead.Add(allLife.ElementAt(l));
                                            allLife.RemoveAt(n);
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


                            break;
                        case 1:
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

                            break;

                        case 2:
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

        private void killLG()
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

        public void Play()
        {
           this.allLife = new List<Personnages>(village);
           this.isDead = new List<Personnages>();
           this.allLifeDefences = new List<Personnages>(allLife);
           this.JokerActive = true;

            ///MIS EN COUPLE DE DEUX VILLAGEOIS
            cupidonPlay();

            useJoker();


            Console.WriteLine("Vous êtes le maire du village");
            Console.WriteLine("Il y a 15 villageois, parmis eux il y a 3 loup-garous, une sorcière, un voleur, une voyante, un cupidon, un bouc émissaire.");
            while (allDead == false)
            {
                Console.WriteLine("\nVoici les villageois en vies :");
                allLife.ForEach((villageois) =>
                {
                    Console.WriteLine(villageois.name);
                });
                
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
