using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double capacity)
        : base(fuelQuantity, fuelConsumption, capacity)
    {
    }

    public override void DriveVehicle(double distance)
    {
        if (this.FuelQuantity - (this.FuelConsumption + 1.6) * distance < 0)
        {
            throw new ArgumentException("Truck needs refueling");
        }
        else
        {
            this.FuelQuantity -= ((this.FuelConsumption + 1.6) * distance);
            Console.WriteLine($"Truck travelled {distance} km");
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
        this.FuelQuantity += (0.95 * fuelAmount);
    }
}

