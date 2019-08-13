using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Warmup
    {
        public static int SolveMeFirst(int a, int b)
        {
            return a + b;
        }

        public static int SimpleArraySum(int[] ar)
        {
            return ar.Sum();
        }

        public static List<int> CompareTriplets(List<int> a, List<int> b)
        {
            int firstPersonResult = 0;
            int secondPersonResult = 0;
            List<int> result = new List<int>();

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    firstPersonResult++;
                }

                if (a[i] < b[i])
                {
                    secondPersonResult++;
                }
            }

            result.Add(firstPersonResult);
            result.Add(secondPersonResult);

            return result;
        }

        public static long AVeryBigSum(long[] ar)
        {
            return ar.Sum();
        }

        public static int DiagonalDifference(List<List<int>> arr)
        {
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                var currentRow = arr[i];

                primaryDiagonalSum += currentRow[i];
                secondaryDiagonalSum += currentRow[currentRow.Count - i - 1];
            }

            return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
        }

        public static void PlusMinus(int[] arr)
        {
            double positiveNumbers = arr.Where(item => item > 0).ToList().Count;
            double negativeNumbers = arr.Where(item => item < 0).ToList().Count;
            double zeroes = arr.Where(item => item == 0).ToList().Count;

            Console.WriteLine(String.Format("{0:0.000000}", positiveNumbers / arr.Length));
            Console.WriteLine(String.Format("{0:0.000000}", negativeNumbers / arr.Length));
            Console.WriteLine(String.Format("{0:0.000000}", zeroes / arr.Length));
        }

        public static void Staircase(int n)
        {
            int spacesCount = n - 1;
            int hashesCount = 1;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = new String(' ', spacesCount) + new String('#', hashesCount);
                result.Append(line).Append("\n");

                spacesCount--;
                hashesCount++;
            }

            Console.WriteLine(result.ToString());
        }

        public static void MiniMaxSum(int[] arr)
        {
            int indexOfMinNumber = 0;
            int indexOfMaxNumber = arr.Length - 1;
            long minSum = 0;
            long maxSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[indexOfMinNumber])
                {
                    indexOfMinNumber = i;
                }

                if (arr[i] > arr[indexOfMaxNumber])
                {
                    indexOfMaxNumber = i;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == indexOfMinNumber)
                {
                    minSum += arr[i];
                }
                else if (i == indexOfMaxNumber)
                {
                    maxSum += arr[i];
                }
                else
                {
                    minSum += arr[i];
                    maxSum += arr[i];
                }
            }

            Console.WriteLine(minSum + " " + maxSum);
        }

        public static int BirthdayCakeCandles(int[] ar)
        {
            int numberOfCandles = ar.Length;
            int biggestCandle = ar.Max();
            int counter = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] == biggestCandle)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static string TimeConversion(string s)
        {
            string[] inputTime = s.Split(':');
            var hours = inputTime[0];
            var minutes = inputTime[1];
            var seconds = inputTime[2].ToString().Substring(0, 2);
            var time = inputTime[2].ToString().Substring(2);

            if (hours == "12")
            {
                if (time == "AM")
                {
                    return "00" + ":" + minutes + ":" + seconds;
                }
                else
                {
                    return "12" + ":" + minutes + ":" + seconds;
                }
            }

            if (time == "PM")
            {
                hours = (Int32.Parse(hours) + 12).ToString();
            }

            return hours + ":" + minutes + ":" + seconds;
        }
    }
}
