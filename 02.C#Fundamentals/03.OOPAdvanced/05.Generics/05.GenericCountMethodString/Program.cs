using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var elements = new List<string>();

        var elementsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < elementsCount; i++)
        {
            elements.Add(Console.ReadLine());
        }

        var valueToCompareWith = Console.ReadLine();

        var result = CountGreaterThanValue(elements, valueToCompareWith);

        Console.WriteLine(result);
    }

    public static int CountGreaterThanValue<T>(List<T> elements, T value)
        where T : IComparable<T>
    {
        int counter = 0;

        foreach (var element in elements)
        {
            if (element.CompareTo(value) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}