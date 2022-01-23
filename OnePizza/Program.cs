using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnePizza
{
    internal class Program
    {
        // https://codingcompetitions.withgoogle.com/hashcode/round/00000000008f5ca9/00000000008f6f33

        private static void Main(string[] args)
        {
            // TODO prune possible pizzas
            
            var input = File.ReadLines(args[0]).ToArray();

            var clients = InputParser.Parse(input).ToArray();
            var ingredients = clients.SelectMany(x => x.Likes.Union(x.Dislikes)).Distinct().OrderBy(x => x).ToArray();
            Console.WriteLine($"Found {clients.Length} clients");
            Console.WriteLine($"Found {ingredients.Length} ingredients");
            Console.WriteLine($"There are {Math.Pow(2, ingredients.Length) - 1} possible pizzas!");


            var pizzas = PizzaGenerator.GeneratePizzas(ingredients);

            // PrintPizzas(pizzas);
            var scores = EvaluatePizzas(pizzas, clients);
            var maxScore = scores.Values.Max(x => x);
            PrintScores(scores
                .Where(x => x.Value == maxScore)
                .OrderByDescending(x => x.Value)
                .ToArray());

        }

        private static Dictionary<Pizza, int> EvaluatePizzas(IEnumerable<Pizza> pizzas, IEnumerable<Client> clients)
        {
            return pizzas.ToDictionary(
                x => x,
                x => Evaluator.EvaluatePizza(x, clients));
        }

        private static void PrintScores(KeyValuePair<Pizza, int>[] scores)
        {
            Console.WriteLine($"Found {scores.Length} pizza(s):");
            foreach (var (pizza, score) in scores)
                Console.WriteLine($" - {pizza} scores {score} points.");
        }

        private static void PrintPizzas(Pizza[] pizzas)
        {
            Console.WriteLine($"Found {pizzas.Length} possible pizzas!");
            foreach (var pizza in pizzas) Console.WriteLine(" - " + pizza);
        }
    }
}