using System;
using System.Collections.Generic;
using System.Text;

public class Frog : Animal
{
    public Frog(string name, int age, GenderEnum gender) : base(name, age, gender)
    {
    }

    protected override string ProduceSound()
    {
        return "Ribbit";
    }
}

