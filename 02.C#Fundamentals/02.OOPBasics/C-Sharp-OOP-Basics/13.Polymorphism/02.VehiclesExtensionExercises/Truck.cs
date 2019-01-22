using System;

public class Truck : Vehicle
{
    private const double TakenFuelInCharging = 0.95; 

    public Truck(double fuelAmount, double fuelConsumption, double airConditioningConsumption, double fuelTankCapacity)
        : base(fuelAmount, fuelConsumption, airConditioningConsumption, fuelTankCapacity)
    {
    }
    protected override double FuelAmount
    {
        get
        {
            return base.FuelAmount;
        }

        set
        {
            if (value > this.FuelTankCapacity)
            {
                throw new ArgumentException($"Cannot fit {value * 0.95238089995:F0} fuel in the tank");
            }

            base.FuelAmount = value;
        }
    }
    public override void Refuel(double fuel)
    {
        fuel *= TakenFuelInCharging;
        base.Refuel(fuel);
    }
}