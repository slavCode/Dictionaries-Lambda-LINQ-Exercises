using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOfCards
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(':');
            var name = input[0];
            var persons = new Dictionary<string, List<string>>();
            var personsValues = new Dictionary<string, int>();

            while (name != "JOKER")
            {
                var cards = SeparateCards(input);
                if (!persons.ContainsKey(name)) persons.Add(name, cards);
                else
                {
                    foreach (var item in cards)
                    {
                        if (!persons[name].Contains(item)) persons[name].Add(item);
                    }
                }

                input = Console.ReadLine().Split(':');
                name = input[0];
            }

            foreach (var person in persons)
            {
                string currentName = person.Key;

                foreach (var card in person.Value)
                {
                    string power = card.Substring(0, card.Length - 1);
                    char type = card[card.Length - 1];

                    if (personsValues.ContainsKey(currentName))
                    {
                        personsValues[currentName] += GetValue(power, type);
                    }
                    else personsValues.Add(currentName, GetValue(power, type));
                }
            }

            foreach (var person in personsValues)
            {
                Console.WriteLine($"{person.Key}: {person.Value}");
            }
        }

        static int GetValue(string power, char type)
        {
            int powerAsInt = 0;
            switch (power)
            {
                case "2":
                    powerAsInt = 2;
                    break;
                case "3":
                    powerAsInt = 3;
                    break;
                case "4":
                    powerAsInt = 4;
                    break;
                case "5":
                    powerAsInt = 5;
                    break;
                case "6":
                    powerAsInt = 6;
                    break;
                case "7":
                    powerAsInt = 7;
                    break;
                case "8":
                    powerAsInt = 8;
                    break;
                case "9":
                    powerAsInt = 9;
                    break;
                case "10":
                    powerAsInt = 10;
                    break;
                case "J":
                    powerAsInt = 11;
                    break;
                case "Q":
                    powerAsInt = 12;
                    break;
                case "K":
                    powerAsInt = 13;
                    break;
                case "A":
                    powerAsInt = 14;
                    break;
            }

            int typeAsInt = 0;
            switch (type)
            {
                case 'S':
                    typeAsInt = 4;
                    break;
                case 'H':
                    typeAsInt = 3;
                    break;
                case 'D':
                    typeAsInt = 2;
                    break;
                case 'C':
                    typeAsInt = 1;
                    break;
            }
            return powerAsInt * typeAsInt;
        }

        static List<string> SeparateCards(string[] input)
        {
            return input[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => x.Trim())
                           .Distinct()
                           .ToList();
        }
    }
}
