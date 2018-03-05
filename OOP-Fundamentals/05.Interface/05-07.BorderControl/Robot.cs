using System;
using System.Collections.Generic;
using System.Text;

public class Robot: Humanoid
{
    public string Model { get;private set; }

    public Robot(string model,string id):base(id)
    {
        this.Model = model;
    }
}

