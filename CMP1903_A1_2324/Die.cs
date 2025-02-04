﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Class <c>Die</c> creates a Dice object that can generate a random number between 1 and 6
    /// </summary>
    internal class Die
    {
        /// <summary>
        /// The <c>Random</c> object used by the <c>Roll()</c> function
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Represents the die's current value
        /// </summary>
        public int DieValue { get; private set; }

        /// <summary>
        /// Randomly generates a new value between 1 and 6 (inclusive) and updates <c>DieValue</c> accordingly
        /// </summary>
        /// <returns>The Die's new value, also accessible using <c>DieValue</c></returns>
        public int Roll()
        {
            // Generate new random number, between 1-6 (maxValue is non-inclusive so it is 7
            DieValue = _random.Next(minValue: 1, maxValue: 7);
            
            // Return new value
            return DieValue;
        }
    }
}
