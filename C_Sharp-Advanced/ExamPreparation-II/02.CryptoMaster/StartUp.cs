using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split(new char[] { ' ',','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var maxSequence = 0;

            for (int i = 0; i <inputNums.Count; i++)
            {
                for (int j = 1; j < inputNums.Count; j++)
                {
                    
                    var currentSeq = 0;
                    var startNum = inputNums[i];
                    var temp = i;
                    while (true)
                    {
                        temp +=j;

                        if (temp > inputNums.Count - 1)
                            temp -=inputNums.Count;
                        
                        var nextNum = inputNums[temp];

                        if (startNum < nextNum)
                            currentSeq++;
                        else
                            break;

                        startNum = nextNum;
                    }
                    if (currentSeq > maxSequence)
                        maxSequence = currentSeq;
                }
            }
            Console.WriteLine(maxSequence+1);
        }
    }
}
