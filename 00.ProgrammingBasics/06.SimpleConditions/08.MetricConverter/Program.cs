using System;

namespace _08.MetricConverter
{
    class Program
    {
        static void Main()
        {
            var num = double.Parse(Console.ReadLine());
            var metricOne = Console.ReadLine();
            var metricTwo = Console.ReadLine();
            double metric = 0;
            double result = 0;

            if (metricOne == "mm")
            {
                metric = num / 1000;
            }   
            else if (metricOne == "cm")
            {
                metric = num / 100;
            }
            else if (metricOne == "mi")
            {
                metric = num / 0.000621371192;
            }
            else if (metricOne == "in")
            {
                metric = num / 39.3700787;
            }
            else if (metricOne == "km")
            {
                metric = num / 0.001;
            }
            else if (metricOne == "ft")
            {
                metric = num / 3.2808399;
            }
            else if (metricOne == "yd")
            {
                metric = num / 1.0936133;
            }
            else if (metricOne == "m")
            {
                metric = num;
            }

            if (metricTwo == "mm")
            {
                result = metric * 1000;
            }
            else if (metricTwo == "cm")
            {
                result = metric * 100;
            }
            else if (metricTwo == "mi")
            {
                result = metric * 0.000621371192;
            }
            else if (metricTwo == "in")
            {
                result = metric * 39.3700787;
            }
            else if (metricTwo == "km")
            {
                result = metric * 0.001;
            }
            else if (metricTwo == "ft")
            {
                result = metric * 3.2808399;
            }
            else if (metricTwo == "yd")
            {
                result = metric * 1.0936133;
            }
            else if (metricTwo == "m")
            {
                result = metric;
            }

            Console.WriteLine($"{result} {metricTwo}");
        }
    }
}
