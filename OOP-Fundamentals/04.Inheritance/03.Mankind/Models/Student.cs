using System;
using System.Collections.Generic;
using System.Text;

public class Student : Human
{
    private string facultyNumber;
   
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
    public Student(string firstName, string lastName,string facNum):this(firstName,lastName)
    {
        this.FacultyNumber = facNum;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length<5||value.Length>10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");
        return sb.ToString();
    }
}

