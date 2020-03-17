using System;
using System.Collections.Generic;
using MilitaryElite.Models;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<ISoldier> allSoldiers = new List<ISoldier>();

            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                var soldier = input[0];

                var id = int.Parse(input[1]);
                var firstName = input[2];
                var lastName = input[3];

                try
                {
                    if (soldier == "Private")
                    {
                        var newPrivate = CreatePrivate(input, id, firstName, lastName);
                        allSoldiers.Add(newPrivate);
                    }
                    else if (soldier == "LieutenantGeneral")
                    {
                        var newCreateLieutenantGeneral = CreateLieutenantGeneral(allSoldiers, input, id, firstName, lastName);
                        allSoldiers.Add(newCreateLieutenantGeneral);
                    }
                    else if (soldier == "Engineer")
                    {
                        var corps = input[5];

                        if (corps == "Airforces" || corps == "Marines")
                        {
                            var newEngineer = CreateEngineer(input, id, firstName, lastName, corps);
                            allSoldiers.Add(newEngineer);
                        }
                    }
                    else if (soldier == "Commando")
                    {
                        var corps = input[5];

                        if (corps == "Airforces" || corps == "Marines")
                        {
                            var newCommando = CreateCommando(input, id, firstName, lastName, corps);
                            allSoldiers.Add(CreateCommando(input, id, firstName, lastName, corps));
                        }
                    }
                    else if (soldier == "Spy")
                    {
                        var newSpy = CreateSpy(input, id, firstName, lastName);
                        allSoldiers.Add(newSpy);
                    }
                }
                catch (ArgumentException e) { }

                input = Console.ReadLine().Split();
            }


            foreach (var soldier in allSoldiers)
            {
                Console.WriteLine(soldier);
            }

        }

        private static Spy CreateSpy(string[] input, int id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(input[4]);
            var newSpy = new Spy(id, firstName, lastName, codeNumber);
            return newSpy;
        }

        private static Commando CreateCommando(string[] input, int id, string firstName, string lastName, string corps)
        {
            var salary = decimal.Parse(input[4]);

            var newCommando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                var code = input[i];
                var state = input[i + 1];

                if (state == "inProgress" || state == "Finished")
                {
                    newCommando.Missions.Add(new Mission(code, state));
                }

            }

            return newCommando;
        }

        private static Engineer CreateEngineer(string[] input, int id, string firstName, string lastName, string corps)
        {
            var salary = decimal.Parse(input[4]);


            var newEngineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                var part = input[i];
                var work = int.Parse(input[i + 1]);

                newEngineer.Repairs.Add(new Repair(part, work));

            }

            return newEngineer;
        }

        private static LieutenantGeneral CreateLieutenantGeneral(List<ISoldier> all, string[] input, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(input[4]);
            var newLG = new LieutenantGeneral(id, firstName, lastName, salary);
            for (int i = 5; i < input.Length; i++)
            {
                var idPrivate = int.Parse(input[i]);
                foreach (var item in all)
                {
                    if (item.GetType() == typeof(Private) && item.Id == idPrivate)
                    {
                        newLG.PrivateCorp.Add((Private)item);
                    }
                }

            }

            return newLG;
        }

        private static Private CreatePrivate(string[] input, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(input[4]);
            var newPrivat = new Private(id, firstName, lastName, salary);
            return newPrivat;
        }
    }
}
