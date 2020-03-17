using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;


namespace MilitaryElite.Models
{
    public class Commando : Private, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;

            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; private set; }

        public string Corps { get; private set; }


        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
