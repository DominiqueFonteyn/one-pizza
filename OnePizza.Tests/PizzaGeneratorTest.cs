using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using NSubstitute;
using Xunit;

namespace OnePizza.Tests
{
    public class PizzaGeneratorTest
    {
        private static readonly string[] Ingredients = { "a", "b", "c" };

        [Fact]
        public void GeneratesAllPossibleCombinations()
        {
            var client = Substitute.For<IClient>();
            client.LikesPizza(Arg.Any<Pizza>()).Returns(true);

            var pizzas = PizzaGenerator.GeneratePizzas(new[] { client }, Ingredients);

            Assert.Contains(new Pizza("a"), pizzas);
            Assert.Contains(new Pizza("b"), pizzas);
            Assert.Contains(new Pizza("c"), pizzas);
            Assert.Contains(new Pizza("a", "b"), pizzas);
            Assert.Contains(new Pizza("a", "c"), pizzas);
            Assert.Contains(new Pizza("b", "c"), pizzas);
            Assert.Contains(new Pizza("a", "b", "c"), pizzas);

            Assert.Equal(Math.Pow(2, Ingredients.Length) - 1, pizzas.Length);
        }

        // [Fact]
        // public void FindK1()
        // {
        //     var result = FindFrequentItemsetsManually(Ingredients, 1).ToArray();
        //
        //     Assert.Contains("a", result);
        //     Assert.Contains("b", result);
        //     Assert.Contains("c", result);
        // }
        //
        // [Fact]
        // public void FindK2()
        // {
        //     var result = FindFrequentItemsetsManually(Ingredients, 2).ToArray();
        //
        //     Assert.Contains("ab", result);
        //     Assert.Contains("ac", result);
        //     Assert.Contains("bc", result);
        // }
        //
        // [Fact]
        // public void FindK3()
        // {
        //     var result = FindFrequentItemsetsManually(Ingredients, 3).ToArray();
        //
        //     Assert.Contains("abc", result);
        // }
        //
        // [Fact]
        // public void FindK4()
        // {
        //     var result = FindFrequentItemsetsManually(Ingredients, 4).ToArray();
        //
        //     Assert.Empty(result);
        // }

        // [Theory]
        // [InlineData(1, "a")]
        // [InlineData(2, "ab")]
        // [InlineData(3, "abc")]
        // public void TestFindRecursive(int k, string expected)
        // {
        //     var result = FindRecursive(Ingredients, k, 0);
        //     Assert.Equal(expected, result);
        // }

        [Fact]
        public void FindAllFrequentItemSets()
        {
            var input = new[] { "a", "b", "c", "d" };

            var itemSets = new List<string>();
            for (var k = 1; k <= input.Length; k++)
            {
                var combinations = new Combinations<string>(input, k, GenerateOption.WithoutRepetition);
                itemSets.AddRange(combinations.Select(x => string.Join("", x)));
            }

            AssertResults(itemSets.ToArray(), input);
        }

        private static void AssertResults(string[] itemSets, string[] input)
        {
            // k = 1
            Assert.Contains("a", itemSets);
            Assert.Contains("b", itemSets);
            Assert.Contains("c", itemSets);
            Assert.Contains("d", itemSets);

            // k = 2
            Assert.Contains("ab", itemSets);
            Assert.Contains("ac", itemSets);
            Assert.Contains("ad", itemSets);
            Assert.Contains("bc", itemSets);
            Assert.Contains("bd", itemSets);
            Assert.Contains("cd", itemSets);

            // k = 3
            Assert.Contains("abc", itemSets);
            Assert.Contains("abd", itemSets);
            Assert.Contains("acd", itemSets);
            Assert.Contains("bcd", itemSets);

            // k = 4
            Assert.Contains("abcd", itemSets);

            Assert.Equal(Math.Pow(2, input.Length) - 1, itemSets.Length);
        }

        private IEnumerable<string> FindMe(string[] items, int length, int current)
        {
            if (current >= items.Length) return new string[0];
            if (length <= 1) return new[] { items[current] };

            return new[] { items[current] }.Concat(FindMe(items, length - 1, current + 1));
        }

        // private IEnumerable<string> FindFrequentItemsetsManually(string[] items, int k)
        // {
        //     var itemSets = new List<string>();

        //     // k == 1
        //     for (var i = 0; i < items.Length; i++) itemSets.Add(FindMe(items, 1, i));
        //
        //     // k == 2
        //     for (var i = 0; i < items.Length; i++)
        //         itemSets.Add(FindMe(items, 2, i));
        //     // for (int j = i + 1; j < items.Length; j++)
        //     // {
        //     //     itemSets.Add(items[i] + items[j]);
        //     // }
        //
        //     // k == 3
        //     for (var i = 0; i < items.Length; i++)
        //     for (var j = i + 1; j < items.Length; j++)
        //     for (var l = j + 1; l < items.Length; l++)
        //         itemSets.Add(items[i] + items[j] + items[l]);
        //
        //     // k == 4
        //     for (var i = 0; i < items.Length; i++)
        //     for (var j = i + 1; j < items.Length; j++)
        //     for (var l = j + 1; l < items.Length; l++)
        //     for (var m = l + 1; m < items.Length; m++)
        //         itemSets.Add(items[i] + items[j] + items[l] + items[m]);
        //
        //     return itemSets;
        //
        //     if (k == 1) return items;
        //
        //
        //     if (k > items.Length) return itemSets;
        //
        //     for (var i = 0; i < items.Length; i++)
        //     for (var offset = 1; offset < items.Length - i; offset++)
        //         itemSets.Add(items[i] + FindRecursive(items, k - 1, i + offset));
        //
        //     return itemSets;
        // }

        // private string FindRecursive(string[] items, int k, int start)
        // {
        //     if (k == 0 || start == items.Length) return string.Empty;
        //     return items[start] + FindRecursive(items, k - 1, start + 1);
        // }
    }
}