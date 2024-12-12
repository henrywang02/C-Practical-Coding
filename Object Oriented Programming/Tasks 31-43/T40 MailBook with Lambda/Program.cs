using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T40_MailBook_with_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Friend(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class MailBook
    {
        private List<Friend> friends;
        public IReadOnlyList<Friend> Friends => friends.AsReadOnly();

        public MailBook(string filePath)
        {
            friends = new List<Friend>();
            LoadFriendsFromFile(filePath);
        }

        private void LoadFriendsFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            friends.Add(new Friend(parts[0], parts[1]));
                        }
                    }
                    Console.WriteLine($"{friends.Count} names in the address book:");
                }
                else
                {
                    Console.WriteLine("File not found. Starting with an empty address book.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        public void ShowAllFriends()
        {
            foreach (var friend in friends)
            {
                Console.WriteLine($"{friend.Name} {friend.Email}");
            }
        }

        public void SearchFriends(string searchString)
        {
            var results = friends.Where(f =>
            {
                return NewMethod(searchString, f);
            }).ToList();
            if (results.Any())
            {
                foreach (var friend in results)
                {
                    Console.WriteLine($"{friend.Name} {friend.Email}");
                }
            }
            else
            {
                Console.WriteLine("No friends found with that name.");
            }
        }

        private static bool NewMethod(string searchString, Friend f)
        {
            return f.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }

        public void AddFriend(string name, string email, string filePath)
        {
            try
            {
                var newFriend = new Friend(name, email);
                friends.Add(newFriend);
                File.AppendAllText(filePath, $"{name},{email}\n");
                Console.WriteLine("Friend added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "friends.csv";
            MailBook mailBook = new MailBook(filePath);

            mailBook.ShowAllFriends();

            Console.Write("Enter the name or part of the name of the person you are looking for > ");
            string searchString = Console.ReadLine();
            mailBook.SearchFriends(searchString);

            Console.Write("Do you want to add a new friend? (yes/no) > ");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter friend's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter friend's email: ");
                string email = Console.ReadLine();
                mailBook.AddFriend(name, email, filePath);
            }

            Console.WriteLine("Program completed successfully. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
