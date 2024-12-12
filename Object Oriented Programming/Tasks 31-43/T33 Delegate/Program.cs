using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T33_Delegate
{
    // Define a delegate that takes a string and returns a string
    public delegate string StringOperation(string input);
    internal class Program
    {
        static void Main(string[] args)
        {
            // Methods to perform various transformations
            StringOperation toUpperCase = ToUpperCase;
            StringOperation toLowerCase = ToLowerCase;
            StringOperation toTitleCase = ToTitleCase;
            StringOperation reverseString = ReverseString;

            Console.WriteLine("Enter the string to process:");
            string inputString = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nChoose the treatment you want, you can give several treatments at once as one string, e.g. '123'");
                Console.WriteLine("1: to capital letters");
                Console.WriteLine("2: lowercase");
                Console.WriteLine("3: as a title");
                Console.WriteLine("4: as a palindrome");
                Console.WriteLine("0: terminate");
                Console.Write("Selection: ");
                string selection = Console.ReadLine();

                if (selection == "0")
                {
                    break;
                }

                // Iterate over each character in the selection string
                foreach (char option in selection)
                {
                    switch (option)
                    {
                        case '1':
                            Console.WriteLine($"{inputString} changed to {toUpperCase(inputString)}");
                            break;
                        case '2':
                            Console.WriteLine($"{inputString} changed to {toLowerCase(inputString)}");
                            break;
                        case '3':
                            Console.WriteLine($"{inputString} changed to {toTitleCase(inputString)}");
                            break;
                        case '4':
                            Console.WriteLine($"{inputString} changed to {reverseString(inputString)}");
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
        }

        // Method to convert string to uppercase
        public static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        // Method to convert string to lowercase
        public static string ToLowerCase(string input)
        {
            return input.ToLower();
        }

        // Method to convert string to title case (first letter uppercase, rest lowercase)
        public static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        // Method to reverse the string
        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    }

