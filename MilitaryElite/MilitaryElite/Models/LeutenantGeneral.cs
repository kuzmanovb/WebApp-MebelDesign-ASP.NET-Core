using System.Text;
using System.Collections.Generic;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.PrivateCorp = new List<IPrivate>();
        }

        public ICollection<IPrivate> PrivateCorp { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in PrivateCorp)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
