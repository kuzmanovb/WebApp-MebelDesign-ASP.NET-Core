using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;
        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return data.Count; }
        }

        public void Add(Astronaut astronaut)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(astronaut);
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
        public Astronaut GetOldestAstronaut()
        {
            var oldesAstronaut = data[0];
            foreach (var astro in data)
            {
                if (astro.Age > oldesAstronaut.Age)
                {
                    oldesAstronaut = astro;
                }
            }
            return oldesAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = null;
            foreach (var astro in data)
            {
                if (astro.Name == name)
                {
                    astronaut = astro;
                }
            }
            return astronaut;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            foreach (var astro in data)
            {
                sb.AppendLine(astro.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
