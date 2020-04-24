using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Rules
    {
        public void allRules()
        {
            Console.WriteLine("Le joueur est le maire du village et décide de qui doit mourir la journée\n");
            Console.WriteLine("le village ce compose de 15 villageois parmis ces 15 villageois il y a 3 loup garou et 12 villageois.\n");
            Console.WriteLine("chaque nuit les loups tue une personne au hasard.\n");
            Console.WriteLine("Le joueur a le droit a un joker aléatoire au début du jeu, si il tue un loup le joueur obtient un nouveau joker\n");

            Console.WriteLine("Les joker sont:\n" +
                "la voyante (elle le rôle d'un personne dans le village)\n" +
                "sorcière (peut réanimé un joueur qui a été tuer.)\n" +
                "Voleur (échanger les cartes)\n");
            Console.WriteLine("Le joueur gagne lorsque ous les loup garou sont morts\n");


            Console.WriteLine("Chaque rôle aura 4 défenses et ne pourront pas utilisé deux fois la même.\n");

            Console.WriteLine("Le village est composés de: \n" +
                "1 voleur\n" +
                "(je me balade le soir,\n" +
                "je me déplace en silence,\n" +
                "je vais voler votre bourses,\n" +
                "je me prépare pour aller en soirée avec les autres villageois)\n" +
                "1 sorcière\n" +
                " je porte un chapeau pour me rendre beau, \n" +
                "je suis là pour vous jouer de mauvais tours!, \n" +
                "je me balade le soir,\n" +
                "je me prépare pour aller en soirée avec les autres villageois\n" +
                "1 Voyante\n" +
                "je vois des choses que d’autres ne voient pas, \n" +
                "je me balade seul le soir,\n" +
                "je me prépare pour aller en soirée avec les autres villageois\n" +
                "je parle aux objet\n" +
                "1 cupidon\n" +
                "Je me balade seul le soir,\n" +
                "je me prépare pour aller en soirée avec les autres villageois,\n" +
                "j’adore jouer aux fléchettes,\n" +
                "je suis un personnage meetic\n" +
                "1 Bouc émissaire\n" +
                "Je me balade seul le soir,\n" +
                "Je n’aime pas le village,\n" +
                "Je ne veux pas vous répondre,\n" +
                "Je vais tous vous tuer!\n" +
                "Les autres villageois\n" +
                "je me prépare pour aller en soirée avec les autres villageois,\n" +
                "Viens faire la fête avec nous!,\n" +
                "Tu me payes quand le Mcdo ??,\n" +
                "Wesh la famille ca dit quoi ?\n" +
                "Les loup garou\n" +
                "je me prépare pour aller en soirée avec les autres villageois,\n" +
                "Je me balade seul le soir,\n" +
                "Je vais tous vous tuer!,\n" +
                "Je ne veux pas vous répondre\n");
            Console.WriteLine("Le joueur choisit le personnage qu'il veut intérroger.\n" +
                "Il a le droit a 5 question par jour et 1 question par villageois et par jour\n");

            Console.WriteLine("Une fois que les 4 défenses seront utilisés il ne pourront plus l'interroger mais le voter pour l'exécuter.\n");
        }
    }
}
