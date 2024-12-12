using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T43_Bonus_task
{
    // Class representing a fellow (employee)
    class Fellow
    {
        public string Initials { get; set; }
        public List<WorkEntry> WorkEntries { get; set; } = new List<WorkEntry>();

        public Fellow(string initials)
        {
            Initials = initials;
        }

        public void AddWorkEntry(WorkEntry entry)
        {
            WorkEntries.Add(entry);
            Console.WriteLine($"Work entry added for {Initials}: {entry.Date.ToShortDateString()} - Project: {entry.ProjectId} - Hours: {entry.Hours}\n");
        }
    }

    // Class representing a work entry
    class WorkEntry
    {
        public string ProjectId { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }

        public WorkEntry(string projectId, DateTime date, double hours)
        {
            ProjectId = projectId;
            Date = date;
            Hours = hours;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fellow> fellows = new List<Fellow>();

            // Adding fellows
            Fellow alice = new Fellow("AL");
            Fellow bob = new Fellow("BO");
            Fellow charlie = new Fellow("CH");
            fellows.Add(alice);
            fellows.Add(bob);
            fellows.Add(charlie);
            Console.WriteLine("Fellows added to the system:\n- AL (Alice)\n- BO (Bob)\n- CH (Charlie)\n");

            // Adding work entries
            alice.AddWorkEntry(new WorkEntry("ProjectA", DateTime.Now.AddDays(-2), 5));
            alice.AddWorkEntry(new WorkEntry("ProjectB", DateTime.Now.AddDays(-1), 3));
            bob.AddWorkEntry(new WorkEntry("ProjectA", DateTime.Now, 7));
            charlie.AddWorkEntry(new WorkEntry("ProjectC", DateTime.Now.AddDays(-3), 4));

            // Display work hours by fellow
            Console.WriteLine("Work hours by fellows:\n");
            foreach (var fellow in fellows)
            {
                Console.WriteLine($"{fellow.Initials} has logged the following hours:");
                foreach (var entry in fellow.WorkEntries)
                {
                    Console.WriteLine($"- {entry.Date.ToShortDateString()} - Project: {entry.ProjectId} - Hours: {entry.Hours}");
                }
                Console.WriteLine();
            }

            // Display work hours by project
            Console.WriteLine("Work hours by project:\n");
            var workEntriesByProject = fellows.SelectMany(f => f.WorkEntries)
                                              .GroupBy(e => e.ProjectId)
                                              .ToList();
            foreach (var projectGroup in workEntriesByProject)
            {
                Console.WriteLine($"Project {projectGroup.Key}:");
                foreach (var entry in projectGroup)
                {
                    Console.WriteLine($"- {entry.Date.ToShortDateString()} - Fellow: {fellows.First(f => f.WorkEntries.Contains(entry)).Initials} - Hours: {entry.Hours}");
                }
                Console.WriteLine();
            }

            // Display total work hours by week
            Console.WriteLine("Total work hours by week:\n");
            var workEntriesByWeek = fellows.SelectMany(f => f.WorkEntries)
                                           .GroupBy(e => System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(e.Date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                                           .ToList();
            foreach (var weekGroup in workEntriesByWeek)
            {
                Console.WriteLine($"Week {weekGroup.Key}: Total Hours: {weekGroup.Sum(e => e.Hours)}");
            }

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}
