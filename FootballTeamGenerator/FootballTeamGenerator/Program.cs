using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            var input = Console.ReadLine().Split(';');

            while (input[0] != "END")
            {
                var command = input[0];
                var teamName = input[1];
                try
                {
                    if (command == "Add")
                    {
                        CheckTeam(teams, teamName);

                        var playerName = input[2];
                        var newPlayer = new Player(playerName, CreatNewStats(input));
                        
                        teams.First(t => t.Name == teamName).AddPlayer(newPlayer);

                    }
                    else if (command == "Remove")
                    {

                        CheckTeam(teams, teamName);
                       
                        var playerName = input[2];
                        teams.First(t => t.Name == teamName).RemovePlayer(playerName);

                    }
                    else if (command == "Rating")
                    {

                        CheckTeam(teams, teamName);

                        var rating = teams.First(t => t.Name == teamName).RatingTeam();
                        
                        Console.WriteLine($"{teamName} - {Math.Round(rating)}");

                    }
                    else if (command == "Team")
                    {

                        teams.Add(new Team(teamName));
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }


                input = Console.ReadLine().Split(';');
            }


        }

        private static void CheckTeam(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        private static Stats CreatNewStats(string[] input)
        {
            int endurance = int.Parse(input[3]);
            int sprint = int.Parse(input[4]);
            int dribble = int.Parse(input[5]);
            int passing = int.Parse(input[6]);
            int shooting = int.Parse(input[7]);


            return new Stats(endurance, sprint, dribble, passing, shooting);
           
        }
    }
}
