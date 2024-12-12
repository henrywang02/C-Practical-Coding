using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T14_Amplifier
{   
    public class Amplifier
    {
        // Backing field for Volume
        private int _volume;

        // Property for Volume with get and set accessors
        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value < 0)
                {
                    _volume = 0;
                    Console.WriteLine("-> Too low volume - Amplifier volume is set to minimum : 0");
                }
                else if (value > 100)
                {
                    _volume = 100;
                    Console.WriteLine("-> Too much volume - Amplifier volume is set to maximum : 100");
                }
                else
                {
                    _volume = value;
                    Console.WriteLine($"-> Amplifier volume is set to : {_volume}");
                }

            }
            }

        // Constructor to initialise the amplifier with a default volume of 0
        public Amplifier()
        {
            _volume = 0;
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {

            // Create an Amplifier object;
            Amplifier amp = new Amplifier();

            // Main loop to continuosly ask for the new volume
            while (true)
            {
                // Ask user for the next volume value
                Console.WriteLine("Give a new volume value (0-100) >");
                string input = Console.ReadLine();

                // Try to parse the user's input
                // Try to parse the user's input
                if (int.TryParse(input, out int newVolume))
                {
                    // Set the volume through the property, which will handle the range checks
                    amp.Volume = newVolume;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                }
            }
        }
    }
}
