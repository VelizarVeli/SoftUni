using System;

namespace _04.Telephony
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' });
            var urls = Console.ReadLine().Split(new[] { ' ' });

            Smartphone phone = new Smartphone(numbers, urls);

            Console.Write(phone.ToString());
        }
    }
}
