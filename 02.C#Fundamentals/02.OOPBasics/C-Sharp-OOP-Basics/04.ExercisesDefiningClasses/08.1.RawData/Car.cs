public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tire Tire { get; set; }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, 
        int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age,
        double tire4Pressure, int tire4Age)
    {
        this.Model = model;
        this.Engine = new Engine(engineSpeed, enginePower);
        this.Cargo = new Cargo(cargoWeight, cargoType);
        this.Tire = new Tire( tire1Pressure,  tire1Age,  tire2Pressure,  tire2Age,  tire3Pressure,  tire3Age,
         tire4Pressure,  tire4Age);
    }
}