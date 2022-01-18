using System;
using System.Linq;

namespace OnePizza
{
    internal class Program
    {
        // https://codingcompetitions.withgoogle.com/hashcode/round/00000000008f5ca9/00000000008f6f33

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            string[] input =
            {
                "3",
                "2 cheese peppers",
                "0",
                "1 basil",
                "1 pineapple",
                "2 mushrooms tomatoes",
                "1 basil"
            };

            var clients = InputParser.Parse(input).ToArray();

            var ingredients = clients.SelectMany(x => x.Likes.Union(x.Dislikes)).Distinct().OrderBy(x => x).ToArray();

            var pizzas = PizzaGenerator.GeneratePizzas(ingredients);
            
            // TODO score each pizza
            
            Console.WriteLine("Bye!");
        }
    }
}