using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType,string bakingTechnique,double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (!value.Equals("white")&&!value.Equals("wholegrain"))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (!value.Equals("crispy") && !value.Equals("chewy") && !value.Equals("homemade"))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value; }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value<1||200<value)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public double GetDoughCalories()
    {
        return 2 * this.Weight * FlourTypeModifier()*BakingTechniqueModifier();
    }

    private double BakingTechniqueModifier()
    {
        if (this.BakingTechnique.Equals("crispy"))
            return 0.9;
        else if (this.BakingTechnique.Equals("chewy"))
            return 1.1;
        else
            return 1.0;
    }

    private double FlourTypeModifier()
    {
        if (this.FlourType.Equals("white"))
            return 1.5;
        else
            return 1.0;
    }
}

