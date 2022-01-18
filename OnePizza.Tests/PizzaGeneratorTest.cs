using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OnePizza.Tests
{
    public class PizzaGeneratorTest
    {
        [Fact]
        public void GeneratesAllPossibleCombinations()
        {
            var ingredients = new[] { "a", "b", "c" };

            var pizzas = PizzaGenerator.GeneratePizzas(ingredients).ToArray();

            Assert.Contains(new[] { "a" }, pizzas);
            Assert.Contains(new[] { "b" }, pizzas);
            Assert.Contains(new[] { "c" }, pizzas);
            Assert.Contains(new[] { "a", "b" }, pizzas);
            Assert.Contains(new[] { "a", "c" }, pizzas);
            Assert.Contains(new[] { "b", "c" }, pizzas);
            Assert.Contains(new[] { "a", "b", "c" }, pizzas);

            Assert.Equal(Math.Pow(2, ingredients.Length) - 1, pizzas.Length);
        }

        [Fact]
        public void FindAllFrequent2Itemsets()
        {
            var items = new[] { "a", "b", "c", "d"};
            
            var result = FindItemsets(items);

            Assert.Equal(Math.Pow(2, items.Length) - 1, result.Length);
            
            Assert.Equal(new[]
            {
                "a", 
                "b", 
                "c", 
                "d",
                "ab", 
                "ac",
                "ad",
                "bc",
                "bd",
                "cd",
                "abc",
                "abd",
                "acd",
                "bcd",
                "abcd"
            }, result);
        }

        private string[] FindItemsets(string[] items)
        {
            var allItems = new List<string[]>();
            allItems.AddRange(items.Select(x => new[] { x }));

            var permutations = new List<string[]>(allItems);
            while (permutations.Any())
            {
                permutations = Permutate(items, permutations).ToList();
                allItems.AddRange(permutations);
            }

            var result = allItems
                .Select(x => string.Join("", x.OrderBy(y => y)))
                .Distinct()
                .ToArray();
            return result;
        }

        private IEnumerable<string[]> Permutate(string[] items, List<string[]> permutations)
        {
            foreach (var t in permutations)
            foreach (var item in items)
            {
                if (t.Contains(item))
                    continue;
                yield return t.Concat(new[] { item }).OrderBy(x => x).ToArray();
            }
        }
    }
}