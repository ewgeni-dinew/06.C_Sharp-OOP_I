using System;
using System.Linq;

namespace App
{
    class StartUp
    {
        static void Main()
        {
            var stack = new Stack<string>();
            bool isEmpty = false;

            while (true)
            {
                var args = Console.ReadLine().Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries);

                var command = args[0];

                try
                {
                    if (command.Equals("END"))
                    {
                        break;
                    }
                    else if (command.Equals("Push"))
                    {
                        stack.Push(args.Skip(1).ToList());
                    }
                    else if (command.Equals("Pop"))
                    {
                        stack.Pop();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    isEmpty = true;
                    break;
                }
                
            }

            if (!isEmpty)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            } 
        }
    }
}
