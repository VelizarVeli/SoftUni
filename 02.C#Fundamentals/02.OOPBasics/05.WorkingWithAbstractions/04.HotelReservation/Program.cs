using System;

class Program
{
    static void Main()
    {
        var command = Console.ReadLine();
        var priceCalculator = new PriceCalculator(command);
        var totalPrice = priceCalculator.CalculatePrice();
        Console.WriteLine(totalPrice);
    }
}
