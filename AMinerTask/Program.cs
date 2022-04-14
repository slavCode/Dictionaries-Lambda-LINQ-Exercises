using System;
using System.Collections.Generic;

namespace AMinerTask
{
    internal class Program
    {
        static void Main()
        {
            var resourse = Console.ReadLine();
            var data = new Dictionary<string, long>();

            while (resourse != "stop")
            {
                long quantity = long.Parse(Console.ReadLine());
                if (data.ContainsKey(resourse)) data[resourse] += quantity;
                else data.Add(resourse, quantity);

                resourse = Console.ReadLine();
            }
           
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");    
            }
        }
    }
}
