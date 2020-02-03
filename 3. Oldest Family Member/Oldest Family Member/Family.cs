using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> Members { get; set; } = new List<Person>();

        public void AddMember(Person newPerson)
        {
            Members.Add(newPerson);
        }
        public string GetOldestMember()
        {
            Person oldMember = Members[0];

            foreach (var member in this.Members)
            {
                if (member.Age > oldMember.Age)
                {
                    oldMember = member;
                }
            }
            return $"{oldMember.Name} {oldMember.Age}";
        }

    }
}
