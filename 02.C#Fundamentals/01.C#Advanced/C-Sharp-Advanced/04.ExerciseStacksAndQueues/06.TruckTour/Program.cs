using System;
using System.Collections.Generic;
using System.Linq;
// 20/100
namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<long> pumps = new Queue<long>();
            Queue<long> distances = new Queue<long>();

            long[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long amountOfPetrol = input[0];
            long distance = input[1];
            pumps.Enqueue(amountOfPetrol);
            distances.Enqueue(distance);

            for (int i = 1; i < N; i++)
            {
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                amountOfPetrol = input[0];
                distance = input[1];
                pumps.Enqueue(amountOfPetrol);
                distances.Enqueue(distance);
            }
            int index = 0;
           
            while (true)
            {
                long tank = 0;
                bool checky = true;

                for (int i = 0; i < N; i++)
                {
                    amountOfPetrol = pumps.Dequeue();
                    distance = distances.Dequeue();
                    tank += amountOfPetrol;
                    if (tank < distance)
                    {
                        pumps.Enqueue(amountOfPetrol);
                        distances.Enqueue(distance);
                        checky = false;
                        break;
                    }
                }
                if (checky)
                {
                    break;
                }
                index++;
            }
            Console.WriteLine(index);
        }
    }
}
