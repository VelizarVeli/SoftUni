using System;
using System.Collections.Generic;

namespace _06.TrafficLights
{
    class Program
    {
        static void Main()
        {
            int cycle = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            while (input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < cycle; i++)
                    {
                        if (cars.Count ==0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
