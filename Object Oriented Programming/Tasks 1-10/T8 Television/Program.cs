using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace T8_Television
{
    class Television
    {
        // Auto-implemented properties
        public bool IsOn { get; set; } = false;
        public int Volume { get; set; } = 50; // Default volume at 50
        public int Channel { get; set; } = 1; // Default channel 1
        public string InputSource { get; set; } = "HDMI1"; // Default input source
        public int Brightness { get; set; } = 50; // Default brightness at 50

        // Method to turn on the TV
        public void TurnOn()
        {
            IsOn = true;
        }

        // Method to turn off the TV
        public void TurnOff()
        {
            IsOn = false;
        }

        // Method to increase the volume
        public void IncreaseVolume()
        {
            if (IsOn && Volume < 100)
                Volume++;
        }

        // Method to decrease the volume
        public void DecreaseVolume()
        {
            if (IsOn && Volume > 0)
                Volume--;
        }

        // Method to change the channel
        public void ChangeChannel(int newChannel)
        {
            if (IsOn && newChannel > 0)
                Channel = newChannel;
        }

        // Method to change the input source
        public void SetInputSource(string newInputSource)
        {
            if (IsOn)
                InputSource = newInputSource;
        }

        // Method to adjust the brightness
        public void AdjustBrightness(int newBrightness)
        {
            if (IsOn && newBrightness >= 0 && newBrightness <= 100)
                Brightness = newBrightness;
        }

        // Method to get the status of the television
        public string GetStatus()
        {
            if (IsOn)
            {
                return $"Television is ON\n" +
                       $"Channel: {Channel}\n" +
                       $"Volume: {Volume}\n" +
                       $"Input Source: {InputSource}\n" +
                       $"Brightness: {Brightness}";
            }
            else
            {
                return "Television is OFF";
            }
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Create a new Television object
            Television myTV = new Television();

            // Turn on the TV
            myTV.TurnOn();

            // Change the channel, volume, and input source
            myTV.ChangeChannel(5);
            myTV.IncreaseVolume();
            myTV.IncreaseVolume();
            myTV.SetInputSource("HDMI2");
            myTV.AdjustBrightness(70);

            // Display the current status of the TV
            Console.WriteLine(myTV.GetStatus());

            // Decrease the volume and change the channel
            myTV.DecreaseVolume();
            myTV.ChangeChannel(10);

            // Display the updated status of the TV
            Console.WriteLine("\nUpdated TV status:");
            Console.WriteLine(myTV.GetStatus());

            // Turn off the TV
            myTV.TurnOff();
            Console.WriteLine("\nTV Status after turning off");
            Console.WriteLine(myTV.GetStatus());
        }
    }
}
