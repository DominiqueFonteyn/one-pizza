using System.Linq;

namespace OnePizza
{
    public interface IClient
    {
        string[] Likes { get; }
        string[] Dislikes { get; }
        bool LikesPizza(Pizza pizza);
    }

    public class Client : IClient
    {
        public Client(string[] likes, string[] dislikes)
        {
            Likes = likes;
            Dislikes = dislikes;
        }

        public string[] Likes { get; }
        public string[] Dislikes { get; }

        public bool LikesPizza(Pizza pizza)
        {
            return LikesAllIngredients(pizza.Ingredients) && 
                   HasNoDislikedIngredients(pizza.Ingredients);
        }

        private bool HasNoDislikedIngredients(string[] ingredients)
        {
            return !Dislikes.Intersect(ingredients).Any();
        }

        private bool LikesAllIngredients(string[] ingredients)
        {
            return Likes.Intersect(ingredients).Count() == Likes.Length;
        }
    }
}