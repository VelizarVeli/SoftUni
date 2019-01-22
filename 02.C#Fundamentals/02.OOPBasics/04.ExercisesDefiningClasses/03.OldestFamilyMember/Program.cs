using System;

public class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        var family = new Family();
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);

            Person member = new Person(name, age);
            family.AddMember(member);
        }

        int oldestAge = family.GetOldestMember().Age;
        string oldestName = family.GetOldestMember().Name;
        Console.WriteLine($"{oldestName} {oldestAge}");
    }
}