using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static int ChocolateFeast(int n, int c, int m)
        {
            int startingMoney = n;
            int price = c;
            int numberOfWrappersToTurnForNewBar = m;
            int counter = 0;
            int availableWrappers = 0;

            int firstBought = startingMoney / price;
            counter = firstBought;
            availableWrappers = counter;
            startingMoney %= price;

            while (availableWrappers >= numberOfWrappersToTurnForNewBar)
            {
                int bought = availableWrappers / numberOfWrappersToTurnForNewBar;
                availableWrappers %= numberOfWrappersToTurnForNewBar;
                counter += bought;
                availableWrappers += bought;
            }

            return counter;
        }

        public static int[] ServiceLane(int n, int[][] cases, int[] width)
        {
            int[] result = new int[cases.Length];

            for (int i = 0; i < cases.Length; i++)
            {
                int[] currentCase = cases[i];
                int start = currentCase[0];
                int end = currentCase[1];

                int min = width[start];
                for (int j = start + 1; j <= end; j++)
                {
                    if (width[j] < min)
                    {
                        min = width[j];
                    }
                }

                result[i] = min;
            }

            return result;
        }

        public static int Workbook(int n, int k, int[] arr)
        {
            int chapters = n;
            int maximumProblemsOnPage = k;
            int counter = 0;
            int currentPage = 1;

            for (int i = 1; i <= chapters; i++)
            {
                int numberOfProblemsOnCurrentChapter = arr[i - 1];

                for (int j = 1; j <= numberOfProblemsOnCurrentChapter; j++)
                {
                    int problemNumber = j;

                    if (j == currentPage)
                    {
                        counter++;
                    }
                    if (problemNumber % maximumProblemsOnPage == 0 || problemNumber == numberOfProblemsOnCurrentChapter)
                    {
                        currentPage++;
                    }
                }
            }

            return counter;
        }

        // Solution from comments.
        public static int FlatlandSpaceStations_V2(int n, int[] c)
        {
            int numberOfCities = n;
            int[] arrayWithCitiesWithStations = c;

            Array.Sort(arrayWithCitiesWithStations);
            int maxLength = arrayWithCitiesWithStations[0];

            for (int i = 1; i < arrayWithCitiesWithStations.Length; i++)
            {
                int distance = (arrayWithCitiesWithStations[i] - arrayWithCitiesWithStations[i - 1]) / 2;

                if (distance > maxLength)
                {
                    maxLength = distance;
                }
            }

            int lastSpaceStation = numberOfCities - 1 - arrayWithCitiesWithStations[arrayWithCitiesWithStations.Length - 1];

            if (lastSpaceStation > maxLength)
            {
                maxLength = lastSpaceStation;
            }

            return maxLength;
        }

        // Fails one test due to timeout.
        public static int FlatlandSpaceStations(int n, int[] c)
        {
            int numberOfCities = n;
            int[] arrayWithCitiesWithStations = c;
            int maxLength = -1;

            for (int i = 0; i < numberOfCities; i++)
            {
                int currentCity = i;
                int nearestStation = _FindNearestSpaceStation(arrayWithCitiesWithStations, currentCity);

                if (Math.Abs(currentCity - nearestStation) > maxLength)
                {
                    maxLength = Math.Abs(currentCity - nearestStation);
                }
            }

            return maxLength;
        }

        private static int _FindNearestSpaceStation(int[] arrayWithCitiesWithStations, int currentCity)
        {
            int nearest = Int32.MaxValue;

            for (int i = 0; i < arrayWithCitiesWithStations.Length; i++)
            {
                if (Math.Abs(arrayWithCitiesWithStations[i] - currentCity) < Math.Abs(currentCity - nearest))
                {
                    nearest = arrayWithCitiesWithStations[i];
                }
            }

            return nearest;
        }

        // In order solution to be valid in hackerrank - the cases where you should just print "NO" - return -1 and change the checkings in hackerrank if the result is -1 to be interpretated as "NO". Discussed by other people in the comments.
        public static int FairRations(int[] B)
        {
            int sum = 0;
            int counter = 0;

            for (int i = 0; i < B.Length; i++)
            {
                sum += B[i];
            }

            if (sum % 2 != 0)
            {
                Console.WriteLine("NO");

                return -1;
            }

            for (int i = 0; i < B.Length - 1; i++)
            {
                if (i == B.Length - 1)
                {
                    if (B[B.Length - 1] % 2 == 0)
                    {
                        Console.WriteLine(counter);

                        return counter;
                    }
                    else
                    {
                        Console.WriteLine("NO");

                        return -1;
                    }
                }
                else
                {
                    if (B[i] % 2 != 0)
                    {
                        B[i] = B[i] + 1;
                        B[i + 1] = B[i + 1] + 1;

                        counter += 2;
                    }
                }
            }

            return counter;
        }

        // Should be matrix. Dont know why it is not.
        public static string[] CavityMap(string[] grid)
        {
            string[] modified = grid;

            for (int i = 1; i < modified.Length - 1; i++)
            {
                string currentCell = modified[i];
                string rowAbove = modified[i - 1];
                string rowBelow = modified[i + 1];

                for (int j = 1; j < currentCell.Length - 1; j++)
                {
                    if (currentCell[j - 1] == 'X' || currentCell[j + 1] == 'X' || rowAbove[j] == 'X' || rowBelow[j] == 'X')
                    {
                        continue;
                    }

                    if (Int32.Parse(currentCell[j].ToString()) > Int32.Parse(currentCell[j - 1].ToString())
                        && Int32.Parse(currentCell[j].ToString()) > Int32.Parse(currentCell[j + 1].ToString())
                        && Int32.Parse(currentCell[j].ToString()) > Int32.Parse(rowAbove[j].ToString())
                        && Int32.Parse(currentCell[j].ToString()) > Int32.Parse(rowBelow[j].ToString()))
                    {
                        StringBuilder sb = new StringBuilder(currentCell);
                        sb[j] = 'X';
                        currentCell = sb.ToString();
                    }
                }

                modified[i] = currentCell;
            }

            return modified;
        }

        public static int[] Stones(int n, int a, int b)
        {
            // CREDITS:
            // Developed by Venislav Venkov. Check him on Linkedin.
            int numberOfStones = n;
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            int[] result = new int[numberOfStones];
            int diff = max - min;
            result[0] = (n - 1) * min;

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = result[0] + diff * i;
            }

            return result.Distinct().ToArray();
        }

        public static long StrangeCounter(long t)
        {
            // CREDITS:
            // Code optimization by Venislav Venkov. Check him on Linkedin.
            long initialNumber = 3;
            long counter = initialNumber;
            long i = 0;

            while (initialNumber * (Math.Pow(2, i + 1) - 1) < t)
            {
                i++;
            }

            // left and right side are the left and right side from the equation in our white list used to come with this solution.
            long leftSide = initialNumber * (long)(Math.Pow(2, i) - 1) + 1;
            long rightSide = initialNumber * (long)Math.Pow(2, i);

            return (leftSide + rightSide - t);
        }

        // dumb task. delete it pls
        public static string HappyLadybugs(string b)
        {
            if (b.Length == 1 && b[0] != '_')
            {
                return "NO";
            }
            if (b.IndexOf('_') >= 0)
            {
                Dictionary<char, int> letters = new Dictionary<char, int>();

                for (int i = 0; i < b.Length; i++)
                {
                    if (!letters.ContainsKey(b[i]))
                    {
                        letters[b[i]] = 1;
                    }
                    else
                    {
                        letters[b[i]] = letters[b[i]] + 1;
                    }
                }

                var keys = letters.Keys;

                foreach (var key in keys)
                {
                    if (letters[key] == 1 && key != '_')
                    {
                        return "NO";
                    }
                }

                return "YES";
            }
            else
            {
                for (int i = 1; i < b.Length; i++)
                {
                    if (i == b.Length - 1)
                    {
                        if (b[i - 1] == b[i])
                        {
                            // happy
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                    else
                    {
                        if (b[i - 1] == b[i] || b[i] == b[i + 1])
                        {
                            // happy
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                }
                return "YES";
            }
        }

        public static int[] ClimbingLeaderboard(int[] scores, int[] alice)
        {
            int[] result = new int[alice.Length];
            List<int> distinctScores = scores.Distinct().ToList();
            int lastVisitedIndex = distinctScores.Count - 1;

            for (int i = 0; i < alice.Length; i++)
            {
                int currentScore = alice[i];

                if (currentScore >= distinctScores[0])
                {
                    result[i] = 1;
                    continue;
                }

                if (currentScore <= distinctScores[distinctScores.Count - 1])
                {
                    // edge case for equal numbers
                    if (currentScore == distinctScores[distinctScores.Count - 1])
                    {
                        result[i] = distinctScores.Count;
                        continue;
                    }

                    result[i] = distinctScores.Count + 1;
                    continue;
                }

                for (int j = lastVisitedIndex; j > 0; j--)
                {
                    if (currentScore >= distinctScores[j] && currentScore <= distinctScores[j - 1])
                    {
                        // edge case for equal numbers
                        if (currentScore == distinctScores[j - 1])
                        {
                            result[i] = j;
                            lastVisitedIndex = j;
                            break;
                        }

                        result[i] = j + 1;
                        lastVisitedIndex = j;
                        break;
                    }
                }
            }

            return result;
        }

        private static List<int> AllIndexesOf(string str, string value)
        {
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        // Two solutions, both 3/16 test cases failed. Not great, not terrible.
        public static string GridSearch(string[] G, string[] P)
        {
            int index = 0;
            int indexOfPattern = -1;
            bool firstMatch = false;
            List<int> previousIndexes = new List<int>();

            for (int i = 0; i < G.Length; i++)
            {
                bool invalid = true;
                if (index >= P.Length)
                {
                    break;
                }

                string row = G[i];
                var pattern = P[index];
                List<int> matches = AllIndexesOf(row, pattern);

                if (matches.Count > 0)
                {
                    if (!firstMatch)
                    {
                        firstMatch = true;

                        foreach (var match in matches)
                        {
                            indexOfPattern = match;
                            previousIndexes = matches;
                        }
                    }

                    foreach (var m in matches)
                    {
                        if (indexOfPattern == m)
                        {
                            invalid = false;
                        }
                    }

                    if (invalid)
                    {
                        index = 0;
                        continue;
                    }

                    index++;
                }
                else
                {
                    if (index > 0 && G[i].IndexOf(P[index - 1]) >= 0)
                    {
                        previousIndexes = AllIndexesOf(G[i], P[index - 1]);
                        indexOfPattern = previousIndexes[previousIndexes.Count - 1];//G[i].IndexOf(P[index - 1]);
                        index = 1;
                        continue;
                    }

                    index = 0;
                }
            }

            if (index == P.Length)
            {
                return "YES";
            }

            return "NO";
        }

        // Optimize it. Working, but tests are failing due to timeout.
        public static int NonDivisibleSubset(int k, List<int> s)
        {
            //s = s.Distinct().ToList();
            int index = 0;
            int max = -1;

            while (index < s.Count)
            {
                int count = GenerateValidNumbersForNum(index, s, k);

                if (count > max)
                {
                    max = count;
                }

                index++;
            }

            return max;
        }

        private static int GenerateValidNumbersForNum(int index, List<int> s, int k)
        {
            List<int> validNumbers = new List<int>() { s[index] };

            for (int i = 0; i < s.Count; i++)
            {
                if (i == index) continue;

                if (ShouldAddNumber(validNumbers, k, s[i]))
                {
                    validNumbers.Add(s[i]);
                }
            }

            return validNumbers.Distinct().Count();
        }

        private static bool ShouldAddNumber(List<int> validNumbers, int k, int currentNumber)
        {
            foreach (var num in validNumbers)
            {
                if ((num + currentNumber) % k == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
