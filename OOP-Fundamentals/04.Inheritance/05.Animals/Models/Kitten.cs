using System;
using System.Collections.Generic;
using System.Text;

public class Kitten : Cat
{
    public Kitten(string name, int age, GenderEnum gender) : base(name, age, gender)
    {
        this.Gender = GenderEnum.Female;
    }
    protected override string ProduceSound()
    {
        return "Meow";
    }
}

