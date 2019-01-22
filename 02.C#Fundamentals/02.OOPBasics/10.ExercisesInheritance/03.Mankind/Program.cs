using System;

public class Program
{
    static void Main()
    {
        string[] studentInput = Console.ReadLine().Split();
        string[] workerInput = Console.ReadLine().Split();

        try
        {
            Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);
            Worker worker = new Worker(workerInput[0],workerInput[1],decimal.Parse(workerInput[2]),decimal.Parse(workerInput[3]));
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }


    }
}