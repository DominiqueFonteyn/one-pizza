namespace OnePizza
{
    public class Client
    {
        public string[] Likes { get; }
        public string[] Dislikes { get; }

        public Client(string[] likes, string[] dislikes)
        {
            Likes = likes;
            Dislikes = dislikes;
        }
    }
}