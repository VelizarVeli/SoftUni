using System;

namespace _03._1.Mankind
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();
                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                string facultyNumber = studentInfo[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerInfo = Console.ReadLine().Split();
                string workerFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal salary = decimal.Parse(workerInfo[2]);
                decimal workingHours = decimal.Parse(workerInfo[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, salary, workingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
