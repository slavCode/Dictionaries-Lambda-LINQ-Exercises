using System;
using System.Collections.Generic;
using System.Linq;

namespace FixEmails
{
    internal class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var emails = new Dictionary<string, string>();

            while (name != "stop")
            {
                var email = Console.ReadLine();

                var domain = String.Join("", email.Skip(email.Length - 2).Take(2)).ToLower();
                if (domain != "uk" && domain != "us")
                {
                    emails.Add(name, email);
                }

                name = Console.ReadLine();
            }

            foreach (var person in emails)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
