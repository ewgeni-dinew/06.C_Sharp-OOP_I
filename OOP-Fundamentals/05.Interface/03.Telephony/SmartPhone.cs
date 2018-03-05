using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SmartPhone : IBrowsable, ICallable
{
    public string Browsing(string url)
    {
        if (url.Any(u => char.IsDigit(u)))
            return "Invalid URL!";
        else
            return $"Browsing: {url}!";
    }

    public string Calling(string number)
    {
        if (number.Any(n => char.IsLetter(n)))
            return "Invalid number!";
        else
            return $"Calling... {number}";
    }
}

