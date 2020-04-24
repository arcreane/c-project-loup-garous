using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Debut du jeu
            Console.WriteLine("Bonjour et bienvenue dans le village de Panam");
            Console.WriteLine("Choissiez entre: \n 1 - Jouez \n 2 - Regle");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Game game =new Game();
                game.createGame();
                game.Play();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Voici les regles");
                Rules rules = new Rules();
                rules.allRules();
                Console.WriteLine("\n\n\nLancez le jeu 1");
                choice = Console.ReadLine();
                if(choice == "1")
                {
                    Game game = new Game();
                    game.createGame();
                    game.Play();
                }
                


            }
        }
    }
}
