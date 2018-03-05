using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari:ICar
{
    public string Model => "488-Spider";

    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }
    public string Gas()
    {
        return "Zadu6avam sA!";
    }
}

