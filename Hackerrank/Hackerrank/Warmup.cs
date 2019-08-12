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
    }
}
