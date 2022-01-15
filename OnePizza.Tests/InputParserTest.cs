using System.Linq;
using Xunit;

namespace OnePizza.Tests
{
    public class InputParserTest
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
        public void ParsesInput()
        {
            var clients = InputParser.Parse(_input);

            Assert.Collection(clients,
                client => Assert.True(client.Likes.SequenceEqual(new[] { "cheese", "peppers" }) &&
                                      !client.Dislikes.Any()),
                client => Assert.True(client.Likes.SequenceEqual(new[] { "basil" }) &&
                                      client.Dislikes.SequenceEqual(new[] { "pineapple" })),
                client => Assert.True(client.Likes.SequenceEqual(new[] { "mushrooms", "tomatoes" }) &&
                                      client.Dislikes.SequenceEqual(new[] { "basil" })));
        }
    }
}