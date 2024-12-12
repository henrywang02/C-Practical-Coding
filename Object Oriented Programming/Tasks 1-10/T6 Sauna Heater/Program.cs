using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T6_Sauna_Heater
{
    // Heater class
    class Heater
    {
        // Private fields
        private int temperature;
        private int humidity;
        private bool isOn;

        // Constructor
        public Heater()
        {
            temperature = 0;
            humidity = 0;
            isOn = false;
        }

        // Method to turn on the heater
        public void TurnOn()
        {
            isOn = true;
        }

        // Method to turn off the heater
        public void TurnOff()
        {
            isOn = false;
        }

        // Method to set the temperature
        public void SetTemperature(int temp)
        {
            if (isOn)
            {
                temperature = temp;
            }
            else
            {
                Console.WriteLine("Heater is off! Turn it on first");
            }
        }

        // Method to set the humidity
        public void SetHumidity(int hum)
        {
            if (isOn)
            {
                humidity = hum;
            }
            else
            {
                Console.WriteLine("Heater is off! Turn it on first");
            }
        }

        // Method to get the temperature
        public int GetTemperature()
        {
            return temperature;
        }

        // Method to get the humidity
        public int GetHumidity() 
        {
            return humidity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new Heater object
            Heater myHeater = new Heater();

            // Turn the heater on
            myHeater.TurnOn();
            Console.WriteLine("Heater is now ON");

            // Set temperature and humidity
            myHeater.SetTemperature(80);
            myHeater.SetHumidity(40);

            // Display current temperature and humidity
            Console.WriteLine($"Current temperature: {myHeater.GetTemperature()} °C");
            Console.WriteLine($"Current humidity: {myHeater.GetHumidity()} %");

            // Turn the heater off
            myHeater.TurnOff();
            Console.WriteLine("Heater is now OFF.");

            // Try to set temperature while the heater is off
            myHeater.SetTemperature(90);
        }
    }
}
