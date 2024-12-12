using System;

// Abstract class Mammal
public abstract class Mammal
{
    public int Age { get; set; }

    // Abstract method Move
    public abstract void Move();

    // Method to increase the Age
    public void Grow()
    {
        Age++;
    }
}

// Human class inheriting from Mammal
public class Human : Mammal
{
    public string Name { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }

    // Override the Move method to print a default message
    public override void Move()
    {
        Console.WriteLine("Moving");
    }

    // Display the details of a Human
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Weight: {Weight}kg, Height: {Height}m";
    }
}

// Baby class inheriting from Human
public class Baby : Human
{
    public string Diaper { get; set; }

    // Override the Move method to print "Crawling"
    public override void Move()
    {
        Console.WriteLine("Crawling");
    }

    // Display details specific to a Baby
    public override string ToString()
    {
        return base.ToString() + $", Diaper: {Diaper}";
    }
}

// Adult class inheriting from Human
public class Adult : Human
{
    public string Auto { get; set; }

    // Override the Move method to print "Walking"
    public override void Move()
    {
        Console.WriteLine("Walking");
    }

    // Display details specific to an Adult
    public override string ToString()
    {
        return base.ToString() + $", Auto: {Auto}";
    }
}

// Main program to test the classes
class Program
{
    static void Main(string[] args)
    {
        // Create a Baby object
        Baby baby = new Baby
        {
            Name = "Emma",
            Age = 1,
            Weight = 10.5f,
            Height = 0.75f,
            Diaper = "Pampers"
        };

        // Create an Adult object
        Adult adult = new Adult
        {
            Name = "John",
            Age = 30,
            Weight = 80.0f,
            Height = 1.85f,
            Auto = "Tesla Model 3"
        };

        // Display Baby details and test functionality
        Console.WriteLine(baby.ToString());
        baby.Move(); // Baby should Crawl
        baby.Grow();
        Console.WriteLine($"After growing, {baby.Name}'s Age: {baby.Age}");

        // Display Adult details and test functionality
        Console.WriteLine(adult.ToString());
        adult.Move(); // Adult should Walk
        adult.Grow();
        Console.WriteLine($"After growing, {adult.Name}'s Age: {adult.Age}");
    }
}
