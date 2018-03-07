using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override string DriveCar(double distance)
    {
        var result = string.Empty;

        if (this.FuelQuantity-(this.FuelConsumption + 0.9) * distance<0)
        {
            result = "Car needs refueling";
        }
        else
        {
            this.FuelQuantity -= ((this.FuelConsumption + 0.9) * distance);
            result = $"Car travelled {distance} km";
        }
        return result;
    }

    public override void RefuelCar(double fuelAmount)
    {
        this.FuelQuantity += fuelAmount;
    }
}

