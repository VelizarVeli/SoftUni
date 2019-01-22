using System;
using System.Collections.Generic;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorker> workingMethods = new List<IWorker>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inp = input.Split();
                string type = inp[0];
                string name = inp[1];

                if (type == "robot")
                {
                    IWorker robot = new Robot(name);
                    workingMethods.Add(robot);
                }
                else
                {
                    Worker worker = new Worker(name);
                    workingMethods.Add(worker);
                }
            }

            GetRobot(workingMethods);
        }

        public static void GetRobot(List<IWorker> workingMethods)
        {
            foreach (var unit in workingMethods)
            {
                unit.Work();

                if (unit is Robot)
                {
                    Console.WriteLine(unit);
                }
            }
        }
    }
}
