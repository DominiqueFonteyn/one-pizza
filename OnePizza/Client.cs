using System.Linq;

namespace OnePizza
{
    public class Client
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