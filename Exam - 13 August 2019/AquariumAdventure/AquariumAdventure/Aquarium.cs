using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            fishInPool = new List<Fish>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public void Add(Fish fish)
        {
            var check = true;

            foreach (var item in fishInPool)
            {
                if (item.Name == fish.Name)
                {
                    check = false;
                    break;
                }
            }
            if (check && fishInPool.Count < this.Capacity)
            {
                fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {

            for (int i = 0; i < fishInPool.Count; i++)
            {
                if (fishInPool[i].Name == name)
                {
                    fishInPool.RemoveAt(i);
                    return true;
                }
            }

            return false;

        }
        public Fish FindFish(string name)
        {

            Fish fishFor = null;
           foreach (var item in fishInPool)
            {
                if (item.Name == name)
                {
                    fishFor = item;
                }
            }

            return fishFor;
        }
         
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var item in fishInPool)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
