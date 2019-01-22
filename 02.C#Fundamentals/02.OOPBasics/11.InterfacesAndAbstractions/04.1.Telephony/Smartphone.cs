using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class Smartphone : ICallable, IBrowsable
{
    private long number;
    private string site;

    public Smartphone(string site)
    {
        this.Site = site;
    }

    public Smartphone()
    {
        this.Number = number;
    }
    private long Number
    {
        get { return number; }
        set
        {
            number = value;
        }
    }

    public string Site
    {
        get { return site; }
        set
        {

            foreach (var character in value)
            {
                if (Char.IsDigit(character))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }

            site = value;
        }
    }

    public void Call(string num)
    {

        Console.WriteLine($"Calling... {num}");
    }

    public void Browse()
    {
        Console.WriteLine($"Browsing: {Site}!");
    }
}