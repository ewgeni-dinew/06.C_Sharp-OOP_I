using System;
using System.Collections.Generic;
using System.Text;

public class Person : Humanoid,IBirthdate,IBuyer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public int Food { get; set; }

    public Person(string name,string id,int age):base(id)
    {
        this.Name = name;
        this.Age = Age;
        this.Food = 0;
    }

    public Person(string name, string id, int age,DateTime birth) : this(name,id,age)
    {
        this.Birthdate = birth;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

