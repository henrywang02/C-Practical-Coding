using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_Hill_jumping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numberOfJudges = 5;
            int[] points = new int[numberOfJudges];
            
            // Loop to get the input from the user
            for (int i = 0; i < numberOfJudges; i++)
            {
                while (true)
                {
                    Console.Write($"Give points from judge {i + 1}: ");
                    string input = Console.ReadLine();

                    // Validate that the input is a valid integer
                    if (int.TryParse(input, out int point))
                    {
                        points[i] = point;
                        break; // Exit the inner loop when a valid number is provided
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
            }

            // Calculate the sum of points
            int totalPoints = 0;
            foreach (int point in points)
            {
                totalPoints += point;
            }

            // Subtract the smallest and largest points
            int smallest = points[0];
            int largest = points[0];

            foreach (int point in points) 
            {
                if (point < smallest)
                {
                    smallest = point;
                }

                if (point > largest)
                {
                    largest = point;
                }
            }

            // Calculate the final total after removing the smallest and largest points
            int finalTotal = totalPoints - smallest - largest;

            // Output the total points
            Console.WriteLine($"Total points are {finalTotal}");
        }
    }
}
