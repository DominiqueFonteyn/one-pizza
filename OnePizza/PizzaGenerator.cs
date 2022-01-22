using System.Collections.Generic;
using System.Linq;

namespace OnePizza
{
    public class PizzaGenerator
    {
        public static Pizza[] GeneratePizzas(params string[] ingredients)
        {
            var pizzas = new List<Pizza>();
            pizzas.AddRange(ingredients.Select(x => new Pizza(x)));

            var newPizzas = new List<Pizza>(pizzas);
            while (newPizzas.Any())
            {
                newPizzas = FindNewPizzas(ingredients, newPizzas).ToList();
                pizzas.AddRange(newPizzas);
            }

            return pizzas.Distinct().ToArray();
        }

        private static IEnumerable<Pizza> FindNewPizzas(string[] ingredients, List<Pizza> previousPizzas)
        {
            foreach (var pizza in previousPizzas)
            foreach (var ingredient in ingredients)
            {
                if (pizza.HasIngredient(ingredient)) continue;
                yield return pizza.AddIngredient(ingredient);
            }
        }
    }
}