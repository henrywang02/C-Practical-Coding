using System;

public class Item
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }

    public Item(string name, string brand, decimal price)
    {
        Name = name;
        Brand = brand;
        Price = price;
    }

    // Base class method for getting details
    public virtual string GetDetails()
    {
        return $"Item: {Name}, Brand: {Brand}, Price: ${Price}";
    }
}

public class Electronics : Item
{
    public int BatteryLife { get; set; } // in hours
    public int Storage { get; set; } // in GB

    public Electronics(string name, string brand, decimal price, int batteryLife, int storage)
        : base(name, brand, price)
    {
        BatteryLife = batteryLife;
        Storage = storage;
    }

    // Override to provide electronics-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", BatteryLife: {BatteryLife}h, Storage: {Storage}GB";
    }
}

public class Phone : Electronics
{
    public int SIMSlots { get; set; } // Number of SIM slots

    public Phone(string name, string brand, decimal price, int batteryLife, int storage, int simSlots)
        : base(name, brand, price, batteryLife, storage)
    {
        SIMSlots = simSlots;
    }

    // Override to provide phone-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", SIM Slots: {SIMSlots}";
    }
}

public class ReadingMaterial : Item
{
    public string Author { get; set; }
    public int Pages { get; set; }

    public ReadingMaterial(string name, string brand, decimal price, string author, int pages)
        : base(name, brand, price)
    {
        Author = author;
        Pages = pages;
    }

    // Override to provide reading material-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", Author: {Author}, Pages: {Pages}";
    }
}

public class Book : ReadingMaterial
{
    public string Genre { get; set; }

    public Book(string name, string brand, decimal price, string author, int pages, string genre)
        : base(name, brand, price, author, pages)
    {
        Genre = genre;
    }

    // Override to provide book-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", Genre: {Genre}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some objects for testing
        Phone phone = new Phone("Galaxy S20", "Samsung", 999.99m, 24, 128, 2);
        Book book = new Book("C# Programming", "No Publisher", 49.99m, "John Doe", 500, "Programming");

        // Print their details
        Console.WriteLine(phone.GetDetails());
        Console.WriteLine(book.GetDetails());
    }
}

