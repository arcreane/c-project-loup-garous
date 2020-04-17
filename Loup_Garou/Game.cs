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
                Console.WriteLine(loupGarou[i].name);
            }

        }

        public void Play()
        {
            List<Personnages> allLife = new List<Personnages>(village);
            bool JokerActive = true;

            ///MIS EN COUPLE DE DEUX VILLAGEOIS
            Console.WriteLine("Cupidon va choisir deux ames soeurs");
            for(int i = 0; i < 2; i++) 
            {
                bool isLove = true;
                while (isLove)
                {
                    isLove = false;
                    int generatedIndex = random.Next(allLife.Count);

                    if(allLife.ElementAt(generatedIndex).inLove == true)
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
                    Console.WriteLine(allLife.ElementAt(generatedIndex).name);
                }
                ///Ajouter deux defences disant qu ils sont amoureux et retirer deux EFFECTUER
                ///patch deux fois le meme amoureux
             
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
                        Console.WriteLine(generatedIndex);
                        Console.ReadLine();
                        switch (generatedIndex)
                        {
                            case 0:
                                /// Partie de Nouhailla 
                                Console.WriteLine("Joker Sorciere");
                                break;
                            case 1:
                                /// Partie de Amanda
                                Console.WriteLine("Joker Voyante");
                                break;
                            case 2:
                                /// Partie de Clement
                                Console.WriteLine("Joker Voleur");
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
                ///ETAPES DE L INTEROGATOIRE
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
                ///ETAPE DU VOTE POUR TUER UNE PERSONNE DU VILLAGE
                ///AJOUT DE JOKER
                ///ELIMINATION DES PERSONNES ET AUSSI DU COUPLE
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
                                    allLife.RemoveAt(l);
                                    for (int n = 0; n < allLife.Count; n++)
                                    {
                                        if (allLife.ElementAt(n).inLove == true)
                                        {
                                            allLife.ElementAt(n).inLife = false;
                                            allLife.ElementAt(n).inLove = false;
                                            Console.WriteLine("Vous avez decidez d'éliminer " + name + " qui était " + role);
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
                    if (!findVote)
                    {
                        Console.WriteLine("La personne à soit était deja etait tuer soit tu as mal ecris le nom");
                        Console.WriteLine("choissisez le personnage à voter ou appuyer sur Blanc pour ne pas voter ");
                        vote = Console.ReadLine();
                    }
                }   
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
                List<Personnages> allLifeWithoutLG = new List<Personnages>(allLife);
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
                    if(allLifeWithoutLG.Count == 0)
                    {
                        break;
                    }
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
