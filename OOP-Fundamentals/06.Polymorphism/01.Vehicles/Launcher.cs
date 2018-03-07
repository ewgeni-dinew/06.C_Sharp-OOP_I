using System;

public class Launcher
{
    static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        var truckInfo = Console.ReadLine().Split();

        var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        var commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i <commandCount; i++)
        {
            var args = Console.ReadLine().Split();

            switch (args[0])
            {
                case "Drive": DriveVehicle(args[1],double.Parse(args[2]),car,truck);
                    break;
                case "Refuel":RefuelVehicle(args[1], double.Parse(args[2]), car, truck);
                    break;
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }

    private static void RefuelVehicle(string type, double litres, Car car, Truck truck)
    {
        if (type.Equals("Car"))
            car.RefuelCar(litres);

        else if (type.Equals("Truck"))
            truck.RefuelCar(litres);
    }

    private static void DriveVehicle(string type, double distance, Car car, Truck truck)
    {
        string result = string.Empty;

        if (type.Equals("Car"))
            result = car.DriveCar(distance);
        else if (type.Equals("Truck"))
            result = truck.DriveCar(distance);

        Console.WriteLine(result);
    }
}

