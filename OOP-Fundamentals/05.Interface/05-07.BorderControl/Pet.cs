using System;
using System.Collections.Generic;
using System.Text;

public class Pet:IBirthdate
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }

    public Pet(DateTime birth,string name)
    {
        this.Birthdate = birth;
        this.Name = name;
    }
}

