using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester:Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyReq,int sonicFactor)
        :base(id, oreOutput, energyReq)
    {
        this.EnergyRequirement /= sonicFactor;
    }

    public override string Type => "Sonic";
}

