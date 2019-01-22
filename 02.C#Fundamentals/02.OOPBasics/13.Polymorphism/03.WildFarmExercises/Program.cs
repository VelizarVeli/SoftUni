using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var animals = new List<Animal>();

        string animalArgs = string.Empty;
        while ((animalArgs = Console.ReadLine()) != "End")
        {
            var args = animalArgs.Split();
            var animalType = args[0];

            Animal animal;

            var feeding = Console.ReadLine().Split();
            var foodType = feeding[0];
            var quantity = int.Parse(feeding[1]);

            try
            {
                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    case "Tiger":
                        animal = new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    case "Owl":
                        animal = new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    case "Hen":
                        animal = new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    case "Mouse":
                        animal = new Mouse(args[1], double.Parse(args[2]), args[3]);
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    case "Dog":
                        animal = new Dog(args[1], double.Parse(args[2]), args[3]);
                        animals.Add(animal);
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(foodType, quantity);
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        animals.ForEach(a => Console.WriteLine(a));
    }
}