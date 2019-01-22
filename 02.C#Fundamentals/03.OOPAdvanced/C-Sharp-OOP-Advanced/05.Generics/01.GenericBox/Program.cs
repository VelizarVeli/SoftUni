using System;

class Startup
{
    static void Main()
    {
        var intInput = int.Parse(Console.ReadLine());
        var intBox = new Box<int>(intInput);
        Console.WriteLine(intBox);

        var stringInput = Console.ReadLine();
        var stringBox = new Box<string>(stringInput);
        Console.WriteLine(stringBox);
    }
}