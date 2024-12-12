using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T35_Unit_Test_for_Shopping_cart
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int GetProductCount()
        {
            return products.Count;
        }

        public void PrintProducts()
        {
            Console.WriteLine("Your products in shopping cart:");
            foreach (var product in products)
            {
                Console.WriteLine($"- product: {product.Name} {product.Price:F2} e");
            }
            Console.WriteLine($"There are {products.Count} products in the shopping cart.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product("Milk", 1.4));
            cart.AddProduct(new Product("Bread", 2.2));
            cart.AddProduct(new Product("Butter", 3.2));
            cart.AddProduct(new Product("Cheese", 4.2));

            cart.PrintProducts();

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}
