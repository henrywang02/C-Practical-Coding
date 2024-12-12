using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T42_FishRegister
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Class representing a fisherman
    class Fisherman
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Fish> FishCaught { get; set; } = new List<Fish>();

        public Fisherman(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public void AddFish(Fish fish)
        {
            FishCaught.Add(fish);
            Console.WriteLine($"Fisherman {Name} got a new fish\n - species: {fish.Species} {fish.Length} cm {fish.Weight} kg\n - place: {fish.Location.Name}\n - location: {fish.Location.Place}\n");
        }
    }

    // Class representing a fish
    class Fish
    {
        public string Species { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public FishingLocation Location { get; set; }

        public Fish(string species, double length, double weight, FishingLocation location)
        {
            Species = species;
            Length = length;
            Weight = weight;
            Location = location;
        }
    }

    // Class representing a fishing location
    class FishingLocation
    {
        public string Name { get; set; }
        public string Place { get; set; }

        public FishingLocation(string name, string place)
        {
            Name = name;
            Place = place;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fisherman> fishermen = new List<Fisherman>();

            // Adding fishermen
            Fisherman kirsi = new Fisherman("Kirsi Kernell", "020-12345678");
            Fisherman uolevi = new Fisherman("Uolevi Kärppä", "041-12345678");
            fishermen.Add(kirsi);
            fishermen.Add(uolevi);
            Console.WriteLine($"A new Fisherman added to Fish-register:\n- Fisherman: {kirsi.Name} Phone: {kirsi.Phone}\n- Fisherman: {uolevi.Name} Phone: {uolevi.Phone}\n");

            // Adding fish to fishermen
            FishingLocation lakeJyvaskyla = new FishingLocation("The Lake of Jyväskylä", "Jyväskylä");
            FishingLocation riverTeno = new FishingLocation("River Teno", "The Northern edge of Finland");

            kirsi.AddFish(new Fish("Pike", 120, 4.5, lakeJyvaskyla));
            kirsi.AddFish(new Fish("Salmon", 190, 13.2, riverTeno));
            uolevi.AddFish(new Fish("Crucian carp", 20, 0.2, riverTeno));

            // Printing all fish in the register
            Console.WriteLine("All fish in register:\n");
            foreach (var fisherman in fishermen)
            {
                Console.WriteLine($"{fisherman.Name} has got following fish:");
                for (int i = 0; i < fisherman.FishCaught.Count; i++)
                {
                    var fish = fisherman.FishCaught[i];
                    Console.WriteLine($"{i + 1}) {fish.Species} {fish.Length} cm {fish.Weight} kg at {fish.Location.Name}, {fish.Location.Place}");
                }
                Console.WriteLine();
            }

            // Printing sorted register by fish weight (heaviest first)
            Console.WriteLine("Sorted register\n\n*** All fish in Fish-register: ***\n");
            var allFish = fishermen.SelectMany(f => f.FishCaught)
                                   .OrderByDescending(f => f.Weight)
                                   .ToList();

            for (int i = 0; i < allFish.Count; i++)
            {
                var fish = allFish[i];
                Console.WriteLine($"{i + 1}) {fish.Species} {fish.Length} cm {fish.Weight} kg at {fish.Location.Name}, {fish.Location.Place} by: {fishermen.First(f => f.FishCaught.Contains(fish)).Name}");
            }

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}
