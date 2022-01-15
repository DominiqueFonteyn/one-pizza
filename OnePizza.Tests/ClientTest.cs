using System;
using System.Collections.Generic;
using Xunit;

namespace OnePizza.Tests
{
    public class ClientTest
    {
        public static IEnumerable<object[]> Data => new[]
        {
            new object[]
            {
                new[] { "cheese", "peppers" },
                Array.Empty<string>(),
                true
            },
            new object[]
            {
                new[] { "basil" },
                new[] { "pineapple" },
                false
            },
            new object[]
            {
                new[] { "mushrooms", "tomatoes" },
                new[] { "basil" },
                true
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void LikesPizza(string[] likes, string[] dislikes, bool expected)
        {
            var pizzaIngredients = new[] { "cheese", "mushrooms", "tomatoes", "peppers" };

            Assert.Equal(expected, new Client(likes, dislikes).LikesPizza(pizzaIngredients));
        }
    }
}