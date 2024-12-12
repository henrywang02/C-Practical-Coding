using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T12_Ralley_car
{
    public class RallyCar
    {
        // Public properties for Name and Type
        public string Name { get; set; }
        public string Type { get; set; }
        // Backing field for Speed property
        private float _speed;

        // Read-only SpeedMax property with a default value of 200
        public float SpeedMax { get; } = 200.0f;
        // Read-only float Speed
        public float Speed
        {
            get { return _speed; }
        }

        // Constructor
        public RallyCar(string name, string type)
        {
            Name = name;
            Type = type;
            _speed = 0; // Speed is initially set to zero
        }

        // Accelerate to a certain speed
        public void AccelerateTo(float value)
        {
            if (value >= 0 && value <= SpeedMax)
            {
                _speed = value;
                Console.WriteLine($"{Name} accelerated to {Speed} km/h.");
            }
            else
            {
                Console.WriteLine($"Invalid acceleration value. {Name} cannot accelerate beyond the range 0 - {SpeedMax} km/h.");
            }
        }

        // Slow down to a certain speed
        public void SlowTo(float value)
        {
            if (value >= 0 && value <= _speed)
            {
                _speed = value;
                Console.WriteLine($"{Name} slowed down to {Speed} km/h.");
            }
            else
            {
                Console.WriteLine($"Invalid deceleration value. {Name} cannot decelerate below 0 or above its current speed ({_speed} km/h).");
            }
        }

    }
    internal class TestRalley
    {
        static void Main(string[] args)
        {
            // Create a RallyCar object
            RallyCar car = new RallyCar("Subaru Impreza", "Rally Car");

            // Test Different speeds
            car.AccelerateTo(100); // Valid acceleration
            car.AccelerateTo(250); // Invalid acceleration, beyond SpeedMax

            car.SlowTo(50);  // Valid deceleration
            car.SlowTo(-10); // Invalid deceleration, below 0
            car.SlowTo(120); // Invalid deceleration, greater than current speed

            // Print current speed and other details
            Console.WriteLine($"Car: {car.Name}, Type: {car.Type}, Current Speed: {car.Speed} km/h, Max Speed: {car.SpeedMax} km/h.");
        }
    }
}
