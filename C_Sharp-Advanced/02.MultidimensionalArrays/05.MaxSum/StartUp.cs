using System;
using System.Linq;

namespace _05.MaxSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = input[0];
            var columns = input[1];
            var matrix = new int[rows][];

            var result = new int[3][];
            var maxSum = 0;

            for (int i = 0; i < rows; i++)
            {
                matrix[i]= Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            for (int i = 0; i < rows-2; i++)
            {
                var currentMatrix = new int[3][];
                
                for (int j = 0; j < columns-2; j++)
                {
                    var currentSum = 0;
                   
                    for (int m = 0; m < 3; m++)
                    {
                        currentMatrix[m]= matrix[i].Skip(j).Take(3).ToArray();
                        i++;
                    }
                    i -= 3;
                    for (int m = 0; m < 3; m++)
                    {
                        currentSum += currentMatrix[m].Sum();
                    }

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        for (int l = 0; l < 3; l++)
                        {
                            result[l] = currentMatrix[l];
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(" ",result[i]));
            }
        }
    }
}
