using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name 
        { 
            get => this.name;
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            } 
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (!players.Any(p => p.Name == name))
            {
                throw new ArgumentException($"Player {name} is not in {this.name} team.");
            }
           
            players.Remove(players.First(p => p.Name == name));
        }

        public double RatingTeam()
        {
            double TeamSkill = 0;
            foreach (var player in players)
            {
                TeamSkill += player.PlayerStats.AverageSkill();
            }
            return players.Count > 0 ? TeamSkill / players.Count : 0;
        }

    }
}
