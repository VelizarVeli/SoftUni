using System;

public class Player
{
    private const int MIN_STAT = 0;
    private const int MAX_STAT = 100;

    private string name;

    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == "")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }


    public int Endurance
    {
        get { return endurance; }
        private set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Endurance should be between {MIN_STAT} and {MAX_STAT}.");
            }

            endurance = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Sprint should be between {MIN_STAT} and {MAX_STAT}.");
            }

            sprint = value;
        }
    }
    public int Dribble
    {
        get { return dribble; }
        private set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Dribble should be between {MIN_STAT} and {MAX_STAT}.");
            }

            dribble = value;
        }
    }
    public int Passing
    {
        get { return passing; }
        private set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Passing should be between {MIN_STAT} and {MAX_STAT}.");
            }

            passing = value;
        }
    }
    public int Shooting
    {
        get { return shooting; }
        private set
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException($"Shooting should be between {MIN_STAT} and {MAX_STAT}.");
            }

            shooting = value;
        }
    }

    public double CalculateAverageStats()
    {
        double average = Math.Round((double)(this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5);

        return average;
    }
}