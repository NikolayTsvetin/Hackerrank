using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class StringCategory
    {
        public static string SuperReducedString(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    s = s.Remove(i - 1, 2);
                    i = 0;
                }
            }

            if (s.Length == 0)
            {
                return "Empty String";
            }

            return s;
        }

        public static int Camelcase(string s)
        {
            int counter = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if ((int)s[i] >= 65 && (int)s[i] <= 90)
                {
                    counter++;
                }
            }

            return counter + 1;
        }

        public static int MinimumNumber(int n, string password)
        {
            int counter = 0;

            var numberRegex = new Regex("[0-9]");
            var numbersMatch = numberRegex.Match(password);

            if (String.IsNullOrEmpty(numbersMatch.Value))
            {
                counter++;
            }

            var lowerCaseLettersRegex = new Regex("[a-z]");
            var lowerCaseLettersMatch = lowerCaseLettersRegex.Match(password);

            if (String.IsNullOrEmpty(lowerCaseLettersMatch.Value))
            {
                counter++;
            }

            var upperCaseLettersRegex = new Regex("[A-Z]");
            var upperCaseLettersMatch = upperCaseLettersRegex.Match(password);

            if (String.IsNullOrEmpty(upperCaseLettersMatch.Value))
            {
                counter++;
            }

            var specialCharsRegex = new Regex("[!@#$%^&*()+-]");
            var specialCharsMatch = specialCharsRegex.Match(password);

            if (String.IsNullOrEmpty(specialCharsMatch.Value))
            {
                counter++;
            }

            if (password.Length + counter < 6)
            {
                counter += (6 - (password.Length + counter));
            }

            return counter;
        }
    }
}
