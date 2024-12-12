using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T26_SMLeague
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameLocation { get; set; }
        public int Number { get; set; }

        public Player(string firstName, string lastName, string gameLocation, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            GameLocation = gameLocation;
            Number = number;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {GameLocation}, #{Number}";
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        private List<Player> Players { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
            if (name == "JYP")
            {
                Hometown = "Jyväskylä";
                Players.Add(new Player("Matti", "Virtanen", "Forward", 10));
                Players.Add(new Player("Teemu", "Korhonen", "Defense", 15));
                Players.Add(new Player("Jussi", "Laine", "Goalie", 1));
            }
            else if (name == "Ilves")
            {
                Hometown = "Tampere";
                Players.Add(new Player("Sami", "Heikkinen", "Forward", 22));
                Players.Add(new Player("Antti", "Koskinen", "Defense", 18));
                Players.Add(new Player("Kari", "Mäkinen", "Goalie", 30));
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Console.WriteLine($"Player {player.FirstName} {player.LastName} added to team {Name}.");
        }

        public void RemovePlayer(Player player)
        {
            if (Players.Remove(player))
            {
                Console.WriteLine($"Player {player.FirstName} {player.LastName} removed from team {Name}.");
            }
            else
            {
                Console.WriteLine($"Player {player.FirstName} {player.LastName} not found in team {Name}.");
            }
        }

        public void ListPlayers()
        {
            Console.WriteLine($"Players in team {Name}:");
            foreach (var player in Players)
            {
                Console.WriteLine(player);
            }
        }

        public override string ToString()
        {
            return $"Team: {Name}, Hometown: {Hometown}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a JYP team and list its players
            Team jyp = new Team("JYP");
            Console.WriteLine(jyp);
            jyp.ListPlayers();

            // Add a new player to JYP
            Player newPlayer = new Player("Pekka", "Nieminen", "Forward", 12);
            jyp.AddPlayer(newPlayer);
            Console.WriteLine();
            jyp.ListPlayers();

            // Remove a player from JYP
            jyp.RemovePlayer(newPlayer);
            Console.WriteLine();
            jyp.ListPlayers();

            // Create an Ilves team and list its players
            Team ilves = new Team("Ilves");
            Console.WriteLine();
            Console.WriteLine(ilves);
            ilves.ListPlayers();
        }
    }
}
