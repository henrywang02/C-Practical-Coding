using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static T34_Unit_test_for_ArrayCalculator.Program;

namespace T34_Unit_test_for_ArrayCalculator
{
    public class ArrayCalculator
    {
        public static double Sum(double[] array)
        {
            return array.Sum();
        }

        public static double Average(double[] array)
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Cannot calculate average of an empty array.");
            return array.Average();
        }

        public static double Min(double[] array)
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Cannot find minimum of an empty array.");
            return array.Min();
        }

        public static double Max(double[] array)
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Cannot find maximum of an empty array.");
            return array.Max();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

            Console.WriteLine($"Sum = {ArrayCalculator.Sum(array):F2}");
            Console.WriteLine($"Ave = {ArrayCalculator.Average(array):F2}");
            Console.WriteLine($"Min = {ArrayCalculator.Min(array):F2}");
            Console.WriteLine($"Max = {ArrayCalculator.Max(array):F2}");

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}