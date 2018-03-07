using System;
using System.Collections.Generic;
using System.Text;

public interface IVehicle
{
    double FuelQuantity { get; set; }
    double FuelConsumption { get; set; }

    string DriveCar(double distance);
    void RefuelCar(double fuelAmount);
}

