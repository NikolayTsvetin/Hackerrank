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
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] arr2 = new int[] { 5, -6 };
            List<int> numbers = new List<int>() { 1, 4, 4, 4, 5, 3 };
            List<int> numbers2 = new List<int>() { 24, 36 };

            Implementation.MigratoryBirds(numbers);
        }
    }
}
