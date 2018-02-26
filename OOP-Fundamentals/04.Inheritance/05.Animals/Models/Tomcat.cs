using System;
using System.Collections.Generic;
using System.Text;

public class Tomcat : Cat
{
    public Tomcat(string name, int age, GenderEnum gender) : base(name, age, gender)
    {
        this.Gender = GenderEnum.Male;
    }

    protected override string ProduceSound()
    {
        return "MEOW";
    }
}

