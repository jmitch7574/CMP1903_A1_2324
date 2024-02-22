using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new testing object, test the Die and test the Game
            Testing test = new Testing();
            test.TestDie();
            test.TestGame();
        }
    }
}
