using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>(); // List to store persons 

            while (true)
            {
                Console.Write($"Give a name and birth year (e.g., John, 1990) or press Enter to stop: ");
                string input = Console.ReadLine();

                // Stop if the user presses Enter without typing anything
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                // Split the input into name and birth year
                string[] parts = input.Split(',');

                // Check if the input is valid (has both name and year)
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int birthYear))
                {
                    string name = parts[0].Trim(); // Remove any extra spaces around the name

                    // Add the person to the list
                    people.Add(new Person(name, birthYear));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter in the format 'Name, Year'.");
                }
            }

            // Output the total number of names entered
            Console.WriteLine($"n{people.Count} names are given:");

            // Get the current year to calculate ages
            int currentYear = DateTime.Now.Year;

            // Sort people by age (ascending)
            people.Sort((p1, p2) => p1.GetAge(currentYear).CompareTo(p2.GetAge(currentYear)));

            // Display the names and their ages
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} is {person.GetAge(currentYear)} years old");
            }

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        // Class to represent a person
        class Person
        {
            public string Name { get; set; }
            public int BirthYear { get; set; }

            // Constructor to initialise name and birth year
            public Person(string name, int birthYear)
            {
                Name = name;
                BirthYear = birthYear;
            }

            // Method to calculate age based on the current year
            public int GetAge(int currentYear)
            {
                return currentYear - BirthYear;
            }
        }
    }
}
