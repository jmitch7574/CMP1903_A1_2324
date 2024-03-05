using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Creates a <c>Game</c> class and checks that the arithmetic logic inside the functions is correct
    /// </summary>
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */
        
        
        /// <summary>
        /// Creates a <c>Die</c> object and runs <see cref="Die.Roll()"/> 100,000 to test if values are valid. 
        /// Uses Debug.Assert() to check dice value is between 1-6 and throws error if value is outside range.
        /// </summary>
        /// 
        public void TestDie()
        {
            // Create a new Die object to test
            Die die = new Die();
            
            // Loop 100,000 times to check if Die object only produces valid values
            // 100,000 loops should be enough to make the chance of a false-positive practically 0
            for (int i = 0; i < 100000; i++)
            {
                // Rolls the Die
                die.Roll();
                
                // Uses Debug.Assert() to confirm DieValue remains between 1-6
                // Split into two instances in line with code feedback
                Debug.Assert(1 <= die.DieValue, "Die value outside lower range");
                Debug.Assert(6 >= die.DieValue, "Die value outside upper range");
            }
            Console.WriteLine("Completed Dice Class Check");
        }

        /// <summary>
        /// Creates a <c>Game</c> object and runs <see cref="Game.RollThreDice()"/> 1000 times.
        /// Each time it is run it will check the values reported by the Game class and check they are correct
        /// </summary>
        public void TestGame()
        {
            // Create new game object and run playgame
            Game testGame = new Game();
            
            // Initialise a variable that contains the total from the previous state
            int oldRunningSum = 0;
            
            // Loop through all state saves generated during PlayGame()
            for (int turn = 0; turn < 1000; turn++)
            {
                // Roll three dice
                testGame.RollThreeDice();
                
                // Split the state tuple into different variables
                int[] rolls = new []{testGame.Die1.DieValue, testGame.Die2.DieValue, testGame.Die3.DieValue};
                int sum = testGame.Sum;
                
                // Use Debug.Assert() to validate that the Sum() and new running sum are calculated correctly
                Debug.Assert(rolls.Sum() == sum, "Reported Sum of rolls does not match actual sum of rolls");
                Debug.Assert(testGame.RunningSum == oldRunningSum + rolls.Sum(), "Reported running sum does not match actual running sum");

                // Update the old running total for the next loop
                oldRunningSum = testGame.RunningSum;
            }
            
            Console.Write("Completed Game Class Check");
        }
        
    }
}
