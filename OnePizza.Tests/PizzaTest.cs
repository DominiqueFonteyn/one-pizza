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

        [Fact]
        public void HasIngredient()
        {
            var pizza = new Pizza("a", "b");
            
            Assert.True(pizza.HasIngredient("a"));
            Assert.False(pizza.HasIngredient("d"));
        }

        [Fact]
        public void AddIngredient()
        {
            var pizza = new Pizza("a", "b");

            var newPizza = pizza.AddIngredient("c");
            
            Assert.NotEqual(pizza, newPizza);
            Assert.Equal(new Pizza("a", "b", "c"), newPizza);
        }
    }
}