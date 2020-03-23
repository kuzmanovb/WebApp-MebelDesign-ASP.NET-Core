using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Bird;
using WildFarm.Models.Animals.Mammal;
using WildFarm.Models.Animals.Mammal.Feline;

namespace WildFarm.Core
{
    public class Engine
    {
        private List<IAnimal> animals;
        public Engine()
        {

            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                var type = input[0];
                var name = input[1];
                var weight = double.Parse(input[2]);

                try
                {
                    Animal curentAnimal;
                    switch (type)
                    {
                        case "Owl":
                            var wingOwl = double.Parse(input[3]);
                            curentAnimal = new Owl(name, weight, wingOwl);
                            animals.Add(curentAnimal);
                            break;
                        case "Hen":
                            var wingHen = double.Parse(input[3]);
                            curentAnimal = new Hen(name, weight, wingHen);
                            animals.Add(curentAnimal);
                            break;
                        case "Mouse":
                            var regionMouse = input[3];
                            curentAnimal = new Mouse(name, weight, regionMouse);
                            animals.Add(curentAnimal);
                            break;
                        case "Dog":
                            var regionDog = input[3];
                            curentAnimal = new Dog(name, weight, regionDog);
                            animals.Add(curentAnimal);
                            break;
                        case "Cat":
                            var regionCat = input[3];
                            var breedCat = input[4];
                            curentAnimal = new Cat(name, weight, regionCat, breedCat);
                            animals.Add(curentAnimal);
                            break;
                        case "Tiger":
                            var regionTiger = input[3];
                            var breed = input[4];
                            curentAnimal = new Tiger(name, weight, regionTiger, breed);
                            animals.Add(curentAnimal);
                            break;
                        default:
                            throw new ArgumentException("Wrog type");
                            break;
                    }

                    var foodForAnimal = Console.ReadLine().Split();
                    var typeFood = foodForAnimal[0];
                    var quantity = int.Parse(foodForAnimal[1]);

                    Console.WriteLine(curentAnimal.Sound());
                    curentAnimal.Eaten(typeFood, quantity);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
