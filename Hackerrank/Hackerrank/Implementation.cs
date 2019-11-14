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

        public static int PageCount(int n, int p)
        {
            int numbersOfPagesInBook = n;
            int searchedPage = p;

            return Math.Min(searchedPage / 2, numbersOfPagesInBook / 2 - searchedPage / 2);
        }

        public static int CountingValleys(int n, string s)
        {
            int startingHeight = 0;
            bool inValley = false;
            int counter = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char currentPosition = s[i];

                if (currentPosition == 'U')
                {
                    startingHeight++;
                }
                else
                {
                    startingHeight--;
                }

                if (startingHeight < 0)
                {
                    inValley = true;
                }

                if (inValley && startingHeight >= 0)
                {
                    inValley = false;
                    counter++;
                }
            }

            return counter;
        }

        public static int GetMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int moneyToSpend = b;
            int max = -1;

            for (int i = 0; i < keyboards.Length; i++)
            {
                int currentKeyboardPrice = keyboards[i];
                var possiblePairs = drives.Select(item => item + currentKeyboardPrice);
                var pairsFittingPrice = possiblePairs.Where(item => item <= moneyToSpend);

                if (pairsFittingPrice.Count() <= 0)
                {
                    continue;
                }

                var maxPriceForPair = pairsFittingPrice.Max();

                if (maxPriceForPair > max)
                {
                    max = maxPriceForPair;
                }
            }

            return max;
        }

        public static string CatAndMouse(int x, int y, int z)
        {
            int firstCatLocation = x;
            int secondCatLocation = y;
            int mouseLocation = z;
            int firstDifference = Math.Abs(firstCatLocation - mouseLocation);
            int secondDifference = Math.Abs(secondCatLocation - mouseLocation);

            if (firstDifference < secondDifference)
            {
                return "Cat A";
            }
            else if (secondDifference < firstDifference)
            {
                return "Cat B";
            }
            else
            {
                return "Mouse C";
            }
        }

        public static int PickingNumbers(List<int> a)
        {
            int maxNumber = 0;

            for (int i = 0; i < a.Count; i++)
            {
                int currentNumber = a[i];
                var suitableNumbers = a.Where(number => currentNumber >= number && currentNumber - number <= 1);
                var secondOptionSuitableNumbers = a.Where(number => number >= currentNumber && number - currentNumber <= 1);
                var chosenOption = Math.Max(suitableNumbers.Count(), secondOptionSuitableNumbers.Count());

                if (chosenOption > maxNumber)
                {
                    maxNumber = suitableNumbers.Count();
                }
            }

            return maxNumber;
        }

        public static int HurdleRace(int k, int[] height)
        {
            int heightJump = k;
            int maxHeight = height.Max();

            if (heightJump < maxHeight)
            {
                return maxHeight - heightJump;
            }
            else
            {
                return 0;
            }
        }

        public static int DesignerPdfViewer(int[] h, string word)
        {
            int highestLetter = 0;
            char[] alphabet = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k','l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            };

            for (int i = 0; i < word.Length; i++)
            {
                int index = Array.IndexOf(alphabet, word[i]);

                if (h[index] > highestLetter)
                {
                    highestLetter = h[index];
                }
            }

            return highestLetter * word.Length;
        }

        public static int UtopianTree(int n)
        {
            int initialHeight = 1;
            bool isSpring = true;
            bool isSummer = false;

            for (int i = 0; i < n; i++)
            {
                if (isSpring)
                {
                    isSpring = false;
                    initialHeight *= 2;

                    isSummer = true;
                    continue;
                }

                if (isSummer)
                {
                    isSummer = false;
                    initialHeight += 1;

                    isSpring = true;
                    continue;
                }
            }

            return initialHeight;
        }

        public static string AngryProfessor(int k, int[] a)
        {
            int numberOfStudentsForClassToStart = k;
            int counter = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0)
                {
                    counter++;
                }
            }

            if (counter < numberOfStudentsForClassToStart)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        public static int BeautifulDays(int i, int j, int k)
        {
            int startingDay = i;
            int endingDay = j;
            int divisor = k;
            int beautifulDaysCounter = 0;

            for (int counter = startingDay; counter <= endingDay; counter++)
            {
                string reversedCurrentNumber = ReverseNumber(counter);
                int parsedToIntReversedNumber = Int32.Parse(reversedCurrentNumber);

                if (Math.Abs(counter - parsedToIntReversedNumber) % divisor == 0)
                {
                    beautifulDaysCounter++;
                }
            }

            return beautifulDaysCounter;
        }

        private static string ReverseNumber(int number)
        {
            string numberAsString = number.ToString();
            StringBuilder reversedNumber = new StringBuilder();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                reversedNumber.Append(numberAsString[i]);
            }

            return reversedNumber.ToString();
        }

        public static int ViralAdvertising(int n)
        {
            int initialPeopleGiven = 5;
            int peopleSharedWith = initialPeopleGiven;
            int peopleWhoLiked = initialPeopleGiven / 2;
            int total = peopleWhoLiked;

            for (int i = 2; i <= n; i++)
            {
                peopleSharedWith = peopleWhoLiked * 3;

                int newLikes = peopleSharedWith / 2;
                total += newLikes;

                peopleWhoLiked = newLikes;
            }

            return total;
        }

        public static int SaveThePrisoner(int n, int m, int s)
        {
            throw new NotImplementedException("fuck this task");
        }

        public static int[] CircularArrayRotation(int[] a, int k, int[] queries)
        {
            int[] numbersArray = a;
            int timesToRotate = k;
            int[] indicesToReturn = queries;

            int[] rotatedArray = new int[numbersArray.Length];

            for (int i = 0; i < numbersArray.Length; i++)
            {
                int currentElement = numbersArray[i];
                int indexToBePlaced = i + timesToRotate;

                if (indexToBePlaced < numbersArray.Length)
                {
                    rotatedArray[indexToBePlaced] = currentElement;
                }
                else
                {
                    indexToBePlaced = indexToBePlaced % numbersArray.Length;
                    rotatedArray[indexToBePlaced] = currentElement;
                }
            }

            int[] returnIndices = new int[indicesToReturn.Length];

            for (int i = 0; i < indicesToReturn.Length; i++)
            {
                int wantedIndex = indicesToReturn[i];
                returnIndices[i] = rotatedArray[wantedIndex];
            }

            return returnIndices;
        }

        public static int[] PermutationEquation(int[] p)
        {
            // Extremely, extremely dumb task!!! Nothing logical here, please dont try it.
            // Counting starts from 1. Then you find index and start counting from 1 again. Then again. Awful.
            int[] numbers = p;
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                int x = i + 1;
                int index = Array.IndexOf(numbers, x) + 1;
                int secondIndex = Array.IndexOf(numbers, index);

                result[i] = secondIndex + 1;
            }

            return result;
        }

        public static int JumpingOnClouds(int[] c, int k)
        {
            int startingEnergy = 100;
            int jumpSize = k;
            int[] clouds = c;
            int i = 0;

            while (true)
            {
                int nextCloud = clouds[(i + jumpSize) % clouds.Length];
                i = (i + jumpSize) % clouds.Length;

                startingEnergy -= 1;

                if (c[i] == 1)
                {
                    startingEnergy -= 2;
                }

                if (i == 0)
                {
                    break;
                }
            }

            return startingEnergy;
        }

        public static int EqualizeArray(int[] arr)
        {
            Dictionary<int, int> numbersHolder = new Dictionary<int, int>();
            int maxNumber = -1;
            int keyHolder = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!numbersHolder.ContainsKey(arr[i]))
                {
                    numbersHolder.Add(arr[i], 1);
                }
                else
                {
                    numbersHolder[arr[i]] = numbersHolder[arr[i]] + 1;
                }
            }

            var keys = numbersHolder.Keys;

            foreach (var key in keys)
            {
                int count = numbersHolder[key];

                if (count > maxNumber)
                {
                    maxNumber = count;
                    keyHolder = key;
                }
            }

            var numbersToBeRemoved = arr.Where(number => number != keyHolder);

            return numbersToBeRemoved.Count();
        }

        public static int[] AcmTeam(string[] topic)
        {
            int fullNumberOfTopics = topic[0].Length;
            int maxTopics = 0;
            int teamsWithMaxTopics = 0;
            int[] result = new int[2];

            for (int i = 0; i < topic.Length; i++)
            {
                var currentParticipant = topic[i];

                for (int j = i + 1; j < topic.Length; j++)
                {
                    var otherParticipant = topic[j];
                    int topicsCounter = 0;

                    for (int t = 0; t < fullNumberOfTopics; t++)
                    {
                        if (currentParticipant[t] == '1' || otherParticipant[t] == '1')
                        {
                            topicsCounter++;
                        }
                    }

                    if (topicsCounter > maxTopics)
                    {
                        maxTopics = topicsCounter;
                        teamsWithMaxTopics = 1;
                    }
                    else if (topicsCounter == maxTopics)
                    {
                        teamsWithMaxTopics++;
                    }
                }
            }

            result[0] = maxTopics;
            result[1] = teamsWithMaxTopics;

            return result;
        }

        public static long TaumBday(long b, long w, long bc, long wc, long z)
        {
            long numberOfBlackGiftsToBeBought = b;
            long numberOfWhiteGiftsToBeBought = w;
            long costOfBlackGift = bc;
            long costOfWhiteGift = wc;
            long costOfConvertingColors = z;
            long result = 0;

            costOfBlackGift = Math.Min(bc, wc + z);
            costOfWhiteGift = Math.Min(wc, bc + z);

            result = numberOfBlackGiftsToBeBought * costOfBlackGift + numberOfWhiteGiftsToBeBought * costOfWhiteGift;

            return result;
        }

        public static void KaprekarNumbers(int p, int q)
        {
            string result = "";

            for (int i = p; i <= q; i++)
            {
                string squaredNumber = Math.Pow(i, 2).ToString();
                int numberLength = i.ToString().Length;
                string leftPart = "";
                string rightPart = "";
                int leftPartLength = squaredNumber.Length - numberLength;

                leftPart = squaredNumber.Substring(0, leftPartLength);
                rightPart = squaredNumber.Substring(leftPartLength);

                if (leftPart == "")
                {
                    if (i == int.Parse(rightPart))
                    {
                        result += $"{i} ";
                    }
                }
                else
                {
                    if (i == int.Parse(leftPart) + int.Parse(rightPart))
                    {
                        result += $"{i} ";
                    }
                }
            }

            if (String.IsNullOrEmpty(result))
            {
                Console.WriteLine("INVALID RANGE");
            }
            else
            {

                Console.WriteLine(result);
            }
        }

        public static int BeautifulTriplets(int d, int[] arr)
        {
            int counter = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                int currentNumber = arr[i];

                for (int j = 0; j < i; j++)
                {
                    if (currentNumber - arr[j] == d)
                    {
                        for (int k = i + 1; k < arr.Length; k++)
                        {
                            if (arr[k] - currentNumber == d)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }

        public static int MinimumDistances(int[] a)
        {
            int minimumDistance = Int32.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                int currentElement = a[i];

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] == currentElement)
                    {
                        if (Math.Abs(i - j) < minimumDistance)
                        {
                            minimumDistance = Math.Abs(i - j);
                        }
                    }
                }
            }

            if (minimumDistance == Int32.MaxValue)
            {
                return -1;
            }

            return minimumDistance;
        }

        public static int HowManyGames(int p, int d, int m, int s)
        {
            int startingPrice = p;
            int dollarsDiscount = d;
            int border = m;
            int money = s;
            int counter = 0;

            if (money < startingPrice)
            {
                return counter;
            }

            money -= startingPrice;
            startingPrice -= dollarsDiscount;
            counter++;

            while (startingPrice >= border && money >= startingPrice)
            {
                money -= startingPrice;
                startingPrice -= dollarsDiscount;
                counter++;
            }

            if (startingPrice < border)
            {
                startingPrice = border;
            }

            while (money >= startingPrice)
            {
                money -= border;
                counter++;
            }

            return counter;
        }
    }
}
