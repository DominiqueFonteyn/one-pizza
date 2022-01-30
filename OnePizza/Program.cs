using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OnePizza
{
    /*
     Approach 1:
     - generate all possible pizzas (like frequent itemset generation in the Apriori algorithm)
     - evaluate pizzas for each client
     - pizzas with the highest score wins     
     
     Approach 2:
     - construct complete graph with all ingredients (each ingredient is a node, all nodes are interconnected)
     - find the path that satisfies the most clients
     
     Approach 3:
     - continuing on approach 2 - is a complete graph required?
     - what if we only connect 2 nodes when a client likes them both?
     
     */
    internal class Program
    {
        public static string[] c_coarse = new[]
        {
            "10",
            "3 akuof byyii dlust",
            "1 xdozp",
            "3 dlust luncl qzfyo",
            "1 xdozp",
            "3 akuof luncl vxglq",
            "1 qzfyo",
            "3 dlust vxglq luncl",
            "0",
            "3 dlust xveqd tfeej",
            "0",
            "3 qzfyo vxglq luncl",
            "1 byyii",
            "3 luncl xdozp xveqd",
            "1 sunhp",
            "3 byyii xdozp tfeej",
            "1 qzfyo",
            "3 dlust akuof tfeej",
            "1 xveqd",
            "3 vxglq dlust byyii",
            "1 akuof"
        };

        // https://codingcompetitions.withgoogle.com/hashcode/round/00000000008f5ca9/00000000008f6f33
        private static void Main(string[] args)
        {
            // TODO prune possible pizzas
            var input = args.Any() ? File.ReadLines(args[0]).ToArray() : c_coarse;

            var clients = InputParser.Parse(input).ToArray();
            var ingredients = clients.SelectMany(x => x.Likes.Union(x.Dislikes)).Distinct().OrderBy(x => x).ToArray();
            Logger.Write($"Found {clients.Length} clients");
            Logger.Write($"Found {ingredients.Length} ingredients");
            Logger.Write($"There are {Math.Pow(2, ingredients.Length) - 1} possible pizzas!");

            var stopwatch = Stopwatch.StartNew();
            var pizzas = PizzaGenerator.GeneratePizzas(clients, ingredients);
            stopwatch.Stop();
            Logger.Write($"Generated {pizzas.LongLength} in {stopwatch.ElapsedMilliseconds}ms");

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
            Logger.Write($"Found {scores.Length} pizza(s):");
            foreach (var (pizza, score) in scores)
                Logger.Write($" - {pizza} scores {score} points.");
        }

        private static void PrintPizzas(Pizza[] pizzas)
        {
            Logger.Write($"Found {pizzas.Length} possible pizzas!");
            foreach (var pizza in pizzas) Logger.Write(" - " + pizza);
        }
    }
}