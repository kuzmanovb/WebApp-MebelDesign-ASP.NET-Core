using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>(); 

        }

        public string Color{ get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Present present)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            var heavPresent = data[0];
            foreach (var present in data)
            {
                if (heavPresent.Weight < present.Weight)
                {
                    heavPresent = present;
                }
            }
            return heavPresent;
        }

        public Present GetPresent(string name)
        {
            Present presentForGive = null;

            presentForGive = data.FirstOrDefault(x => x.Name == name);

            return presentForGive;

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();

        }

    }
}
