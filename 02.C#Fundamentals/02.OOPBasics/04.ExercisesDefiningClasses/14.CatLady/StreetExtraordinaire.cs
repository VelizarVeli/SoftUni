﻿public class StreetExtraordinaire : Cat
{
    private int decibels;

    public StreetExtraordinaire(string name, int decibels)
    {
        this.Name = name;
        this.Decibels = decibels;
    }

    public int Decibels
    {
        get { return decibels; }
        set { decibels = value; }
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.Decibels}";
    }
}