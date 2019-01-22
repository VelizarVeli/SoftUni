using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SvetovenRecordPoPluvane
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double lengthInMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double seconds = lengthInMeters * secondsPerMeter;
            double plusPetnadeset = Math.Floor(lengthInMeters / 15) * 12.5;
            double totalTime = seconds + plusPetnadeset;

            double diff = Math.Abs(totalTime - record);

            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {diff:f2} seconds slower.");
            }
        }
    }
}
