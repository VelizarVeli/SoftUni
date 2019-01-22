using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolCompetition
{
    public class Program
    {
        public static void Main()
        {
            var categories = new Dictionary<string,HashSet<string>>();
            var results = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }

                string studentName = input[0];
                string category = input[1];
                int points = int.Parse(input[2]);

                if (!categories.ContainsKey(studentName))
                {
                    categories.Add(studentName, new HashSet<string>());
                }

                categories[studentName].Add(category);

                if (!results.ContainsKey(studentName))
                {
                    results.Add(studentName, points);
                }
                else
                {
                    results[studentName] += points;
                }
            }

            var orderedStudents = results.OrderByDescending(s => s.Value).ThenBy(s => s.Key);

            foreach (var student in orderedStudents)
            {
                var orderedCategories = categories[student.Key].OrderBy(c => c);

                Console.WriteLine($"{student.Key}: {student.Value} [{string.Join(", ", orderedCategories)}]");
            }
        }
    }
}