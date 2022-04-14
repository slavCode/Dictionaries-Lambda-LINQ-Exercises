using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(':');
            var name = input[0];
            var cards = SeparateCards(input);
            var persons = new Dictionary<string, List<string>>();

            while (name != "JOKER")
            {
                name = input[0];

                if (!persons.ContainsKey(name)) persons.Add(name, cards);
                else
                {
                    foreach (var item in cards)
                    {
                        if (!persons[name].Contains(item)) persons[name].Add(item);
                    }
                }

                input = Console.ReadLine().Split(':');

                int debug = 0;

            }

        }

        static List<string> SeparateCards(string[] input)
        {
            return input[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
        }
    }
}
