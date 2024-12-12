using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T36_Invoice
{
    public class InvoiceItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public InvoiceItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double Total
        {
            get { return Price * Quantity; }
        }

        public override string ToString()
        {
            return $"{Name} {Price:F2}e {Quantity} pieces {Total:F2}e total";
        }
    }

    public class Invoice
    {
        public string Customer { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public int ItemsCount
        {
            get { return Items.Count; }
        }

        public int ItemsTogether
        {
            get
            {
                int totalItems = 0;
                foreach (var item in Items)
                {
                    totalItems += item.Quantity;
                }
                return totalItems;
            }
        }

        public double CountTotal()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Total;
            }
            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice
            {
                Customer = "Kirsi Kernel"
            };

            invoice.Items.Add(new InvoiceItem("Milk", 1.75, 1));
            invoice.Items.Add(new InvoiceItem("Beer", 5.25, 1));
            invoice.Items.Add(new InvoiceItem("Butter", 2.50, 2));

            PrintInvoice(invoice);

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }

        private static void PrintInvoice(Invoice invoice)
        {
            Console.WriteLine($"Customer {invoice.Customer}'s invoice:");
            Console.WriteLine("=================================");
            foreach (var item in invoice.Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=================================");
            Console.WriteLine($"Total: {invoice.ItemsTogether} pieces {invoice.CountTotal():F2} euros");
        }
    }
}
