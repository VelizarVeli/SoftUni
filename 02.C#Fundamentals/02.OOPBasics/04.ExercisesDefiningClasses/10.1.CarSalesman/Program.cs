using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._1.CarSalesman
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                if (input.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else
                {
                    if (input.Length == 3)
                    {
                        try
                        {
                            int displacement = int.Parse(input[2]);
                            Engine engine = new Engine(model, power, displacement);
                            engines.Add(engine);
                        }
                        catch (Exception)
                        {
                            string efficiency = input[2];
                            Engine engine = new Engine(model, power, efficiency);
                            engines.Add(engine);
                        }
                    }
                    else
                    {
                        int displacement = int.Parse(input[2]);
                        string efficiency = input[3];
                        Engine engine = new Engine(model, power, displacement, efficiency);
                        engines.Add(engine);
                    }
                }
            }

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engine = input[1];

                if (input.Length == 2)
                {
                    Engine currentEngine = engines.FirstOrDefault(a => a.Model == engine);
                    Car car = new Car(model, currentEngine);
                    cars.Add(car);
                }
                else
                {
                    if (input.Length == 3)
                    {
                        try
                        {
                            double weight = double.Parse(input[2]);
                            Engine currentEngine = engines.FirstOrDefault(a => a.Model == engine);
                            Car car = new Car(model, currentEngine, weight);
                            cars.Add(car);
                        }
                        catch (Exception)
                        {
                            string color = input[2];
                            Engine currentEngine = engines.FirstOrDefault(a => a.Model == engine);
                            Car car = new Car(model, currentEngine, color);
                            cars.Add(car);
                        }
                    }
                    else
                    {
                        double weight = double.Parse(input[2]);
                        string color = input[3];
                        Engine currentEngine = engines.FirstOrDefault(a => a.Model == engine);
                        Car car = new Car(model, currentEngine, weight, color);
                        cars.Add(car);
                    }
                }
            }

            foreach (var eng in cars)
            {
                Console.WriteLine(eng);
            }
        }
    }
}
