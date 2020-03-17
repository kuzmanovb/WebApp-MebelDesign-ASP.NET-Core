using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get; set; }

        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
