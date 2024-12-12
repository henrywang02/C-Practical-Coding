using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T25_Movie_stars
{
    class Human
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public Human(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }

    class Actor : Human
    {
        public Actor(string name, int birthYear) : base(name, birthYear) { }
    }

    class Director : Human
    {
        public Director(string name, int birthYear) : base(name, birthYear) { }
    }

    class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Director Director { get; private set; }
        private List<Actor> Actors { get; set; }

        public Movie(string name, int year, Director director)
        {
            Name = name;
            Year = year;
            Director = director;
            Actors = new List<Actor>();
        }

        public void AddActor(Actor actor)
        {
            Actors.Add(actor);
        }

        public void RemoveActor(Actor actor)
        {
            Actors.Remove(actor);
        }

        public override string ToString()
        {
            string actorList = Actors.Count > 0 ? string.Join("\n", Actors.ConvertAll(actor => $"- {actor.Name} ({actor.BirthYear})")) : "No actors assigned";
            return $"Movie: {Name} ({Year})\nDirector: {Director.Name} ({Director.BirthYear})\nActors:\n{actorList}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Director and Actors
            Director christopherNolan = new Director("Christopher Nolan", 1970);
            Actor leonardoDiCaprio = new Actor("Leonardo DiCaprio", 1974);
            Actor josephGordonLevitt = new Actor("Joseph Gordon-Levitt", 1981);
            Actor ellenPage = new Actor("Elliot Page", 1987);

            // Create Movie and add actors
            Movie inception = new Movie("Inception", 2010, christopherNolan);
            inception.AddActor(leonardoDiCaprio);
            inception.AddActor(josephGordonLevitt);
            inception.AddActor(ellenPage);

            Console.WriteLine(inception);

            // Remove an actor and print updated movie details
            inception.RemoveActor(ellenPage);
            Console.WriteLine("\nAfter removing an actor:");
            Console.WriteLine(inception);

            // Create another Movie
            Director stevenSpielberg = new Director("Steven Spielberg", 1946);
            Actor samNeill = new Actor("Sam Neill", 1947);
            Actor lauraDern = new Actor("Laura Dern", 1967);

            Movie jurassicPark = new Movie("Jurassic Park", 1993, stevenSpielberg);
            jurassicPark.AddActor(samNeill);
            jurassicPark.AddActor(lauraDern);

            Console.WriteLine();
            Console.WriteLine(jurassicPark);
        }
    }
}
