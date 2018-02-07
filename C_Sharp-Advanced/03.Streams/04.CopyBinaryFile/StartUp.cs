using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var sourceFile=new FileStream("copyMe.png",FileMode.Open))
            {
                using (var destinationFile=new FileStream("destination.png",FileMode.Create))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = sourceFile.Read(buffer,0, buffer.Length);
                        if (readBytes==0)
                        {
                            break;
                        }
                        destinationFile.Write(buffer,0,readBytes);
                    }
                }
            }
        }
    }
}
