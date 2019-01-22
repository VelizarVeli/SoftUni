using System;

namespace _00._2.GenericArrayCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
