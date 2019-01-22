using System;

namespace _09.PasswordGuess
{
    class Program
    {
        static void Main()
        {
            var pass = Console.ReadLine();

            if (pass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
