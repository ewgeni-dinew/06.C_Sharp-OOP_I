using System;
using System.Collections.Generic;
using System.Text;

public class Company
{
    public string Name { get; private set; }
    public string Department { get; private set; }
    public decimal Salary { get; private set; }

    public Company(string compName,string dep,decimal salary)
    {
        this.Name = compName;
        this.Department = dep;
        this.Salary = salary;
    }
}

