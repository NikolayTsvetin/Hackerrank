using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Arrays
    {
        public static int[] ReverseArray(int[] a)
        {
            return a.Reverse().ToArray();
        }

        public static int HourglassSum(int[][] arr)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 2; j += 1)
                {
                    int tempResult = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
                        arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    if (tempResult > max)
                    {
                        max = tempResult;
                    }
                }
            }

            return max;
        }

        public static List<int> DynamicArray(int n, List<List<int>> queries)
        {
            int numberOfSequences = n;
            int numberOfQueries = queries.Count;
            List<List<int>> seqList = new List<List<int>>();
            List<int> results = new List<int>();

            for (int i = 0; i < numberOfSequences; i++)
            {
                seqList.Add(new List<int>());
            }

            int lastAnswer = 0;

            for (int i = 0; i < numberOfQueries; i++)
            {
                if (queries[i][0] == 1)
                {
                    int numberToAppend = queries[i][2];
                    int index = ((queries[i][1] ^ lastAnswer) % numberOfSequences);
                    seqList[index].Add(numberToAppend);
                }
                else if (queries[i][0] == 2)
                {
                    int index = ((queries[i][1] ^ lastAnswer) % numberOfSequences);

                    int temp = queries[i][2] % seqList[index].Count;
                    lastAnswer = seqList[index][temp];

                    Console.WriteLine(lastAnswer);
                    results.Add(lastAnswer);
                }
                else
                {
                    throw new ArgumentException("Something went wrong. Check how you handle the queries!!!");
                }
            }

            return results;
        }

        public static void LeftRotate(int[] array, int length, int shift)
        {
            int[] copy = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                int currentEl = array[i];
                int indexToBePlaced = i - shift;

                while (indexToBePlaced < 0)
                {
                    indexToBePlaced = length + indexToBePlaced;
                }

                copy[indexToBePlaced] = currentEl;
            }

            Console.WriteLine(string.Join(" ", copy));
        }

        public static int[] MatchingStrings(string[] strings, string[] queries)
        {
            int[] result = new int[queries.Length];
            int i = 0;

            foreach (var query in queries)
            {
                int counter = 0;

                foreach (var str in strings)
                {
                    if (query == str)
                    {
                        counter++;
                    }
                }

                result[i] = counter;
                i++;
            }

            return result;
        }
    }
}
