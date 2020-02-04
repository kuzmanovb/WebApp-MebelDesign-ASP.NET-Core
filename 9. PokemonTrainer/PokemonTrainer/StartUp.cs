using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            AddTrainersWithPokemons(trainers);

            var command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.CommandExecution(command);

                }
                
                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.MyPokemons.Count}");
            }
        }

        private static void AddTrainersWithPokemons(Dictionary<string, Trainer> trainers)
        {
            var input = Console.ReadLine();

            while (input != "Tournament")
            {
                var inputArr = input.Split();
                var trainerName = inputArr[0];
                var pokemonName = inputArr[1];
                var pokemonElement = inputArr[2];
                var pokemonHealth = int.Parse(inputArr[3]);

                var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.ContainsKey(trainerName))
                {
                    var newTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, newTrainer);
                }

                trainers[trainerName].MyPokemons.Add(newPokemon);

                input = Console.ReadLine();
            }
        }
    }
}
