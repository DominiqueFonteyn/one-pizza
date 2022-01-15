using System;
using System.Collections.Generic;
using System.Linq;

namespace OnePizza
{
    public class InputParser
    {
        public static IEnumerable<Client> Parse(string[] input)
        {
            for (var i = 0; i < (input.Length - 1) / 2; i++)
                yield return new Client(
                    ParseLine(input[i * 2 + 1]),
                    ParseLine(input[i * 2 + 2])
                );
        }

        private static string[] ParseLine(string line)
        {
            var split = line.Split(new[] { " " }, StringSplitOptions.None);
            return split.Length == 1 ? Array.Empty<string>() : split.Skip(1).ToArray();
        }
    }
}