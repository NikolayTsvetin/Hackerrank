using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Implementation
    {
        public static List<int> GradingStudents(List<int> grades)
        {
            List<int> modifiedGrades = new List<int>();

            for (int i = 0; i < grades.Count; i++)
            {
                int currentGrade = grades[i];

                if (currentGrade < 38)
                {
                    modifiedGrades.Add(currentGrade);
                }
                else
                {
                    int currentValueFromDivision = currentGrade / 5;
                    int nextValue = currentValueFromDivision + 1;
                    int nextNumber = nextValue * 5;

                    if (nextNumber - currentGrade < 3)
                    {
                        currentGrade = nextNumber;
                    }

                    modifiedGrades.Add(currentGrade);
                }
            }

            return modifiedGrades;
        }

        public static void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int houseStart = s;
            int houseEnd = t;
            int appleTreeLocation = a;
            int orangeTreeLocation = b;
            int applesCounter = 0;
            int orangesCounter = 0;

            for (int i = 0; i < apples.Length; i++)
            {
                if (apples[i] < 0)
                {
                    continue;
                }

                if (appleTreeLocation + apples[i] >= houseStart && appleTreeLocation + apples[i] <= houseEnd)
                {
                    applesCounter++;
                }
            }

            for (int j = 0; j < oranges.Length; j++)
            {
                if (oranges[j] > 0)
                {
                    continue;
                }

                if (orangeTreeLocation + oranges[j] <= houseEnd && orangeTreeLocation + oranges[j] >= houseStart)
                {
                    orangesCounter++;
                }
            }

            Console.WriteLine(applesCounter);
            Console.WriteLine(orangesCounter);
        }

        public static string Kangaroo(int x1, int v1, int x2, int v2)
        {
            int positionOfTheFirstKangaroo = x1;
            int positionOfTheSecondKangaroo = x2;
            int speedOfTheFirstKangaroo = v1;
            int speedOfTheSecondKangaroo = v2;

            for (int i = 0; i < 10000; i++)
            {
                if (positionOfTheFirstKangaroo == positionOfTheSecondKangaroo)
                {
                    return "YES";
                }

                positionOfTheFirstKangaroo += speedOfTheFirstKangaroo;
                positionOfTheSecondKangaroo += speedOfTheSecondKangaroo;
            }

            return "NO";
        }

        public static int GetTotalX(List<int> a, List<int> b)
        {
            List<int> factors = new List<int>();
            int firstSetBiggestNumber = a.Max();
            int secondSetSmallestNumber = b.Min();
            int counter = 0;

            for (int i = Math.Min(firstSetBiggestNumber, secondSetSmallestNumber); i <= Math.Max(firstSetBiggestNumber, secondSetSmallestNumber); i++)
            {
                bool factor = true;

                for (int j = 0; j < b.Count; j++)
                {
                    if (b[j] % i != 0)
                    {
                        factor = false;
                    } 
                }

                if (factor)
                {
                    factors.Add(i);
                }
            }

            for (int f = 0; f < factors.Count; f++)
            {
                bool valid = true;

                for (int k = 0; k < a.Count; k++)
                {
                    if (factors[f] % a[k] != 0)
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int[] BreakingRecords(int[] scores)
        {
            int min = scores[0];
            int max = scores[0];
            int newMinRecordCounter = 0;
            int newMaxRecordCounter = 0;
            int[] result = new int[2];

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < min)
                {
                    min = scores[i];
                    newMinRecordCounter++;
                }
                if (scores[i] > max)
                {
                    max = scores[i];
                    newMaxRecordCounter++;
                }
            }

            result[0] = newMaxRecordCounter;
            result[1] = newMinRecordCounter;

            return result;
        }

        public static int Birthday(List<int> s, int d, int m)
        {
            List<int> chocolateBars = s;
            int birthDay = d;
            int birthMonth = m;
            int counter = 0;

            for (int i = 0; i <= s.Count - birthMonth; i++)
            {
                int sum = 0;

                for (int j = i; j < i + birthMonth; j++)
                {
                    sum += s[j];
                }

                if (sum == birthDay)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int DivisibleSumPairs(int n, int k, int[] ar)
        {
            int counter = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                int currentNumber = ar[i];

                for (int j = i + 1; j < ar.Length; j++)
                {
                    if ((currentNumber + ar[j]) % k == 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public static int MigratoryBirds(List<int> arr)
        {
            Dictionary<int, int> birdsAndSights = new Dictionary<int, int>();

            for (int i = 0; i < arr.Count; i++)
            {
                if (!birdsAndSights.ContainsKey(arr[i]))
                {
                    birdsAndSights.Add(arr[i], 1);
                }
                else
                {
                    birdsAndSights[arr[i]] = birdsAndSights[arr[i]] + 1;
                }
            }

            int maxValue = birdsAndSights.Values.Max();
            IEnumerable<int> keys = birdsAndSights.Keys;
            IEnumerable<int> x = keys.Where(key => birdsAndSights[key] == maxValue);

            return x.Min();
        }

        public static string DayOfProgrammer(int year)
        {
            throw new NotImplementedException();
        }
    }
}
