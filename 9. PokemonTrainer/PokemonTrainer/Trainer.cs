using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            MyPokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> MyPokemons { get; set; } 

        public void CommandExecution(string command)
        {
            var flag = false;
            foreach (var pokemon in this.MyPokemons)
            {
                if (pokemon.Element.Contains(command))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                this.Badges++;
                    
            }
            else
            {
                for (int i = 0; i < MyPokemons.Count; i++)
                {
                    MyPokemons[i].Health -= 10;
                    if (MyPokemons[i].Health <= 0)
                    {
                        MyPokemons.RemoveAt(i);
                        i--;
                    }

                }
            }

        }
    }
}
