using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacityBag = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gem = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string item = safe[i];
                long itemValue = long.Parse(safe[i + 1]);

                string itemType = FindItemType(item);
                if (itemType == string.Empty)
                {
                    continue;
                }
                else if (capacityBag < bag.Values.Select(x => x.Values.Sum()).Sum() + itemValue)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (itemValue > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + itemValue > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (itemValue > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + itemValue > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(item))
                {
                    bag[itemType][item] = 0;
                }

                bag[itemType][item] += itemValue;
                if (itemType == "Gold")
                {
                    gold += itemValue;
                }
                else if (itemType == "Gem")
                {
                    gem += itemValue;
                }
                else if (itemType == "Cash")
                {
                    cash += itemValue;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static string FindItemType(string item)
        {

            if (item.Length == 3)
            {
                return "Cash";
            }
            else if (item.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (item.ToLower() == "gold")
            {
                return "Gold";
            }
            else
            {
                return string.Empty;
            }

        }
    }
}