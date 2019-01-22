using System;

class Startup
{
    static void Main()
    {
        var boxesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < boxesCount; i++)
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}