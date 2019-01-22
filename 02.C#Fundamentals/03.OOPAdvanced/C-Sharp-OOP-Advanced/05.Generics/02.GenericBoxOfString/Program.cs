using System;

class Startup
{
    static void Main()
    {
        var boxesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < boxesCount; i++)
        {
            var input = int.Parse(Console.ReadLine());
            var box = new Box<int>(input);
            Console.WriteLine(box);
        }
    }
}