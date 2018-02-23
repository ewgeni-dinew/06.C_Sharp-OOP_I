using System;
using System.Collections.Generic;
using System.Text;

public class Parent
{ 
    public string Name { get; private set; }
    public string Birth { get; private set; }

    public Parent(string name,string birth)
    {
        this.Birth = birth;
        this.Name = name;
    }
}

