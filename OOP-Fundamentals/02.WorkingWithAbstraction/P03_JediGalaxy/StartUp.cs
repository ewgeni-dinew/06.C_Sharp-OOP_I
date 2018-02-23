using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        var dimestions = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var rows = dimestions[0];
        var columns = dimestions[1];

        var matrix = new int[rows, columns];

        matrix=InitializeMatrix(rows, columns);

        string line = Console.ReadLine();
        long sum = 0;

        while (line != "Let the Force be with you")
        {
            var sumStartCoordinates= line
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var removeStartCoordinates = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            RemoveMatrixElements(matrix,removeStartCoordinates);

            var currentSum=FindSumOfMatrixElements(matrix, sumStartCoordinates);

            sum += currentSum;

            line = Console.ReadLine();
        }
        Console.WriteLine(sum);
    }

    private static long FindSumOfMatrixElements(int[,] matrix, int[] sumStartCoordinates)
    {
        long sum = 0;
        var sumStartX = sumStartCoordinates[0];
        var sumStartY = sumStartCoordinates[1];

        while (sumStartX >= 0 && sumStartY < matrix.GetLength(1))
        {
            if (sumStartX < matrix.GetLength(0) && sumStartY >= 0)
                sum += matrix[sumStartX, sumStartY];
            
            sumStartY++;
            sumStartX--;
        }
        return sum;
    }

    private static void RemoveMatrixElements(int[,] matrix, int[] removeStartCoordinates)
    {
        var removeStartX = removeStartCoordinates[0];
        var removeStartY = removeStartCoordinates[1];

        while (removeStartX >= 0 && removeStartY >= 0)
        {
            if (removeStartX < matrix.GetLength(0) && removeStartY < matrix.GetLength(1))
                matrix[removeStartX, removeStartY] = 0;
            
            removeStartX--;
            removeStartY--;
        }
    }

    private static int[,] InitializeMatrix(int rows, int columns)
    {
        int value = 0;
        var matrix = new int [rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = value++;
            }
        }

        return matrix;
    }
}

