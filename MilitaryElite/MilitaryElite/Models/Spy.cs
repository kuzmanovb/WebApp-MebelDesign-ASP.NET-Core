using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Spy : ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName } {this.LastName } Id: {this.Id }");
            sb.AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
