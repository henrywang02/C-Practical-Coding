using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_Consumption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) // Infinite loop to continuously ask for input
            {
                // Ask for input
                Console.Write($"Enter distance traveled (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                // Allow the user to exit the program by typing 'exit'
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting Program...");
                    break; // Break the loop and exit the program
                }

                // Validate that the input is a number
                if (double.TryParse(input, out double distance) && distance > 0)
                {
                    // Call the method to calculate fuel consumption and cost
                    var result = TripCalculator.CalculateCost(distance);

                    // Display the results
                    Console.WriteLine($"Fuel Consumption is {result.litersUsed:F2} liters and it costs {result.cost:F2} euros.");
                }
                else
                {
                    // Displat the error message if input is invalid
                    Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
                }
            }
        }
    }

    // Seperate class for the calculation
    public class TripCalculator
    {
        // Static method to calculate fuel consumption and cost
        public static (double litersUsed, double cost) CalculateCost(double distance)
        {
            // Randomly select fuel consumption between 6 and 9 liters per 100km
            Random random = new Random();
            double fuelConsumption = random.NextDouble() * (9 - 6) + 6; // liters per 100 km

            // Randomly select fuel price between 1.75 and 2.50 euros per liter
            double fuelPrice = random.NextDouble() * (2.50 - 1.75) + 1.75; // price per liter

            // Calculate total fuel consumption
            double litersUsed = (fuelConsumption / 100) * distance;

            // Calculate total cost
            double cost = litersUsed * fuelPrice;

            return (litersUsed, cost);

        }
    }
}
