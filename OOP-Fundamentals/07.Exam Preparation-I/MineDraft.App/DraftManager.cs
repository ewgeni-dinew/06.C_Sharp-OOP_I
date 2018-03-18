using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    //private List<Provider> waitingProviderList;
    private List<Provider> providers;
    private string mode;
    private double dailyOreProduction;
    private double totalOreProduction;
    private double dailyEnergyProduction;
    private double totalEnergyProduction;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        //this.waitingProviderList = new List<Provider>();
        this.mode = "Full";
        this.dailyOreProduction = 0;
        this.totalOreProduction = 0;
        this.dailyEnergyProduction = 0;
        this.totalEnergyProduction = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            var energyRequirement = double.Parse(arguments[3]);
            Harvester harvester = null;

            if (type.Equals("Hammer"))
            {
                harvester = new HammerHarvester(id, oreOutput, energyRequirement);
            }
            else if (type.Equals("Sonic"))
            {
                var sonicFactor = int.Parse(arguments[4]);
                harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor); 
            }
            harvesters.Add(harvester);

            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];
            var energyOutput = double.Parse(arguments[2]);
            Provider provider = null;

            if (type.Equals("Solar"))
            {
                provider = new SolarProvider(id, energyOutput);
            }
            else if (type.Equals("Pressure"))
            {
                provider = new PressureProvider(id, energyOutput);
            }
            this.providers.Add(provider);

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double harvesterEnrgCoef;
        double harvesterOrePrdCoef;

        switch (this.mode)
        {
            case "Half":
                harvesterEnrgCoef = 0.6;
                harvesterOrePrdCoef = 0.5;
                break;
            case "Energy":
                harvesterEnrgCoef = 0.0;
                harvesterOrePrdCoef = 0.0;
                break;
            default:
                harvesterEnrgCoef = 1;
                harvesterOrePrdCoef = 1;
                break;
        }

        var energyRequired = harvesters.Sum(h => h.EnergyRequirement*harvesterEnrgCoef);

        foreach (var provider in providers)
        {
            this.dailyEnergyProduction += provider.EnergyOutput;
        }

        this.totalEnergyProduction += this.dailyEnergyProduction;

        if (this.totalEnergyProduction>=energyRequired)
        {
            foreach (var harveser in harvesters)
            {
                this.dailyOreProduction += harveser.OreOutput * harvesterOrePrdCoef;
            }

            this.totalOreProduction += this.dailyOreProduction;
            this.totalEnergyProduction -= energyRequired;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {this.dailyEnergyProduction}");
        sb.Append($"Plumbus Ore Mined: {this.dailyOreProduction}");

        this.dailyOreProduction = 0;
        this.dailyEnergyProduction = 0;

        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }

    public string Check(List<string> arguments)
    {
        var harvester = harvesters.FirstOrDefault(h=>h.Id.Equals(arguments[0]));
        var provider = providers.FirstOrDefault(p=>p.Id.Equals(arguments[0]));

        var sb = new StringBuilder();

        if (harvester==null&&provider!=null)
        {
            sb.AppendLine($"{provider.Type} Provider - {provider.Id}");
            sb.Append($"Energy Output: {provider.EnergyOutput}");
        }
        else if (provider==null&&harvester!=null)
        {
            sb.AppendLine($"{harvester.Type} Harvester - {harvester.Id}");
            sb.AppendLine($"Ore Output: {harvester.OreOutput}");
            sb.Append($"Energy Requirement: {harvester.EnergyRequirement}");
        }
        else
        {
            return $"No element found with id - {arguments[0]}";
        }

        return sb.ToString();
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyProduction}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalOreProduction}");

        return sb.ToString();
    }
}