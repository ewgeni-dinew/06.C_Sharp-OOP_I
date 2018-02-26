using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workingHours;

    public Worker(string firstName, string lastName) : base(firstName, lastName)
    {
    }
    public Worker(string firstName, string lastName,decimal salary,decimal hours):this(firstName,lastName)
    {
        this.WeekSalary = salary;
        this.WorkingHours = hours;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value<10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value; }
    }

    public decimal WorkingHours
    {
        get { return workingHours; }
        set
        {
            if (value<1||value>12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workingHours = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkingHours:f2}");
        sb.AppendLine($"Salary per hour: {(this.WeekSalary/(this.workingHours*5)):f2}");
        return sb.ToString();
    }
}

