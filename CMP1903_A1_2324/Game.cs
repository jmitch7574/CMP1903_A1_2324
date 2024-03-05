using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    
    /// <summary>
    /// A class that creates our three dice and manages logic for rolling them
    /// </summary>
    internal class Game
    {
        // Dice Objects
        public readonly Die Die1 = new Die();
        public readonly Die Die2 = new Die();
        public readonly Die Die3 = new Die();

        /// <summary>
        /// The sum of the latest set of dice rolls
        /// </summary>
        public int Sum = 0;
        
        /// <summary>
        /// The sum of every dice roll
        /// </summary>
        public int RunningSum = 0;
        

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
                
                // Output roll resutls
                this.OutputInfo();
                
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
        
        // This function has been refactored in line with feedback gathered in the code review

        /// <summary>
        /// Rolls three dice
        /// Calculates the sum of the three rolls
        /// Updates the running total
        /// Updates the <c>States</c> object with this information
        /// </summary>
        public void RollThreeDice()
        {
            Die1.Roll();
            Die2.Roll();
            Die3.Roll();

            int[] rolls = { Die1.DieValue, Die2.DieValue, Die3.DieValue };
            Sum = rolls.Sum();
            
            RunningSum += Sum;
        }
        
        /// <summary>
        /// Outputs Info for current set of rolls
        /// </summary>
        void OutputInfo()
        {
            Console.WriteLine($"Dice 1: {Die1.DieValue}");
            Console.WriteLine($"Dice 2: {Die2.DieValue}");
            Console.WriteLine($"Dice 3: {Die3.DieValue}");
            Console.WriteLine($"Total for this roll: {Sum}");
            Console.WriteLine($"Total overall: {RunningSum}");
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
