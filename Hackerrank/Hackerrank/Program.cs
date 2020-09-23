using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hackerrank.LinkedLists;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 3, 2, 1, 1, 1 };
            List<int> list2 = new List<int>() { 4, 3, 2 };
            List<int> list3 = new List<int>() { 1, 1, 4, 1 };

            Stacks.EqualStacks(list1, list2, list3);

            //List<int> list = "278 576 496 727 410 124 338 149 209 702 282 718 771 575 436".Split(' ').Select(x => int.Parse(x)).ToList();
            //Implementation.NonDivisibleSubset(7, list);
        }
    }
}
