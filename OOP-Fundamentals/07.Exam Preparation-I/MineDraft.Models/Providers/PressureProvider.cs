﻿using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput *= 1.5f;
    }

    public override string Type => "Pressure";
}

