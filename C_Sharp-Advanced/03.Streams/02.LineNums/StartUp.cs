using System;
using System.IO;

namespace _02.LineNums
{
    class StartUp
    {
        static void Main()
        {
            using (var reader=new StreamReader("text.txt"))
            {
                using (var writer=new StreamWriter("result_02.txt"))
                {
                    var index = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line==null)
                        {
                            break;
                        }
                        writer.WriteLine($"Line {index++}: {line}");
                        
                    }
                }
            }
        }
    }
}
