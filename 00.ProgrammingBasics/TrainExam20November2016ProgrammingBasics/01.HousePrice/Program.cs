using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HousePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double roomOne = double.Parse(Console.ReadLine());
            double kitchen = double.Parse(Console.ReadLine());
            double pricePerSqM = double.Parse(Console.ReadLine());

            double roomTwo = roomOne * 1.1;
            double roomThree = roomTwo * 1.1;
            double bathroom = roomOne / 2;
            double allSquare = (roomOne + roomTwo + roomThree + bathroom + kitchen) * 1.05;

            double totalPrice = allSquare * pricePerSqM;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
