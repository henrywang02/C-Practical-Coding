using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T39_Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        // Properties for the timer duration and alarm notification
        public int DurationInSeconds { get; set; }
        public string AlarmNotification { get; set; } = "Wake wake, the little bird";

        // Constructor to initialize the timer duration and optional notification
        public Timer(int durationInSeconds, string alarmNotification = null)
        {
            DurationInSeconds = durationInSeconds;
            if (!string.IsNullOrEmpty(alarmNotification))
            {
                AlarmNotification = alarmNotification;
            }
        }

        // Method to start the timer
        public void StartTimer()
        {
            Console.WriteLine($"Timer started for {DurationInSeconds} seconds...");
            Thread.Sleep(DurationInSeconds * 1000); // Wait for the specified duration
            Console.WriteLine($"Alarm: {AlarmNotification}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user input for the duration
            Console.Write("Enter the timer duration (in seconds or minutes, e.g., 30s or 2m): ");
            string input = Console.ReadLine();
            int durationInSeconds = 0;

            // Parse the user input to determine the duration in seconds
            if (input.EndsWith("s"))
            {
                durationInSeconds = int.Parse(input.TrimEnd('s'));
            }
            else if (input.EndsWith("m"))
            {
                durationInSeconds = int.Parse(input.TrimEnd('m')) * 60;
            }
            else
            {
                Console.WriteLine("Invalid input format. Please use 's' for seconds or 'm' for minutes.");
                return;
            }

            // Ensure the duration is between 1 second and 60 minutes
            if (durationInSeconds < 1 || durationInSeconds > 3600)
            {
                Console.WriteLine("Invalid duration. Please enter a value between 1 second and 60 minutes.");
                return;
            }

            // Get user input for the alarm notification (optional)
            Console.Write("Enter the alarm notification message (or press Enter to use default): ");
            string alarmNotification = Console.ReadLine();

            // Create a Timer object
            Timer timer = new Timer(durationInSeconds, alarmNotification);

            // Start the timer
            timer.StartTimer();
        }
    }
    }

