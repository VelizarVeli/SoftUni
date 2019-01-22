using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var decimalNumber = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (decimalNumber != 0)
                {
                    stack.Push(decimalNumber % 2);
                    decimalNumber /= 2;
                }
                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
                Console.WriteLine();
            }
        }
    }
}
