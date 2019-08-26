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
            bool isLeapYear = false;
            int sum = 0;
            List<Months> months = new List<Months>()
            {
                Months.January, Months.February, Months.March,
                Months.April, Months.May, Months.June,
                Months.July, Months.August, Months.September,
                Months.October, Months.November, Months.December
            };
            int fullMonthsCounter = 0;
            int diff = 0;

            // < 1700 ???
            if (year <= 1917)
            {
                isLeapYear = year % 4 == 0 ? true : false;
            }
            else if (year == 1918)
            {
                sum = 46;
                fullMonthsCounter = 2;

                for (int i = 2; i < months.Count; i++)
                {
                    if (sum + (int)months[i] > 256)
                    {
                        diff = 256 - sum;
                        sum += diff;
                        break;
                    }

                    sum += (int)months[i];
                    fullMonthsCounter++;
                }

                string monthsToReturn = (fullMonthsCounter + 1).ToString().Length == 1 ? ("0" + (fullMonthsCounter + 1)).ToString() : (fullMonthsCounter + 1).ToString();

                return $"{diff}.{monthsToReturn}.{year}";
            }
            else
            {
                isLeapYear = ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) ? true : false;
            }

            for (int i = 0; i < months.Count; i++)
            {
                if (isLeapYear)
                {
                    if (months[i] == Months.February)
                    {
                        sum += 29;
                        fullMonthsCounter++;
                    }
                    else
                    {
                        if (sum + (int)months[i] > 256)
                        {
                            diff = 256 - sum;
                            sum += diff;
                            break;
                        }

                        sum += (int)months[i];
                        fullMonthsCounter++;
                    }
                }
                else
                {
                    if (sum + (int)months[i] > 256)
                    {
                        diff = 256 - sum;
                        sum += diff;
                        break;
                    }

                    sum += (int)months[i];
                    fullMonthsCounter++;
                }
            }

            Console.WriteLine((int)Months.February);
            string modifiedMonths = (fullMonthsCounter + 1).ToString().Length == 1 ? ("0" + (fullMonthsCounter + 1)).ToString() : (fullMonthsCounter + 1).ToString();

            return $"{diff}.{modifiedMonths}.{year}";
        }

        public enum Months
        {
            January = 31,
            February = 28,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30,
            December = 31
        }

        public static void BonAppetit(List<int> bill, int k, int b)
        {
            int indexOfFoodToBeExcluded = k;
            int paidMoney = b;
            int wholeSum = bill.Sum();
            int sumWithoutExcludedFood = 0;

            for (int i = 0; i < bill.Count; i++)
            {
                if (i != indexOfFoodToBeExcluded)
                {
                    sumWithoutExcludedFood += bill[i];
                }
            }

            if (wholeSum / 2 == paidMoney)
            {
                Console.WriteLine((wholeSum / 2) - sumWithoutExcludedFood / 2);
            }
            else
            {
                Console.WriteLine("Bon Appetit");
            }

        }

        public static int SockMerchant(int n, int[] ar)
        {
            int[] socksInStore = ar;
            Dictionary<int, int> pairsOfSocks = new Dictionary<int, int>();
            int pairsCounter = 0;

            for (int i = 0; i < socksInStore.Length; i++)
            {
                if (!pairsOfSocks.ContainsKey(socksInStore[i]))
                {
                    pairsOfSocks.Add(socksInStore[i], 1);
                }
                else
                {
                    pairsOfSocks[socksInStore[i]] = pairsOfSocks[socksInStore[i]] + 1;
                }
            }

            var values = pairsOfSocks.Values;

            foreach (var value in values)
            {
                if (value % 2 == 0)
                {
                    pairsCounter += (value / 2);
                }
                else
                {
                    pairsCounter += ((value - 1) / 2);
                }
            }

            return pairsCounter;
        }
    }
}
