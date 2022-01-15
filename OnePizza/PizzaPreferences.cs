using System;
using System.Collections.Generic;
using System.Linq;

namespace OnePizza
{
    public class PizzaPreferences
    {
        public PizzaPreferences(string[] clientPreferences)
        {
            var likes = new HashSet<string>();
            var i = 1;
            foreach (var line in clientPreferences)
            {
                if (i == 1)
                {
                    NumberOfPotentialClients = int.Parse(clientPreferences[0]);
                }
                else if (i % 2 == 0)
                {
                    var split = line.Split(new[] { " " }, StringSplitOptions.None);
                    if (split.Length > 1)
                        foreach (var s in split.Skip(1))
                            likes.Add(s);
                }

                i++;
            }

            Likes = likes;
        }

        public int NumberOfPotentialClients { get; }
        public ISet<string> Likes { get; }
    }
}