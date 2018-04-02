using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result==0)
                result = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());

            return result;
        }
    }
}
