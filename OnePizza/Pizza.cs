using System.Linq;

namespace OnePizza
{
    public class Pizza
    {
        public Pizza(params string[] ingredients)
        {
            Ingredients = ingredients.OrderBy(x => x).ToArray();
        }

        public string[] Ingredients { get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var pizza = (Pizza)obj;

            return Ingredients.SequenceEqual(pizza.Ingredients);
        }

        public override int GetHashCode()
        {
            return Ingredients.Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
        }

        public static bool operator ==(Pizza left, Pizza right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pizza left, Pizza right)
        {
            return !Equals(left, right);
        }

        public bool HasIngredient(string ingredient)
        {
            return Ingredients.Contains(ingredient);
        }

        public Pizza AddIngredient(string ingredient)
        {
            return new Pizza(Ingredients.Union(new[] { ingredient }).ToArray());
        }

        public override string ToString()
        {
            return "Pizza with " + string.Join(", ", Ingredients);
        }
    }
}