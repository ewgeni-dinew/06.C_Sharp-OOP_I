using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider:Unit
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        :base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }
}