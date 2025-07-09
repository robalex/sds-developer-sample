using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            var result = 1;
            for (var i = n; i > 1; i--)
            {
                // Always throws System.OverflowException. If this needs to be performance critical or we want to throw a custom exception, manually check overflow.
                checked
                {
                    result *= i;
                }
            }

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
            {
                return string.Empty;
            }
            
            if (items.Length == 1)
            {
                return items[0];
            }

            return $"{string.Join(", ", items, 0, items.Length - 1)} and {items[^1]}";
        }
    }
}
