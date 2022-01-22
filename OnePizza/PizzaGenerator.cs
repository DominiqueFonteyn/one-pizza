using System.Collections.Generic;
using System.Linq;

namespace OnePizza
{
    public class PizzaGenerator
    {
        public static IEnumerable<string[]> GeneratePizzas(params string[] ingredients)
        {
            var itemset = new HashSet<string[]>();

            // k = 1
            foreach (var ingredient in ingredients) itemset.Add(new[] { ingredient });

            // k > 1
            var k2 = Generate(ingredients, itemset);
            foreach (var v in k2) itemset.Add(v);
            // itemset.Add(new[] { "a", "b", "c" });

            return itemset.ToArray();
        }

        private static IEnumerable<string[]> Generate(string[] input, IEnumerable<string[]> lattice)
        {
            var permutations =
                from a in lattice
                from b in input
                select a.Concat(new[] { b }).ToArray();

            return permutations;


            var itemset = new List<string[]>();
            for (var i = 0; i < input.Length; i++)
            for (var j = i + 1; j < input.Length; j++)
                itemset.Add(new[] { input[i], input[j] });

            return itemset;
            // TODO genereer voor k + 1
            // return itemset.Concat(Generate(input, itemset));
        }

      
    }
}