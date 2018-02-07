using System;
using System.IO;

namespace _01.OddLines
{
    class StartUp
    {
        static void Main()
        {
            using (var stream=new StreamReader("text.txt"))
            {
                var index = 0;

                while (true)
                {
                    var line = stream.ReadLine();

                    if (line==null)
                    {
                        break;
                    }
                    if (index%2==1)
                    {
                        Console.WriteLine(line);
                    }
                    index++;
                }
            }
        }
    }
}
