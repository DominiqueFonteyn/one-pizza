using System.Linq;

namespace OnePizza
{
    public interface IClient
    {
        string[] Likes { get; }
        string[] Dislikes { get; }
        bool LikesPizza(string[] ingredients);
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

        public bool LikesPizza(string[] ingredients)
        {
            return LikesAllIngredients(ingredients) && HasNoDislikedIngredients(ingredients);
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