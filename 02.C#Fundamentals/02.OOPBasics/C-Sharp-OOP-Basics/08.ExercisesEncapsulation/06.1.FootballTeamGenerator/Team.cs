using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players = new List<Player>();

    public Team(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value == "")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    public double CalculateRating()
    {
        double rating = 0;

        if (players.Count != 0)
        {
            rating = this.players.Select(a => a.CalculateAverageStats()).Average();
        }

        return rating;
    }

    public void AddPlayer(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        try
        {
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            this.players.Add(player);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void RemovePlayer(string currentPlayerName)
    {
        var currentPlayer = players.FirstOrDefault(p => p.Name == currentPlayerName);
        if (currentPlayer == null)
        {
            Console.WriteLine($"Player {currentPlayerName} is not in {this.Name} team.");
        }
        else
        {
            this.players.Remove(currentPlayer);
        }
    }
}