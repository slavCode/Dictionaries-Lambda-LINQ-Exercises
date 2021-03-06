using System;
using System.Collections.Generic;

namespace PhonebookUpgrade
{
    internal class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var phonebook = new SortedDictionary<string, string>();

            while (input != "END")
            {
                var entries = input.Split(' ');
                var command = entries[0];

                switch (command)
                {
                    case "A":
                        var name = entries[1];
                        var number = entries[2];
                        phonebook[name] = number;
                        break;

                    case "S":
                        var searchedName = entries[1];
                        if (phonebook.ContainsKey(searchedName))
                        {
                            Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
                        }
                        else Console.WriteLine($"Contact {searchedName} does not exist.");
                        break;

                    case "ListAll":
                        foreach (var entry in phonebook)
                        {
                            Console.WriteLine($"{entry.Key} -> {entry.Value}");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
