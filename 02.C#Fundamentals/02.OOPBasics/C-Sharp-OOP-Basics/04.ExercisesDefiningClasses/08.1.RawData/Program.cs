using System;
using System.Collections.Generic;

namespace _08._1.RawData
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure,
                    tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == command && (car.Tire.Tire1Pressure < 1 || car.Tire.Tire2Pressure < 1 || car.Tire.Tire3Pressure < 1
                        || car.Tire.Tire4Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
