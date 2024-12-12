using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T28_Refrigerator
{
    class FoodItem
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public FoodItem(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public override string ToString()
        {
            return $"{Name}, {Quantity} {Unit}";
        }
    }

    class Refrigerator
    {
        private List<FoodItem> Items { get; set; }

        public Refrigerator()
        {
            Items = new List<FoodItem>();
        }

        public void AddItem(FoodItem item)
        {
            Items.Add(item);
            Console.WriteLine($"Item {item.Name} added to the refrigerator.");
        }

        public void RemoveItem(string itemName)
        {
            FoodItem itemToRemove = Items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
                Console.WriteLine($"Item {itemName} removed from the refrigerator.");
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in the refrigerator.");
            }
        }

        public void ListItems()
        {
            Console.WriteLine("Items in the refrigerator:");
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }

        public override string ToString()
        {
            return "Refrigerator contains the following items:";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Refrigerator fridge = new Refrigerator();

            // Add items to the refrigerator
            fridge.AddItem(new FoodItem("Milk", 1, "Litre"));
            fridge.AddItem(new FoodItem("Eggs", 12, "Pieces"));
            fridge.AddItem(new FoodItem("Butter", 200, "Grams"));

            // List items in the refrigerator
            Console.WriteLine();
            fridge.ListItems();

            // Remove an item from the refrigerator
            fridge.RemoveItem("Eggs");
            Console.WriteLine();
            fridge.ListItems();
        }
    }
}
