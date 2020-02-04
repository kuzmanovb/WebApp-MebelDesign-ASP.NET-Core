using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> allPerson;
        private int id = 0;
        public Repository()
        {
            allPerson = new Dictionary<int, Person>();
        }

        public int Count
        {
            get
            {
                return allPerson.Count;
            }
        }

        public void Add(Person person)
        {
            allPerson.Add(id, person);
            id++;
        }
        public Person Get(int id)
        {
            Person personForGive = null;
            if (allPerson.ContainsKey(id))
            {
                personForGive = this.allPerson[id];
            }
            return personForGive;
        }
        public bool Update(int id, Person newPerson)
        {
            if (allPerson.ContainsKey(id))
            {
                this.allPerson[id] = newPerson;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (allPerson.ContainsKey(id))
            {
                this.allPerson.Remove(id);
                return true;
            }
            return false;
        }
    }
}
