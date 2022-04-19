using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrubskoUnleashed
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('@').ToArray();
            var name = input[0];
            var singers = new Dictionary<string, Dictionary<string, int>>();

            while (name != "end")
            {
                var venuePriceAndCounts = input[2].Split().ToArray();
                int ticketPrice = 0;
                bool ticketIsNumber = int.TryParse(
                    venuePriceAndCounts[venuePriceAndCounts.Length - 2],
                    out ticketPrice);
                if (venuePriceAndCounts.Length > 2 && ticketIsNumber)
                {
                    if (!singers.ContainsKey(name))
                    {
                        singers.Add(name, new Dictionary<string, int>());
                    }
                    else
                    {
                        singers[name]
                    }
                    for (int i = 0; i < venuePriceAndCounts.Length; i++)
                    {

                    }
                }
                else
                {

                }










            }
        }
    }
}
