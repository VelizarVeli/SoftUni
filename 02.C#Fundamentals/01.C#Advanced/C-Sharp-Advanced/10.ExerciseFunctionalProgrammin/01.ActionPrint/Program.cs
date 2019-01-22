using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                Action<string> print = message => Console.WriteLine(message);
                print(input[i]);
            }
        }
    }
}
