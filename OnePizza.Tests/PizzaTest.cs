using Xunit;

namespace OnePizza.Tests
{
    public class PizzaTest
    {
        [Fact]
        public void Compare_Equal()
        {
            Assert.Equal(
                new Pizza("a", "b", "c"),
                new Pizza("a", "b", "c"));
        }

        [Fact]
        public void Compare_NotEqual()
        {
            Assert.NotEqual(
                new Pizza("a", "b", "c"),
                new Pizza("a", "b", "d"));
        }

        [Fact]
        public void Compare_DifferentOrder_Equal()
        {
            Assert.Equal(
                new Pizza("a", "b", "c"),
                new Pizza("b", "a", "c"));
        }
    }
}