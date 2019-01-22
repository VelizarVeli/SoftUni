using System;

public class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        var middleAged = new MiddleAged();
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            int age = int.Parse(input[1]);
            Person member = new Person(name, age);

            middleAged.AddMember(member);
        }
        var checky = middleAged.GetMiddleAged();
        
        foreach (var memb in checky)
        {
            Console.WriteLine($"{memb.Name} - {memb.Age}");
        }
    }
}