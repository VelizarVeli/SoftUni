using System;

class Startup
{
    static void Main()
    {
        var firstLine = Console.ReadLine().Split();
        var fullName = firstLine[0] + " " + firstLine[1];
        var address = firstLine[2];
        var town = firstLine[3];

        var firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);
        Console.WriteLine(firstThreeuple);

        var secondLine = Console.ReadLine().Split();
        var name = secondLine[0];
        var litersOfBeer = int.Parse(secondLine[1]);
        var isDrunk = false;
        if (secondLine[2] == "drunk")
        {
            isDrunk = true;
        }

        var secondThreeuple = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);
        Console.WriteLine(secondThreeuple);

        var thirdLine = Console.ReadLine().Split();
        var persoName = thirdLine[0];
        var bankBalance = double.Parse(thirdLine[1]);
        var bankName = thirdLine[2];

        var thirdThreeuple = new Threeuple<string, double, string>(persoName, bankBalance, bankName);
        Console.WriteLine(thirdThreeuple);
    }
}