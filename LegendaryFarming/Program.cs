using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    internal class Program
    {
        static void Main()
        {
            var materials = new Dictionary<string, int>();
            var junks = new SortedDictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            bool hasWinner = false;
            while (!hasWinner)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length - 1; i += 2)
                {
                    var material = input[i + 1].ToLower();
                    var quantity = int.Parse(input[i]);
                    if (material == "shards"
                     || material == "fragments"
                     || material == "motes")
                    {
                        materials[material] += quantity;
                        if (materials[material] >= 250)
                        {
                            string message = "";
                            switch (material)
                            {
                                case "fragments":
                                    message = "Valanyr obtained!";
                                    break;
                                case "motes":
                                    message = "Dragonwrath obtained!";
                                    break;
                                case "shards":
                                    message = "Shadowmourne obtained!";
                                    break;
                            }
                            Console.WriteLine(message);
                            hasWinner = true;
                            materials[material] -= 250;

                            break;
                        }
                    }
                    else if (!junks.ContainsKey(material)) junks.Add(material, quantity);
                    else junks[material] += quantity;
                }
            }

            foreach (var material in materials.OrderByDescending(m => m.Value)
                                              .ThenBy(m => m.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var junk in junks)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}
