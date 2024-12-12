using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T22_Cards
{
    class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }

    class CardDeck
    {
        private List<Card> cards;
        private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static readonly string[] Values = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };

        public CardDeck()
        {
            cards = new List<Card>();
            foreach (string suit in Suits)
            {
                foreach (string value in Values)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        public override string ToString()
        {
            return string.Join("\n", cards);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck deck = new CardDeck();
            Console.WriteLine("Deck before shuffling:");
            Console.WriteLine(deck);

            deck.Shuffle();
            Console.WriteLine("\nDeck after shuffling:");
            Console.WriteLine(deck);
        }
    }
}
