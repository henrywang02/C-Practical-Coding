using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T15_Employee
{
    public class Employee
    {
        // Fields for Employee class
        public string Name { get; set; }
        public string Profession { get; set; }
        public double Salary { get; set; }

        // Construct to initialise the Employee
        public Employee(string name, string profession, double salary)
        {
            Name = name;
            Profession = profession;
            Salary = salary;
        }

        // Method to return the employee's information
        public virtual string GetEmployeeInfo()
        {
            return $"Employee:\n- Name: {Name} Profession: {Profession} Salary: {Salary}";
        }
    }

    public class Boss : Employee
    {
        // Field for Boss class
        public string Car { get; set; }
        public double Bonus { get; set; }

        // Constructor to initialise the Boss
        public Boss(string name, string profession, double salary, string car, double bonus)
            : base(name, profession, salary) // Call the base class constructor
        {
            Car = car;
            Bonus = bonus;
        }

        // Method to return the boss's information
        public override string GetEmployeeInfo()
        {
            return $"Boss:\n- Name: {Name} Profession: {Profession} Salary: {Salary} Car: {Car} Bonus {Bonus}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an Employee object
            Employee employee = new Employee("Kirsi Kernel", "Teacher", 1200);
            Console.WriteLine(employee.GetEmployeeInfo());

            // Create a Boss object
            Boss boss = new Boss("Hanna Husso", "Head of Institute", 9000, "Audi", 5000);
            Console.WriteLine(boss.GetEmployeeInfo());

            // Modify the employee's details
            employee.Name = "Kirsi Kernel";
            employee.Profession = "Principal Teacher";
            employee.Salary = 2200;
            Console.WriteLine(employee.GetEmployeeInfo());
        }
    }
}
