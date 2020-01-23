using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            var allVloggers = new Dictionary<string, FollowersAndFollowing>();

            var input = Console.ReadLine();

            while (input != "Statistics")
            {
                var commandArr = input.Split();
                var command = commandArr[1];
                var vloggerForAdd = commandArr[0];
                var placeOrVlogger = commandArr[2];

                if (command == "joined")
                {
                    if (!allVloggers.ContainsKey(vloggerForAdd))
                    {
                        allVloggers.Add(vloggerForAdd, new FollowersAndFollowing());
                    }
                }
                else if (command == "followed" && vloggerForAdd != placeOrVlogger)
                {
                    var checkVlogger = allVloggers.ContainsKey(vloggerForAdd);
                    var checkPlaceOrVlogger = allVloggers.ContainsKey(placeOrVlogger);
                    
                    if (checkVlogger && checkPlaceOrVlogger)
                    {
                        if (!allVloggers[placeOrVlogger].Followers.Contains(vloggerForAdd))
                        {
                            allVloggers[placeOrVlogger].Followers.Add(vloggerForAdd);
                            allVloggers[vloggerForAdd].Following.Add(placeOrVlogger);

                        }

                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {allVloggers.Count} vloggers in its logs.");

            var count = 1;
            foreach (var vlogger in allVloggers.OrderByDescending(x =>x.Value.Followers.Count).ThenBy(x=>x.Value.Following.Count))
            {
                Console.WriteLine($"{count}. {vlogger.Key}: {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                if (count == 1)
                {
                    foreach (var item in vlogger.Value.Followers.OrderBy(x=> x))
                    {
                        Console.WriteLine($"* {item}");
                    }
                }
                count++;
            }
        }
    }

    public class FollowersAndFollowing
    {
        public FollowersAndFollowing()
        {
            Followers = new List<string>();
            Following = new List<string>();
        }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
    }
}
