using System;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionFor1Km { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionFor1Km)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1Km = fuelConsumptionFor1Km;
        this.DistanceTraveled = 0;
    }

    public void DistanceCheck(double amountOfKm)
    {
        double usedFuel = amountOfKm * this.FuelConsumptionFor1Km;

        if (usedFuel <= this.FuelAmount)
        {
            this.FuelAmount -= usedFuel;
            this.DistanceTraveled += amountOfKm;
        }

        else
        {
            Console.WriteLine($"Insufficient fuel for the drive");
        }
    }
}