using System;
using System.Collections.Generic;
using System.Linq;

namespace SrubskoUnleashed
{
    internal class Program
    {
        static void Main()
        {

            //40|100
            var input = Console.ReadLine().Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
            var singerName = input[0];
            var events = new Dictionary<string, Dictionary<string, int>>();

            while (singerName != "End")
            {
                var venues = input[1].Split().ToList();
                int ticketsCount = 0;
                int ticketsPrice = 0;
                bool countIsNumber = int.TryParse(
                    venues[venues.Count - 1],
                    out ticketsCount);
                bool priceIsNumber = int.TryParse(
                    venues[venues.Count - 2],
                    out ticketsPrice);
                

                if (venues.Count > 2 && priceIsNumber && countIsNumber)
                {
                    string venueName = String.Join(" ", venues.Take(venues.Count - 2));
                    ticketsCount = int.Parse(venues[venues.Count - 1]);
                    ticketsPrice = int.Parse(venues[venues.Count - 2]);
                    var totalMoney = ticketsCount * ticketsPrice;
                    var singer = new Dictionary<string, int>();
                    singer.Add(singerName, totalMoney);

                    if (!events.ContainsKey(venueName))
                    {
                        events.Add(venueName, singer);
                    }
                    else
                    {
                        if (!events[venueName].ContainsKey(singerName))
                        {
                            events[venueName].Add(singerName, totalMoney);
                        }
                        else events[venueName][singerName] += totalMoney;
                    }
                }
                input = Console.ReadLine().Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
                singerName = input[0];
            }
            foreach (var happening in events)
            {
                Console.WriteLine($"{happening.Key}");
                foreach (var singer in happening.Value
                    .OrderByDescending(s => s.Value)
                    .ThenBy(s => s.Key))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}