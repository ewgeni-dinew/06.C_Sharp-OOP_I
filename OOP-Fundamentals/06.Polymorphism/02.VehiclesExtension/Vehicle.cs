using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }
    public double TankCapacity { get; set; }

    public Vehicle(double fuelQuantity, double fuelConsumption, double capacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        if (fuelQuantity>capacity)
        {
            this.TankCapacity = 0;
        }
        else
        {
            this.TankCapacity = capacity;
        }
    }

    public abstract void DriveVehicle(double distance);

    public abstract void RefuelVehicle(double fuelAmount);
}

