using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        Chicken chicken;

        try
        {
            chicken = new Chicken(name, age);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine(
            "Chicken {0} (age {1}) can produce {2} eggs per day.",
            chicken.Name,
            chicken.Age,
            chicken.GetProductPerDay());
    }
}