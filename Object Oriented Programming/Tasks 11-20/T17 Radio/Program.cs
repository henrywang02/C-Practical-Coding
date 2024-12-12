using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static T17_Radio.ElectricalDevice;

namespace T17_Radio
{
    public class ElectricalDevice
    {
        // Properties
        public bool On { get; set; }
        public float Power { get; set; }

        // Constructor of ElectricalDevice
        public ElectricalDevice(float power)
        {
            Power = power;
            On = false; // Device is initially off
        }

        // To string method to print device information
        public override string ToString()
        {
            return $"Electrical Device [Power: {Power}W, On: {On}";
        }

        public class PortableRadio : ElectricalDevice
        {
            // Properties for the radio
            public int Volume { get; set; }
            public float Channel { get; set; }

            // Constructor
            public PortableRadio(float power) : base(power)
            {
                Volume = 0; // Default volume is 0
                Channel = 2000.0f; // Default channel is minimum frequency
            }

            // Toggle the power on/off
            public void TogglePower()
            {
                On = !On;
                Console.WriteLine(On ? "Radio is now ON." : "Radio is now off.");
            }

            // Set Volume (0 to 9)
            public void SetVolume(int volume)
            {
                if (On)
                {
                    if (volume >= 0 && volume <= 9)
                    {
                        Volume = volume;
                        Console.WriteLine($"Volume set to {Volume}");
                    }
                    else
                    {
                        Console.WriteLine("Volume out of range (0-9).");
                    }
                }
                else
                {
                    Console.WriteLine("Radio is off. Cannot set volume.");
                }
            }

            // Set channel (2000.0 to 26000.0)
            public void SetChannel(float channel)
            {
                if (On)
                {
                    if (channel >= 2000.0f && channel <= 26000.0f)
                    {
                        Channel = channel;
                        Console.WriteLine($"Channel set to {Channel} Hz");
                    }
                    else
                    {
                        Console.WriteLine("Channel out of range (2000.0 - 26000.0).");
                    }
                }
                else
                {
                    Console.WriteLine("Radio is off. Cannot set channel.");
                }
            }

            // Override ToString() to print radio information
            public override string ToString()
            {
                return $"Portable Radio [Power: {Power}W, On: {On}, Volume: {Volume}, Channel: {Channel}Hz]";
            }
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            // Create a portable radio with 50W power
            PortableRadio radio = new PortableRadio(50.0f);

            // Test toggling power on/off
            radio.TogglePower();  // Turn radio on
            radio.SetVolume(5);   // Set volume to 5
            radio.SetChannel(5000.0f); // Set channel to 5000.0

            // Print the current state of the radio
            Console.WriteLine(radio.ToString());

            // Try setting volume and channel while the radio is off
            radio.TogglePower();  // Turn radio off
            radio.SetVolume(8);   // Try to set volume while off
            radio.SetChannel(25000.0f); // Try to set channel while off

            // Turn radio back on and set invalid values
            radio.TogglePower();  // Turn radio on
            radio.SetVolume(15);  // Invalid volume
            radio.SetChannel(30000.0f); // Invalid channel

            // Final radio status
            Console.WriteLine(radio.ToString());
        }
    }
}
