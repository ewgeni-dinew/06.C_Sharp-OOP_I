using System;

public class Launcher
{
    static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        var truckInfo = Console.ReadLine().Split();
        var busInfo = Console.ReadLine().Split();

        var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        var commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandCount; i++)
        {
            var args = Console.ReadLine().Split();

            try
            {
                switch (args[0])
                {
                    case "Drive":
                        DriveVehicle(args[1], double.Parse(args[2]), car, truck,bus);
                        break;
                    case "Refuel":
                        RefuelVehicle(args[1], double.Parse(args[2]), car, truck,bus);
                        break;
                    case "DriveEmpty":
                        bus.DriveEmptyBus(double.Parse(args[2]));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }

    private static void RefuelVehicle(string type, double litres, Car car, Truck truck,Bus bus)
    {
        if (type.Equals("Car"))
        {
            car.RefuelVehicle(litres);
        }
        else if (type.Equals("Truck"))
        {
            truck.RefuelVehicle(litres);
        }
        else if (type.Equals("Bus"))
        {
            bus.RefuelVehicle(litres);
        }
    }

    private static void DriveVehicle(string type, double distance, Car car, Truck truck,Bus bus)
    {
        if (type.Equals("Car"))
        {
            car.DriveVehicle(distance);
        }
        else if (type.Equals("Truck"))
        {
            truck.DriveVehicle(distance);
        }
        else if (type.Equals("Bus"))
        {
            bus.DriveVehicle(distance);
        }
    }
}

