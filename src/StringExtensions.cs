using System;
using System.Linq;
using System.Xml.Linq;

namespace Cook.DotnetExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets index-sensitive substring.
        /// https://sharpsnippets.wordpress.com/2014/01/25/safe-substring/
        /// </summary>
        /// <param name="input">String to safely get substring of.</param>
        /// <param name="start">Start index in typical substring call.</param>
        /// <param name="stop">Stop index in typical substring call.</param>
        /// <returns>
        ///   Emtpy if start is out of range.
        ///   String from beginning to given length, if start < 0.
        ///   String from start to end of string, if stop > input.length.
        ///   Appropriate string if value is correct.
        /// </returns>
        public static string SafeSubstring(this string input, int start, int stop)
        {
            return new string((input ?? "").Skip(start).Take(stop).ToArray());
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return String.IsNullOrWhiteSpace(input);
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input);
        }
    }
}
