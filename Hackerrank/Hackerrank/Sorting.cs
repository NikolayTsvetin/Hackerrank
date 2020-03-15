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
    }
}
