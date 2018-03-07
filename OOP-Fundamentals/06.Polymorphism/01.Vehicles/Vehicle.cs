using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public abstract string DriveCar(double distance);

    public abstract void RefuelCar(double fuelAmount);
}

