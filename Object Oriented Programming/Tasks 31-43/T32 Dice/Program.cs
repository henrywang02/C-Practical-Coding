using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T32_Dice
{
    class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        // Method to roll the dice
        public int Roll()
        {
            return random.Next(1, 7); // Generates a number between 1 and 6
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Dice dice = new Dice();

                // Step 1: Test roll
                int testRoll = dice.Roll();
                Console.WriteLine($"Dice, one test throw value is {testRoll}\n");

                // Step 2: Ask user for number of throws
                Console.Write("How many times you want to throw a dice: ");
                if (int.TryParse(Console.ReadLine(), out int numberOfThrows) && numberOfThrows > 0)
                {
                    int sum = 0;
                    int[] counts = new int[6]; // To store the occurrences of each value (1-6)

                    // Step 3: Roll the dice multiple times and keep track of the results
                    for (int i = 0; i < numberOfThrows; i++)
                    {
                        int roll = dice.Roll();
                        sum += roll;
                        counts[roll - 1]++; // Increment the count for the rolled value
                    }

                    // Calculate average
                    double average = (double)sum / numberOfThrows;
                    Console.WriteLine($"\nDice is now thrown {numberOfThrows} times, average is {average:F4}\n");

                    // Step 4: Print occurrences of each number
                    for (int i = 0; i < counts.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} count is {counts[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }

                Console.WriteLine("\nPress enter key to continue...");
                Console.ReadLine();
            }
        }
    }
}
