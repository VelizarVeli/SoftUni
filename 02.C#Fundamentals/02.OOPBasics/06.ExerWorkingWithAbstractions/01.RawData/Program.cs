using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                var engine = new Engine(int.Parse(parameters[1]), int.Parse(parameters[2]));
                var cargo = new Cargo(int.Parse(parameters[3]), parameters[4]);
                var tire1 = new Tire(double.Parse(parameters[5]), int.Parse(parameters[6]));
                var tire2 = new Tire(double.Parse(parameters[7]), int.Parse(parameters[8]));
                var tire3 = new Tire(double.Parse(parameters[9]), int.Parse(parameters[10]));
                var tire4 = new Tire(double.Parse(parameters[11]), int.Parse(parameters[12]));

                cars.Add(new Car(model, engine.Speed, engine.Power, cargo.Weight, cargo.Type, tire1.Pressure, tire1.Age,
                    tire2.Pressure, tire2.Age, tire3.Pressure, tire3.Age, tire4.Pressure, tire4.Age));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
