using System.Linq;

namespace WordSorter.Extensions
{
    public static class StringExtensions
    {
        public static int GetVowelsQuantity(this string word)
        {
            const string vowels = "АЯОЁУЮЫИЭЕ";

            return word.Count(c => $"{vowels}{vowels.ToLower()}".Contains(c));
        }
    }
}