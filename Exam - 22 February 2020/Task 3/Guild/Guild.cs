using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();

        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                roster.Add(player);
            }

        }

        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Name == name)
                {
                    roster.RemoveAt(i);
                    return true;
                }
            }

            return false;

        }

        public void PromotePlayer(string name)
        {

            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Name == name)
                {
                    if (roster[i].Rank != "Member")
                    {
                        roster[i].Rank = "Member";
                    }
                    break;
                }
            }

        }

        public void DemotePlayer(string name)
        {

            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Name == name)
                {
                    if (roster[i].Rank != "Trial")
                    {
                        roster[i].Rank = "Trial";
                    }
                    break;
                }
            }

        }

        public Player[] KickPlayersByClass(string class1)
        {
            var listPlayer = new List<Player>();
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Class == class1)
                {
                    listPlayer.Add(roster[i]);
                    roster.RemoveAt(i);
                    i--;
                }
            }

            var arrayForReturn = listPlayer.ToArray();
            return arrayForReturn;

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }




    }
}
