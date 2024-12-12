using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace T9_Vehicle

{
    public class Vehicle
    {
        private string brand;

        // Auto-implemented properties for Brand, Model, Speed, Tires
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }

        // Constructor to initialise the Vehicle object
        public Vehicle(string brand, string model, int speed, int tires)
        {
            Brand = brand;
            Model = model;
            Speed = speed;
            Tires = tires;
        }

        // ShowInfo method returns the manufacturer and model information
        public string ShowInfo()
        {
            return $"Brand: {Brand}, Model: {Model}";
        }

        // Overiding ToString method to return all vehicle properties as a string
        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, Speed: {Speed}, Tires: {Tires}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating two Vehicle objects
            Vehicle vehicle1 = new Vehicle("Toyota", "Corolla", 120, 4);
            Vehicle vehicle2 = new Vehicle("Harley-Davidson", "Sportster", 100, 2);

            // Display information using ShowInfo() method
            Console.WriteLine("Vehicle 1 Info: " + vehicle1.ShowInfo());
            Console.WriteLine("Vehicle 2 Info: " + vehicle2.ShowInfo());

            // Changing properties of the vehicles
            vehicle1.Speed = 130; // Changing speed of vehicle 1
            vehicle2.Model = "Softail"; // Changing model of vehicle 2

            // Displaying updated information using ToString() method
            Console.WriteLine("\nUpdated Vehicle 1 Info: " + vehicle1.ToString());
            Console.WriteLine("\nUpdated Vehicle 2 Info: " + vehicle2.ToString());

        }
    }
}

    
    
