using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var people = new List<Person>();
                FillPeopleList(peopleInput, people);

                var produtsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                var products = new List<Product>();
                FillProductsList(produtsInput, products);

                BuyingProduct(people, products);

                PrintPersonProducts(people);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void BuyingProduct(List<Person> people, List<Product> products)
        {
            var input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                var curentPerson = people.FirstOrDefault(x => x.Name == input[0]);
                var curentProduct = products.FirstOrDefault(x => x.Name == input[1]);

                Console.WriteLine(curentPerson.BoughtProduct(curentProduct));

                input = Console.ReadLine().Split();
            }
        }

        private static void PrintPersonProducts(List<Person> people)
        {
            foreach (var item in people)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void FillProductsList(string[] produtsInput, List<Product> products)
        {
            foreach (var product in produtsInput)
            {
                var curentProduct = product.Split('=',StringSplitOptions.RemoveEmptyEntries);
                var name = curentProduct[0];
                var cost = decimal.Parse(curentProduct[1]);
                products.Add(new Product(name, cost));
            }
        }

        private static void FillPeopleList(string[] peopleInput, List<Person> people)
        {
            foreach (var person in peopleInput)
            {
                var curentPerson = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = curentPerson[0];
                var money = decimal.Parse(curentPerson[1]);
                people.Add(new Person(name, money));
            }
        }
    }
}
