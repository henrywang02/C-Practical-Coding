using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T29_Cashier
{
    public interface ITransaction
    {
        string ShowTransaction();
        float Money { get; set; }
    }

    class PaidWithCash : ITransaction
    {
        public float Money { get; set; }
        private int BillNumber { get; set; }

        public PaidWithCash(float amount, int billNumber)
        {
            Money = amount;
            BillNumber = billNumber;
        }

        public string ShowTransaction()
        {
            return $"Paid with cash: bill number {BillNumber} amount {Money} €";
        }
    }

    class PaidWithCard : ITransaction
    {
        public float Money { get; set; }
        private string CardNumber { get; set; }
        private string Date { get; set; }

        public PaidWithCard(float amount, string cardNumber, string date)
        {
            Money = amount;
            CardNumber = cardNumber;
            Date = date;
        }

        public string ShowTransaction()
        {
            return $"Transaction to bank: charge from card {CardNumber} date {Date} amount {Money} €";
        }
    }

    class CashMachine
    {
        private List<ITransaction> Transactions { get; set; }

        public CashMachine()
        {
            Transactions = new List<ITransaction>();
        }

        public void AddTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
            Console.WriteLine(transaction.ShowTransaction());
        }

        public float ShowTotal()
        {
            float total = 0;
            foreach (var transaction in Transactions)
            {
                total += transaction.Money;
            }
            return total;
        }

        public float ShowCash()
        {
            float totalCash = 0;
            foreach (var transaction in Transactions)
            {
                if (transaction is PaidWithCash)
                {
                    totalCash += transaction.Money;
                }
            }
            return totalCash;
        }

        public float ShowTotalSales()
        {
            return ShowTotal();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CashMachine cashMachine = new CashMachine();

            // Card payments
            cashMachine.AddTransaction(new PaidWithCard(78.95f, "0001-0002", "1.1.2024"));
            cashMachine.AddTransaction(new PaidWithCard(45.65f, "0003-0004", "1.1.2024"));
            Console.WriteLine($"Total money at bank account: {cashMachine.ShowTotal() - cashMachine.ShowCash()} €");

            // Cash payments
            cashMachine.AddTransaction(new PaidWithCash(100f, 1));
            cashMachine.AddTransaction(new PaidWithCash(50f, 2));
            Console.WriteLine($"Total money in cash: {cashMachine.ShowCash()} €");

            // Total sales
            Console.WriteLine($"Total sales today {DateTime.Now:dddd MMMM d, yyyy} is {cashMachine.ShowTotal()} €");

            Console.WriteLine("Program completed successfully. Press any key to quit.");
            Console.ReadKey();
        }
    }
}
