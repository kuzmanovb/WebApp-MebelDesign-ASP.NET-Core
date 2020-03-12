using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.PlayerStats = stats;
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
        public Stats PlayerStats { get; private set; }
    }
}
