using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
// 44/100
namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> plants = new Stack<int>();
            Stack<int> after = new Stack<int>();
            for (int i = 0; i < numberOfPlants; i++)
            {
                plants.Push(input[i]);
            }
            int days = 0;
            while (true)
            {
                int count = plants.Count;
                for (int j = 0; j < numberOfPlants; j++)
                {
                    int first = plants.Pop();
                    int second = plants.Peek();
                    if (first <= second)
                    {
                        after.Push(first);
                    }
                    if (plants.Count == 1)
                    {
                        if (first <= second)
                        {
                            after.Push(plants.Peek());
                        }
                        break;
                    }
                }
                if (count == after.Count)
                {
                    break;
                }
                days++;
                plants.Clear();

                plants = new Stack<int>(after);
                after.Clear();
            }
            Console.WriteLine(days);
        }
    }
}
