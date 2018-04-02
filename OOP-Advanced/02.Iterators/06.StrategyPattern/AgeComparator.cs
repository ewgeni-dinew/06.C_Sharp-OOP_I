﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}