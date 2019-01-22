public class Car
{
    private string model;
    private double fuel;
    private double consumption;
    private double distance;

    public Car(string model, double fuel, double consumption)
    {
        this.model = model;
        this.fuel = fuel;
        this.consumption = consumption;
    }
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public double Fuel
    {
        get { return this.fuel; }
        set { this.fuel = value; }
    }
    public double Consumption
    {
        get { return this.consumption; }
        set { this.consumption = value; }
    }
    public double Distance
    {
        get { return this.distance; }
        set { this.distance = value; }
    }

    public void IsMove(int km)
    {
        var fuelNeeded = km * this.consumption;
        if (fuelNeeded > this.fuel)
        {
            System.Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.fuel -= fuelNeeded;
            this.Distance += km;
        }
    }
}