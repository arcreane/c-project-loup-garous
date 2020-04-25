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
            bool playGame = true;
            while (playGame)
            {
                ///Debut du jeu
                Console.WriteLine("Bonjour et bienvenue dans le village de Panam");
                Console.WriteLine("Choissiez entre: \n 1 - Jouez \n 2 - Regle\n 3 - Quittez le jeu");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Game game = new Game();
                    game.createGame();
                    game.Play();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Voici les regles");
                    Rules rules = new Rules();
                    rules.allRules();
                    Console.WriteLine("\n\n\n1 - Jouez \n2 - Quittez le jeu ");
                    choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Game game = new Game();
                        game.createGame();
                        game.Play();
                    }
                    else if(choice == "2")
                    {
                        playGame = false;
                        break;
                    }
                }
                else if (choice == "3")
                {
                    playGame = false;
                    break;
                }
            }
           
        }
    }
}
