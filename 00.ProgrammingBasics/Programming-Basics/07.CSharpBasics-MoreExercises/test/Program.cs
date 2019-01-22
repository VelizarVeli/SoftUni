using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = (int)Math.Floor(Math.Log10(n) + 1);

            Console.WriteLine(count);
        }
    }
}
