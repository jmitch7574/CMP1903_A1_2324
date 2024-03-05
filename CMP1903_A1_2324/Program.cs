using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        // This function has been rewritten with process selection in mind
        
        /// <summary>
        /// Main function that manages and calls program logic
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a new testing object, test the Die and test the Game
            Testing test = new Testing();
            test.TestDie();
            test.TestGame();
            
            // Creates a game class and plays the game
            Game game = new Game();
            game.PlayGame();
        }

    }
}
