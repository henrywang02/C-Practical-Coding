using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T24_Vehicle
{
    class Tire
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TireSize { get; set; }

        public Tire(string manufacturer, string model, string tireSize)
        {
            Manufacturer = manufacturer;
            Model = model;
            TireSize = tireSize;
        }

        public override string ToString()
        {
            return $"- Name: {Manufacturer} Model: {Model} TireSize: {TireSize}";
        }
    }

    class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        private List<Tire> Tires { get; set; }

        public Vehicle(string name, string model)
        {
            Name = name;
            Model = model;
            Tires = new List<Tire>();
            Console.WriteLine($"Created a new vehicle {Name} model {Model}");
        }

        public void AddTire(Tire tire)
        {
            Tires.Add(tire);
            Console.WriteLine($"Tire {tire.Manufacturer} added to vehicle {Name}");
        }

        public override string ToString()
        {
            string tireList = string.Join("\n", Tires);
            return $"Vehicle Name: {Name} Model: {Model} has tires:\n{tireList}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Porsche vehicle and add tires
            Vehicle porsche = new Vehicle("Porsche", "911");
            Tire nokiaTire = new Tire("Nokia", "Hakkapeliitta", "205R16");
            for (int i = 0; i < 4; i++)
            {
                porsche.AddTire(nokiaTire);
            }
            Console.WriteLine();
            Console.WriteLine(porsche);

            // Create Ducati vehicle and add tires
            Vehicle ducati = new Vehicle("Ducati", "Diavel");
            ducati.AddTire(new Tire("MIC", "Pilot", "160R17"));
            ducati.AddTire(new Tire("MIC", "Pilot", "140R16"));
            Console.WriteLine();
            Console.WriteLine(ducati);
        }
    }
}
