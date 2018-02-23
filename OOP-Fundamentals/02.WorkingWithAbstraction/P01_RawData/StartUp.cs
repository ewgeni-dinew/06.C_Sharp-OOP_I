using System;
using System.Collections.Generic;
using System.Linq;

public class RawData
{
    static void Main(string[] args)
    {
        var carList = new List<Car>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var currentCar = new Car(line[0],int.Parse(line[1]),int.Parse(line[2]),
                                    int.Parse(line[3]),line[4]);

             for (int j = 5; j < line.Length; j++)
                currentCar.Tyres.Add(decimal.Parse(line[j++]),int.Parse(line[j]));

            carList.Add(currentCar);
        }

        string command = Console.ReadLine();

        if (command.Equals("fragile"))
        {
            var result=PrintFragileCars(carList);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
        else
        {
            var result=PrintFlamableCars(carList);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }

    private static List<string> PrintFlamableCars(List<Car> carList)
    {
        var result = carList
                .Where(x => x.CargoType.Equals("flamable") && x.EnginePower > 250)
                .Select(x => x.Model)
                .ToList();

        return result;
    }

    private static List<string> PrintFragileCars(List<Car> carList)
    {
        var result = carList
            .Where(c => c.CargoType.Equals("fragile") && c.Tyres.Any(t => t.Key < 1))
            .Select(c=>c.Model)
            .ToList();

        return result;
    }
}

