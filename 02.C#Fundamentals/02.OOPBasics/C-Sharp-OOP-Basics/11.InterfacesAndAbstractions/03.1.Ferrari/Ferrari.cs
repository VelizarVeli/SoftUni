using System;

public class Ferrari:IMovable
{
    private string DriverName { get; }

    public Ferrari(string name)
    {
        this.DriverName = name;
    }

    public string Run()
    {
        string run = "Zadu6avam sA!";

        return run;
    }

    public string Stop()
    {
        string stop = "Brakes!";

        return stop;
    }

    public override string ToString()
    {
        return $"488-Spider/{Stop()}/{Run()}/{DriverName}";
    }
}