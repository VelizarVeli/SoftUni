using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main()
        {
            Console.Write("Choose a file path: ");
            var filePath = Console.ReadLine();

            using (var reader = new StreamReader(filePath))
            {
                var readLine = reader.ReadLine();
                int counter = 0;
                while (true)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(readLine);
                    }
                    if (readLine == null)
                    {
                        break;
                    }
                    readLine = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}
