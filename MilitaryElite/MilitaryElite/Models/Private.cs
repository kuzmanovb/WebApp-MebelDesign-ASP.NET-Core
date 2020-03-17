using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName } {this.LastName } Id: {this.Id } Salary: {this.Salary:f2}";
        }
    }
}
