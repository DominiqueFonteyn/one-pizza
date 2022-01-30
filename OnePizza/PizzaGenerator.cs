using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace OnePizza
{
    public class PizzaGenerator
    {
        public static Pizza[] GeneratePizzas(IClient[] clients, params string[] ingredients)
        {
            var pizzas = new List<Pizza>();

            for (int k = 1; k <= ingredients.Length; k++)
            {
                var combinations = new Combinations<string>(ingredients, k, GenerateOption.WithoutRepetition);
                pizzas.AddRange(combinations
                    .Select(x => new Pizza(x.ToArray()))
                    .Where(x => Evaluator.EvaluatePizza(x, clients) > 0)
                );
            }

            //
            // pizzas.AddRange(ingredients.Select(x => new Pizza(x)));
            //
            // var newPizzas = new List<Pizza>(pizzas);
            // while (newPizzas.Any())
            // {
            //     newPizzas = FindNewPizzas(ingredients, newPizzas).ToList();
            //     // TODO prune 
            //     pizzas.AddRange(newPizzas.Where(x => Evaluator.EvaluatePizza(x, clients) > 0));
            // }
            //
            // return pizzas.Distinct().ToArray();

            return pizzas.ToArray();
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