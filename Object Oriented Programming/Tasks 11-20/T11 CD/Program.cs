using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T11_CD
{
    // Class representing a song
    public class Song
    {
        public string Name { get; set; }
        public string Duration { get; set; }

        public Song(string name, string duration)
        {
            Name = name;
            Duration = duration;
        }

        public string GetSongInfo()
        {
            return $"--- Name: {Name} - {Duration}";
        }
    }

    // Class representing a CD
    public class CD
    {
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public List<Song> Songs { get; set; }

        public CD(string artist, string name, string genre, double price)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public string GetCDInfo()
        {
            string cdInfo = $"CD:\n" +
                            $"   -Artist: {Artist}\n" +
                            $"   -Name: {Name}\n" +
                            $"   -Genre: {Genre}\n" +
                            $"   -Price: {Price}\n" +
                            $"    Songs:\n";

            foreach (var song in Songs)
            {
                cdInfo += song.GetSongInfo() + "\n";
            }
            return cdInfo;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create CD object
            CD cd = new CD("Nightwish", "Endless Forms Most Beautiful", "Symphonic metal", 19.9);

            // Add songs to the CD
            cd.AddSong(new Song("Shudder Before the Beautiful", "06:29"));
            cd.AddSong(new Song("Weak Fantasy", "05:23"));
            cd.AddSong(new Song("Elan", "04:45"));
            cd.AddSong(new Song("Yours Is an Empty Hope", "05:34"));
            cd.AddSong(new Song("Our Decades in the Sun", "06:37"));
            cd.AddSong(new Song("My Walden", "04:38"));
            cd.AddSong(new Song("Endless Forms Most Beautiful", "05:07"));
            cd.AddSong(new Song("Edema Ruh", "05:15"));
            cd.AddSong(new Song("Alpenglow", "04:45"));
            cd.AddSong(new Song("The Eyes of Sharbat Gula", "06:03"));
            cd.AddSong(new Song("The Greatest Show on Earth", "24:00"));

            // Print CD information
            Console.WriteLine(cd.GetCDInfo());
        }
    }
}
