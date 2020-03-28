using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Sorting
    {
        public static string[] BigSorting(string[] unsorted)
        {
            Array.Sort(unsorted, (string a, string b) =>
            {
                if (a.Length == b.Length)
                    return string.Compare(a, b, StringComparison.Ordinal);
                return a.Length - b.Length;
            });

            return unsorted;
        }

        public static int IntroTutorial(int V, int[] arr)
        {
            return Array.IndexOf(arr, V);
        }

        public static void InsertionSort1(int n, int[] arr)
        {
            int unsortedNumber = arr[n - 1];
            int index = n - 2;

            while (index >= 0)
            {
                if (arr[index] > unsortedNumber)
                {
                    arr[index + 1] = arr[index];
                    Console.WriteLine(String.Join(" ", arr));

                    if (index == 0)
                    {
                        // break so it wont decrement index again
                        break;
                    }
                }
                else
                {
                    arr[index + 1] = unsortedNumber;
                    Console.WriteLine(String.Join(" ", arr));
                    break;
                }

                index--;
            }

            // Corner case.
            if (index == 0 && arr[index] > unsortedNumber)
            {
                arr[index + 1] = arr[index];
                arr[index] = unsortedNumber;
                Console.WriteLine(String.Join(" ", arr));
            }
        }

        public static void InsertionSort2(int n, int[] arr)
        {
            int index = 1;

            while (index < arr.Length)
            {
                int unsortedNumber = arr[index];
                int indexToPlaceUnsortedNumber = _FindIndexToInsert(unsortedNumber, index, arr);

                if (indexToPlaceUnsortedNumber == 0 && arr[0] > unsortedNumber)
                {
                    arr = _InsertNumberInPosition(indexToPlaceUnsortedNumber, index, arr);

                    index++;
                    Console.WriteLine(String.Join(" ", arr));
                    continue;
                }
                else if (indexToPlaceUnsortedNumber > 0)
                {
                    arr = _InsertNumberInPosition(indexToPlaceUnsortedNumber, index, arr);
                }

                Console.WriteLine(String.Join(" ", arr));
                index++;
            }
        }

        private static int[] _InsertNumberInPosition(int indexToPlaceUnsortedNumber, int index, int[] arr)
        {
            int[] newArr = new int[arr.Length + 1];
            int elementToBeInserted = arr[index];

            for (int i = 0; i < newArr.Length; i++)
            {
                if (i < indexToPlaceUnsortedNumber)
                {
                    newArr[i] = arr[i];
                }
                else if (i == indexToPlaceUnsortedNumber)
                {
                    newArr[i] = elementToBeInserted;
                }
                else
                {
                    newArr[i] = arr[i - 1];
                }
            }

            var list = newArr.ToList();
            list.RemoveAt(index + 1);
            newArr = list.ToArray();

            return newArr;
        }

        private static int _FindIndexToInsert(int unsortedNumber, int upperBound, int[] arr)
        {
            int index = 0;

            for (int i = 0; i <= upperBound; i++)
            {
                if (arr[i] > unsortedNumber)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public static void InsertionSort(int[] A)
        {
            var j = 0;
            for (var i = 1; i < A.Length; i++)
            {
                var value = A[i];
                j = i - 1;
                while (j >= 0 && value < A[j])
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = value;
            }
            Console.WriteLine(string.Join(" ", A));
        }

        public static int RunningTime(int[] arr)
        {
            int counter = 0;
            var j = 0;

            for (var i = 1; i < arr.Length; i++)
            {
                var value = arr[i];
                j = i - 1;
                while (j >= 0 && value < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                    counter++;
                }

                arr[j + 1] = value;
            }

            return counter;
        }

        // Part one - partition
        public static int[] QuickSort(int[] arr)
        {
            int pivot = arr[0];
            List<int> left = new List<int>();
            List<int> equal = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < pivot)
                {
                    left.Add(arr[i]);
                }
                else if (arr[i] == pivot)
                {
                    equal.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            List<int> result = new List<int>();

            result.AddRange(left);
            result.AddRange(equal);
            result.AddRange(right);

            return result.ToArray();
        }

        // Part one - count elements
        public static int[] CountingSort(int[] arr)
        {
            // max number is arr is 100.
            int[] count = new int[100];
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }

            return count;
        }

        //  Part two - sort
        public static int[] CountingSort2(int[] arr)
        {
            // max number is arr is 100.
            int[] count = new int[100];
            int[] result = new int[arr.Length];
            int k = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    for (int j = 0; j < count[i]; j++)
                    {
                        result[k] = i;
                        k++;
                    }
                }
            }

            return result;
        }

        public static int[] ClosestNumbers(int[] arr)
        {
            Array.Sort(arr);
            int minDifference = Int32.MaxValue;
            List<int> result = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                int diff = Math.Abs(arr[i] - arr[i - 1]);

                if (diff < minDifference)
                {
                    minDifference = diff;
                }
            }

            for (int i = 1; i < arr.Length; i++)
            {
                int diff = Math.Abs(arr[i] - arr[i - 1]);

                if (diff == minDifference)
                {
                    result.Add(arr[i - 1]);
                    result.Add(arr[i]);
                }
            }

            return result.ToArray();
        }

        // wtf ?!?! :D
        public static int FindMedian(int[] arr)
        {
            Array.Sort(arr);

            return arr[arr.Length / 2];
        }
    }
}
