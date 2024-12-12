using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10_Student
{
    public class Student
    {
        // Auto-implemented properties for Firstname, Lastname, Age, StudentID, GradeLevel
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        private int Age { get; set; }
        private string StudentID { get; set; }
        private int GradeLevel { get; set; }

        // Constructor to initialise the Student object
        public Student(string firstname, string lastname, int age, string studentID, int gradelevel)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            StudentID = studentID;
            GradeLevel = gradelevel;    
        }

        // Method to display basic information about the student
        public string ShowInfo()
        {
            return $"Name: {Firstname} {Lastname}, ID: {StudentID}, Grade Level: {GradeLevel}";
        }

        // Overriding ToString() to provide a detailed string representation of the student
        public override string ToString()
        {
            return $"Name: {Firstname} {Lastname}, Age: {Age}, ID: {StudentID}, Grade: {GradeLevel}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a collection (List) to store Student objects
            List<Student> students = new List<Student>();

            // Create five student objects
            students.Add(new Student("Laroi", "Nguyen", 22, "TIC220", 1));
            students.Add(new Student("Loris", "Luu", 23, "TIC221", 2));
            students.Add(new Student("Franklyn", "Le", 21, "TIC222", 2));
            students.Add(new Student("Harol", "Tran", 25, "TIC223", 4));
            students.Add(new Student("Louis", "Dao", 28, "TIC224", 3));

            // Print the data for each student using a loop
            Console.WriteLine("Student Information:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString()); // Using the overidden ToString method
            }
        }
    }
}
