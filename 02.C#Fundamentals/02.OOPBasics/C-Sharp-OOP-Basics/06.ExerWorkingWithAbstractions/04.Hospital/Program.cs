using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string input = Console.ReadLine();
            while (input != "Output")
            {
                string[] commands = input.Split();
                var departament = commands[0];
                var firstDoctorName = commands[1];
                var secondDoctorName = commands[2];
                var patient = commands[3];
                var doctorFirstAndLastName = firstDoctorName + secondDoctorName;

                GatheringInDictionary(doctors, departments, departament, firstDoctorName, secondDoctorName, doctorFirstAndLastName);

                IsTherePlace(doctors, departments, departament, patient, doctorFirstAndLastName);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                input = PrintOutput(doctors, departments, input);
            }
        }

        private static string PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string input)
        {
            string[] args = input.Split();

            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
            input = Console.ReadLine();
            return input;
        }

        private static void GatheringInDictionary(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string firstDoctorName, string secondDoctorName, string doctorFirstAndLastName)
        {
            if (!doctors.ContainsKey(firstDoctorName + secondDoctorName))
            {
                doctors[doctorFirstAndLastName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void IsTherePlace(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string doctorFirstAndLastName)
        {
            bool thereIsPlace = departments[departament].SelectMany(x => x).Count() < 60;
            if (thereIsPlace)
            {
                int room = 0;
                doctors[doctorFirstAndLastName].Add(patient);
                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }
    }
}
