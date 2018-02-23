using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon
{
    public string Name { get;private set; }
    public string Type { get; private set; }

    public Pokemon(string name,string type)
    {
        this.Name = name;
        this.Type = type;
    }
}

