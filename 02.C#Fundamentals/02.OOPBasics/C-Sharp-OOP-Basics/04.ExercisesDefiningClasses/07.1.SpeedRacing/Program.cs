using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._1.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);
                cars.Add(car);
            }

            string inp;

            while ((inp = Console.ReadLine()) != "End")
            {
                string[] input = inp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[1];
                double amountOfKm = double.Parse(input[2]);

                Car car = cars.FirstOrDefault(a => a.Model == carModel);
                car.DistanceCheck(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
