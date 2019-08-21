using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> data = new List<List<int>>() { new List<int>() { 11, 2, 4 }, new List<int>() { 4, 5, 6 }, new List<int>() { 10, 8, -12 } };
            int[] arr = new int[] { -2, 2, 1 };
            int[] arr2 = new int[] { 5, -6 };

            List<int> numbers = new List<int>() { 73, 67, 38, 33 };

            Implementation.CountApplesAndOranges(7, 11, 5, 15, arr, arr2);
        }
    }
}
