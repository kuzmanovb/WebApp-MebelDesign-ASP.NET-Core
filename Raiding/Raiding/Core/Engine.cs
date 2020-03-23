using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine
    {
        private List<BaseHero> heros;
        public Engine()
        {
            this.heros = new List<BaseHero>();
        }
        public void Run()
        {
            var heros = new List<BaseHero>();
            var numberInputs = int.Parse(Console.ReadLine());

            while (numberInputs > 0)
            {
                var curentName = Console.ReadLine();
                var curentHero = Console.ReadLine();

                switch (curentHero)
                {
                    case "Paladin":
                        heros.Add(new Paladin(curentName)); numberInputs--;
                        break;
                    case "Druid":
                        heros.Add(new Druid(curentName)); numberInputs--;
                        break;
                    case "Rogue":
                        heros.Add(new Rogue(curentName)); numberInputs--;
                        break;
                    case "Warrior":
                        heros.Add(new Warrior(curentName)); numberInputs--;
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }


            var powerBoss = int.Parse(Console.ReadLine());
            PrinHeros(heros, powerBoss);
        }

        private static void PrinHeros(List<BaseHero> heros, int powerBoss)
        {
            var powerHero = 0;

            foreach (var item in heros)
            {
                powerHero += item.Power;
                Console.WriteLine(item.CastAbility());
            }
            if (powerBoss <= powerHero)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
