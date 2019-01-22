using System;

namespace _03.Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new global::Ferrari(Console.ReadLine());
            Console.WriteLine(car.ToString());

            string ferrariName = typeof(global::Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
