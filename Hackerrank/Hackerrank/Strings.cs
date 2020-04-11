using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Strings
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

        public static int Gemstones(string[] arr)
        {
            int numberOfStones = arr.Length;
            int gemstones = 0;
            Dictionary<char, int> typesOfStones = new Dictionary<char, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                var currentStone = arr[i];
                var distinctChars = currentStone.Distinct();

                foreach (var c in distinctChars)
                {
                    if (!typesOfStones.ContainsKey(c))
                    {
                        typesOfStones.Add(c, 1);
                    }
                    else
                    {
                        typesOfStones[c] = typesOfStones[c] + 1;
                    }
                }
            }

            var keys = typesOfStones.Keys;

            foreach (var key in keys)
            {
                if (typesOfStones[key] == numberOfStones)
                {
                    gemstones++;
                }
            }

            return gemstones;
        }

        public static int AlternatingCharacters(string s)
        {
            int counter = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int BeautifulBinaryString(string b)
        {
            int counter = 0;
            var allIndicesOfZeroes = new List<int>();

            for (int i = b.IndexOf('0'); i > -1; i = b.IndexOf('0', i + 1))
            {
                allIndicesOfZeroes.Add(i);
            }

            for (int i = 0; i < allIndicesOfZeroes.Count; i++)
            {
                int currentIndex = allIndicesOfZeroes[i];

                if (currentIndex < b.Length - 2 && b[currentIndex] == '0' && b[currentIndex + 1] == '1' && b[currentIndex + 2] == '0')
                {
                    StringBuilder sb = new StringBuilder(b);
                    sb[currentIndex + 2] = '1';
                    b = sb.ToString();
                    counter++;
                }
            }

            return counter;
        }

        public static int TheLoveLetterMystery(string s)
        {
            int counter = 0;
            int middleIndex = s.Length / 2;
            string firstHalf = String.Empty;
            string secondHalf = String.Empty;

            if (s.Length % 2 == 0)
            {
                firstHalf = s.Substring(0, middleIndex);
                secondHalf = s.Substring(middleIndex);
            }
            else
            {
                firstHalf = s.Substring(0, middleIndex);
                secondHalf = s.Substring(middleIndex + 1);
            }

            for (int i = 0; i < firstHalf.Length; i++)
            {
                counter += Math.Abs((int)firstHalf[i] - (int)secondHalf[secondHalf.Length - i - 1]);
            }

            return counter;
        }

        public static int PalindromeIndex(string s)
        {
            int index = -1;
            int middleIndex = s.Length / 2;
            string firstHalf = String.Empty;
            string secondHalf = String.Empty;

            if (_IsPalindrome(s))
            {
                return index;
            }

            firstHalf = s.Substring(0, middleIndex);
            secondHalf = s.Substring(middleIndex);

            for (int i = 0; i < firstHalf.Length; i++)
            {
                if (firstHalf[i] != secondHalf[secondHalf.Length - i - 1])
                {
                    string testFirstHalf = firstHalf.Remove(i, 1);
                    string testSecondHalf = secondHalf.Remove(secondHalf.Length - i - 1, 1);

                    string resultFirstHalf = testFirstHalf + secondHalf;
                    string resultSecondHalf = firstHalf + testSecondHalf;

                    if (_IsPalindrome(resultFirstHalf))
                    {
                        return i;
                    }
                    else if (_IsPalindrome(resultSecondHalf))
                    {
                        return s.Length - i - 1;
                    }
                    else
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        public static bool _IsPalindrome(string s)
        {
            int middleIndex = s.Length / 2;
            string firstHalf = String.Empty;
            string secondHalf = String.Empty;

            if (s.Length % 2 == 0)
            {
                firstHalf = s.Substring(0, middleIndex);
                secondHalf = s.Substring(middleIndex);
            }
            else
            {
                firstHalf = s.Substring(0, middleIndex);
                secondHalf = s.Substring(middleIndex + 1);
            }

            for (int i = 0; i < firstHalf.Length; i++)
            {
                if (firstHalf[i] != secondHalf[secondHalf.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static int Anagram(string s)
        {
            if (s.Length % 2 != 0)
            {
                return -1;
            }

            int counter = 0;
            string leftHalf = s.Substring(0, s.Length / 2);
            string rightHalf = s.Substring(s.Length / 2);
            List<char> lettersInLeftHalf = new List<char>();
            List<char> lettersInRightHalf = new List<char>();

            lettersInLeftHalf.AddRange(leftHalf);
            lettersInRightHalf.AddRange(rightHalf);

            for (int i = 0; i < lettersInLeftHalf.Count; i++)
            {
                char currentLetter = lettersInLeftHalf[i];
                int indexInRightHalf = lettersInRightHalf.IndexOf(currentLetter);

                if (indexInRightHalf < 0)
                {
                    counter++;
                }
                else
                {
                    lettersInRightHalf.RemoveAt(indexInRightHalf);
                }
            }

            return counter;
        }

        public static string TwoStrings(string s1, string s2)
        {
            char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                char currentChar = letters[i];
                int indexInFirstString = s1.IndexOf(currentChar);
                int indexInSecondString = s2.IndexOf(currentChar);

                if (indexInFirstString >= 0 && indexInSecondString >= 0)
                {
                    return "YES";
                }
            }

            return "NO";
        }

        public static int StringConstruction(string s)
        {
            int counter = 0;
            List<char> copied = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char currentLetter = s[i];

                if (copied.IndexOf(currentLetter) < 0)
                {
                    counter++;
                }

                copied.Add(currentLetter);
            }

            return counter;
        }

        public static string CaesarCipher(string s, int k)
        {
            StringBuilder encrypted = new StringBuilder();
            int step = k;

            for (int i = 0; i < s.Length; i++)
            {
                char currentLetter = s[i];
                step = k;

                if (currentLetter >= 65 && currentLetter <= 90)
                {
                    if (currentLetter + k > 90)
                    {
                        char modifiedLetter = _ModifyLetter(currentLetter, k, 65, 90);

                        encrypted.Append(modifiedLetter);
                    }
                    else
                    {
                        encrypted.Append((char)(currentLetter + k));
                    }
                }
                else if (currentLetter >= 97 && currentLetter <= 122)
                {
                    if (currentLetter + k > 122)
                    {
                        char modifiedLetter = _ModifyLetter(currentLetter, k, 97, 122);

                        encrypted.Append(modifiedLetter);
                    }
                    else
                    {
                        encrypted.Append((char)(currentLetter + k));
                    }
                }
                else
                {
                    encrypted.Append(currentLetter);
                }
            }

            return encrypted.ToString();
        }

        private static char _ModifyLetter(char currentLetter, int k, int lowerBound, int upperBound)
        {
            while (k > 0)
            {
                if (currentLetter == upperBound)
                {
                    currentLetter = (char)(lowerBound - 1);
                }

                currentLetter++;
                k--;
            }

            return currentLetter;
        }

        public static string GameOfThrones(string s)
        {
            if (_IsPalindromePossible(s))
            {
                return "YES";
            }

            return "NO";
        }

        private static bool _IsPalindromePossible(string s)
        {
            int middleIndex = s.Length / 2;
            string firstHalf = String.Empty;
            string secondHalf = String.Empty;
            Dictionary<char, int> countOfLetters = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!countOfLetters.ContainsKey(s[i]))
                {
                    countOfLetters.Add(s[i], 1);
                }
                else
                {
                    countOfLetters[s[i]] = countOfLetters[s[i]] + 1;
                }
            }

            var keys = countOfLetters.Keys;

            if (s.Length % 2 == 0)
            {
                foreach (var key in keys)
                {
                    if (countOfLetters[key] % 2 != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                int counter = 0;

                foreach (var key in keys)
                {
                    if (countOfLetters[key] % 2 != 0)
                    {
                        counter++;
                    }
                }

                if (counter > 1)
                {
                    return false;
                }

                return true;
            }
        }

        public static int MakingAnagrams(string s1, string s2)
        {
            int counter = 0;
            Dictionary<char, int> countOfLettersInFirstString = new Dictionary<char, int>();
            Dictionary<char, int> countOfLettersInSecondString = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!countOfLettersInFirstString.ContainsKey(s1[i]))
                {
                    countOfLettersInFirstString.Add(s1[i], 1);
                }
                else
                {
                    countOfLettersInFirstString[s1[i]] = countOfLettersInFirstString[s1[i]] + 1;
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!countOfLettersInSecondString.ContainsKey(s2[i]))
                {
                    countOfLettersInSecondString.Add(s2[i], 1);
                }
                else
                {
                    countOfLettersInSecondString[s2[i]] = countOfLettersInSecondString[s2[i]] + 1;
                }
            }

            var firstStingKeys = countOfLettersInFirstString.Keys;
            var secondStringKeys = countOfLettersInSecondString.Keys;
            var allKeys = new List<char>();
            allKeys.AddRange(firstStingKeys);
            allKeys.AddRange(secondStringKeys);

            var keysInBothStrings = allKeys.Where(key => countOfLettersInFirstString.ContainsKey(key) && countOfLettersInSecondString.ContainsKey(key)).Distinct();
            var differentKeys = allKeys.Where(key => (countOfLettersInFirstString.ContainsKey(key) && !countOfLettersInSecondString.ContainsKey(key))
                                        || !countOfLettersInFirstString.ContainsKey(key) && countOfLettersInSecondString.ContainsKey(key));

            foreach (var sameKey in keysInBothStrings)
            {
                counter += Math.Abs(countOfLettersInFirstString[sameKey] - countOfLettersInSecondString[sameKey]);
            }

            foreach (var diffKey in differentKeys)
            {
                if (countOfLettersInFirstString.ContainsKey(diffKey))
                {
                    counter += countOfLettersInFirstString[diffKey];
                }
                else
                {
                    counter += countOfLettersInSecondString[diffKey];
                }
            }

            return counter;
        }

        public static int Alternate(string s)
        {
            Dictionary<char, int> countOfLettersInString = new Dictionary<char, int>();
            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!countOfLettersInString.ContainsKey(s[i]))
                {
                    countOfLettersInString.Add(s[i], 1);
                }
                else
                {
                    countOfLettersInString[s[i]] = countOfLettersInString[s[i]] + 1;
                }
            }

            var keys = countOfLettersInString.Keys.ToList();

            // Awful
            for (int i = 0; i < keys.Count; i++)
            {
                var currentKey = keys[i];

                for (int j = i + 1; j < keys.Count; j++)
                {
                    StringBuilder result = new StringBuilder();

                    for (int k = 0; k < s.Length; k++)
                    {
                        if (s[k] == currentKey || s[k] == keys[j])
                        {
                            result.Append(s[k]);
                        }
                    }

                    if (_IsValidStringWithAlternatingChars(result.ToString()))
                    {
                        if (result.ToString().Length > maxLength)
                        {
                            maxLength = result.ToString().Length;
                        }
                    }
                }
            }

            return maxLength;
        }

        private static bool _IsValidStringWithAlternatingChars(string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                char letter = str[i - 1];

                if (str[i] == letter)
                {
                    return false;
                }
            }

            return true;
        }

        public static string[] WeightedUniformStrings(string s, int[] queries)
        {
            HashSet<int> availableWeights = new HashSet<int>();
            char currentLetter = s[0];
            // first letter is 'a' which has 97 charCode.
            int counter = currentLetter - 96;
            availableWeights.Add(counter);

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == currentLetter)
                {
                    counter += (s[i] - 96);
                    availableWeights.Add(counter);
                }
                else
                {
                    currentLetter = s[i];
                    counter = (s[i] - 96);
                    availableWeights.Add(counter);
                }
            }

            List<string> results = new List<string>();

            for (int query = 0; query < queries.Length; query++)
            {
                if (availableWeights.Contains(queries[query]))
                {
                    results.Add("Yes");
                }
                else
                {
                    results.Add("No");
                }
            }

            return results.ToArray();
        }
    }
}
