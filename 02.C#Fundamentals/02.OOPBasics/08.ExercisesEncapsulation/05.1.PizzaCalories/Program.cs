using System;

class Program
{
    static void Main()
    {
        try
        {

            string pizzaName = Console.ReadLine().Split()[1];
            Pizza pizza = new Pizza(pizzaName);

            Dough dough = CreateDough();

            pizza.SetDough(dough);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                CreateTopping(command, pizza);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static Dough CreateDough()
    {
        string[] doughInput = Console.ReadLine().Split();
        string flourType = doughInput[1];
        string bakingTechnique = doughInput[2];
        double doughWeight = double.Parse(doughInput[3]);

        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
        return dough;
    }

    static void CreateTopping(string command, Pizza pizza)
    {
        string[] toppingInput = command.Split();
        string toppingType = toppingInput[1];
        double toppingWeight = double.Parse(toppingInput[2]);

        Topping topping = new Topping(toppingType, toppingWeight);
        pizza.AddToping(topping);
    }
}