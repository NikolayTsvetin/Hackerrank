﻿using System;
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
            int[] arr = new int[] { 1, 1, 3, 2, 1 };
            int[] arr2 = new int[] { 3, 1, 2 };
            List<int> numbers = new List<int>() { 2, 2, 3, 4, 5 };
            List<int> numbers2 = new List<int>() { 5, 2, 8 };
            string[] strings = new string[] { "aba", "baba", "aba", "xzxb" };
            string[] queries = new string[] { "aba", "xzxb", "ab" };

            Arrays.MatchingStrings(strings, queries);
        }
    }
}
