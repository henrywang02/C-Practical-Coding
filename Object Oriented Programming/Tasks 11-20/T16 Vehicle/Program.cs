using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T16_Vehicle
{
    public class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }

        // Constructor to initialise common vehicle properties
        public Vehicle(string name, string model, int modelYear, string color)
        {
            Name = name;
            Model = model;
            ModelYear = modelYear;
            Color = color;
        }

        // Virtual method to return vehicle information
        public virtual string GetVehicleInfo()
        { 
            return $"- Name: {Name} Model: {Model} ModelYear: {ModelYear} Color: {Color}";
        }
    }

    public class Bicycle: Vehicle
    {
        public bool GearWheels { get; set; }
        public string GearName { get; set; }

        // Construct to initialise bicycle-specific properties
        public Bicycle(string name, string model, int modelYear, string color, bool gearWheels, string gearName)
            : base(name, model, modelYear, color)
        {
            GearWheels = gearWheels;
            GearName = gearName;
        }

        // Override to include bicycle-specific information
        public override string GetVehicleInfo()
        {
            return $"Bike info\n{base.GetVehicleInfo()} GearWheels: {GearWheels} Gear Name: {GearName}";
        }
    }

    public class Boat : Vehicle
    {
        public int SeatCount { get; set; }
        public string BoatType { get; set; }

        // Constructor to initialize boat-specific properties
        public Boat(string name, string model, int modelYear, string color, int seatCount, string boatType)
            : base(name, model, modelYear, color)
        {
            SeatCount = seatCount;
            BoatType = boatType;
        }

        // Override to include boat-specific information
        public override string GetVehicleInfo()
        {
            return $"Boat info\n{base.GetVehicleInfo()} SeatCount: {SeatCount} BoatType: {BoatType}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Bicycle objects
            Bicycle bike1 = new Bicycle("Jopo", "Street", 2016, "Blue", false, "");
            Bicycle bike2 = new Bicycle("Tunturi", "StreetPower", 2010, "Black", true, "Shimano Nexus");

            // Create Boat objects
            Boat boat1 = new Boat("SummerFun", "S900", 1990, "White", 3, "Rowboat");
            Boat boat2 = new Boat("Yamaha", "Model 1000", 2010, "Yellow", 5, "Motorboat");

            // Print information of the vehicles
            Console.WriteLine(bike1.GetVehicleInfo());
            Console.WriteLine();
            Console.WriteLine(bike2.GetVehicleInfo());
            Console.WriteLine();
            Console.WriteLine(boat1.GetVehicleInfo());
            Console.WriteLine();
            Console.WriteLine(boat2.GetVehicleInfo());
        }
    }
}
