using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('|');
            var countries = new Dictionary<string, Dictionary<string, long>>();
            var countriesCount = new Dictionary<string, long>();

            while (input[0] != "report")
            {

                string country = input[1];
                string city = input[0];
                long population = long.Parse(input[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                    countries[country].Add(city, population);
                }
                else if (!countries[country].ContainsKey(city))
                {
                    countries[country].Add(city, population);
                }

                input = Console.ReadLine().Split('|');
            }

            var sortedCountriesByPopulation = new Dictionary<string, Dictionary<string, long>>();
            sortedCountriesByPopulation = countries = countries.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in sortedCountriesByPopulation)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Sum(c => c.Value)})");
                foreach (var city in country.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
