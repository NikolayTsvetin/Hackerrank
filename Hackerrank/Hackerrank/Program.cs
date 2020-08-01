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
            int[] scores = new int[] { 100, 100, 50, 40, 40, 20, 10 };
            int[] aliceScores = new int[] { 5, 25, 50, 120 };

            Implementation.ClimbingLeaderboard(/*scores, aliceScores*/test, test2);
        }
    }
}
