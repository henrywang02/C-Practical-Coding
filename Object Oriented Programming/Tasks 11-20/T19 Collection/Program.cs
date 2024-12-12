using System;

public class Media
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public string ISBN { get; set; }

    public Media(string title, string author, int yearPublished, string isbn)
    {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        ISBN = isbn;
    }

    // Base class method for getting media details
    public virtual string GetDetails()
    {
        return $"Title: {Title}, Author: {Author}, Year: {YearPublished}, ISBN: {ISBN}";
    }
}

public class Book : Media
{
    public string Genre { get; set; }

    public Book(string title, string author, int yearPublished, string isbn, string genre)
        : base(title, author, yearPublished, isbn)
    {
        Genre = genre;
    }

    // Override to provide book-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", Genre: {Genre}";
    }
}

public class Magazine : Media
{
    public int IssueNumber { get; set; }

    public Magazine(string title, string author, int yearPublished, string isbn, int issueNumber)
        : base(title, author, yearPublished, isbn)
    {
        IssueNumber = issueNumber;
    }

    // Override to provide magazine-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", Issue: {IssueNumber}";
    }
}

public class EBook : Book
{
    public float FileSize { get; set; } // File size in MB

    public EBook(string title, string author, int yearPublished, string isbn, string genre, float fileSize)
        : base(title, author, yearPublished, isbn, genre)
    {
        FileSize = fileSize;
    }

    // Override to provide e-book-specific details
    public override string GetDetails()
    {
        return base.GetDetails() + $", File Size: {FileSize}MB";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some media objects
        Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565", "Fiction");
        Magazine magazine = new Magazine("National Geographic", "Multiple Authors", 2021, "978-1257894567", 345);
        EBook ebook = new EBook("Learning C#", "John Smith", 2020, "978-0137849322", "Programming", 15.5f);

        // Print their details
        Console.WriteLine(book.GetDetails());
        Console.WriteLine(magazine.GetDetails());
        Console.WriteLine(ebook.GetDetails());
    }
}
