using System;
using System.Linq;

namespace WordSorter.Extensions
{
    public static class StringExtensions
    {
        public static int GetVowelsQuantity(this string word)
        {
            const string vowels = "АЯОЁУЮЫИЭЕ";

            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"{nameof(word)} is null or empty!");
            }
            
            return word.Count(c => $"{vowels}{vowels.ToLower()}".Contains(c));
        }
    }
}