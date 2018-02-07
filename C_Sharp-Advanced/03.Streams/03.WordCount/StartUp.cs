using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var wordsCount = new Dictionary<string, int>();

            using (var reader=new StreamReader("words.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    line = line.ToLower();

                    if (!wordsCount.ContainsKey(line))
                    {
                        wordsCount[line] = 0;
                    }
                }
            }
            using (var reader=new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line==null)
                    {
                        break;
                    }
                    
                    foreach (var word in line
                        .Split(" .,?!:;-[]{}()".ToCharArray(),
                            StringSplitOptions.RemoveEmptyEntries)
                        .Select(e=>e.ToLower())
                        .ToArray())
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }
            using (var writer=new StreamWriter("result.txt"))
            {
                foreach (var kvp in wordsCount.OrderByDescending(v=>v.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
