using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double capacity)
        : base(fuelQuantity, fuelConsumption,capacity)
    {
    }

    public override void DriveVehicle(double distance)
    {
        if (this.FuelQuantity-(this.FuelConsumption + 0.9) * distance<0)
        {
            throw new ArgumentException("Car needs refueling");
        }
        else
        {
            this.FuelQuantity -= ((this.FuelConsumption + 0.9) * distance);
            Console.WriteLine($"Car travelled {distance} km");
        }
    }

    public override void RefuelVehicle(double fuelAmount)
    {
        if (fuelAmount <= 0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }
        else if (fuelAmount + this.FuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
        this.FuelQuantity += fuelAmount;
    }
}

