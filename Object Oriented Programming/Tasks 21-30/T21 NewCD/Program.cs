using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T21_NewCD
{
    class Song
    {
        public string Name { get; set; }
        public int LengthMinutes { get; set; }
        public int LengthSeconds { get; set; }

        public Song(string name, int lengthMinutes, int lengthSeconds)
        {
            Name = name;
            LengthMinutes = lengthMinutes;
            LengthSeconds = lengthSeconds;
        }

        public int GetLengthInSeconds()
        {
            return LengthMinutes * 60 + LengthSeconds;
        }

        public override string ToString()
        {
            return $"{Name}, {LengthMinutes}:{LengthSeconds:D2}";
        }
    }

    class CD
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        private List<Song> Songs { get; set; }

        public CD(string name, string artist)
        {
            Name = name;
            Artist = artist;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public int NumberOfSongs
        {
            get { return Songs.Count; }
        }

        public string TotalLength
        {
            get
            {
                int totalSeconds = 0;
                foreach (var song in Songs)
                {
                    totalSeconds += song.GetLengthInSeconds();
                }
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                return $"{minutes} min {seconds} sec";
            }
        }

        public override string ToString()
        {
            string songList = string.Join("\n", Songs.ConvertAll(song => $"  - {song}"));
            return $"You have a CD:\n- name: {Name}\n- artist: {Artist}\n- total length: {TotalLength}\n- {NumberOfSongs} songs:\n{songList}";
        }
    }
    internal class Program
    {   
        static void Main(string[] args)
        {
            CD cd = new CD("Endless Forms Most Beautiful", "Nightwish");
            cd.AddSong(new Song("Shudder Before the Beautiful", 6, 29));
            cd.AddSong(new Song("Weak Fantasy", 5, 23));
            cd.AddSong(new Song("Elan", 4, 45));
            cd.AddSong(new Song("Yours Is an Empty Hope", 5, 34));
            cd.AddSong(new Song("Our Decades in the Sun", 6, 37));
            cd.AddSong(new Song("My Walden", 4, 38));
            cd.AddSong(new Song("Endless Forms Most Beautiful", 5, 7));
            cd.AddSong(new Song("Edema Ruh", 5, 15));
            cd.AddSong(new Song("Alpenglow", 4, 45));
            cd.AddSong(new Song("The Eyes of Sharbat Gula", 6, 3));
            cd.AddSong(new Song("The Greatest Show on Earth", 24, 0));

            Console.WriteLine(cd);
        }
    }
}
