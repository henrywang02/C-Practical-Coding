using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) //Infinite loop to continuously ask for input
            {
                // Ask for input
                Console.Write($"Enter a sentence or string to check if it's a palindrome (or type 'exit to quite): ");
                string input = Console.ReadLine();

                // Allow the user to exit the program by typing 'exit'
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting Program...");
                    break; // Break the loop and exit the program
                }

                // Call the static method to check if the input is a palindrome
                bool isPalindrome = IsPalindrome(input);

                // Show the result to the user
                if (isPalindrome)
                {
                    Console.WriteLine("The given sentence or string is a palindrome.");
                }
                else
                {
                    Console.WriteLine("The given sentence or word is not a palindrome.");
                }

            }
        }

        // Static method to check if a string is a palindrome
        public static bool IsPalindrome(string text)
        {
            // Remove spaces and convert to lowercase for case-intensive comparison
            string cleanedText = text.Replace(" ", "").ToLower();

            // Initialise pointers for the start and the end of the string
            int left = 0;
            int right = cleanedText.Length - 1;

            // Loop to compare characters from both ends of the string
            while (left < right)
            {
                if (cleanedText[left] != cleanedText[right])
                {
                    return false; // If any characters don't match, it's not a palindrome 
                }

                left++;
                right--;
            }

            return true; // If all characters match, it's a palindrome
        }
    }
}
