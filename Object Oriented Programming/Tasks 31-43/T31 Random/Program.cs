using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T31_Random
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public Person(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, Surname: {Surname}";
        }
    }
    public class Program
    {
        private static Random random = new Random();

        private static string GenerateRandomString(int length)
        {
            char[] letters = new char[length];
            for (int i = 0; i < length; i++)
            {
                letters[i] = (char)random.Next('A', 'Z' + 1);
            }
            return new string(letters);
        }

        public static void Main()
        {
            ListCollectionExample();
            DictionaryCollectionExample();
            Console.ReadLine();
        }

        public static void ListCollectionExample()
        {
            List<Person> persons = new List<Person>();
            Stopwatch stopwatch = new Stopwatch();

            // Generate 10000 Person objects and add to List
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                string firstName = GenerateRandomString(4);
                string surname = GenerateRandomString(10);
                persons.Add(new Person(firstName, surname));
            }
            stopwatch.Stop();
            Console.WriteLine("List Collection:");
            Console.WriteLine($"- Adding time : {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count : {persons.Count}");

            // Search for 1000 random people based on their first name
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                string searchFirstName = GenerateRandomString(4);
                List<Person> foundPersons = persons.FindAll(p => p.FirstName == searchFirstName);
                foreach (var person in foundPersons)
                {
                    Console.WriteLine($"- Found person with {searchFirstName} firstname : {person.FirstName} {person.Surname}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"- Persons tried to find : 1000");
            Console.WriteLine($"- Total finding time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }

        public static void DictionaryCollectionExample()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Stopwatch stopwatch = new Stopwatch();

            // Generate 10000 Person objects and add to Dictionary
            stopwatch.Start();
            while (persons.Count < 10000)
            {
                string firstName = GenerateRandomString(4);
                string surname = GenerateRandomString(10);
                if (!persons.ContainsKey(firstName))
                {
                    persons.Add(firstName, new Person(firstName, surname));
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary Collection:");
            Console.WriteLine($"- Adding time : {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count : {persons.Count}");

            // Search for 1000 random people based on their first name
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                string searchFirstName = GenerateRandomString(4);
                if (persons.TryGetValue(searchFirstName, out Person person))
                {
                    Console.WriteLine($"- Found person with {searchFirstName} firstname : {person.FirstName} {person.Surname}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"- Persons tried to find : 1000");
            Console.WriteLine($"- Total finding time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    }
}

// Differences observed between List and Dictionary:
// 1. Adding time: Dictionary might take slightly longer due to key uniqueness checks, but it's generally efficient.
// 2. Search time: Dictionary is significantly faster for lookups due to hashing, whereas List requires linear search.
// 3. In Dictionary, keys must be unique, which requires additional checks while adding elements.

