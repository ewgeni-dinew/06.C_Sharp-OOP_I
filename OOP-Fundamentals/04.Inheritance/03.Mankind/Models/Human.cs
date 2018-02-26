using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName,string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (char.IsLower(value.ElementAt(0)))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if (value.Length<4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (char.IsLower(value.ElementAt(0)))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.Append($"Last Name: {this.LastName}");
        return sb.ToString();
    }
}

