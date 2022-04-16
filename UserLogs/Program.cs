using System;
using System.Collections.Generic;

namespace UserLogs
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var parts = input.Split();
                var ip = parts[0].Substring(3);
                var user = input.Split()[2].Substring(5);

                if (!users.ContainsKey(user))
                {
                    users.Add(user, new Dictionary<string, int>());
                }

                if (!users[user].ContainsKey(ip)) users[user].Add(ip, 0);
                users[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");
                int counter = user.Value.Count;
                foreach (var ip in user.Value)
                {
                    if (counter != 1)
                    {
                        Console.Write($"{ip.Key} => {ip.Value}, ");
                    }
                    else Console.WriteLine($"{ip.Key} => {ip.Value}.");

                    counter--;
                }
            }
        }
    }
}
