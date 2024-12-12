using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T37_Patterns
{
    public abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double Area { get; }
        public abstract double Circumference { get; }

        public override string ToString()
        {
            return $"{Name} Area={Area:F2} Circumference={Circumference:F2}";
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }

        public override double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public override double Circumference
        {
            get { return 2 * Math.PI * Radius; }
        }

        public override string ToString()
        {
            return $"{Name} Radius={Radius} Area={Area:F2} Circumference={Circumference:F2}";
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }

        public override double Area
        {
            get { return Width * Height; }
        }

        public override double Circumference
        {
            get { return 2 * (Width + Height); }
        }

        public override string ToString()
        {
            return $"{Name} Width={Width} Height={Height} Area={Area:F2} Circumference={Circumference:F2}";
        }
    }

    public class Shapes
    {
        public List<Shape> ShapesList { get; set; } = new List<Shape>();

        public void AddShape(Shape shape)
        {
            ShapesList.Add(shape);
        }

        public void PrintShapes()
        {
            foreach (var shape in ShapesList)
            {
                Console.WriteLine(shape);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shapes shapes = new Shapes();

            shapes.AddShape(new Circle(1));
            shapes.AddShape(new Circle(2));
            shapes.AddShape(new Circle(3));
            shapes.AddShape(new Rectangle(10, 20));
            shapes.AddShape(new Rectangle(20, 30));
            shapes.AddShape(new Rectangle(40, 50));

            shapes.PrintShapes();

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}
