using System;
using System.Collections.Generic;
using System.Text;

public class DateModifier
{
    private  DateTime FirstDate { get; set; }
    private DateTime SecondDate { get; set; }

    public DateModifier(DateTime firstDate,DateTime secondDate)
    {
        FirstDate = firstDate;
        SecondDate = secondDate;
    }

    public int DateDiff()
    {
        return Math.Abs((FirstDate - SecondDate).Days);
    } 
}

