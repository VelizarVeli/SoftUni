using System;
using System.Collections.Generic;

namespace _05._1.BorderControl
{
    class Program
    {
        static void Main()
        {
            List<National> nationals = new List<National>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inp = input.Split();

                if (inp.Length == 2)
                {
                    string model = inp[0];
                    string id = inp[1];

                    Robot robot = new Robot(model, id);
                    nationals.Add(robot);
                }

                else if (inp.Length == 3)
                {
                    string name = inp[0];
                    int age = int.Parse(inp[1]);
                    string id = inp[2];

                    Citizen citizen = new Citizen(name, age, id);
                    nationals.Add(citizen);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (var national in nationals)
            {
                string check = national.Id.Substring(national.Id.Length - fakeId.Length);

                if (check == fakeId)
                {
                    Console.WriteLine(national.Id);
                }
            }
        }
    }
}
