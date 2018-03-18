using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id,double oreOutput, double energyReq) 
        : base(id,oreOutput, energyReq)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string Type => "Hammer";
}

