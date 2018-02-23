using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarSalesman
{
    static void Main(string[] args)
    {
        var engineCount = int.Parse(Console.ReadLine());

        var engineList=ReadEngines(engineCount);
        
        int carCount = int.Parse(Console.ReadLine());

        var carList = ReadCars(carCount,engineList);

        foreach (var car in carList)
        {
            Console.WriteLine(car);
        }
    }
    
    private static List<Engine> ReadEngines(int engineCount)
    {
        var engineList = new List<Engine>();

        for (int i = 0; i < engineCount; i++)
        {
            var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = parameters[0];
            var power = int.Parse(parameters[1]);

            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                engineList.Add(new Engine(model, power, displacement));
            }
            else if (parameters.Length == 3)
            {
                var efficiency = parameters[2];
                engineList.Add(new Engine(model, power, efficiency));
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                engineList.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
            }
            else
                engineList.Add(new Engine(model, power));
        }
        return engineList;
    }

    private static List<Car> ReadCars(int carCount, List<Engine> engineList)
    {
        var carList = new List<Car>();

        for (int i = 0; i < carCount; i++)
        {
            var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = parameters[0];
            var engineModel = parameters[1];
            var engine = engineList.FirstOrDefault(x => x.model == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                carList.Add(new Car(model, engine, weight));
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                carList.Add(new Car(model, engine, color));
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                carList.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
                carList.Add(new Car(model, engine));
        }
        return carList;
    }
}


