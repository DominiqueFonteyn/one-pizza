using System;
using Xunit;

namespace OnePizza.Tests
{
    public class PizzaGeneratorTest
    {
        [Fact]
        public void GeneratesAllPossibleCombinations()
        {
            var ingredients = new[] { "a", "b", "c" };

            var pizzas = PizzaGenerator.GeneratePizzas(ingredients);

            Assert.Contains(new Pizza("a"), pizzas);
            Assert.Contains(new Pizza("b"), pizzas);
            Assert.Contains(new Pizza("c"), pizzas);
            Assert.Contains(new Pizza("a", "b"), pizzas);
            Assert.Contains(new Pizza("a", "c"), pizzas);
            Assert.Contains(new Pizza("b", "c"), pizzas);
            Assert.Contains(new Pizza("a", "b", "c"), pizzas);

            Assert.Equal(Math.Pow(2, ingredients.Length) - 1, pizzas.Length);
        }
    }
}