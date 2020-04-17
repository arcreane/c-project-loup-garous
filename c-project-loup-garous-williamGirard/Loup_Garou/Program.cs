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

            }
            else
            {
                Console.WriteLine("fuck");
            }
        }
    }
}
