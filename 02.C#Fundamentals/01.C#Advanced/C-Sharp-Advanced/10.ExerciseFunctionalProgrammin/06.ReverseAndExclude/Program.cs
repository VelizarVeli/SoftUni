using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int delimeter = int.Parse(Console.ReadLine());
            input = input.Where(n => n % delimeter != 0).ToList();
             input.Reverse();
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
