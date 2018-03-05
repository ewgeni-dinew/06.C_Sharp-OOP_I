using System;
using System.Collections.Generic;
using System.Text;

public class Citizen:IPerson,IBirthable,IIdentifiable
{
    public string Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Birthdate { get; set; }

    public Citizen(string name,int age,string id,string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    //Task-01.
    //public override string ToString()
    //{
    //    var sb = new StringBuilder();
    //    sb.AppendLine(this.Name);
    //    sb.AppendLine(this.Age.ToString());
    //    return sb.ToString();
    //}

    //Task-02.
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.Id);
        sb.AppendLine(this.Birthdate);
        return sb.ToString();
    }
}

