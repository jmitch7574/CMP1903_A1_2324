using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        // Dice Objects
        private readonly Die _die1 = new Die();
        private readonly Die _die2 = new Die();
        private readonly Die _die3 = new Die();

        /// <summary>
        /// The sum of the latest set of dice rolls
        /// </summary>
        private int _sum = 0;
        
        /// <summary>
        /// The sum of every dice roll
        /// </summary>
        private int _runningSum = 0;
        
        /// <summary>
        /// A list of tuples that tracks dice information
        /// Each tuple represents a set of 3 dice rolls
        /// Each tuple contains the three values that were rolled, the sum of the three rolls and the running sum when the three die were rolled
        /// </summary>
        public List<(int[], int, int)> States = new List<(int[], int, int)>();
        

        /// <summary>
        /// Function that will repeatedly run our <c>RollThreeDice()</c>.
        /// Asks the user if program should keep rolling dice after each run
        /// </summary>
        public void PlayGame()
        {
            // Initialise variable for loop
            bool playing = true;

            // Keep rolling dice as long as we keep playing
            while (playing)
            {
                // Clear the console
                Console.Clear();
                
                // Roll the three dice
                this.RollThreeDice();
                
                // Ask user if program should keep rolling
                playing = ContinuePlaying();
            }

            // End game function
            EndGame();
        }
        
        /// <summary>
        /// A function that asks the user to keep playing as a yes no question
        /// </summary>
        /// <returns>true if the user wants to keep playing, false if the user does not</returns>
        private static bool ContinuePlaying()
        {
            while (true)
            {
                Console.WriteLine("Would you like to roll again? (y/n)");
                char input = Console.ReadKey().KeyChar;
                switch(input)
                {
                    case 'y':
                        return true;
                    case 'n':
                        return false;
                    default:
                        break;
                }                
            }
            
        }

        /// <summary>
        /// Rolls three dice
        /// Calculates the sum of the three rolls
        /// Updates the running total
        /// Outputs the information to console
        /// Updates the <c>States</c> object with this information
        /// </summary>
        void RollThreeDice()
        {
            _die1.Roll();
            _die2.Roll();
            _die3.Roll();

            int[] rolls = { _die1.DieValue, _die2.DieValue, _die3.DieValue };
            _sum = rolls.Sum();
            
            _runningSum += _sum;
            
            
            Console.WriteLine($"Dice 1: {_die1.DieValue}");
            Console.WriteLine($"Dice 2: {_die2.DieValue}");
            Console.WriteLine($"Dice 3: {_die3.DieValue}");
            Console.WriteLine($"Total for this roll: {_sum}");
            Console.WriteLine($"Total overall: {_runningSum}");

            States.Append((rolls, _sum, _runningSum));
        }

        /// <summary>
        /// Ends the game
        /// Clears the console
        /// Outputs a thank you message
        /// </summary>
        void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for Playing");
        }
    }
}
