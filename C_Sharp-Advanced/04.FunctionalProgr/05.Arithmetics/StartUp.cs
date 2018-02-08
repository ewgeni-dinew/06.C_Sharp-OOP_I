using System;
using System.Linq;

namespace _05.Arithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            Func<int,int> add = (n) => ++n;
            Func<int,int> multiply = (n) => n*2;
            Func<int,int> subtract = (n) => --n;

            string command;
            do
            {
                command = Console.ReadLine()
                    .ToLower();

                switch (command)
                {
                    case "add": input=input.Select(add).ToList();
                        break;
                    case "multiply": input=input.Select(multiply).ToList();
                        break;
                    case "subtract": input=input.Select(subtract).ToList();
                        break;
                    case "print": Console.WriteLine(string.Join(" ",input));
                        break;
                }
            } while (command!="end");
        }
    }
}
