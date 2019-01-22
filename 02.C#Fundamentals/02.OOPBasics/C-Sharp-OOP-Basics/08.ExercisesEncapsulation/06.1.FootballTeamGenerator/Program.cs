using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._1.FootballTeamGenerator
{
    class Program
    {
        static void Main()
        {
            string input;
            List<Team> teams = new List<Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandInfo = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string teamName = commandInfo[1];

                switch (commandInfo[0])
                {
                    case "Team":
                        AddNewTeam(teamName, teams);
                        break;

                    case "Add":
                        string playerName = commandInfo[2];
                        int endurance = int.Parse(commandInfo[3]);
                        int sprint = int.Parse(commandInfo[4]);
                        int dribble = int.Parse(commandInfo[5]);
                        int passing = int.Parse(commandInfo[6]);
                        int shooting = int.Parse(commandInfo[7]);
                        AddPlayer(teamName, playerName, endurance, sprint, dribble, passing, shooting, teams);
                        break;

                    case "Remove":
                        string playerNam = commandInfo[2];
                        RemovePlayer(teamName, playerNam, teams);
                        break;

                    case "Rating":
                        RateTeam(teamName, teams);
                        break;
                }
            }
        }

        private static void RateTeam(string teamName, List<Team> teams)
        {
            Team currTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (currTeam != null)
            {
                Console.WriteLine($"{currTeam.Name} - {currTeam.CalculateRating()}");
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }

        private static void RemovePlayer(string teamName, string playerNam, List<Team> teams)
        {
            Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);
            currentTeam.RemovePlayer(playerNam);
        }

        private static void AddNewTeam(string teamName, List<Team> teams)
        {
            try
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddPlayer(string teamName, string playerName, int endurance, int sprint, int dribble, int passing,
            int shooting, List<Team> teams)
        {
            Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);
            if (currentTeam != null)
            {
                currentTeam.AddPlayer(playerName, endurance, sprint, dribble, passing, shooting);
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }
    }
}
