using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.TextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lineCount = int.Parse(Console.ReadLine());

            var text = String.Empty;
            var stack = new Stack<string>();

            for (int i = 0; i <lineCount; i++)
            {
                var line = Console.ReadLine()
                    .Split(' ');

                var command = int.Parse(line[0]);

                switch (command)
                {
                    case 1:
                        stack.Push(text);
                        text += line[1];
                        break;
                    case 2:
                        stack.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(line[1]));
                        break;
                    case 3:
                        Console.WriteLine(text.ElementAt(int.Parse(line[1]) - 1));
                        break;
                    case 4:
                        text = stack.Pop();
                        break;
                }
            }
        }
    }
}
