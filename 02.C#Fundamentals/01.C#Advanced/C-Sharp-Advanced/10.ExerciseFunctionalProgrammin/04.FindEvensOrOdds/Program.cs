using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main()
        {
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(bounds);
            int numbersCount = bounds[1] - bounds[0] + 1;
            List<int> numbers = Enumerable.Range(bounds[0], numbersCount).ToList();
            string filter = Console.ReadLine();
            if (filter.ToLower().Equals("even")) numbers = numbers.FindAll(even);
            else if (filter.ToLower().Equals("odd")) numbers = numbers.FindAll(odd);
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}