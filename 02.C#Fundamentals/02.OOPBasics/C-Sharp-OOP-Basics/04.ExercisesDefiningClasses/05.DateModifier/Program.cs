using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateDaysBetween(firstDate,secondDate));
    }
}