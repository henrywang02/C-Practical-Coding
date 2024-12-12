using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_Washing_machine
{

    class WashingMachine
    {
        // Private fields
        private bool isOn;
        private int temperature;
        private string washMode;
        private string spinSpeed;
        private double loadCapacity;
        private int timer;
        private double v1;
        private int v2;

        // Default constructor
        public WashingMachine() // Set up the default
        {
            isOn = false;
            temperature = 30; // Default temperature
            washMode = "Normal"; // Default mode
            spinSpeed = "Medium"; // Default spin speed
            loadCapacity = 5.0; //Default capacity in kg
            timer = 60; //Default wash time in minutes
        }

        public WashingMachine(double v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        // Method to turn on the washing machine
        public void TurnOn()
        {
            isOn = true;
        }

        // Method to turn off the washing machine
        public void TurnOff()
        {
            isOn = false;
        }

        // Method to set the wash mode
        public void SetWashMode(string mode)
        {
            if (isOn)
                washMode = mode;
            
        }

        // Method to set the temperature
        public void SetTemperature(int temp)
        {
            if (isOn)
                temperature = temp;

        }

        // Method to set the spin speed
        public void SetSpinSpeed(string speed)
        {
            if (isOn)
                spinSpeed = speed;
        }

        // Method to set the timer
        public void SetTimer(int time)
        {
            if (isOn)
                timer = time;
        }

        // Method to get the status of the washing machine
        public string GetStatus()
        {
            if (isOn)
            {
                return $"Washing Machine is ON\n" +
                       $"Temperature: {temperature}°C\n" +
                       $"Wash Mode: {washMode}\n" +
                       $"Spin Speed: {spinSpeed}\n" +
                       $"Load Capacity: {loadCapacity} kg\n" +
                       $"Time Remaining: {timer} minutes";
            }
            else
            {
                return "Washing Machine is OFF";
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new Washing Machine object using the default constructor
            WashingMachine myWasher = new WashingMachine();
            myWasher.TurnOn();
            myWasher.SetWashMode("Delicate");
            myWasher.SetTemperature(40);
            myWasher.SetSpinSpeed("High");
            myWasher.SetTimer(45);

            // Dispaly the current status of the washing machine
            Console.WriteLine(myWasher.GetStatus());

            // Create another Washing Machine object using the parameterised constructor
            WashingMachine mySecondWasher = new WashingMachine(7.0, 60);
            mySecondWasher.TurnOn();
            mySecondWasher.SetWashMode("Heavy");
            mySecondWasher.SetSpinSpeed("Low");

            // Display the status of the second washing machine
            Console.WriteLine(mySecondWasher.GetStatus());
        }
    }
}
