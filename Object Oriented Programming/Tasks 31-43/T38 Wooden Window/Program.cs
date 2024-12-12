using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T38_Wooden_Window
{
    public class Window
    {
        // Properties for width and height of the window
        public double Width { get; set; }
        public double Height { get; set; }

        // Constructor to initialize the width and height of the window
        public Window(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Method to calculate the area of the window in square meters
        public double CalculateArea()
        {
            return Width * Height;
        }

        // Method to calculate the circumference of the window frame
        public double CalculateCircumference()
        {
            return 2 * (Width + Height);
        }

        // Method to calculate the area of the glass layers (3 layers of glass)
        public double CalculateGlassUsage()
        {
            return 3 * CalculateArea();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user input for width and height
            Console.Write("Enter the width of the window in meters: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the window in meters: ");
            double height = double.Parse(Console.ReadLine());

            // Create a Window object
            Window window = new Window(width, height);

            // Calculate and display the area, circumference, and glass usage
            Console.WriteLine($"Area of the window: {window.CalculateArea():F2} square meters");
            Console.WriteLine($"Circumference of the window: {window.CalculateCircumference():F2} meters");
            Console.WriteLine($"Glass usage (3 layers): {window.CalculateGlassUsage():F2} square meters");
        }
    }
}
