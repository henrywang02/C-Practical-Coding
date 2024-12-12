using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace T1_School_number
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true) // Infinite loop to continuously ask for input
            {
                // Ask for input
                Console.Write("Give Points (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                // Allow the user to exit the program by typing 'exit'
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting Program...");
                    break; // Break the loop and exit the program
                }

                // Try to convert the input into an integer
                if (int.TryParse(input, out int score))
                {
                    int grade;

                    // Assign grade based on the score range
                    if (score >= 0 && score <= 19)
                    {
                        grade = 0;
                    }
                    else if (score >= 20 && score <= 29)
                    {
                        grade = 1;
                    }
                    else if (score >= 30 && score <= 39)
                    {
                        grade = 2;
                    }
                    else if (score > 40 && score <= 49)
                    {
                        grade = 3;
                    }
                    else if (score > 50 && score <= 59)
                    {
                        grade = 4;
                    }
                    else if (score > 60 && score <= 70)
                    {
                        grade = 5;
                    }
                    else
                    {
                        // Handle out-of-range scores
                        Console.WriteLine("The score must be between 0 and 70.");
                        return;
                    }

                    // Output the grade
                    Console.WriteLine($"Your grade is: {grade}");
                }
                else
                {
                    // Handle invalid input
                    Console.WriteLine("Please enter a valid number.");
                }

                // Wait for the user to press a key before closing the program
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
