using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsAggregator
{
    internal class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var logs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[1];
                var duration = int.Parse(input[2]);
                var ip = input[0];

                if (!logs.ContainsKey(name))
                {
                    logs.Add(name, new SortedDictionary<string, int>());
                    logs[name].Add(ip, duration);
                }
                else
                {
                    if (logs[name].ContainsKey(ip)) logs[name][ip] += duration;
                    else logs[name].Add(ip, duration);
                }
            }

            foreach (var user in logs)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Values.Sum()} [{String.Join(", ", user.Value.Keys)}]");
            }
        }
    }
}
