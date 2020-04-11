using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Search
    {
        public static int[] IcecreamParlor(int m, int[] arr)
        {
            int moneyToSpend = m;
            int[] flavorsChosen = new int[2];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int currentFlavor = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentFlavor + arr[j] == moneyToSpend)
                    {
                        // plus 1 because in the solution in Hackerrank it uses 1-based arrays for some strange reason.
                        flavorsChosen[0] = i + 1;
                        flavorsChosen[1] = j + 1;

                        return flavorsChosen;
                    }
                }
            }

            return flavorsChosen;
        }

        public static int[] MissingNumbers(int[] arr, int[] brr)
        {
            Dictionary<int, int> receivedNumbers = _GetCountOfKeysInArray(arr);
            Dictionary<int, int> originalNumbers = _GetCountOfKeysInArray(brr);
            List<int> diff = new List<int>();

            var keysInOriginal = originalNumbers.Keys;

            foreach (var key in keysInOriginal)
            {
                if (!receivedNumbers.ContainsKey(key) || (receivedNumbers.ContainsKey(key) && receivedNumbers[key] != originalNumbers[key]))
                {
                    diff.Add(key);
                }
            }

            diff.Sort();

            return diff.ToArray();
        }

        private static Dictionary<int, int> _GetCountOfKeysInArray(int[] array)
        {
            Dictionary<int, int> counterForKeys = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                if (counterForKeys.ContainsKey(currentNumber))
                {
                    counterForKeys[currentNumber] = counterForKeys[currentNumber] + 1;
                }
                else
                {
                    counterForKeys[currentNumber] = 1;
                }
            }

            return counterForKeys;
        }

        public static string BalancedSums(List<int> arr)
        {
            if (arr.Count == 1)
            {
                return "YES";
            }

            int sum = arr.Sum();
            int leftSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                int currentNumber = arr[i];
                sum -= currentNumber;

                if (leftSum == sum)
                {
                    return "YES";
                }

                leftSum += currentNumber;
            }

            return "NO";
        }
    }
}
