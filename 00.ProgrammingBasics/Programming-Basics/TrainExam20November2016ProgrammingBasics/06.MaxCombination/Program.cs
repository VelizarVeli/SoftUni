using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    Console.Write($"<{i}-{j}>");
                    counter++;
                    if(counter == control)
                    {
                        break;
                    }
                }
                if (counter == control)
                {
                    break;
                }
            }
        }
    }
}
