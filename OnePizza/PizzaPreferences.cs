namespace OnePizza
{
    public class PizzaPreferences
    {
        public PizzaPreferences(string[] clientPreferences)
        {
            NumberOfPotentialClients = int.Parse(clientPreferences[0]);
        }

        public int NumberOfPotentialClients { get; }
    }
}