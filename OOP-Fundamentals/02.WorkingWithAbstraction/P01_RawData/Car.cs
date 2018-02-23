using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
    public Dictionary<decimal,int> Tyres { get; set; }

    public Car(string model,int speed,int power,int weight,string type)
    {
        this.Model = model;
        this.EngineSpeed = speed;
        this.EnginePower = power;
        this.CargoWeight = weight;
        this.CargoType = type;
        this.Tyres = new Dictionary<decimal, int>();
    }
}

