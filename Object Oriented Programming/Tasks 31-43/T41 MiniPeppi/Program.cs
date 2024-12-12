using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T41_MiniPeppi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SID { get; set; }
        public string Group { get; set; }

        public Student(string firstName, string lastName, string group, int runningNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SID = GenerateSID(firstName, lastName, runningNumber);
            Group = group;
        }

        private string GenerateSID(string firstName, string lastName, int runningNumber)
        {
            return $"{firstName[0]}{lastName[0]}{runningNumber:D3}";
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {SID} {Group}";
        }
    }

    public class MiniPeppi
    {
        private List<Student> students;
        private int runningNumber;

        public MiniPeppi()
        {
            students = new List<Student>();
            runningNumber = 1;
            AddInitialStudents();
        }

        private void AddInitialStudents()
        {
            students.Add(new Student("Hanna", "Husso", "TTV19S1", runningNumber++));
            students.Add(new Student("Kirsi", "Kernell", "TTV19S2", runningNumber++));
            students.Add(new Student("Masa", "Niemi", "TTV19S3", runningNumber++));
            students.Add(new Student("Frank", "Tester", "TTV19SM", runningNumber++));
            students.Add(new Student("Allan", "Aalto", "TTV19SMM", runningNumber++));
        }

        public void AddStudent()
        {
            Console.WriteLine("Please, give data of new Student:");
            Console.Write("SID: ");
            string sid = Console.ReadLine();

            if (students.Any(s => s.SID == sid))
            {
                Console.WriteLine($"Student with SID {sid} already exists in the register.");
                return;
            }

            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Surname: ");
            string lastName = Console.ReadLine();
            Console.Write("Group: ");
            string group = Console.ReadLine();

            Student newStudent = new Student(firstName, lastName, group, runningNumber++);
            students.Add(newStudent);
            Console.WriteLine($"{newStudent.FirstName} {newStudent.LastName} added successfully. There are now {students.Count} students in MiniPeppi.");
        }

        public void ListAllStudents()
        {
            Console.WriteLine("The all students in MiniPeppi:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void ListAllStudentsAlphabetically()
        {
            Console.WriteLine("The all students in alphabetical order in MiniPeppi:");
            foreach (var student in students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMiniPeppi Menu:");
                Console.WriteLine("1. List all students");
                Console.WriteLine("2. List all students in alphabetical order");
                Console.WriteLine("3. Add new student");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListAllStudents();
                        break;
                    case "2":
                        ListAllStudentsAlphabetically();
                        break;
                    case "3":
                        AddStudent();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MiniPeppi miniPeppi = new MiniPeppi();
            miniPeppi.Start();
        }
    }
}
