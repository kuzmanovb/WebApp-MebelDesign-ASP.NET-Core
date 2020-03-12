using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing,  int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateValue(value, "Endurance");
                this.endurance = value;
            }
        }


        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateValue(value, "Sprint");
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateValue(value, "Dribble");
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateValue(value, "Passing");
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateValue(value, "Shooting");
                this.shooting = value;
            }
        }

        public double AverageSkill()
        {
            var result = (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;
            return result;
        }
        private static void ValidateValue(int value , string name)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
