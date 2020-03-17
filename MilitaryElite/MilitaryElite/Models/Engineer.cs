using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer : Private, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;

            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; private set; }
        public string Corps { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
