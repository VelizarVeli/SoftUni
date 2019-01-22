using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a file path: ");
            var filePath = Console.ReadLine();

            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var readLine = reader.ReadLine();
                    int counter = 1;
                    while (true)
                    {
                        writer.WriteLine($"Line {counter}: {readLine}");
                        counter++;
                        readLine = reader.ReadLine();

                        if (readLine == null)
                        {
                           break;
                        }
                    }
                }
            }
        }
    }
}
