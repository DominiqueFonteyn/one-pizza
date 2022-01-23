using NSubstitute;
using Xunit;

namespace OnePizza.Tests
{
    public class EvaluatorTest
    {
        [Fact]
        public void EvaluatePizza()
        {
            var pizza = new Pizza();
            var clients = new[]
            {
                CreateClient(true),
                CreateClient(false),
                CreateClient(true)
            };

            var score = Evaluator.EvaluatePizza(pizza, clients);
            
            Assert.Equal(2, score);
        }

        private static IClient CreateClient(bool likesPizza)
        {
            var client = Substitute.For<IClient>();
            client.LikesPizza(Arg.Any<Pizza>()).Returns(likesPizza);
            return client;
        }
    }
}