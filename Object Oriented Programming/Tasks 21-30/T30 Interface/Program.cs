using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T30_Interface
{
    public interface IAppliance
    {
        void TurnOn();
        void TurnOff();
    }

    class WashingMachine : IAppliance
    {
        private string Brand { get; set; }

        public WashingMachine(string brand)
        {
            Brand = brand;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{Brand} washing machine is now ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{Brand} washing machine is now OFF.");
        }
    }

    class Refrigerator : IAppliance
    {
        private string Brand { get; set; }

        public Refrigerator(string brand)
        {
            Brand = brand;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{Brand} refrigerator is now ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{Brand} refrigerator is now OFF.");
        }
    }
    internal class HomeApplianceTest
    {
        static void Main(string[] args)
        {
            IAppliance washingMachine = new WashingMachine("LG");
            IAppliance refrigerator = new Refrigerator("Samsung");

            // Turn on appliances
            washingMachine.TurnOn();
            refrigerator.TurnOn();

            // Turn off appliances
            washingMachine.TurnOff();
            refrigerator.TurnOff();

            Console.WriteLine("Program completed successfully. Press any key to quit.");
            Console.ReadKey();
        }
    }
}
