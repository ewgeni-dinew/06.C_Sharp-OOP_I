using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var engineList = new List<Engine>();
        var carList=new List<Car>();

        var engineCount = int.Parse(Console.ReadLine());

        for (int i = 0; i <engineCount; i++)
        {
            var line = Console.ReadLine()
                .Split();

            var model = line[0];
            var power = line[1];

            Engine currentEngine;

            if (line.Length==2)
            {
                currentEngine = new Engine(model, power);
            }
            else if (line.Length==3)
            {
                int displacement;

                if (int.TryParse(line[2],out displacement)==true)
                    currentEngine = new Engine(model, power,displacement);
                else
                    currentEngine = new Engine(model, power, line[2]);
            }
            else
            {
                currentEngine = new Engine(model,power,int.Parse(line[2]),line[3]);
            }
            engineList.Add(currentEngine);
        }

        var carCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carCount; i++)
        {
            var line = Console.ReadLine()
                   .Split();

            var model = line[0];
            var engineName = line[1];
            var engine = engineList.Where(e => e.Model == engineName).FirstOrDefault();

            Car currentCar;
            if (line.Length == 2)
            {
                currentCar = new Car(model, engine);
            }
            else if (line.Length == 3)
            {
                int weight;

                if (int.TryParse(line[2], out weight) == true)
                    currentCar = new Car(model, engine,weight);
                else
                    currentCar = new Car(model, engine,line[2]);
            }
            else
            {
                currentCar = new Car(model, engine,int.Parse(line[2]) ,line[3]);
            }
            carList.Add(currentCar);
        }

        foreach (var car in carList)
        {
            Console.WriteLine(car.Model+":");
            Console.WriteLine($"  {car.Engine.Model}:");
            foreach (var engine in engineList.Where(e=>e.Model.Equals(car.Engine.Model)))
            {
                Console.WriteLine($"    Power: {engine.Power}");
                Console.WriteLine("    Displacement: {0}", engine.Displacement == 0 ? "n/a" : engine.Displacement.ToString());
                Console.WriteLine($"    Efficiency: {engine.Efficiency}");
            }
            Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
            Console.WriteLine($"  Color: {car.Color}");

        }
    }
}

