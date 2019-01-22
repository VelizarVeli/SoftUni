using System;

class Startup
{
    static void Main()
    {
        var firstLine = Console.ReadLine().Split();
        var fullName = firstLine[0] + " " + firstLine[1];
        var address = firstLine[2];

        var firstTuple = new Tuple<string, string>(fullName, address);
        Console.WriteLine(firstTuple);

        var secondLine = Console.ReadLine().Split();
        var name = secondLine[0];
        var litersOfBeer = int.Parse(secondLine[1]);

        var secondTuple = new Tuple<string, int>(name, litersOfBeer);
        Console.WriteLine(secondTuple);

        var thirdLine = Console.ReadLine().Split();
        var integerType = int.Parse(thirdLine[0]);
        var doubleType = double.Parse(thirdLine[1]);

        var thirdTuple = new Tuple<int, double>(integerType, doubleType);
        Console.WriteLine(thirdTuple);
    }
}