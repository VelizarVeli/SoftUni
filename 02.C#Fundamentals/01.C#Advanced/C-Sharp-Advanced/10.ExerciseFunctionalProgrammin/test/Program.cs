using System;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        var texts = Console.ReadLine().Split();
        var cmdCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < cmdCount; i++)
        {

            var cmd = Console.ReadLine().Split();

            if (cmd[0] == "Reverse")
            {
                Array.Reverse(texts);

            }
            else if (cmd[0] == "Distinct")
            {
                string[] q = texts.Distinct().ToArray();
                texts = q;

            }

            else if (cmd[0] == "Replace")
            {
                var indexForReplace = int.Parse(cmd[1]);
                var word = cmd[2];
                texts[indexForReplace] = word;
            }

        }


        Console.WriteLine(string.Join(", ", texts));


    }
}
