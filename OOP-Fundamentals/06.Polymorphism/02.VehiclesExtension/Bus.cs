using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double capacity)
        : base(fuelQuantity, fuelConsumption, capacity)
    {
    }

    public override void DriveVehicle(double distance)
    {
        if (this.FuelQuantity - (this.FuelConsumption+1.4) * distance < 0)
        {
            throw new ArgumentException("Bus needs refueling");
        }
        else
        {
            this.FuelQuantity -= ((this.FuelConsumption+1.4) * distance);
            Console.WriteLine($"Bus travelled {distance} km");
        }
    }

    public void DriveEmptyBus(double distance)
    {
        if (this.FuelQuantity - (this.FuelConsumption) * distance < 0)
        {
            throw new ArgumentException("Bus needs refueling");
        }
        else
        {
            this.FuelQuantity -= (this.FuelConsumption * distance);
            Console.WriteLine($"Bus travelled {distance} km");
        }
    }

    public override void RefuelVehicle(double fuelAmount)
    {
        if (fuelAmount<=0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }
        else if (fuelAmount+this.FuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
        this.FuelQuantity += fuelAmount;
    }
}

