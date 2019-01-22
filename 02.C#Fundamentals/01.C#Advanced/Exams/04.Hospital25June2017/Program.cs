using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital25June2017
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, List<string>> departmentData = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();
            Dictionary<string, Dictionary<int, List<string>>> roomPatients = new Dictionary<string, Dictionary<int, List<string>>>();

            while (input[0] != "Output")
            {
                string department = input[0];
                string doctor = input[1] + " " + input[2];
                string patient = input[3];

                if (!departmentData.ContainsKey(department))
                {
                    departmentData.Add(department, new List<string>());
                }
                departmentData[department].Add(patient);


                if (!doctorPatients.ContainsKey(doctor))
                {
                    doctorPatients.Add(doctor, new List<string>());
                }
                doctorPatients[doctor].Add(patient);

                if (!roomPatients.ContainsKey(department))
                {
                    roomPatients.Add(department, new Dictionary<int, List<string>>()); ;
                    roomPatients[department].Add(1, new List<string>());
                }

                int roomNumber = roomPatients[department].Count;
                if (roomNumber < 21)
                {
                    int checkPatientsInRoom = roomPatients[department][roomNumber].Count + 1;
                    if (checkPatientsInRoom >= 3)
                    {
                        roomPatients[department].Add(roomNumber + 1, new List<string>());
                    }

                    roomPatients[department][roomNumber].Add(patient);
                }
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {

                if (commands.Length == 1)
                {
                    foreach (var patient in departmentData[commands[0]])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    try
                    {
                        int room = int.Parse(commands[1]);
                        foreach (var rooms in roomPatients)
                        {
                            string dep = rooms.Key;
                            var roomPatient = rooms.Value;
                            foreach (var roo in roomPatient)
                            {
                                List<string> patiens = roo.Value;
                                if (dep == commands[0] && roo.Key == room)

                                    foreach (var patien in patiens.OrderBy(a => a))
                                    {
                                        Console.WriteLine(patien);
                                    }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string doc = commands[0] + " " + commands[1];
                        foreach (var doctor in doctorPatients)
                        {
                            var patients = doctor.Value.OrderBy(a => a);
                            if (doctor.Key == doc)
                            {
                                foreach (var patient in patients)
                                {
                                    Console.WriteLine(patient);
                                }
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
