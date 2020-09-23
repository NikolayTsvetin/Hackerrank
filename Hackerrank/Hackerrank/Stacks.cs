using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public static class Stacks
    {
        public static string IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, int> counter = new Dictionary<char, int>();
            counter.Add('{', 0);
            counter.Add('}', 0);
            counter.Add('[', 0);
            counter.Add(']', 0);
            counter.Add('(', 0);
            counter.Add(')', 0);

            for (int i = 0; i < s.Length; i++)
            {
                char currentElement = s[i];

                counter[currentElement]++;

                if (IsInvalid(currentElement, counter))
                {
                    return "NO";
                }

                if (stack.Count > 0)
                {
                    char last = stack.Peek();

                    if (IsMatchingClosingBracket(currentElement, last))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(currentElement);
                    }
                }
                else
                {
                    stack.Push(currentElement);
                }
            }

            // If stack is empty that means that all pairs of brackets are closed
            if (stack.Count == 0)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        private static bool IsMatchingClosingBracket(char currentElement, char last)
        {
            if (currentElement == '}')
            {
                return last == '{' ? true : false;
            }
            else if (currentElement == ']')
            {
                return last == '[' ? true : false;

            }
            else if (currentElement == ')')
            {
                return last == '(' ? true : false;

            }
            else
            {
                Console.WriteLine("Incorrect input");

                return false;
            }
        }

        private static bool IsInvalid(char currentElement, Dictionary<char, int> counter)
        {
            if (currentElement == '}' && counter[currentElement] > counter['{'])
            {
                return true;
            }
            else if (currentElement == ']' && counter[currentElement] > counter['['])
            {
                return true;
            }
            else if (currentElement == ')' && counter[currentElement] > counter['('])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MaximumElementInStack(int numberOfQueries)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                string[] query = Console.ReadLine().Split(' ');

                if (int.Parse(query[0].ToString()) == 1)
                {
                    int elementToPush = int.Parse(query[1].ToString());

                    if (stack.Count == 0)
                    {
                        stack.Push(elementToPush);
                    }
                    else
                    {
                        stack.Push(Math.Max(elementToPush, stack.Peek()));
                    }
                }
                else if (int.Parse(query[0].ToString()) == 2)
                {
                    stack.Pop();
                }
                else if (int.Parse(query[0].ToString()) == 3)
                {
                    Console.WriteLine(stack.Peek());
                }
                else
                {
                    Console.WriteLine("Not a valid query.");
                }
            }
        }

        // Timeout - need to be optimized.
        public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            Stack<int> stack1 = CreateStackFromList(h1);
            Stack<int> stack2 = CreateStackFromList(h2);
            Stack<int> stack3 = CreateStackFromList(h3);

            while (true)
            {
                if (StacksAreEqualHeight(stack1, stack2, stack3))
                {
                    return stack1.Sum();
                }

                int lowest = Math.Min(Math.Min(stack1.Sum(), stack2.Sum()), stack3.Sum());

                stack1 = ReduceHeight(stack1, lowest);
                stack2 = ReduceHeight(stack2, lowest);
                stack3 = ReduceHeight(stack3, lowest);
            }
        }

        private static Stack<int> CreateStackFromList(List<int> list)
        {
            Stack<int> result = new Stack<int>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                result.Push(list[i]);
            }

            return result;
        }

        private static bool StacksAreEqualHeight(Stack<int> stack1, Stack<int> stack2, Stack<int> stack3)
        {
            return stack1.Sum() == stack2.Sum() && stack1.Sum() == stack3.Sum();
        }

        private static Stack<int> ReduceHeight(Stack<int> stack, int lowest)
        {
            int currentHeight = stack.Sum();

            while (currentHeight > lowest)
            {
                currentHeight -= stack.Pop();
            }

            return stack;
        }
    }
}
