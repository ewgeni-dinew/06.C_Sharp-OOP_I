using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    private string name;
    private int? age;
    private GenderEnum? gender;

    public Animal(string name,int age,GenderEnum gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value; }
    }

    public int? Age
    {
        get { return age; }
        set
        {
            if (value<0||value==null)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value; }
    }

    public GenderEnum? Gender
    {
        get { return gender; }
        set
        {
            if (value==null)
            {
                throw new ArgumentException("Invalid input!");
            } 
            gender = (GenderEnum)value;
        }
    }

    protected abstract string ProduceSound();

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name);
        sb.AppendLine($"{this.Name} {this.Age} {this.Gender.ToString()}");
        sb.Append(this.ProduceSound());

        return sb.ToString();
    }
}

