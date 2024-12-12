using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T13_Elevator
{   
    public class Elevator
    {
        // Backing field for the current floor
        private int _currentFloor;

        // Constructor to initialise the elevator at floor 1
        public Elevator()
        {
            _currentFloor = 1; // Default starting floor
        }

        // Property to get the current floor
        public int GetCurrentFloor()
        {
            return _currentFloor;
        }

        // Method to move to the desired floor
        public bool GoTo(int floor, out string message)
        {
            if (floor < 1)
            {
                message = "Floor is too small!";
                return false;
            }
            else if (floor > 5)
            {
                message = "Floor is too big!";
                return false;
            }
            else
            {
                _currentFloor = floor;
                message = $"Elevator is now in floor : {floor}";
                return true;
            }
        }
    }
    internal class Program
    { 
        static void Main(string[] args)
        {
            // Create an Elevator object
            Elevator elevator = new Elevator();
            string message;

            // Main loop to continuously ask for the next floor
            while (true)
            {
                // Display the current floor
                Console.WriteLine($"Elevator is now in floor : {elevator.GetCurrentFloor()}");

                // Ask the user for the next floor
                Console.WriteLine("Give a new floor number (1-5) >");
                string input = Console.ReadLine();

                // Try to parse the user's input
                if (int.TryParse(input, out int desiredFloor))
                {
                    // Move the elevator and capture the message
                    elevator.GoTo(desiredFloor, out message);
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }
    }
}
