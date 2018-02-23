using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var inputRowCount = int.Parse(Console.ReadLine());
        var listOfCars = new List<Car>();

        for (int i = 0; i < inputRowCount; i++)
        {
            var line = Console.ReadLine()
                .Split();

            var model = line[0];
            var engineSpeed = int.Parse(line[1]);
            var enginePower = int.Parse(line[2]);
            var cargoWeight = int.Parse(line[3]);
            var cargoType = line[4];

            var currentEngine = new Engine(engineSpeed, enginePower);
            var currentCargo = new Cargo(cargoWeight, cargoType);

            var listOfTires = new List<Tire>();
            for (int j = 5; j < 12; j += 2)
            {
                var pressureT = double.Parse(line[j]);
                var ageT = int.Parse(line[j += 1]);
                var currentTire = new Tire(pressureT, ageT);
                listOfTires.Add(currentTire);
                j -= 1;
            }

            var car = new Car(model, currentEngine, currentCargo, listOfTires);
            listOfCars.Add(car);
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in listOfCars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(p => p.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in listOfCars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

