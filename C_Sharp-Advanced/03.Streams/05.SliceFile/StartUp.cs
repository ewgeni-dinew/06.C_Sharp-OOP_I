using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SliceFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            var parts = new List<string>();

            FillList(parts,inputCount);
            
            Slice("sliceMe.mp4", "", inputCount);
            Assemble(parts,"");
        }

        private static void FillList(List<string> parts,int num)
        {
            for (int i = 0; i < num; i++)
            {
                parts.Add($"Part{i}.mp4");
            }
        }

        static void Slice(string sourcePath,string destinationPath,int partsCount)
        {
            using (var reader = new FileStream(sourcePath, FileMode.Open))
            {
                string extension = sourcePath.Substring(sourcePath.LastIndexOf('.')+1);
                var partSize = (long)Math.Ceiling((double)reader.Length / partsCount);
                
                for (int i = 0; i <partsCount; i++)
                {
                    if (destinationPath==string.Empty)
                    {
                        destinationPath = "./";
                    }
                    long currentSize = 0;
                    var currentPath =destinationPath+$"Part{i}.{extension}";

                    using (var writer=new FileStream(currentPath,FileMode.Create))
                    {
                        var buffer = new byte[4096];

                        while (reader.Read(buffer,0,4096)==4096)
                        {
                            writer.Write(buffer,0,4096);
                            currentSize += 4096;
                            if (currentSize>=partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf('.'));

            if (destinationDirectory==string.Empty)
            {
                destinationDirectory = "./";
            }
            if (!destinationDirectory.EndsWith('/'))
            {
                destinationDirectory += "/";
            }

            var assembledFile = $"{destinationDirectory}Assmb.{extension}";

            using (var writer=new FileStream(assembledFile,FileMode.Create))
            {
                var buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var reader=new FileStream(file,FileMode.Open))
                    {
                        while (reader.Read(buffer,0,4096)==4096)
                        {
                            writer.Write(buffer,0,4096);
                        }
                    }
                }
            }
        }
    }
}
