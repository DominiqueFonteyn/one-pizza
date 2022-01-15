using System.Linq;
using Xunit;

namespace OnePizza.Tests
{
    public class PizzaPreferencesTest
    {
        private readonly string[] _input =
        {
            "3",
            "2 cheese peppers",
            "0",
            "1 basil",
            "1 pineapple",
            "2 mushrooms tomatoes",
            "1 basil"
        };

        [Fact]
        public void Ctor_Parses_NumberOfPotentialClients()
        {
            var preferences = new PizzaPreferences(_input);
            Assert.Equal(3, preferences.NumberOfPotentialClients);
        }

        [Fact]
        public void Ctor_Parses_Likes()
        {
            var preferences = new PizzaPreferences(_input);
            var likes = new[] { "cheese", "peppers", "basil", "mushrooms", "tomatoes" };
            Assert.True(likes.OrderBy(x => x).SequenceEqual(preferences.Likes.OrderBy(x => x)));
        }
    }
}