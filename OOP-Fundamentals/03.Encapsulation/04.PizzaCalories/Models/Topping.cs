using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string type;
    private double weight;

    public Topping(string type,double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return  type; }
        set
        {
            if (!value.Equals("meat")&& !value.Equals("veggies")
                && !value.Equals("cheese") && !value.Equals("sauce"))
            {
                var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                throw new ArgumentException($"Cannot place {valueName} on top of your pizza.");
            }
            type = value; }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value<1||value>50)
            {
                var valueName = this.type[0].ToString().ToUpper() + this.type.Substring(1);
                throw new ArgumentException($"{valueName} weight should be in the range [1..50].");
            }
            weight = value; }
    }

    public double GetToppingCalories()
    {
        return 2 * Weight * TypeModifier();
    }

    private double TypeModifier()
    {
        if (Type.Equals("meat"))
            return 1.2;
        else if (Type.Equals("veggies"))
            return 0.8;
        else if (Type.Equals("cheese"))
            return 1.1;
        else
            return 0.9;
    }
}

