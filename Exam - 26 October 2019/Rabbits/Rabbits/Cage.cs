using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
   public class Cage
    {

        private List<Rabbit> data;

        public Cage( string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Rabbit>();


        }
        public string Name{ get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (data.Count < Capacity)
            {
                data.Add(rabbit);
            }

        }

        public bool RemoveRabbit(string name)
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

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Species == species)
                {
                    data.RemoveAt(i);
                    i--;
                }
            }

        }

       public Rabbit SellRabbit(string name)
        {

            Rabbit rabbitForReturn = null;

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data[i].Available = false;
                    rabbitForReturn = data[i];
                    break;
                }
            }

            return rabbitForReturn;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {

            var listForReturn = new List<Rabbit>();

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Species == species)
                {
                    data[i].Available = false;
                    listForReturn.Add(data[i]);
                }
            }

            return listForReturn.ToArray();

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in data)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }
            
            return sb.ToString().TrimEnd();
        }

    }
}
