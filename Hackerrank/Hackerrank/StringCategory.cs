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

        public static int MarsExploration(string s)
        {
            int errors = 0;
            const string Sos = "SOS";

            for (int i = 0; i < s.Length - (Sos.Length - 1); i += Sos.Length)
            {
                StringBuilder word = new StringBuilder();

                word.Append(s[i]);
                word.Append(s[i + 1]);
                word.Append(s[i + 2]);

                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] != Sos[j])
                    {
                        errors++;
                    }
                }
            }

            return errors;
        }

        public static string HackerrankInString(string s)
        {
            s = s.ToLower();
            const string Hackerrank = "hackerrank";

            if (s.Length < Hackerrank.Length)
            {
                return "NO";
            }

            StringBuilder result = new StringBuilder();
            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (index < Hackerrank.Length && s[i] == Hackerrank[index])
                {
                    result.Append(s[i]);
                    index++;
                }
            }

            if (result.ToString() == Hackerrank)
            {
                return "YES";
            }

            return "NO";
        }

        public static string Pangrams(string s)
        {
            s = s.ToLower();
            var letters = new HashSet<char>();
            var allLetters = "qwertyuiopasdfghjklzxcvbnm".ToList();

            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] >= 97 && (int)s[i] <= 122)
                {
                    if (!letters.Contains(s[i]))
                    {
                        letters.Add(s[i]);
                    }
                }
            }

            int lettersCount = letters.Count;

            if (lettersCount == allLetters.Count)
            {
                return "pangram";
            }

            return "not pangram";
        }

        public static string FunnyString(string s)
        {
            string normalString = s;

            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);

            for (int i = 0; i < s.Length - 1; i++)
            {
                int normalStringDiff = Math.Abs(s[i] - s[i + 1]);
                int reversedStringDiff = Math.Abs(reversedString[i] - reversedString[i + 1]);

                if (normalStringDiff != reversedStringDiff)
                {
                    return "Not Funny";
                }
            }

            return "Funny";
        }
    }
}
