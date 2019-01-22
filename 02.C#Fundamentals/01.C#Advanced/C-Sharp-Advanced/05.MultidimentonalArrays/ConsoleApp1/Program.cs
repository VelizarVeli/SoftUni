using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsColumns = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int sum = 0;
            for (int rows = 0; rows < rowsColumns[0]; rows++)
            {
                int[] rowses = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int columns = 0; columns < rowsColumns[1]; columns++)
                {
                    int element = rowses[columns];
                    sum += element;
                }
            }
            Console.WriteLine(rowsColumns[0]);
            Console.WriteLine(rowsColumns[1]);
            Console.WriteLine(sum);
        }
    }
}
