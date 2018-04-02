using System;
using System.Linq;

namespace App
{
    class StartUp
    {
        static void Main()
        {
            ListyIterator<string> iterator = null;

            while (true)
            {
                var args = Console.ReadLine().Split();
                var command = args[0];

                if (command.Equals("END"))
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "Create":
                            iterator = new ListyIterator<string>(args.Skip(1).ToList());
                            break;
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                        case "Print":
                            iterator.Print();
                            break;
                        case "PrintAll":
                            iterator.PrintAll();
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
