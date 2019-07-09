using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Examples
{
    class RegularExpressions
    {
        static void Main(string[] args)
        {
            string pattern = "^[A-Za-z][A-Ha-hJ-Yj-y][0-9]\\s?[0-9][A-Za-z]{2}$";
            string input = "HP7 2ARi";
            Regex regex = new Regex(pattern);
            Console.WriteLine(regex.IsMatch(input));
            Match match = regex.Match(input);
            Console.WriteLine($"length {match.Length} value {match.Value}");

        }
    }
}
