using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption)
        :base(fuelQuantity, fuelConsumption)
    {
    }

    public override string DriveCar(double distance)
    {
        var result = string.Empty;

        if (this.FuelQuantity - (this.FuelConsumption + 1.6) * distance < 0)
        {
            result = "Truck needs refueling";
        }
        else
        {
            this.FuelQuantity -= ((this.FuelConsumption + 1.6) * distance);
            result = $"Truck travelled {distance} km";
        }
        return result;
    }

    public override void RefuelCar(double fuelAmount)
    {
        this.FuelQuantity += (0.95 * fuelAmount);
    }
}

