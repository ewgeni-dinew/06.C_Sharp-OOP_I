using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();
            var regex = new Regex(@"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]");

            var indexList = new List<int>();
            //var matchList = FindMatchInInput(stack, input);
            //var indexList = FindIndexesInList(matchList, regex);

            foreach (Match match in regex.Matches(input))
            {
                indexList.Add(int.Parse(match.Groups[1].Value));
                indexList.Add(int.Parse(match.Groups[2].Value));
            }

            var result = string.Empty;
            var currentIndex = 0;

            foreach (var i in indexList)
            {
                currentIndex += i;
                var charIndex = currentIndex % (input.Length - 1);
                result+=input[charIndex];
            }
            Console.WriteLine(result);
        }

        private static List<int> FindIndexesInList(List<string> matchList, Regex regex)
        {
            var list = new List<int>();

            foreach (var str in matchList)
            {
                if (regex.IsMatch(str))
                {
                    var firstIndex = int.Parse(regex.Match(str).Groups[1].Value);
                    var secondIndex = int.Parse(regex.Match(str).Groups[2].Value);

                    list.Add(firstIndex);
                    list.Add(secondIndex);
                }
            }

            return list;
        }

        private static List<string> FindMatchInInput(Stack<int> stack, string input)
        {
            var list = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    stack.Push(i);
                }
                if (input[i] == ']')
                {
                    var endIndex = i;
                    int startIndex;
                    var elementExist = stack.TryPop(out startIndex);

                    if (elementExist)
                        list.Add(input.Substring(startIndex, endIndex - startIndex + 1));
                }
            }

            return list;
        }
    }
}
