using System.Collections.Generic;
using System.Linq;

namespace OnePizza
{
    public class Evaluator
    {
        public static int EvaluatePizza(Pizza pizza, IEnumerable<IClient> clients)
        {
            return clients.Count(x => x.LikesPizza(pizza));
        }
    }
}