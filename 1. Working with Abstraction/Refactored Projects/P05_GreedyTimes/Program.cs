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
                else if (!CheckForEnoughCapacity(capacityBag, bag, itemValue))
                {
                    continue;
                }
                else if (!CheckRulesForAmount(itemType, itemValue, bag))
                {
                    continue;
                }

                AddItemTypeIfNotExist(bag, itemType);

                AddItemIfNotExist(bag, item, itemType);

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

            foreach (var type in bag)
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");
                foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void AddItemIfNotExist(Dictionary<string, Dictionary<string, long>> bag, string item, string itemType)
        {
            if (!bag[itemType].ContainsKey(item))
            {
                bag[itemType][item] = 0;
            }
        }

        private static void AddItemTypeIfNotExist(Dictionary<string, Dictionary<string, long>> bag, string itemType)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }
        }

        public static bool CheckRulesForAmount(string itemType, long itemValue, Dictionary<string, Dictionary<string, long>> bag )
        {
            switch (itemType)
            {
                case "Gem":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (itemValue > bag["Gold"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemValue > bag["Gold"].Values.Sum())
                    {
                        return false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (itemValue > bag["Gem"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemValue > bag["Gem"].Values.Sum())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
        private static bool CheckForEnoughCapacity(long capacityBag, Dictionary<string, Dictionary<string, long>> bag, long itemValue)
        {
            return capacityBag >= bag.Values.Select(x => x.Values.Sum()).Sum() + itemValue;
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