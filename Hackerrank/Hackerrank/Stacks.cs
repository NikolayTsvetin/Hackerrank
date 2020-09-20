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
    }
}
