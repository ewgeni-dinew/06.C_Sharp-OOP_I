using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.CryptoBlock
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputSize = int.Parse(Console.ReadLine());
            var paragraph = string.Empty;
            var result = string.Empty;

            //var regex = new Regex(@"[\[\{][\D]*(\d{3,})[\D]*[\]\}]");
            var regex = new Regex(@"[\[\{][\x20-\x2F\x3A-\x7E]*(\d{3,})[\x20-\x2F\x3A-\x7E]*[\]\}]");
            for (int i = 0; i <inputSize; i++)
            {
                var line = Console.ReadLine();
                paragraph += line;
            }

            foreach (Match match in regex.Matches(paragraph))
            {
                if (match.ToString().StartsWith('[') && match.ToString().EndsWith(']'))
                {
                    var length = match.Length;
                    var numbers = match.Groups[1].Value;
                    var firstOfSq = match.ToString().LastIndexOf('[');
                    var lastOfSq = match.ToString().IndexOf(']');
                    var subStr = match.ToString().Substring(firstOfSq, lastOfSq - firstOfSq + 1);
                    var numList = new List<int>();

                    if (numbers.Length % 3 == 0)
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            var currentNum = numbers[i++].ToString();
                            currentNum += numbers[i++].ToString();
                            currentNum += numbers[i].ToString();
                            var parsedNum = int.Parse(currentNum.ToString()) - length;
                            numList.Add(parsedNum);
                        }
                        foreach (var num in numList)
                        {
                            result += (char)num;
                        }
                    }
                }
                else if (match.ToString().StartsWith('{') && match.ToString().EndsWith('}'))
                {
                    var length = match.Length;
                    var numbers = match.Groups[1].Value;
                    var firstOfSq = match.ToString().LastIndexOf('{');
                    var lastOfSq = match.ToString().IndexOf('}');
                    var subStr = match.ToString().Substring(firstOfSq, lastOfSq - firstOfSq + 1);
                    //if (subStr.Contains(numbers))
                    //{
                    //    length = subStr.Length;
                    //}
                    var numList = new List<int>();

                    if (numbers.Length % 3 == 0)
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            var currentNum = numbers[i++].ToString();
                            currentNum += numbers[i++].ToString();
                            currentNum += numbers[i].ToString();
                            var parsedNum = int.Parse(currentNum.ToString()) - length;
                            numList.Add(parsedNum);
                        }
                        foreach (var num in numList)
                        {
                            result += (char)num;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
